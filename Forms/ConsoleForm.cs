using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using ProjectMemo.ProjectMemoConsole;
using ProjectMemo.Formatting;

namespace ProjectMemo.Forms
{
    public partial class ConsoleForm : Form
    {
        private static ConsoleForm ActiveInstance = null;

        private string m_CallingTypeString;
        private bool m_ScrollToCaretAuto;

        public static bool CaretAutoScroll {
            get {
                if (ActiveInstance != null) {
                    return ActiveInstance.m_ScrollToCaretAuto;
                } else {
                    return false;
                }
            }

            set {
                if (ActiveInstance != null) {
                    ActiveInstance.m_ScrollToCaretAuto = value;
                }
            }
        }

        public ConsoleForm(string a_callingStr)
        {
            if (ActiveInstance != null) {
                ActiveInstance.Close();
            }

            ActiveInstance = this;
            m_CallingTypeString = a_callingStr;
            m_ScrollToCaretAuto = true;
            InitializeComponent();
        }

        private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && inputTextBox.Text != "")
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                string command = inputTextBox.Text;
                string[] splitCommand = command.Split(' ');
                inputTextBox.Text = "";
                CustomConsole.LogCommand(command);

                CustomConsole.ProcessCommand(command);

                /*
                if (command == "savelock.override")
                {
                    MainForm.SaveLock = false;
                    CustomConsole.Log("Set MainForm.SaveLock to " + MainForm.SaveLock);
                    return;
                }*/
            }
        }

        private void ConsoleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            consoleTimer.Stop();
        }

        private void ConsoleForm_Load(object sender, EventArgs e)
        {
            consoleTimer.Start();
            CustomConsole.Log("Opened new instance of ConsoleForm from " + m_CallingTypeString);
        }

        private void consoleTimer_Tick(object sender, EventArgs e)
        {
            consoleText.Lines = CustomConsole.GetMessageQueueAsArray();

            if (m_ScrollToCaretAuto) {
                consoleText.SelectionStart = consoleText.Text.Length - 1;
                consoleText.ScrollToCaret();
            }
        }

        private void ConsoleForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Oemtilde)
            {
                Close();
            }
        }
    }
}
