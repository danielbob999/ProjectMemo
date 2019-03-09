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
        public static List<string> msgQueue = new List<string>();

        public static void Log(string _msg)
        {
            if (_msg != "")
            {
                StackTrace trace = new StackTrace();
                string msgStr = string.Format("[{0}] {1} ({2}.{3})", DateTime.Now.ToLongTimeString(), _msg, trace.GetFrame(1).GetMethod().DeclaringType.Name, trace.GetFrame(1).GetMethod().Name);
                msgQueue.Add(msgStr);
                Console.WriteLine(msgStr);
            }
        }
    }
}
