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
        private int m_OldLineNumber;

        public event EventHandler OnLineNumberChanged;

        public CustomRichTextBox()
        {
            base.BorderStyle = BorderStyle.FixedSingle;
            //base.TabStop = false;
            base.AcceptsTab = true;
            base.SelectionTabs = new int[] { 15, 30, 45 };
            m_OldLineNumber = 0;
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

            if (newLineNumber != m_OldLineNumber)
            {
                if (OnLineNumberChanged.GetInvocationList().Length != 0)
                    OnLineNumberChanged.Invoke(this, EventArgs.Empty);
                m_OldLineNumber = newLineNumber;
            }
        }
    }
}
