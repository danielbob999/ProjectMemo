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
    public partial class NewNoteForm : Form
    {
        public string courseStr;
        public string classTypeStr;
        public bool exited = false;
        public bool selectedValue = false;

        public NewNoteForm()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            courseStr = coursePicker.Text;
            classTypeStr = classTypePicker.Text;
            Close();
        }

        private void NewNoteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            exited = true;

            if (coursePicker.Text == "Blank")
            {
                selectedValue = true;
                return;
            }

            if (coursePicker.Text != "Select Course" && classTypePicker.Text != "Select Class Type")
            {
                selectedValue = true;
                return;
            }
        }
    }
}
