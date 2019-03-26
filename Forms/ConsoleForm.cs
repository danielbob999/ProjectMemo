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
        private List<Thread> threadListRef;

        public ConsoleForm(ref List<Thread> _threadListRef)
        {
            threadListRef = _threadListRef;
            InitializeComponent();
        }

        private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && inputTextBox.Text != "")
            {
                string command = inputTextBox.Text;
                string[] splitCommand = command.Split(' ');
                inputTextBox.Text = "";
                CustomConsole.LogCommand(command);

                if (command == "savelock.override")
                {
                    MainForm.SaveLock = false;
                    CustomConsole.Log("Set MainForm.SaveLock to " + MainForm.SaveLock);
                    return;
                }

                if (command == "keywordcolours.print")
                {
                    RtfCodeFormatter.PrintKeyworldColours(ref consoleText);
                    return;
                }

                if (command.StartsWith("keywordcolours.reload"))
                {
                    string[] splitCmd = command.Split(' ');
                    if (splitCmd.Length == 2)
                        RtfCodeFormatter.InitKeywordColours(splitCmd[1]);
                    else
                        RtfCodeFormatter.InitKeywordColours("keyword_colours.conf");
                    return;
                }
            }
        }

        private void ConsoleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            threadListRef.Remove(Thread.CurrentThread);
            CustomConsole.Log("Closed thread with id: " + Thread.CurrentThread.ManagedThreadId + ". New thread count: " + threadListRef.Count);
            consoleTimer.Stop();
        }

        private void ConsoleForm_Load(object sender, EventArgs e)
        {
            consoleTimer.Start();
            CustomConsole.Log("Opened new instance of ConsoleForm");
        }

        private void consoleTimer_Tick(object sender, EventArgs e)
        {
            consoleText.Lines = CustomConsole.GetMessageQueueAsArray();
        }
    }
}
