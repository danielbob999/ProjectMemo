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
        public const int VERSION_MAJOR = 2;
        public const int VERSION_MINOR = 1;

        public string workingDirectory = "";
        public string workingFileName = "";
        public string defaultName;

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
            OutputModule.SaveToHtml(mainInputTextBox,  workingDirectory + pathTextBox.Text);
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

            // Set the working directory
            //workingDirectory = string.Format("{0}\\{1}\\{2}\\", Directory.GetCurrentDirectory(), coursePicker.SelectedItem.ToString().Replace(".", ""), "Notes");
            directoryLabel.Text = workingDirectory;

            // Set the filename
            //workingFileName = string.Format("{0}-{1}-{2}_{3}_Notes.html", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, classTypePicker.SelectedItem);
            pathTextBox.Text = workingFileName;

            titleLabel.Text = workingFileName;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mainInputTextBox.Text != "")
            {
                var result = MessageBox.Show("Do you want create a new note without saving this one?", "Warning", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;
            }

            string cStr;
            string ctStr;
            bool formEndedWithValue = false;

            using (NewNoteForm form = new NewNoteForm())
            {
                form.ShowDialog();
                cStr = form.courseStr;
                ctStr = form.classTypeStr;
                formEndedWithValue = form.selectedValue;
            }

            //Console.WriteLine(formExited);
            if (!formEndedWithValue)
                return;

            if (cStr == "Blank")
            {
                workingDirectory = Directory.GetCurrentDirectory() + "\\";
                directoryLabel.Text = workingDirectory;

                int indx = 0;

                while (indx < 100)
                {
                    if (File.Exists(workingDirectory + "BlankNote" + indx + ".html"))
                    {
                        indx++;
                        continue;
                    }

                    workingFileName = string.Format("BlankNote" + indx + ".html");
                    pathTextBox.Text = workingFileName;
                    break;
                }

            }
            else
            {
                workingDirectory = string.Format("{0}\\{1}\\{2}\\", Directory.GetCurrentDirectory(), cStr.Replace(".", ""), "Notes");
                directoryLabel.Text = workingDirectory;
                workingFileName = string.Format("{0}-{1}-{2}_{3}.html", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, ctStr);
                pathTextBox.Text = workingFileName;
            }

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

            OutputModule.ReadFromHtml(mainInputTextBox, path);

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
    }
}
