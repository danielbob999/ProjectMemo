using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using ProjectMemo.Forms;

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
        public bool newFile = true;

        public CustomTab(string _sem, string _cour, string _ctype, bool _newFile = true, string _fullPath = null)
        {
            mTabId = sNextId;
            sNextId++;
            mSemester = _sem;
            mCourse = _cour;
            mClassType = _ctype;
            mFullPath = _fullPath;
            newFile = _newFile;
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
    }
}
