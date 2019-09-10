using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Diagnostics;

using ProjectMemo.ProjectMemoConsole;
using ProjectMemo.ProjectMemoConsole.CommandAttributes;

namespace ProjectMemo
{
    public class AutoSaveModule
    {
        private static AutoSaveModule ActiveInstance;

        public event EventHandler OnAutoSave;

        private string mSaveDirectory;
        private bool mRunLoop = false;
        private Stopwatch mStopWatch;

        public AutoSaveModule() {
            ActiveInstance = this;
            mSaveDirectory = Directory.GetCurrentDirectory() + "\\autosaves\\";
            mStopWatch = new Stopwatch();
        }

        public void Run() {
            CustomConsole.Log("Started AutoSaveModule", true);
            mRunLoop = true;
            mStopWatch.Start();

            while (mRunLoop) {
                Thread.Sleep(1000);
                //Console.WriteLine(mStopWatch.ElapsedMilliseconds);
                if (mStopWatch.ElapsedMilliseconds > ProjectMemo.Forms.MainForm.AutoSaveInterval) {
                    /*
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
                    */

                    if (OnAutoSave != null) {
                        if (OnAutoSave.GetInvocationList().Length > 0) {
                            OnAutoSave.Invoke(this, EventArgs.Empty);
                        }
                    }

                    mStopWatch.Restart();
                }
            }

            CustomConsole.Log("Closing the AutoSaveModule thread.");
            mStopWatch.Stop();
        }

        private void Stop() {
            mRunLoop = false;
        }

        [CommandMethod("autosave.stop", "")]
        public static void End(string[] aArgs) {
            ActiveInstance.Stop();
        }

        [CommandMethod("autosave.interval", "")]
        public static void LogInternal(string[] aArgs) {
            int mins = (ProjectMemo.Forms.MainForm.AutoSaveInterval / 1000) / 60;
            CustomConsole.Log("AutoSaveInterval: " + mins + " minutes (" + ProjectMemo.Forms.MainForm.AutoSaveInterval + ")");
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
