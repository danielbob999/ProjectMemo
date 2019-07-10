using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using ProjectMemo.ProjectMemoConsole;

namespace ProjectMemo
{
    static class IOModule
    {
        public const string PREFERENCES_FILENAME = "preferences.conf";

        public static void SetupCurrentDirectory() {
            // Check to see if the autosaves folder exists, if not, create it
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\autosaves")) {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\autosaves");
            }

            // Check to see if the logs folder exists, if not, create it
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\logs")) {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\logs");
            }
        }

        public static void GetNoteDetailsFromFile(string _path, string _mainDir, string _semesterFold, out string _courseId, out string _classType)
        {
            string trimmedString = _path.Replace(_mainDir, "");
            trimmedString = trimmedString.Replace(_semesterFold, "");

            string[] splitStr = trimmedString.Split(new char[] { '\\', '_', '.' });

            _courseId = splitStr[1];
            _classType = splitStr[4];
        }

        public static bool ReadPreferencesFromFile(out List<string> _prefs)
        {
            _prefs = new List<string>();


            try
            {
                using (StreamReader reader = new StreamReader(PREFERENCES_FILENAME))
                {
                    _prefs.Add(reader.ReadLine());
                    _prefs.Add(reader.ReadLine());

                    reader.Close();
                    reader.Dispose();
                }

                CustomConsole.Log("Successfully read in all preferences from '" + PREFERENCES_FILENAME + "'");
                return true;
            }
            catch (Exception e)
            {
                CustomConsole.Log("Failed to load preferences from '" + PREFERENCES_FILENAME + "'");
                CustomConsole.Log(e.Message);
                return false;
            }
        }

        public static Dictionary<string, string[]> GetCodeFragsFromRawText(string[] _str)
        {
            Dictionary<string, string[]> codeFrags = new Dictionary<string, string[]>();

            List<string> activeCodeFrag = new List<string>();
            string activeCodeFragId = "NULL";

            foreach (string line in _str)
            {
                if (line.StartsWith("start_"))
                {
                    string[] splitStr = line.Split('_');
                    activeCodeFragId = splitStr[1];
                    continue;
                }

                if (line.StartsWith("end_"))
                {
                    string[] splitStr = line.Split('_');

                    CustomConsole.Log("Read Code Fragment with ID '" + activeCodeFragId + "'");

                    codeFrags.Add(activeCodeFragId, activeCodeFrag.ToArray());
                    activeCodeFrag.Clear();
                    activeCodeFragId = "NULL";
                    continue;
                }

                if (activeCodeFragId != "NULL")
                {
                    activeCodeFrag.Add(line);
                    continue;
                }
            }

            MainContent.nextId = codeFrags.Count;
            return codeFrags;
        }
    }
}
