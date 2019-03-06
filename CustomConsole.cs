using System;
using System.Collections.Generic;
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
                msgQueue.Add(_msg);
                Console.WriteLine(_msg);
            }
        }
    }
}
