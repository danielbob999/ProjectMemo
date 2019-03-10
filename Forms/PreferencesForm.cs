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
    public partial class PreferencesForm : Form
    {
        public string selectedDirectory = "NULL";
        public string selectedSemester = "NULL";

        public PreferencesForm()
        {
            InitializeComponent();
        }

        private void mainDirectoryButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fileDialog = new FolderBrowserDialog();
            fileDialog.ShowDialog();

            mainDirectoryTextBox.Text = fileDialog.SelectedPath;
            selectedDirectory = mainDirectoryTextBox.Text;

            fileDialog.Dispose();
            CustomConsole.Log("Set the main directory: " + mainDirectoryTextBox.Text);

            string[] dirs = Directory.GetDirectories(selectedDirectory);

            semesterFolderPicker.Items.Clear();

            foreach (string str in dirs)
                semesterFolderPicker.Items.Add(str.Replace(selectedDirectory, ""));
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter("details.conf"))
            {
                // Write the selected  main directory to teh details file
                if (mainDirectoryTextBox.Text != "")
                {
                    writer.WriteLine(mainDirectoryTextBox.Text);
                }
                else
                {
                    writer.WriteLine("NULL");
                }

                // Write the selected semester folder to the details file
                if (selectedSemester != "")
                {
                    writer.WriteLine(selectedSemester);
                }
                else
                {
                    writer.WriteLine("NULL");
                }

                writer.Close();
                writer.Dispose();
            }

            CustomConsole.Log("Saved Preferences to details.conf");
        }

        private void PreferencesForm_Load(object sender, EventArgs e)
        {
            CustomConsole.Log("Opening PreferencesFrom...");
            using (System.IO.StreamReader reader = new System.IO.StreamReader("details.conf"))
            {
                mainDirectoryTextBox.Text = reader.ReadLine();
                selectedDirectory = mainDirectoryTextBox.Text;
                string tempSemester = reader.ReadLine();

                if (selectedDirectory != "")
                {
                    string[] dirs = Directory.GetDirectories(selectedDirectory);

                    foreach (string str in dirs)
                        semesterFolderPicker.Items.Add(str.Replace(selectedDirectory, ""));
                }

                if (tempSemester != "NULL")
                {
                    for (int i = 0; i < semesterFolderPicker.Items.Count; i++)
                    {
                        if (semesterFolderPicker.Items[i].ToString() == tempSemester)
                        {
                            semesterFolderPicker.SelectedIndex = i;
                            selectedSemester = tempSemester;
                        }
                    }
                }
                else
                {
                    selectedSemester = "NULL";
                }

                reader.Close();
                reader.Dispose();
            }
        }

        private void PreferencesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CustomConsole.Log("Closing PreferencesForm...");
        }

        private void semesterFolderPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSemester = semesterFolderPicker.SelectedItem.ToString();
        }
    }
}
