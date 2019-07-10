using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ProjectMemo.CustomControls;
using ProjectMemo.ProjectMemoConsole;
using ProjectMemo.ProjectMemoConsole.CommandAttributes;
using ProjectMemo.Formatting;

namespace ProjectMemo.Forms
{
    public partial class MainForm : Form
    {
        public static MainForm ThisForm;

        private const int VERSION_MAJOR = 5;
        private const int VERSION_MINOR = 9;
        private const int VERSION_PATCH = 1;

        public static string Version
        {
            get {
                return string.Format("v{0}.{1}.{2}", VERSION_MAJOR, VERSION_MINOR, VERSION_PATCH);
            }
        }

        public static Dictionary<string, string> RichTextBoxData
        {
            get { return ThisForm.mRtbData; }
        }

        public static int AutoSaveInterval
        {
            get { return ((int)(ThisForm.mAutoSaveInterval * 60)) * 1000; }
        }

        private List<Thread> openThreads = new List<Thread>();
        private Dictionary<string, string> mRtbData = new Dictionary<string, string>();
        private CustomRichTextBox template_rtb;
        private CustomRichTextBox activeRichTextBox;
        private float mAutoSaveInterval = 5.0f;
        private List<string> mLoadedSemesters = new List<string>();
        private bool mSaveLock = false;
        private AutoSaveModule mAutoSaveModule;

        private bool formLoaded = false;

        public static string MainNoteDirectory;

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CustomConsole.Init();
            ThisForm = this;

            versionLabel.Text = Version;

            MainContent.InitFontStyles(template_richTextBox.Font.Size);
            RtfCodeFormatter.LoadLanguageThemes();

            mAutoSaveModule = new AutoSaveModule();

            Thread saveModuleThread = new Thread(mAutoSaveModule.Run);
            saveModuleThread.Start();
            openThreads.Add(saveModuleThread);

            foreach (string str in MainContent.GetFontStyleList())
            {
                if (str != "Code Fragment")
                    format_textStyleSelector.Items.Add(str);
            }

            foreach (string str in RtfCodeFormatter.GetLanguageThemeTitles())
            {
                format_languageSelector.Items.Add(str);
            }

            mainFormTimer.Start();

            List<string> prefs = new List<string>();

            // Read in preferences from the file
            if (IOModule.ReadPreferencesFromFile(out prefs))
            {
                MainNoteDirectory = prefs[0];
                mAutoSaveInterval = Convert.ToInt32(prefs[1]);
            }

            // Set the valid semester choices
            string[] semesterFolders = new string[] { };

            if (!string.IsNullOrEmpty(MainNoteDirectory))
                semesterFolders = Directory.GetDirectories(MainNoteDirectory);

            mLoadedSemesters.Clear();

            foreach (string str in semesterFolders) {
                if (str.EndsWith("_s2") || str.EndsWith("_s1")) {
                    mLoadedSemesters.Add(str.Replace(MainNoteDirectory, ""));
                }
            }

            template_rtb = template_richTextBox; 
            activeRichTextBox = null;
            CustomConsole.Log("Set activeRichTextBox to null");
            template_richTextBox.Visible = false;
            CustomConsole.Log("Set the visibility of the template_richTextBox to False");
            mainTabControl.TabPages.RemoveAt(0);
            CustomConsole.Log("Removed the default tab from mainTabControl");

            /*
            string[] semesterFolders = Directory.GetDirectories(mMainNoteDirectory);

            semesterSelector.Items.Clear();

            foreach (string str in semesterFolders)
                if (str.EndsWith("_s2") || str.EndsWith("_s1"))
                    semesterSelector.Items.Add(str.Replace(mMainNoteDirectory, ""));*/

            formLoaded = true;
            format_textStyleSelector.SelectedIndex = 0;

            SetTabControlRTBSize();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            CustomRichTextBox newBox = new CustomRichTextBox();
            newBox.Font = new Font(newBox.Font.FontFamily, 10.5f, FontStyle.Regular);
            newBox.Size = template_rtb.Size;
            newBox.Location = template_rtb.Location;
            newBox.HideSelection = false;

