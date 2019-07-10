using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectMemo.ProjectMemoConsole;

namespace ProjectMemo.Forms
{
    public partial class PreferencesForm : Form
    {
        public string selectedDirectory = null;
        public int autoSaveInterval;

        public PreferencesForm(string _currentMainDir, int _autoSaveInt)
        {
            if (_currentMainDir != "" && _currentMainDir != null)
            {
                selectedDirectory = _currentMainDir;
            }

            autoSaveInterval = _autoSaveInt;

            InitializeComponent();
        }

        private void PreferencesForm_Load(object sender, EventArgs e)
        {
            directoryTextBox.Text = selectedDirectory;
            autoSaveIntervalInput.Value = autoSaveInterval;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fileDialog = new FolderBrowserDialog();
            fileDialog.ShowDialog();

            directoryTextBox.Text = fileDialog.SelectedPath;
            selectedDirectory = directoryTextBox.Text;

            fileDialog.Dispose();
            CustomConsole.Log("Set the main note directory: " + directoryTextBox.Text);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            autoSaveInterval = (int)autoSaveIntervalInput.Value;

            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(IOModule.PREFERENCES_FILENAME))
            {
                // Write the selected  main directory to teh details file
                if (selectedDirectory != null)
                {
                    writer.WriteLine(selectedDirectory);
                }
                else
                {
                    writer.WriteLine("NULL");
                }

                writer.WriteLine(autoSaveIntervalInput.Value);

                writer.Close();
                writer.Dispose();
            }

            CustomConsole.Log("Saved Preferences to '" + IOModule.PREFERENCES_FILENAME + "'");
        }
    }
}
