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
using UniversityNoteProgram.CustomControls;

namespace UniversityNoteProgram.Forms
{
    public partial class MainForm : Form
    {
        private List<Thread> openThreads = new List<Thread>();
        private CustomRichTextBox template_rtb;
        private CustomRichTextBox activeRichTextBox;

        private bool formLoaded = false;
        private bool testingBool = false;

        public static bool SaveLock = false;
        public static string MainNoteDirectory;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MainContent.InitFontStyles(template_richTextBox.Font.Size);
            RtfCodeFormatter.InitKeywordColours("keyword_colours.conf");

            foreach (string str in MainContent.GetFontStyleList())
            {
                format_textStyleSelector.Items.Add(str);
            }

            mainFormTimer.Start();

            List<string> prefs = new List<string>();

            // Read in preferences from the file
            if (IOModule.ReadPreferencesFromFile(out prefs))
            {
                MainNoteDirectory = prefs[0];
            }

            // Set the valid semester choices
            string[] semesterFolders = new string[] { };

            if (!string.IsNullOrEmpty(MainNoteDirectory))
                semesterFolders = Directory.GetDirectories(MainNoteDirectory);

            semesterSelector.Items.Clear();

            foreach (string str in semesterFolders)
                if (str.EndsWith("_s2") || str.EndsWith("_s1"))
                    semesterSelector.Items.Add(str.Replace(MainNoteDirectory, ""));

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
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to quit without saving?", "Warning", MessageBoxButtons.YesNo);

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
                            CustomConsole.Log("Set the child of CustomTab with id: " + ((CustomTab)mainTabControl.SelectedTab).mTabId + " to the active CustomRichTextBox");

                            if (((CustomTab)mainTabControl.SelectedTab).newFile)
                                SaveLock = false;
                            else
                                SaveLock = true;

                            return;
                        }
                    }
                }
            }
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PreferencesForm form = new PreferencesForm(MainNoteDirectory))
            {
                form.ShowDialog();
                MainNoteDirectory = form.selectedDirectory;
            }

            // Set semester folders
            string[] semesterFolders = new string[] { };

            if (string.IsNullOrEmpty(MainNoteDirectory))
                return;
            else
                semesterFolders = Directory.GetDirectories(MainNoteDirectory);

            semesterSelector.Items.Clear();

            foreach (string str in semesterFolders)
                if (str.EndsWith("_s2") || str.EndsWith("_s1"))
                    semesterSelector.Items.Add(str.Replace(MainNoteDirectory, ""));
        }

        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(OpenConsoleForm);
            thread.Start();
            openThreads.Add(thread);
        }

        private void OpenConsoleForm()
        {
            using (ConsoleForm form = new ConsoleForm(ref openThreads))
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

        private void mainFormTimer_Tick(object sender, EventArgs e)
        {
            semesterSelector.Enabled = !SaveLock;
            courseSelector.Enabled = !SaveLock;
            classTypeSelector.Enabled = !SaveLock;
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

            mainTabControl.SelectedIndex = mainTabControl.TabPages.Count - 1;
        }

        private void semesterSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] courseFolder = Directory.GetDirectories(MainNoteDirectory + semesterSelector.SelectedItem);

            courseSelector.Items.Clear();
            string logStr = "{ ";

            foreach (string folder in courseFolder)
            {
                courseSelector.Items.Add(folder.Replace(MainNoteDirectory + semesterSelector.SelectedItem, "").Replace("\\", ""));

                logStr += (folder + ", ");
            }

            CustomConsole.Log("Updated courseSelector.Items based on the semester: " + semesterSelector.SelectedItem);
            CustomConsole.Log("New courseSelector collection: " + logStr + " }");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MainNoteDirectory))
            {
                MessageBox.Show("You need to set a MainNoteDirectory before saving. (File -> Preferences)", "Error", MessageBoxButtons.OK);
                return;
            }

            string strng;
            CustomTab selectedTab = (CustomTab)mainTabControl.SelectedTab;

            if (selectedTab.newFile)
            {
                strng = string.Format("{0}{1}\\{2}\\Notes\\{3}-{4}-{5}_{6}.rtf",
                MainNoteDirectory, semesterSelector.SelectedItem, courseSelector.SelectedItem,
                DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, classTypeSelector.SelectedItem);

                ((CustomTab)mainTabControl.SelectedTab).mSemester = semesterSelector.SelectedItem.ToString();
                ((CustomTab)mainTabControl.SelectedTab).mCourse = courseSelector.SelectedItem.ToString();
                ((CustomTab)mainTabControl.SelectedTab).mClassType = classTypeSelector.SelectedItem.ToString();
                ((CustomTab)mainTabControl.SelectedTab).mFullPath = strng;
                mainTabControl.SelectedTab.Text = string.Format("[{0}] {1}", courseSelector.SelectedItem,
                    string.Format("{0}-{1}-{2}_{3}.rtf", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, classTypeSelector.SelectedItem));
            }
            else
            {
                strng = selectedTab.mFullPath;
            }

            activeRichTextBox.SaveFile(strng);
            CustomConsole.Log("Saved file to: " + strng);
            SaveLock = true;
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

        private void format_fontStyleButton_Click(object sender, EventArgs e)
        {
            Font f;
            if (MainContent.GetFontFromStyleString(format_textStyleSelector.SelectedItem.ToString(), out f))
            {
                if (activeRichTextBox.SelectedText != "")
                {

                    activeRichTextBox.SelectionFont = f;

                    if (format_textStyleSelector.SelectedItem.ToString() == "Code Fragment")
                    {
                        int s = activeRichTextBox.SelectionStart;
                        int l = activeRichTextBox.SelectionLength;
                        activeRichTextBox.SelectedText = activeRichTextBox.SelectedText.Replace("\t", "   ");
                        RtfCodeFormatter.ColourCodeFragment(ref activeRichTextBox, s, s + l);
                    }

                    activeRichTextBox.SelectionStart = activeRichTextBox.SelectionStart + activeRichTextBox.SelectionLength;
                    activeRichTextBox.SelectionLength = 0;
                    activeRichTextBox.SelectionFont = activeRichTextBox.Font;
                }
            }
        }

        private void format_boldButton_Click(object sender, EventArgs e)
        {
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
            if (activeRichTextBox.SelectedText != "")
            {
                activeRichTextBox.SelectionFont = new Font("Microsoft Sans Serif", activeRichTextBox.Font.Size, FontStyle.Underline);

                activeRichTextBox.SelectionStart = activeRichTextBox.SelectionStart + activeRichTextBox.SelectionLength;
                activeRichTextBox.SelectionLength = 0;
                activeRichTextBox.SelectionFont = activeRichTextBox.Font;
            }

            testingBool = true;
        }

        private void format_textStyleSelector_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}
