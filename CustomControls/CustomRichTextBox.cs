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
        public CustomRichTextBox()
        {
            base.BorderStyle = BorderStyle.FixedSingle;
            //base.TabStop = false;
            base.AcceptsTab = true;
            base.SelectionTabs = new int[] { 15, 30, 45 };
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
    }
}
