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
    public partial class NoteViewerForm : Form
    {
        private string activeNotePath;

        public NoteViewerForm(string _path)
        {
            activeNotePath = _path;
            InitializeComponent();
        }

        private void NoteViewerForm_Load(object sender, EventArgs e)
        {
            mainNoteBrowser.Url = new Uri("file://" + activeNotePath);
            notePathLabel.Text = activeNotePath;
            CustomConsole.Log("Opening NoteViewerForm...");
            CustomConsole.Log("Note Uri: " + activeNotePath);
        }
    }
}
