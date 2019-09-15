using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using ProjectMemo.Forms;
using System.IO;

namespace ProjectMemo.CustomControls
{
    class CustomTab : TabPage
    {
        private static int sNextId = 0;

        public int mTabId;
        public string mSemester = null;
        public string mCourse = null;
        public string mClassType = null;
        public string mFullPath = null;
        public bool canEdit = true;

        public CustomTab(string _sem, string _cour, string _ctype, string _fullPath = null)
        {
            mTabId = sNextId;
            sNextId++;
            mSemester = _sem;
            mCourse = _cour;
            mClassType = _ctype;

            if (_fullPath == null) {
                 mFullPath = string.Format("{0}{1}\\{2}\\Notes\\{3}-{4}-{5}_{6}.rtf",
                        MainForm.MainNoteDirectory, _sem, _cour,
                        DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, _ctype);
                Console.WriteLine("here2");
            } else {
                mFullPath = _fullPath;
                Console.WriteLine("Here1");
            }
        }

        public string GetFullPath()
        {
            if (mFullPath == null)
            {
                return string.Format("{0}{1}\\{2}\\Notes\\{3}-{4}-{5}_{6}.rtf",
                MainForm.MainNoteDirectory, mSemester, mCourse,
                DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, mClassType);
            }

            return mFullPath;
        }

        protected override void OnControlAdded(ControlEventArgs e) {
            base.OnControlAdded(e);

            if (e.Control.GetType() == typeof(CustomRichTextBox)) {
                ((CustomRichTextBox)e.Control).ParentControlDefaultTitle = this.Text;
            }
        }

        public void Save(bool aIsAutosave = false) {
            CustomRichTextBox thisTextBox = Controls.OfType<CustomRichTextBox>().ToArray()[0];

            if (thisTextBox == null) {
                ProjectMemoConsole.CustomConsole.Log("Failed to save note. There is not CustomRichTextBox in the CustomTab with " + mTabId);
                return;
            }

            if (aIsAutosave) {
                string savePath = Directory.GetCurrentDirectory() + "\\autosaves\\";
                string fileName = "autosave_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + ".tmp";

                thisTextBox.SaveFile(savePath + fileName);
                thisTextBox.SetSavePoint();
                ProjectMemoConsole.CustomConsole.Log("Saved file to " + savePath + fileName + ". IsAutoSave=true");
                return;
            }

            thisTextBox.SaveFile(mFullPath);
            thisTextBox.SetSavePoint();
            ProjectMemoConsole.CustomConsole.Log("Saved file to " + mFullPath + ". IsAutoSave=false");
        }
    }
}
