using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectMemo.NoteViewing;
using ProjectMemo.Forms;

namespace ProjectMemo.CustomControls
{
    public partial class ViewingSearchResult : UserControl
    {
        private NoteViewingData.NoteData mNoteData;
        private string mMatchedTerm;

        public ViewingSearchResult(NoteViewingData.NoteData a_data, string a_matchedTerm)
        {
            mNoteData = a_data;
            mMatchedTerm = a_matchedTerm;
            InitializeComponent();
        }

        private void CombinedOnDoubleClick(object sender, EventArgs e)
        {
            NoteViewerForm parent = (NoteViewerForm)(Parent.Parent.Parent);
            parent.OpenNote(mNoteData.fullPath, mNoteData.fileName, mNoteData.course);
        }

        private void ViewingSearchResult_Load(object sender, EventArgs e)
        {
            if (mMatchedTerm == "")
            {
                titleLabel.Text = "[" + mNoteData.course + "] " + mNoteData.fileName;
                searchTermLabel.Text = "";
                Height = 30;
                return;
            }

            titleLabel.Text = "[" + mNoteData.course + "] " + mNoteData.fileName;
            searchTermLabel.Text = "... " + mMatchedTerm + " ...";
        }
    }
}
