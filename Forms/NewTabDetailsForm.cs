using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectMemo.Forms
{
    public partial class NewTabDetailsForm : Form
    {
        private string mSemester;
        private string mCourse;
        private string mClassType;

        private string[] mPredefinedSemesters;

        public string Semester
        {
            get { return mSemester; }
        }

        public string Course
        {
            get { return mCourse; }
        }

        public string ClassType
        {
            get { return mClassType; }
        }

        public NewTabDetailsForm(string[] aSems) {
            mPredefinedSemesters = aSems;
            InitializeComponent();
        }

        public void OnFormLoad(object sender, EventArgs e) {
            semesterSelector.Items.AddRange(mPredefinedSemesters);
        }

        public void OnCreateButtonPressed(object sender, EventArgs e) {
            mSemester = semesterSelector.SelectedItem.ToString();
            mCourse = courseSelector.SelectedItem.ToString();
            mClassType = classTypeSelector.SelectedItem.ToString();
        }

        public void OnSemesterSelectedChanged(object sender, EventArgs e) {
            string[] courses = System.IO.Directory.GetDirectories(MainForm.MainNoteDirectory + semesterSelector.SelectedItem.ToString());

            courseSelector.Items.Clear();
            foreach (string folder in courses) {
                courseSelector.Items.Add(folder.Replace((MainForm.MainNoteDirectory + semesterSelector.SelectedItem.ToString() + "\\"), ""));
            }
        }
    }
}