            // Create new tab, make sure all TabPage values are srt to null
            CustomTab newTab = new CustomTab(null, null, null, true, null);
            newTab.Text = "Untitled_" + GetNumberOfUntitledTabs();
            newTab.Controls.Add(newBox);

            mainTabControl.TabPages.Add(newTab);

            if (mainTabControl.TabPages.Count == 1)
            {
                foreach (Control ctrl in mainTabControl.SelectedTab.Controls)
                {
                    if (ctrl.GetType() == typeof(CustomRichTextBox))
                    {
                        activeRichTextBox = (CustomRichTextBox)ctrl;
                        CustomConsole.Log("Set the child of CustomTab with id: " + ((CustomTab)mainTabControl.SelectedTab).mTabId + " to the active CustomRichTextBox");
                    }
                }
            }*/

            OpenTab();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close this tab without saving?", "Warning", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                mainTabControl.TabPages.Remove(mainTabControl.SelectedTab);
                return;
            }
        }

        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (formLoaded)
            {
                // Get the RichTextBox from the TabPage
                if (mainTabControl.SelectedTab != null)
                {
                    foreach (Control ctrl in mainTabControl.SelectedTab.Controls)
                    {
                        if (ctrl.GetType() == typeof(CustomRichTextBox))
                        {
                            activeRichTextBox = (CustomRichTextBox)ctrl;
                            SetTabControlRTBSize();
                            CustomConsole.Log("Set the child of CustomTab with id: " + ((CustomTab)mainTabControl.SelectedTab).mTabId + " to the active CustomRichTextBox");

                            return;
                        }
                    }
                }
            }
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PreferencesForm form = new PreferencesForm(MainNoteDirectory, (int)mAutoSaveInterval))
            {
                form.ShowDialog();
                MainNoteDirectory = form.selectedDirectory;
                mAutoSaveInterval = form.autoSaveInterval;
                Console.WriteLine("AutoSaveInt is now: " + mAutoSaveInterval);
            }

            // Set semester folders
            string[] semesterFolders = new string[] { };

            if (string.IsNullOrEmpty(MainNoteDirectory))
                return;
            else
                semesterFolders = Directory.GetDirectories(MainNoteDirectory);

            mLoadedSemesters.Clear();

            foreach (string str in semesterFolders)
                if (str.EndsWith("_s2") || str.EndsWith("_s1"))
                    mLoadedSemesters.Add(str.Replace(MainNoteDirectory, ""));
        }

        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            Thread thread = new Thread(OpenConsoleForm);
            thread.Start();
            openThreads.Add(thread);*/

            OpenConsoleForm();
        }

        private void OpenConsoleForm()
        {
            using (ConsoleForm form = new ConsoleForm(GetType().Name))
            {
                form.ShowDialog();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainFormTimer.Stop();

            foreach (Thread t in openThreads)
            {
                try
                {
                    int threadId = t.ManagedThreadId;
                    t.Abort();
                    CustomConsole.Log("Closed thread with id: " + threadId + ". New thread count: " + openThreads.Count);
                }
                catch (ThreadAbortException ex)
                {
                    CustomConsole.Log(ex.Message);
                }
            }
        }

        private void mainFormTimer_Tick(object sender, EventArgs e) {

            if (mainTabControl.TabPages.Count > 0) {
                if (mainTabControl.SelectedTab.Text.Contains("*")) {
                    mSaveLock = false;
                } else {
                    mSaveLock = true;
                }
            }

            saveButton.Enabled = !mSaveLock;

            mRtbData.Clear();
            foreach (CustomControls.CustomTab tab in ThisForm.mainTabControl.TabPages) {
                foreach (Control ctrl in tab.Controls) {
                    if (ctrl.GetType() == typeof(CustomControls.CustomRichTextBox)) {
                        mRtbData.Add(((CustomRichTextBox)ctrl).TabPath, ((CustomRichTextBox)ctrl).Rtf);
                    }
                }
            }
        }

        private void toEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();

            string filePath = fileDialog.FileName;

            if (!filePath.EndsWith(".rtf"))
            {
                MessageBox.Show("You can only open files with the extension .rtf!", "Error", MessageBoxButtons.OK);
                return;
            }

            /*
            string[] splitFileName = filePath.Split('\\');

            string temp_semester = splitFileName[splitFileName.Length - 4];

            string[] classTypeSplit = splitFileName[splitFileName.Length - 1].Split('_');
            string temp_classtype = classTypeSplit[1].Split('.')[0];
            string temp_course = splitFileName[splitFileName.Length - 3];

            // Copied from newTab click event code
            CustomRichTextBox newBox = new CustomRichTextBox();
            newBox.LoadFile(filePath);
            newBox.Font = new Font(newBox.Font.FontFamily, 10.5f, FontStyle.Regular);
            newBox.Size = template_rtb.Size;
            newBox.Location = template_rtb.Location;
            newBox.HideSelection = false;

            // Create new tab, make sure all TabPage values are srt to null
            CustomTab newTab = new CustomTab(temp_semester, temp_course, temp_classtype, false, filePath);
            newTab.Text = string.Format("[{0}] {1}", temp_course, splitFileName[splitFileName.Length - 1]);
            newTab.Controls.Add(newBox);

            mainTabControl.TabPages.Add(newTab);

            CustomConsole.Log("Opened file to edit: " + filePath);

            mainTabControl.SelectedIndex = mainTabControl.TabPages.Count - 1;*/

            OpenTab(filePath);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MainNoteDirectory))
            {
                MessageBox.Show("You need to set a MainNoteDirectory before saving. (File -> Preferences)", "Error", MessageBoxButtons.OK);
                return;
            }

            CustomTab selectedTab = (CustomTab)mainTabControl.SelectedTab;
            string strng = selectedTab.mFullPath;

            activeRichTextBox.SaveFile(strng);
            activeRichTextBox.SetSavePoint();
            CustomConsole.Log("Saved file to: " + strng);
        }

        private int GetNumberOfUntitledTabs()
        {
            int i = 0;

            foreach (TabPage page in mainTabControl.TabPages)
            {
                if (page.Text.StartsWith("Untitled"))
                    i++;
            }

            return i;
        }

        private void format_boldButton_Click(object sender, EventArgs e)
        {
            if (activeRichTextBox == null) {
                return;
            }

            if (activeRichTextBox.SelectedText != "")
            {
                activeRichTextBox.SelectionFont = new Font("Microsoft Sans Serif", activeRichTextBox.Font.Size, FontStyle.Bold);

                activeRichTextBox.SelectionStart = activeRichTextBox.SelectionStart + activeRichTextBox.SelectionLength;
                activeRichTextBox.SelectionLength = 0;
                activeRichTextBox.SelectionFont = activeRichTextBox.Font;
            }
        }

        private void format_italicButton_Click(object sender, EventArgs e)
        {
            if (activeRichTextBox == null) {
                return;
            }

            if (activeRichTextBox.SelectedText != "")
            {
                activeRichTextBox.SelectionFont = new Font("Microsoft Sans Serif", activeRichTextBox.Font.Size, FontStyle.Italic);

                activeRichTextBox.SelectionStart = activeRichTextBox.SelectionStart + activeRichTextBox.SelectionLength;
                activeRichTextBox.SelectionLength = 0;
                activeRichTextBox.SelectionFont = activeRichTextBox.Font;
            }
        }

        private void format_strikeoutButton_Click(object sender, EventArgs e)
        {
            if (activeRichTextBox == null) {
                return;
            }

            if (activeRichTextBox.SelectedText != "")
            {
                activeRichTextBox.SelectionFont = new Font("Microsoft Sans Serif", activeRichTextBox.Font.Size, FontStyle.Strikeout);

                activeRichTextBox.SelectionStart = activeRichTextBox.SelectionStart + activeRichTextBox.SelectionLength;
                activeRichTextBox.SelectionLength = 0;
                activeRichTextBox.SelectionFont = activeRichTextBox.Font;
            }
        }

        private void format_underlineButton_Click(object sender, EventArgs e)
        {
            if (activeRichTextBox == null) {
                return;
            }

            if (activeRichTextBox.SelectedText != "")
            {
                activeRichTextBox.SelectionFont = new Font("Microsoft Sans Serif", activeRichTextBox.Font.Size, FontStyle.Underline);

                activeRichTextBox.SelectionStart = activeRichTextBox.SelectionStart + activeRichTextBox.SelectionLength;
                activeRichTextBox.SelectionLength = 0;
                activeRichTextBox.SelectionFont = activeRichTextBox.Font;
            }
        }

        private void format_textStyleSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            Font f;
            if (MainContent.GetFontFromStyleString(format_textStyleSelector.SelectedItem.ToString(), out f))
            {
                if (activeRichTextBox != null)
                    activeRichTextBox.SelectionFont = f;
            }
        }

        private void format_listButton_Click(object sender, EventArgs e)
        {
            if (activeRichTextBox.SelectedText != "")
            {
                activeRichTextBox.SelectionBullet = true;
                activeRichTextBox.SelectionLength = 0;
                activeRichTextBox.SelectionBullet = false;
            }
        }

        private void noteViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (NoteViewerForm form = new NoteViewerForm(MainNoteDirectory))
            {
                form.ShowDialog();
            }
        }

        private void langThemeCreatorMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;

            using (LanguageThemeCreatorForm form = new LanguageThemeCreatorForm())
            {
                form.ShowDialog();
            }
        }

        [CommandMethod("mainform.closetab", "<int>", "<string:keyword>")]
        public static void CloseTabCommand(string[] a_args)
        {
            if (a_args.Length == 2)
            {
                if (a_args[1] == "all")
                {
                    ThisForm.mainTabControl.TabPages.Clear();
                    CustomConsole.Log("Closed all TabPages");
                    return;
                }

                if (a_args[1] == "active")
                {
                    int selectedIndex = ThisForm.mainTabControl.SelectedIndex;
                    ThisForm.mainTabControl.TabPages.RemoveAt(selectedIndex);
                    CustomConsole.Log("Closed selected TabPage. (Index " + selectedIndex + ")");
                    return;
                }

                int indx = -1;

                if (Int32.TryParse(a_args[1], out indx))
                {
                    if (indx >= ThisForm.mainTabControl.TabPages.Count)
                    {
                        CustomConsole.Log("Cannot close TabPage at index " + indx + ". (Index out of bounds)");
                        return;
                    }

                    ThisForm.mainTabControl.TabPages.RemoveAt(indx);
                    CustomConsole.Log("Closed TabPage at index " + indx);
                }

                Console.WriteLine("Number: " + indx);
            }
            else
            {
                CustomConsole.Log("No override for command " + a_args[0] + " that takes " + (a_args.Length - 1) + " arguments.");
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Oemtilde)
            {
                using (ConsoleForm form = new ConsoleForm(GetType().Name))
                {
                    form.ShowDialog();
                }
            }
        }

        private void format_formatCodeButton_Click(object sender, EventArgs e)
        {
            if (activeRichTextBox == null) {
                return;
            }

            Font f;
            if (MainContent.GetFontFromStyleString("Code Fragment", out f))
            {
                if (activeRichTextBox.SelectedText != "" && format_languageSelector.SelectedItem != null)
                {
                    activeRichTextBox.SelectionFont = f;

                    int s = activeRichTextBox.SelectionStart;
                    int l = activeRichTextBox.SelectionLength;
                    activeRichTextBox.SelectedText = activeRichTextBox.SelectedText.Replace("\t", "   ");
                    RtfCodeFormatter.ColourCodeFragment(format_languageSelector.SelectedItem.ToString(), ref activeRichTextBox, s, s + l);

                    activeRichTextBox.SelectionStart = activeRichTextBox.SelectionStart + activeRichTextBox.SelectionLength;
                    activeRichTextBox.SelectionLength = 0;
                    activeRichTextBox.SelectionFont = activeRichTextBox.Font;
                }
            }
        }

        private void OpenTab(string a_path = "NULL")
        {
            CustomRichTextBox newBox = new CustomRichTextBox();
            newBox.OnLineNumberChanged += Event_OnActiveTextBoxLineChanged;
            newBox.Font = new Font(newBox.Font.FontFamily, 10.5f, FontStyle.Regular);
            newBox.Size = template_rtb.Size;
            newBox.Location = template_rtb.Location;
            newBox.HideSelection = false;

            if (a_path == "NULL")
            {
                using (NewTabDetailsForm form = new NewTabDetailsForm(mLoadedSemesters.ToArray())) {
                    DialogResult result = form.ShowDialog();

                    if (result == DialogResult.OK) {

                        // Create new tab, make sure all TabPage values are set to null
                        CustomTab newTab = new CustomTab(form.Semester, form.Course, form.ClassType, MainNoteDirectory + form.Semester + "\\" + form.Course + "\\Notes\\" + string.Format("{0}-{1}-{2}_{3}.rtf", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, form.ClassType));
                        newTab.Text = string.Format("[{0}] {1}", form.Course,
                                      string.Format("{0}-{1}-{2}_{3}.rtf", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, form.ClassType));
                        newTab.Controls.Add(newBox);

                        mainTabControl.TabPages.Add(newTab);

                        mainTabControl.SelectedIndex = mainTabControl.TabPages.Count - 1;

                        // If the tab that was just added is the only tab (TabPages.Count == 1)
                        if (mainTabControl.TabPages.Count == 1) {
                            foreach (Control ctrl in mainTabControl.SelectedTab.Controls) {
                                if (ctrl.GetType() == typeof(CustomRichTextBox)) {
                                    activeRichTextBox = (CustomRichTextBox)ctrl;
                                    CustomConsole.Log("Set the child of CustomTab with id: " + ((CustomTab)mainTabControl.SelectedTab).mTabId + " to the active CustomRichTextBox");
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                string[] splitFileName = a_path.Split('\\');

                string temp_semester = splitFileName[splitFileName.Length - 4];

                string[] classTypeSplit = splitFileName[splitFileName.Length - 1].Split('_');
                string temp_classtype = classTypeSplit[1].Split('.')[0];
                string temp_course = splitFileName[splitFileName.Length - 3];

                newBox.LoadFile(a_path);

                // Create new tab, make sure all TabPage values are srt to null
                CustomTab newTab = new CustomTab(temp_semester, temp_course, temp_classtype, a_path);
                newTab.Text = string.Format("[{0}] {1}", temp_course, splitFileName[splitFileName.Length - 1]);
                newTab.Controls.Add(newBox);

                mainTabControl.TabPages.Add(newTab);

                CustomConsole.Log("Opened file to edit: " + a_path);

                // If the tab that was just added is the only tab (TabPages.Count == 1)
                if (mainTabControl.TabPages.Count == 1) {
                    foreach (Control ctrl in mainTabControl.SelectedTab.Controls) {
                        if (ctrl.GetType() == typeof(CustomRichTextBox)) {
                            activeRichTextBox = (CustomRichTextBox)ctrl;
                            CustomConsole.Log("Set the child of CustomTab with id: " + ((CustomTab)mainTabControl.SelectedTab).mTabId + " to the active CustomRichTextBox");
                        }
                    }
                }
            }
        }

        [CommandMethod("mainform.opentab", "", "<string:Path")]
        public static void AddTabCommand(string[] a_args)
        {
            if (a_args.Length == 1)
            {
                ThisForm.OpenTab();
                return;
            }

            if (a_args.Length >= 2)
            {
                if (!File.Exists(a_args[1]))
                {
                    CustomConsole.Log("The path: " + a_args[1] + " is not a valid path");
                    return;
                }

                ThisForm.OpenTab(a_args[1]);

                return;
            }


        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            SetTabControlRTBSize();
        }

        private void SetTabControlRTBSize()
        {
            // Set new width
            int groupBoxWidth = formatingGroupBox.Width;

            int newWidth = (Size.Width - groupBoxWidth) - (mainTabControl.Location.X + 30);
            mainTabControl.Width = newWidth;
            
            if (activeRichTextBox != null)
                activeRichTextBox.Width = newWidth - 13;

            // Set new height
            int newHeight = (Size.Height - mainTabControl.Location.Y) - 63;
            mainTabControl.Height = newHeight;

            if (activeRichTextBox != null)
                activeRichTextBox.Height = newHeight - 35;
        }

        private void Event_OnActiveTextBoxLineChanged(object sender, EventArgs e)
        {
            SetTabControlRTBSize();
        }

        private void recoverToolStripMenuItem_Click(object sender, EventArgs e) {
            /*
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK) {

            }*/
        }
    }
}
