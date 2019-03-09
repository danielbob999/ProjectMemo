using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace UniversityNoteProgram
{
    public partial class MainForm : Form
    {
        public const int VERSION_MAJOR = 3;
        public const int VERSION_MINOR = 0;

        public string mainDirectory = ""; // The absolute directory of the main note directory (Contains the semester folders, e.g 18_s2, 19_s1)
        public string semesterFolder = ""; // The name of the selected semester folder 
        public string selectedCourseId = ""; // The string of the active note's course E.g 159234
        public string selectedClassType = ""; // The string of the active note's class type E.g Lecture

        public string defaultName;

        private List<System.Threading.Thread> activeThreads = new List<System.Threading.Thread>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void boldButton_Click(object sender, EventArgs e)
        {
            if (mainInputTextBox.SelectedText != "")
                mainInputTextBox.SelectedText = mainInputTextBox.SelectedText.Replace(mainInputTextBox.SelectedText, string.Format("<{0}>{1}</{0}>", "b", mainInputTextBox.SelectedText));
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            IOModule.SaveToHtml(mainInputTextBox, mainDirectory + semesterFolder + "\\" + selectedCourseId + "\\Notes\\" + string.Format("{0}-{1}-{2}_{3}.html", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, selectedClassType), mainDirectory);
            MainContent.saveData = new SaveData(mainInputTextBox.Text, MainContent.codeFragments);
        }

        private void formatEditCode_Click(object sender, EventArgs e)
        {
            int textBoxCaretPos = mainInputTextBox.GetLineFromCharIndex(mainInputTextBox.SelectionStart);

            if (mainInputTextBox.Lines[textBoxCaretPos].StartsWith("[CODEFRAGID=") && mainInputTextBox.Lines[textBoxCaretPos].EndsWith("]"))
            {
                Console.WriteLine("Opening code editor");
                using (CodeEditorForm form = new CodeEditorForm(mainInputTextBox.Lines[textBoxCaretPos]))
                {
                    form.ShowDialog();
                }

                Console.WriteLine("returning now");
                return;
            }

            int textBoxSelectedStart = mainInputTextBox.SelectionStart;
            string insertStr = string.Format("[CODEFRAGID={0}]", MainContent.nextId);
            MainContent.AddCodeFragment("[CODEFRAGID=" + MainContent.nextId + "]", new string[] { });
            mainInputTextBox.Text = mainInputTextBox.Text.Insert(mainInputTextBox.SelectionStart, insertStr);
            mainInputTextBox.Focus();
            mainInputTextBox.SelectionStart = textBoxSelectedStart + insertStr.Length;
            mainInputTextBox.SelectionLength = 0;
        }

        private void formatHeading_Click(object sender, EventArgs e)
        {
            if (mainInputTextBox.SelectedText != "")
                mainInputTextBox.SelectedText = mainInputTextBox.SelectedText.Replace(mainInputTextBox.SelectedText, string.Format("<{0}>{1}</{0}>", formatHeadingChoice.SelectedItem, mainInputTextBox.SelectedText));
        }

        private void formatTextColor_Click(object sender, EventArgs e)
        {
            if (mainInputTextBox.SelectedText != "")
                mainInputTextBox.SelectedText = mainInputTextBox.SelectedText.Replace(mainInputTextBox.SelectedText, string.Format("<span style='color: {0};'>{1}</span>", formatTextColourChoice.SelectedItem, mainInputTextBox.SelectedText));
        }

        private void formatItalic_Click(object sender, EventArgs e)
        {
            if (mainInputTextBox.SelectedText != "")
                mainInputTextBox.SelectedText = mainInputTextBox.SelectedText.Replace(mainInputTextBox.SelectedText, string.Format("<{0}>{1}</{0}>", "i", mainInputTextBox.SelectedText));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            /*
            if (Screen.PrimaryScreen.WorkingArea.Size.Width <= 1366 && Screen.PrimaryScreen.WorkingArea.Size.Height <= 728)
            {
                Size = Screen.PrimaryScreen.WorkingArea.Size;
            }*/

            // Get main directory and semester folder
            using (System.IO.StreamReader reader = new System.IO.StreamReader("details.conf"))
            {
                mainDirectory = reader.ReadLine();
                semesterFolder = reader.ReadLine();

                reader.Close();
                reader.Dispose();
            }

            defaultName = string.Format("{0} v{1}.{2}", this.Text, VERSION_MAJOR, VERSION_MINOR);
            versionLabel.Text = string.Format("v{0}.{1}", VERSION_MAJOR, VERSION_MINOR);
            mainFormLoop.Start();

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType() == typeof(Timer))
                    continue;

                if (ctrl.GetType() == typeof(MenuStrip))
                    continue;

                ctrl.Enabled = false;
            }

            titleLabel.Text = string.Format("{0}-{1}-{2}_{3}.html", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, selectedClassType);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mainInputTextBox.Text != "")
            {
                var result = MessageBox.Show("Do you want create a new note without saving this one?", "Warning", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;
            }

            bool formEndedWithValue = false;

            using (NewNoteForm form = new NewNoteForm())
            {
                form.ShowDialog();
                selectedCourseId = form.courseStr.Replace(".", "");
                selectedClassType = form.classTypeStr;
                formEndedWithValue = form.selectedValue;
            }

            if (!formEndedWithValue)
                return;

            // Enable all controls
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType() == typeof(Timer))
                    continue;

                if (ctrl.GetType() == typeof(MenuStrip))
                    continue;

                ctrl.Enabled = true;
            }

            mainInputTextBox.Text = "";
            MainContent.codeFragments.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();

            string path = openFile.FileName;

            openFile.Dispose();

            IOModule.ReadFromHtml(mainInputTextBox, path);
            IOModule.GetNoteDetailsFromFile(path, mainDirectory, semesterFolder, out selectedCourseId, out selectedClassType);

            // Enable all controls
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType() == typeof(Timer))
                    continue;

                if (ctrl.GetType() == typeof(MenuStrip))
                    continue;

                ctrl.Enabled = true;
            }
        }

        private void mainInputTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void mainFormLoop_Tick(object sender, EventArgs e)
        {
            mainInputTextBox.Font = new Font("Microsoft Sans Serif", (float)fontSizeChanger.Value, FontStyle.Regular);

            if (!MainContent.saveData.DoesCurrentDataMatch(mainInputTextBox.Text, MainContent.codeFragments))
            {
                this.Text = defaultName + "*";
                //saveButton.Enabled = false;
                //Console.WriteLine("You changed something");
            }
            else
            {
                this.Text = defaultName;
                //saveButton.Enabled = true;
            }

            directoryLabel.Text = mainDirectory + semesterFolder + "\\" + selectedCourseId + "\\Notes\\";
            titleLabel.Text = string.Format("{0}-{1}-{2}_{3}.html", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, selectedClassType);

            if (selectedClassType == "" && selectedCourseId == "")
            {
                currentNoteToolStripMenuItem.Enabled = false;
            }
            else
            {
                currentNoteToolStripMenuItem.Enabled = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mainInputTextBox.Text == "")
                return;

            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!MainContent.saveData.DoesCurrentDataMatch(mainInputTextBox.Text, MainContent.codeFragments))
                {
                    var result = MessageBox.Show("Do you want to exit without saving?", "Warning", MessageBoxButtons.YesNo);

                    e.Cancel = (result == DialogResult.No);
                }
            }

            foreach (System.Threading.Thread thread in activeThreads)
            {
                CustomConsole.Log(string.Format("Shutting down Thread with id: {0}", thread.ManagedThreadId));
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void formatUnderline_Click(object sender, EventArgs e)
        {
            if (mainInputTextBox.SelectedText != "")
                mainInputTextBox.SelectedText = mainInputTextBox.SelectedText.Replace(mainInputTextBox.SelectedText, string.Format("<{0}>{1}</{0}>", "u", mainInputTextBox.SelectedText));
        }

        private void formatCodeInText_Click(object sender, EventArgs e)
        {
            if (mainInputTextBox.SelectedText != "")
                mainInputTextBox.SelectedText = mainInputTextBox.SelectedText.Replace(mainInputTextBox.SelectedText, string.Format("<span class='method-variable'>{0}</span>", mainInputTextBox.SelectedText));
        }

        private void formatHighlightNode_Click(object sender, EventArgs e)
        {
            if (mainInputTextBox.SelectedText != "")
                mainInputTextBox.SelectedText = mainInputTextBox.SelectedText.Replace(mainInputTextBox.SelectedText, string.Format("<span class='standout-note'>{0}</span>", mainInputTextBox.SelectedText));
        }

        private void otherNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();

            string path = openFile.FileName;

            IOModule.GetNoteDetailsFromFile(path, mainDirectory, semesterFolder, out selectedCourseId, out selectedClassType);

            openFile.Dispose();

            using (NoteViewerForm form = new NoteViewerForm(path))
            {
                form.ShowDialog();
            }
        }

        private void currentNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = DialogResult.Cancel;

                if (!MainContent.saveData.DoesCurrentDataMatch(mainInputTextBox.Text, MainContent.codeFragments))
                {
                    result = MessageBox.Show("This note isn't saved. Do you want to save this Note?", "Warning", MessageBoxButtons.YesNo);
                }

                string fullPath = "";
                bool savedToTemp = false;

                if (!File.Exists(mainDirectory + semesterFolder + "\\" + selectedCourseId + "\\Notes\\" + string.Format("{0}-{1}-{2}_{3}.html", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, selectedClassType)))
                {
                    if (result == DialogResult.Yes)
                    {
                        saveButton.PerformClick();
                        fullPath = mainDirectory + semesterFolder + "\\" + selectedCourseId + "\\Notes\\" + string.Format("{0}-{1}-{2}_{3}.html", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, selectedClassType);
                    }
                    else
                    {
                        string tempPath = Directory.GetCurrentDirectory() + "\\temp\\";
                        string tempFileName = "tempSaveFile.temp";
                        fullPath = tempPath + tempFileName;
                        savedToTemp = true;

                        IOModule.SaveToHtml(mainInputTextBox, fullPath);
                    }
                }
                else
                {
                    fullPath = mainDirectory + semesterFolder + "\\" + selectedCourseId + "\\Notes\\" + string.Format("{0}-{1}-{2}_{3}.html", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, selectedClassType);
                }

                using (NoteViewerForm form = new NoteViewerForm(fullPath))
                {
                    form.ShowDialog();
                }

                if (savedToTemp)
                {
                    File.Delete(fullPath);
                }
            }
            catch (Exception ex)
            {
                CustomConsole.Log("An error has occured when trying to view the current note");
                CustomConsole.Log(ex.Message);
            }
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PreferencesForm form = new PreferencesForm())
            {
                form.ShowDialog();
            }
        }

        private void consoleWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.Thread newThread = new System.Threading.Thread(OpenConsoleWindow);
            newThread.Start();
        }

        private void OpenConsoleWindow()
        {
            CustomConsole.Log("Starting new Thread with id: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            using (ConsoleForm form = new ConsoleForm())
            {
                form.ShowDialog();
            }

            CustomConsole.Log("Shutting down Thread with id: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
        }
    }
}
