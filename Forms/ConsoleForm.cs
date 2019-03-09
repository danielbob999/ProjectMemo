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
    public partial class ConsoleForm : Form
    {
        public ConsoleForm()
        {
            InitializeComponent();
        }

        private void consoleTimer_Tick(object sender, EventArgs e)
        {
            mainConsoleTextBox.Lines = CustomConsole.msgQueue.ToArray();
        }

        private void ConsoleForm_Load(object sender, EventArgs e)
        {
            consoleTimer.Start();
        }
    }
}
