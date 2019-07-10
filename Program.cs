using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectMemo.Forms;
using ProjectMemo.ProjectMemoConsole.CommandAttributes;

namespace ProjectMemo
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ProjectMemoConsole.CustomConsole.Log("Starting ProjectMemo. (" + MainForm.Version + ")", true);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        [CommandMethod("program.version", "")]
        public static void LogVersion(string[] aArgs) {
            ProjectMemoConsole.CustomConsole.Log(MainForm.Version, true);
        }
    }
}
