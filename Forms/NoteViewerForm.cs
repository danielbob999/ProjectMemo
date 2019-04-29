using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using ProjectMemo.ProjectMemoConsole;
using ProjectMemo.ProjectMemoConsole.CommandAttributes;
using ProjectMemo.CustomControls;
using ProjectMemo.NoteViewing;

namespace ProjectMemo.Forms
{
    public partial class NoteViewerForm : Form
    {
        public static NoteViewerForm ThisForm;

        private CustomRichTextBox template_rtb;

        private NoteViewingData mNoteViewingData;
        private string mMainNoteDirectory = "";

        private string mSelectedSemester = "";
        private string mSelectedCourse = "";
        private string mSelectedClassType = "";
        private string mSearchTerm = "";
        private bool mCanDisplaySearch = false;

        // dsadasd
        public bool shiftActive = false;
        public bool altActive = false;

        public NoteViewerForm(string a_noteDir)
        {
            mMainNoteDirectory = a_noteDir;
            InitializeComponent();
        }

        private void NoteViewerForm_Load(object sender, EventArgs e)
        {
            ThisForm = this;

            mNoteViewingData = new NoteViewingData(mMainNoteDirectory);

            mainDirectoryLabel.Text = mMainNoteDirectory;

            // Set the default class type choice to 'All'
            classTypeSelector.SelectedIndex = 0;

            // Set both from and to dates to tomrrow. This needs to be done to disable date filtering

            // Set semester folders
            if (!string.IsNullOrEmpty(mMainNoteDirectory))
            {
                string[] semesterFolders = new string[] { };

                if (string.IsNullOrEmpty(mMainNoteDirectory))
                    return;
                else
                    semesterFolders = Directory.GetDirectories(mMainNoteDirectory);

                semesterSelector.Items.Clear();

                foreach (string str in semesterFolders)
                    if (str.EndsWith("_s2") || str.EndsWith("_s1"))
                        semesterSelector.Items.Add(str.Replace(mMainNoteDirectory, ""));
            }

            template_rtb = template_richTextBox;
            CustomConsole.Log("Set NoteViewerForm.activeRichTextBox to null");
            template_richTextBox.Visible = false;
            CustomConsole.Log("Set the visibility of the NoteViewerForm.template_richTextBox to False");
            mainTabControl.TabPages.RemoveAt(0);
            CustomConsole.Log("Removed the default tab from NoteViewerForm.mainTabControl");

            mainFormTimer.Start();
            ResizeTabControlAndChildren();
        }

        public void OpenNote(string a_filePath, string a_fileName, string a_course)
        {
            // Check to see if note is already open
            foreach (TabPage page in mainTabControl.TabPages)
            {
                if (page.Text == string.Format("[{0}] {1}", a_course, a_fileName))
                {
                    mainTabControl.SelectedTab = page;
                    return;
                }
            }

            CustomRichTextBox newBox = new CustomRichTextBox();
            newBox.Font = new Font(newBox.Font.FontFamily, 10.5f, FontStyle.Regular);
            newBox.LoadFile(a_filePath);
            newBox.Size = template_rtb.Size;
            newBox.Location = template_rtb.Location;
            newBox.HideSelection = false;
            newBox.ReadOnly = true;

            // Create new tab, make sure all TabPage values are srt to null
            CustomTab newTab = new CustomTab(null, null, null, true, null);
            newTab.Text = string.Format("[{0}] {1}", a_course, a_fileName);
            newTab.Controls.Add(newBox);

            mainTabControl.TabPages.Add(newTab);

            ResizeTabControlAndChildren();
        }

        private void mainFormTimer_Tick(object sender, EventArgs e)
        {
           if (!string.IsNullOrEmpty(mSelectedSemester) && mCanDisplaySearch)
            {
                mNoteViewingData.DisplayResults(ref flowLayoutPanel1, mSelectedSemester, mSelectedCourse, fromDateTimePicker.Value,
                        toDateTimePicker.Value, filterByDateCheckBox.Checked, mSelectedClassType, mSearchTerm, caseSensitiveCheckBox.Checked);
                mCanDisplaySearch = false;
            }
        }

        private void semesterSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            mSelectedSemester = semesterSelector.SelectedItem.ToString();
            mCanDisplaySearch = true;

            if (!string.IsNullOrEmpty(mMainNoteDirectory))
            {
                string[] courseFolder = Directory.GetDirectories(mMainNoteDirectory + semesterSelector.SelectedItem);

                courseSelector.Items.Clear();
                string logStr = "{ ";
                courseSelector.Items.Add("All");

                foreach (string folder in courseFolder)
                {
                    courseSelector.Items.Add(folder.Replace(mMainNoteDirectory + semesterSelector.SelectedItem, "").Replace("\\", ""));

                    logStr += (folder.Replace(mMainNoteDirectory, "") + ", ");
                }

                CustomConsole.Log("Updated courseSelector.Items based on the semester: " + semesterSelector.SelectedItem);
                CustomConsole.Log("New courseSelector collection: " + logStr + " }");

                courseSelector.SelectedIndex = 0;
            }
        }

        private void searchTermTextBox_TextChanged(object sender, EventArgs e)
        {
            mSearchTerm = searchTermTextBox.Text;
            mCanDisplaySearch = true;
        }

        private void courseSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            mSelectedCourse = courseSelector.SelectedItem.ToString();
            mCanDisplaySearch = true;
        }

        private void classTypeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            mSelectedClassType = classTypeSelector.SelectedItem.ToString();
            mCanDisplaySearch = true;
        }

        private void fromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            mCanDisplaySearch = true;
        }

        private void toDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            mCanDisplaySearch = true;
        }

        private void filterByDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mCanDisplaySearch = true;
        }

        private void caseSensitiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mCanDisplaySearch = true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTabControl.TabPages.Remove(mainTabControl.SelectedTab);
        }

        [CommandMethod("noteviewer.closetab", "<int:Index>", "<string:Keyword>")]
        public static void CloseTab(string[] a_args)
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
                CustomConsole.Log("No override for command " + a_args[0] + " that takes " + a_args.Length + " arguments.");
            }
        }

        private void NoteViewerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Oemtilde)
            {
                using (ConsoleForm form = new ConsoleForm(GetType().Name))
                {
                    form.ShowDialog();
                }
            }
        }

        private void ResizeTabControlAndChildren()
        {
            int folderBoxWidth = foldersGroupBox.Width;

            // Get new width
            int newWidth = (Size.Width - mainTabControl.Location.X) - (folderBoxWidth + 40);
            mainTabControl.Width = newWidth;
            
            // Get new height
            int newHeight = (Size.Height - mainTabControl.Location.Y) - 70;
            mainTabControl.Height = newHeight;

            foreach (TabPage tab in mainTabControl.TabPages)
            {
                CustomTab cTab = (CustomTab)tab;

                foreach (Control ctrl in cTab.Controls)
                {
                    if (ctrl.GetType() == typeof(CustomRichTextBox))
                    {
                        ctrl.Width = newWidth - 13;
                        ctrl.Height = newHeight - 35;
                    }
                }
            }
        }

        private void NoteViewerForm_Resize(object sender, EventArgs e)
        {
            ResizeTabControlAndChildren();
        }
    }
}
