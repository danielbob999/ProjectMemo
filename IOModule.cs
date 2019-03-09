using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace UniversityNoteProgram
{
    static class IOModule
    {
        public static void GetNoteDetailsFromFile(string _path, string _mainDir, string _semesterFold, out string _courseId, out string _classType)
        {
            string trimmedString = _path.Replace(_mainDir, "");
            trimmedString = trimmedString.Replace(_semesterFold, "");

            string[] splitStr = trimmedString.Split(new char[] { '\\', '_', '.' });

            _courseId = splitStr[1];
            _classType = splitStr[4];
        }

        public static int SaveToHtml(TextBox _box, string _path)
        {
            try
            {
                string finalString = "";

                StreamWriter writer = new StreamWriter(File.OpenWrite(_path));
                writer.WriteLine("<html>\n" +
                    "<head>\n" +
                    "<script src=\"https://cdn.jsdelivr.net/gh/google/code-prettify@master/loader/run_prettify.js\"></script>\n" +
                    "<link rel='stylesheet' type='text/css' href='../main.css" + "'>\n" +
                    "</head>\n" +
                    "<body><div id='main-content'>");

                foreach (string ln in _box.Lines)
                {
                    if (ln.StartsWith("[CODEFRAGID=") && ln.EndsWith("]"))
                    {
                        writer.WriteLine("<div class='code-div'><code class='prettyprint lang-c'>");
                        string[] codeFragment = MainContent.GetCodeFragment(ln);

                        foreach (string codeLine in codeFragment)
                        {
                            writer.WriteLine(codeLine.Replace(" ", "&nbsp;") + "<br>");
                        }

                        writer.WriteLine("</code></div>");
                        continue;
                    }

                    finalString += ln + "\n";
                    writer.WriteLine(ln + "<br>");
                }

                writer.WriteLine("<span id='raw' style='display: none;'>");
                writer.WriteLine("#RAW_TEXT_START");

                foreach (string line in _box.Lines)
                {
                    writer.WriteLine(line);
                }

                writer.WriteLine("#RAW_TEXT_END");

                writer.WriteLine("#RAW_CODE_START");

                foreach (KeyValuePair<string, string[]> pair in MainContent.codeFragments)
                {
                    writer.WriteLine("start_" + pair.Key);

                    foreach (string codeLine in pair.Value)
                    {
                        writer.WriteLine(codeLine);
                    }

                    writer.WriteLine("end_" + pair.Key);
                }

                writer.WriteLine("#RAW_CODE_END");

                writer.WriteLine("</div></body>\n</html>");

                writer.Close();
                writer.Dispose();

                CustomConsole.Log("Saved Note to: " + _path);

                return 1;
            }
            catch (Exception e)
            {
                CustomConsole.Log("IOModule.SaveToHtml has crashed...");
                CustomConsole.Log(e.Message);
                return 0;
            }
        }

        public static string[] ReadFromHtml(TextBox _box, string _path)
        {
            try
            {
                string[] fileContents = File.ReadAllLines(_path);

                int rawTextLineStart = -1;
                int rawCodeLineStart = -1;
                int rawCodeLineEnd = -1;
                int indx = 0;

                List<string> textContents = new List<string>();


                foreach (string line in fileContents)
                {
                    if (line == "#RAW_TEXT_START")
                    {
                        rawTextLineStart = indx;
                        continue;
                    }

                    if (rawTextLineStart != -1)
                    {
                        if (line == "#RAW_TEXT_END")
                        {
                            rawTextLineStart = -1;
                            continue;
                        }

                        textContents.Add(line);
                    }

                    if (line == "#RAW_CODE_START")
                    {
                        rawCodeLineStart = indx;
                    }

                    if (rawCodeLineStart != -1)
                    {
                        if (line == "#RAW_CODE_END")
                        {
                            rawCodeLineEnd = indx;
                        }
                    }

                    indx++;
                }

                List<string> strList = new List<string>();

                for (int i = rawCodeLineStart; i < fileContents.Length; i++)
                {
                    strList.Add(fileContents[i]);
                }

                MainContent.codeFragments = GetCodeFragsFromRawText(strList.ToArray());

                _box.Lines = textContents.ToArray();
                return textContents.ToArray();
            }
            catch (Exception e)
            {
                CustomConsole.Log("IOModule.ReadFromHtml has crashed...");
                CustomConsole.Log(e.Message);
                return new string[] { };
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
