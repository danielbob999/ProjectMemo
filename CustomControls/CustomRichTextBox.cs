using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace ProjectMemo.CustomControls
{
    class CustomRichTextBox : RichTextBox
    {
        private int mOldLineNumber;
        private string mParentControlDefaultTitle;
        private string mLastSavePointString = "";

        public event EventHandler OnLineNumberChanged;

        public string ParentControlDefaultTitle
        {
            set { mParentControlDefaultTitle = value; }
        }

        public string TabPath
        {
            get { return ((CustomTab)this.Parent).mFullPath; }
        }

        public CustomRichTextBox()
        {
            base.BorderStyle = BorderStyle.FixedSingle;
            //base.TabStop = false;
            base.AcceptsTab = true;
            base.SelectionTabs = new int[] { 15, 30, 45 };
            mOldLineNumber = 0;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            //base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            //base.OnKeyPress(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            //base.OnKeyUp(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            int newLineNumber = GetLineFromCharIndex(SelectionStart);

            if (newLineNumber != mOldLineNumber)
            {
                if (OnLineNumberChanged.GetInvocationList().Length != 0)
                    OnLineNumberChanged.Invoke(this, EventArgs.Empty);

                mOldLineNumber = newLineNumber;
            }

            if (this.Rtf != mLastSavePointString) {
                if (this.Parent != null)
                    this.Parent.Text = mParentControlDefaultTitle + " *";
                //Console.WriteLine("{0} is different from {1}", mLastSavePointString, this.Rtf);
            } else {
                if (this.Parent != null)
                    this.Parent.Text = mParentControlDefaultTitle;
            }
        }

        public void SetSavePoint() {
            mLastSavePointString = this.Rtf;
            if (this.Parent != null)
                this.Parent.Text = mParentControlDefaultTitle;
            ProjectMemoConsole.CustomConsole.Log("Set save point of CustomRichTextBox");
        }
    }
}
