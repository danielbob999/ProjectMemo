using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityNoteProgram
{
    public partial class CodeEditorForm : Form
    {
        private string editingCodeFragId;

        public CodeEditorForm(string _codeFragKey)
        {
            editingCodeFragId = _codeFragKey;
            InitializeComponent();
        }

        private void formTimer_Tick(object sender, EventArgs e)
        {
            
        }

        private void CodeEditorForm_Load(object sender, EventArgs e)
        {
            titleLabel.Text = editingCodeFragId;

            if (MainContent.GetCodeFragment(editingCodeFragId) != null)
            {
                mainInputBox.Lines = MainContent.GetCodeFragment(editingCodeFragId);
            }
        }

        private void mainInputBox_TextChanged(object sender, EventArgs e)
        {
            /*
            if (MainContent.GetCodeFragment(editingCodeFragId) == null)
            {
                MainContent.AddCodeFragment(editingCodeFragId, mainInputBox.Lines);
            }
            else
            {
                MainContent.EditCodeFragment(editingCodeFragId, mainInputBox.Lines);
            }*/
        }

        private void CodeEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainContent.GetCodeFragment(editingCodeFragId) == null)
            {
                MainContent.AddCodeFragment(editingCodeFragId, mainInputBox.Lines);
            }
            else
            {
                MainContent.EditCodeFragment(editingCodeFragId, mainInputBox.Lines);
            }
        }

        private void mainInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                Console.WriteLine("Tab pressed");
                int selectionPos = mainInputBox.SelectionStart;
                mainInputBox.Text = mainInputBox.Text.Insert(mainInputBox.SelectionStart, "   ");
                mainInputBox.SelectionStart = selectionPos + 3;
            }
        }

        private void mainInputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void mainInputBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                int pos = mainInputBox.SelectionStart;
                mainInputBox.Text = mainInputBox.Text.Insert(mainInputBox.SelectionStart, "   ");
                //textBox1.SelectionStart += 1;
                mainInputBox.SelectionStart = pos + 3;
                //indentationLevel++;
            }
        }
    }
}
