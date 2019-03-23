using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityNoteProgram
{
    static class CustomConsole
    {
        private static List<string> msgQueue = new List<string>();

        public static void Log(string _msg, bool a_disableTrace = false)
        {
            if (_msg != "")
            {
                StackTrace trace = new StackTrace();
                string msgStr;

                if (a_disableTrace)
                {
                    msgStr = string.Format("[{0}] {1}", DateTime.Now.ToLongTimeString(), _msg);
                }
                else
                {
                    msgStr = string.Format("[{0}] {1} ({2}.{3})", DateTime.Now.ToLongTimeString(), _msg, trace.GetFrame(1).GetMethod().DeclaringType.Name, trace.GetFrame(1).GetMethod().Name);
                }

                msgQueue.Add(msgStr);
                Console.WriteLine(msgStr);
            }
        }

        public static void LogCommand(string _cmdStr)
        {
            if (_cmdStr != "")
            {
                string msgStr = string.Format("[{0}] >> {1}", DateTime.Now.ToLongTimeString(), _cmdStr);
                msgQueue.Add(msgStr);
                Console.WriteLine(msgStr);
            }
        }

        public static string GetMessageQueueAsString()
        {
            string str = "";

            foreach (string s in msgQueue)
                str += (s + "\n");

            return str;
        }

        public static string[] GetMessageQueueAsArray()
        {
            return msgQueue.ToArray();
        }

        public static void ProcessCommand(string _cmd)
        {

        }
    }
}
