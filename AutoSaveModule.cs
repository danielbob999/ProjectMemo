using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

using ProjectMemo.ProjectMemoConsole;
using ProjectMemo.ProjectMemoConsole.CommandAttributes;

namespace ProjectMemo
{
    public class AutoSaveModule
    {
        private static AutoSaveModule ActiveInstance;

        private string mSaveDirectory;
        private CustomControls.CustomRichTextBox mRtbSurrogate;

        public AutoSaveModule() {
            ActiveInstance = this;
            mSaveDirectory = Directory.GetCurrentDirectory() + "\\" + "autosaves\\";
            mRtbSurrogate = new CustomControls.CustomRichTextBox();
        }

        public void Run() {
            CustomConsole.Log("Started AutoSaveModule", true);

            while (Thread.CurrentThread.ThreadState == ThreadState.Running) {
                Console.WriteLine(ProjectMemo.Forms.MainForm.AutoSaveInterval);

                Thread.Sleep(ProjectMemo.Forms.MainForm.AutoSaveInterval);

                Dictionary<string, string> rtbData = ProjectMemo.Forms.MainForm.RichTextBoxData;
                int saveId = 0;

                foreach (KeyValuePair<string, string> pair in rtbData) {
                    string[] fullPathSplit = pair.Key.Split('\\');
                    string fileName = fullPathSplit[fullPathSplit.Length - 1];

                    string autoSaveFilePath = mSaveDirectory + string.Format("autosave_{0}_{1}.tmp", DateTime.Now.ToString("yyyyMMdd_hhmmss"), saveId);

                    if (File.Exists(autoSaveFilePath)) {
                        File.Delete(autoSaveFilePath);
                    }

                    File.WriteAllText(autoSaveFilePath, pair.Value);
                    CustomConsole.Log("Saved temp file to: " + autoSaveFilePath);
                    saveId++;
                }
            }

            CustomConsole.Log("Closing the AutoSaveModule thread.");
        }

        private void Stop() {
            try {
                Thread.CurrentThread.Abort();
            } catch { return; }
        }

        [CommandMethod("autosave.stop", "")]
        public static void End(string[] aArgs) {
            ActiveInstance.Stop();
        }

        [CommandMethod("autosave.interval", "")]
        public static void LogInternal(string[] aArgs) {
            CustomConsole.Log("AutoSaveInterval: " + ProjectMemo.Forms.MainForm.AutoSaveInterval);
        }

        [CommandMethod("autosave.clearfiles", "")]
        public static void ClearAutoSaveFiles(string[] aArgs) {
            string[] files = Directory.GetFiles(ActiveInstance.mSaveDirectory);

            int i;
            for (i = 0; i < files.Length; i++) {
                File.Delete(files[i]);
            }

            CustomConsole.Log("Removed " + i + " autosave files");
        }
    }
}
