using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityNoteProgram
{
    static class IOModule
    {
        public static void GetNoteDetailsFromFile(string _path, string _mainDir, string _semesterFold, out string _courseId, out string _classType)
        {
            string trimmedString = _path.Replace(_mainDir, "");
            trimmedString = trimmedString.Replace(_semesterFold, "");

            Console.WriteLine("Path left over: " + trimmedString);

            string[] splitStr = trimmedString.Split(new char[] { '\\', '_', '.' });

            _courseId = splitStr[1];
            _classType = splitStr[4];
        }
    }
}
