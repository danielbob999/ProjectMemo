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

namespace ProjectMemo.AutoSave
{
    public class AutoSaveModule
    {
        private static AutoSaveModule ActiveInstance;

        public event EventHandler OnAutoSaveTriggered;

        private string mSaveDirectory;      // The main autosave directory
        private int mSaveInterval;          // The interval, in minutes, that the module should autosave
        private Stopwatch mStopWatch;       // The main stopwatch that records how long it has been since the last save

        public AutoSaveModule() {
            ActiveInstance = this;
            mSaveDirectory = Directory.GetCurrentDirectory() + "\\autosaves\\";
            mStopWatch = new Stopwatch();
        }

        public void Update() {
            if (mStopWatch.Elapsed.Minutes > mSaveInterval) {
                if (OnAutoSaveTriggered != null) {
                    if (OnAutoSaveTriggered.GetInvocationList().Length > 0) {
                        OnAutoSaveTriggered.Invoke(this, EventArgs.Empty);
                    }
                }

                mStopWatch.Restart();
            }
        }

        public void SetInterval(int value) {
            if (value > 0) {
                mSaveInterval = value;
            }
        }

        [CommandMethod("autosave.interval", "")]
        public static void LogInterval(string[] aArgs) {
            if (aArgs.Length == 0) {
                CustomConsole.Log("AutoSaveInterval: " + ActiveInstance.mSaveInterval + " minutes");
                return;
            } else {
                if (int.TryParse(aArgs[1], out int newNum)) {
                    if (newNum > 0) {
                        int oldInterval = ActiveInstance.mSaveInterval;
                        ActiveInstance.mSaveInterval = newNum;
                        CustomConsole.Log("AutoSaveInterval: " + oldInterval + " -> " + ActiveInstance.mSaveInterval);
                        return;
                    }

                    CustomConsole.Log("You cannot set the AutoSaveInterval to a value less than 1");
                    return;
                }

                CustomConsole.Log("Cannot convert '" + aArgs[1] + "' to an int");
                return;
            }
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
