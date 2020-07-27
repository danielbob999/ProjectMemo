using ProjectMemo.AutoSave;
using ProjectMemo.CustomControls;
using ProjectMemo.Formatting;
using ProjectMemo.ProjectMemoConsole;
using ProjectMemo.ProjectMemoConsole.CommandAttributes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace ProjectMemo.Forms {
    public partial class MainForm : Form
    {
        public static MainForm ThisForm;

        // Full Release
        private const int VERSION_MAJOR = 1;
        private const int VERSION_MINOR = 1;
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

        private List<Thread> openThreads = new List<Thread>();
        private Dictionary<string, string> mRtbData = new Dictionary<string, string>();
        private CustomRichTextBox template_rtb;
        private CustomRichTextBox activeRichTextBox;
        private List<string> mLoadedSemesters = new List<string>();
        private bool mSaveLock = false;
        private AutoSaveModule mAutoSaveModule;
        private Stopwatch mStopwatch;

        private bool formLoaded = false;

        public static string MainNoteDirectory;

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ProjectMemoConsole.CustomConsole.Log("Loading ProjectMemo.MainForm on thread: " + Thread.CurrentThread.ManagedThreadId);

            IOModule.SetupCurrentDirectory();
            CustomConsole.Init();
            ThisForm = this;

            mStopwatch = new Stopwatch();
            mStopwatch.Start();
            filesListBox.TimeSinceLastUpdate = mStopwatch.ElapsedMilliseconds;

            versionLabel.Text = Version;

            MainContent.InitFontStyles(template_richTextBox.Font.Size);
            RtfCodeFormatter.LoadLanguageThemes();

            mAutoSaveModule = new AutoSaveModule();
            mAutoSaveModule.OnAutoSaveTriggered += AutosaveAllNotes;

            foreach (string str in MainContent.GetFontStyleList())
            {
                if (str != "Code Fragment")
                    format_textStyleSelector.Items.Add(str);
            }

            format_languageSelector.Items.Clear();
            format_languageSelector.Items.AddRange(RtfCodeFormatter.LoadedLanguageThemes);

            mainFormTimer.Start();

            // If the preferences file cannot be loaded, generate a default config file
            if (!Config.PMConfig.LoadFromFile(Directory.GetCurrentDirectory() + "/preferences.conf")) {
                Config.PMConfig.GenerateDefaultConfigFile(Directory.GetCurrentDirectory() + "/preferences.conf");
            }

            if (Config.PMConfig.GetConfigValue<string>("mainnotedir", out string res)) {
                MainNoteDirectory = res;
            } else {
                MainNoteDirectory = "ERRORDIR";
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
            /*
            using (PreferencesForm form = new PreferencesForm(MainNoteDirectory, (int)mAutoSaveInterval))
            {
                form.ShowDialog();
                MainNoteDirectory = form.selectedDirectory;
                //mAutoSaveInterval = form.autoSaveInterval;
                //Console.WriteLine("AutoSaveInterval is now: " + mAutoSaveInterval);
            }*/

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

            ShutdownChildThreads();

            CustomConsole.Log("Thread count: " + openThreads.Count);

            CustomConsole.Log("Closing MainForm");

            CustomConsole.Close();
        }

        private void mainFormTimer_Tick(object sender, EventArgs e) {

            mAutoSaveModule.Update();

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
                        string str = new string(((CustomRichTextBox)ctrl).Rtf.ToCharArray());
                        mRtbData.Add(((CustomRichTextBox)ctrl).TabPath, str);
                    }
                }
            }

            if (activeRichTextBox != null) {
                string regexPattern = @"\b[^\d\W]+\b";
                MatchCollection matches = Regex.Matches(activeRichTextBox.Text, regexPattern);

                wordCountLabel.Text = "Word Count: " + matches.Count;
            }

            if (mStopwatch.ElapsedMilliseconds - filesListBox.TimeSinceLastUpdate > 5000) {
                UpdateFilesListBox(true);
                filesListBox.TimeSinceLastUpdate = mStopwatch.ElapsedMilliseconds;
            }
        }

        private void toEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            DialogResult res = fileDialog.ShowDialog();

            if (res == DialogResult.OK) {
                string filePath = fileDialog.FileName;

                if (!filePath.EndsWith(".rtf")) {
                    MessageBox.Show("You can only open files with the extension .rtf!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                OpenTab(filePath);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ((CustomTab)(mainTabControl.SelectedTab)).Save();
            if (string.IsNullOrEmpty(MainNoteDirectory))
            {
                MessageBox.Show("You need to set a MainNoteDirectory before saving. (File -> Preferences)", "Error", MessageBoxButtons.OK);
                return;
            }

            CustomTab selectedTab = (CustomTab)mainTabControl.SelectedTab;
            selectedTab.Save();
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
            if (activeRichTextBox == null) {
                return;
            }

            if (activeRichTextBox.SelectedText != "")
            {
                if (activeRichTextBox.SelectionStart > 0) {
                    activeRichTextBox.SelectionStart = activeRichTextBox.SelectionStart - 1;
                    activeRichTextBox.SelectionLength = activeRichTextBox.SelectionLength + 1;
                }

                activeRichTextBox.SelectionBullet = true;
                activeRichTextBox.SelectionLength = 0;
                activeRichTextBox.SelectionBullet = false;
            }
        }

        private void FormatColourText(object sender, EventArgs e) {
            if (activeRichTextBox == null) {
                return;
            }

            if (activeRichTextBox.SelectedText != "") {
                ColorDialog cd = new ColorDialog();
                cd.AllowFullOpen = true;
                cd.AnyColor = true;
                cd.ShowDialog();

                activeRichTextBox.SelectionColor = cd.Color;
                activeRichTextBox.SelectionLength = 0;
            }
        }

        private void FormatIncreaseTextSize(object sender, EventArgs e) {
            if (activeRichTextBox == null) {
                return;
            }

            if (activeRichTextBox.SelectedText != "") {
                float fontSize = activeRichTextBox.SelectionFont.Size;
                Font newFont = new Font(activeRichTextBox.SelectionFont.FontFamily, activeRichTextBox.SelectionFont.Size + 0.7f, activeRichTextBox.SelectionFont.Style);

                activeRichTextBox.SelectionFont = newFont;
                activeRichTextBox.SelectionLength = 0;
                activeRichTextBox.SelectionFont = activeRichTextBox.Font;
            }
        }

        private void FormatDecreaseTextSize(object sender, EventArgs e) {
            if (activeRichTextBox == null) {
                return;
            }

            if (activeRichTextBox.SelectedText != "") {
                float fontSize = activeRichTextBox.SelectionFont.Size;
                Font newFont = new Font(activeRichTextBox.SelectionFont.FontFamily, activeRichTextBox.SelectionFont.Size - 0.7f, activeRichTextBox.SelectionFont.Style);

                activeRichTextBox.SelectionFont = newFont;
                activeRichTextBox.SelectionLength = 0;
                activeRichTextBox.SelectionFont = activeRichTextBox.Font;
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
            /*
            MessageBox.Show("Not implemented yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
            */
            using (LanguageThemeCreatorForm form = new LanguageThemeCreatorForm())
            {
                form.ShowDialog();
            }

            // Reload the language themes
            //RtfCodeFormatter.LoadLanguageThemes();
            format_languageSelector.Items.Clear();
            format_languageSelector.Items.AddRange(RtfCodeFormatter.LoadedLanguageThemes);
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

                return;
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S) {
                ((CustomTab)mainTabControl.SelectedTab).Save();
                return;
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
                    RtfCodeFormatter.FormatCodeFragment(format_languageSelector.SelectedItem.ToString(), ref activeRichTextBox, s, s + l);

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

        [CommandMethod("mainform.opentab", "", "<string:Path>")]
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
            
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK) {
                RichTextBox rtbSurrogate = new RichTextBox();
                rtbSurrogate.LoadFile(ofd.FileName);

                OpenTab();

                if (activeRichTextBox != null)
                    activeRichTextBox.Rtf = rtbSurrogate.Rtf;
            }
        }

        private void AutosaveAllNotes(object sender, EventArgs e) {
            CustomTab[] allTabs = mainTabControl.TabPages.OfType<CustomTab>().ToArray();

            for (int i = 0; i < allTabs.Length; i++) {
                allTabs[i].Save(true);
            }
        }

        private void OpenInsertObjectForm(object sender, EventArgs e) {
            if (activeRichTextBox == null) {
                return;
            }

            using (InsertObjectForm form = new InsertObjectForm()) {
                DialogResult res = form.ShowDialog();

                if (res == DialogResult.OK) {
                    // Paste in the active textbox. Data will already be saved in clipboard at this point
                    activeRichTextBox.Paste();
                    ProjectMemoConsole.CustomConsole.Log("Pasted DataObject into activeRichTextBox");
                }
            }
        }

        public void ShutdownChildThreads() {
            List<Thread> tempThreads = new List<Thread>(openThreads);
            foreach (Thread t in tempThreads) {
                try {
                    int threadId = t.ManagedThreadId;
                    t.Abort();
                    openThreads.Remove(t);
                    CustomConsole.Log("Closed thread with id: " + threadId);
                } catch (ThreadAbortException ex) {
                    //CustomConsole.Log(ex.Message);
                }
            }

            CustomConsole.Log("Thread count: " + openThreads.Count);
        }

        public void UpdateFilesListBox(bool logMsg = true) {
            if (activeRichTextBox == null) {
                filesListBox.Items.Clear();
                if (logMsg) {
                    CustomConsole.Log("Cannot update filesListBox because activeRichTextBox is null");
                }
                return;
            }

            // Get file directories
            List<string> resourceFileDirs = new List<string>();
            string currLine = null;

            if (activeRichTextBox.Lines.Length > 0) {
                currLine = activeRichTextBox.Lines[0];
            }

            int nullLineCount = 0;

            for (int i = 0; i < activeRichTextBox.Lines.Length; i++) {
                currLine = activeRichTextBox.Lines[i];

                if (nullLineCount > 5) {
                    break;
                }

                if (string.IsNullOrWhiteSpace(currLine)) {
                    nullLineCount++;
                    continue;
                }

                if (currLine.StartsWith("[resource=")) {
                    string[] splitStr = currLine.Split('=');

                    string dir = splitStr[splitStr.Length - 1].TrimEnd(']');

                    if (File.Exists(dir)) {
                        resourceFileDirs.Add(dir);
                    }

                    Console.WriteLine("dir : " + splitStr[splitStr.Length - 1].TrimEnd(']'));
                    nullLineCount = 0;
                }
            }

            if (resourceFileDirs.Count > 0) {
                // Add dirs to list box
                filesListBox.Items.Clear();
                filesListBox.Items.AddRange(resourceFileDirs.ToArray());
                if (logMsg) {
                    CustomConsole.Log("Updated filesListBox with " + resourceFileDirs.Count + " items");
                }
            } else {
                if (logMsg) {
                    CustomConsole.Log("Tried to update filesListBox but the current note has no resource files attached");
                }
            }

            //filesListBox.Refresh();
        }

        private void addFileButton_Click(object sender, EventArgs e) {
            if (activeRichTextBox == null) {
                CustomConsole.Log("Cannot add resource because activeRichTextBox is null");
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult res = ofd.ShowDialog();

            Console.WriteLine(res);

            if (res == DialogResult.OK) {
                List<string> linesList = new List<string>();
                linesList.Add(string.Format("[resource={0}]", ofd.FileName));
                linesList.AddRange(activeRichTextBox.Lines);

                activeRichTextBox.Lines = linesList.ToArray();
            }

            UpdateFilesListBox();
        }

        [CommandMethod("mainform.updatefilesbox", "")]
        public static void UpdateFilesBoxCommand(string[] args) {
            ThisForm.UpdateFilesListBox();
        }
    }
}
