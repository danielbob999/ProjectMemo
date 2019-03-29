using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using ProjectMemo.CustomControls;
using ProjectMemo.ProjectMemoConsole;

namespace ProjectMemo.Formatting
{
    static class RtfCodeFormatter
    {
        public const string THEME_FOLDER_PATH = "language_themes/";
        public const string THEME_FILE_EXTENSION = ".lgt";

        private static int activeThemeIndex;
        private static List<LanguageTheme> allLanguageThemes = new List<LanguageTheme>();

        public static void LoadLanguageThemes()
        {   
            int amount = 0;

            // Add a default theme
            allLanguageThemes.Clear();
            allLanguageThemes.Add(new LanguageTheme("Default"));

            try
            {
                string[] allThemeFiles = Directory.GetFiles(THEME_FOLDER_PATH);

                foreach (string path in allThemeFiles)
                {
                    if (!path.EndsWith(THEME_FILE_EXTENSION))
                        return;

                    string themeName = path.Replace(Directory.GetCurrentDirectory(), "");
                    themeName = themeName.Replace(THEME_FILE_EXTENSION, "");
                    LanguageTheme newTheme = new LanguageTheme(themeName);

                    string[] allLines = File.ReadAllLines(path);
                    bool definingColours = false;
                    Dictionary<int, Color> definedColours = new Dictionary<int, Color>();
                    int colourNum = 0;

                    foreach (string line in allLines)
                    {
                        if (line == "#define")
                        {
                            definingColours = true;
                            continue;
                        }

                        if (line == "#end")
                        {
                            definingColours = false;
                            continue;
                        }


                        if (definingColours)
                        {
                            string[] lineSplit = line.Split('=');
                            string[] colourSplit = lineSplit[0].Split('|');
                            Color c = Color.FromArgb(1, Convert.ToInt32(colourSplit[0]), Convert.ToInt32(colourSplit[1]), Convert.ToInt32(colourSplit[2]));

                            definedColours.Add(Convert.ToInt32(lineSplit[1]), c);
                        }
                        else
                        {
                            string[] lineSplit = line.Split('=');

                            if (definedColours.ContainsKey(Convert.ToInt32(lineSplit[1])))
                            {
                                newTheme.AddKeywordColour(lineSplit[0], definedColours[Convert.ToInt32(lineSplit[1])]);
                                colourNum++;
                            }
                        }

                    }

                    allLanguageThemes.Add(newTheme);
                    CustomConsole.Log("Added new LanguageTheme called " + newTheme.GetName() + ". " + colourNum + " colours loaded.");
                }

                if (allLanguageThemes.Count > 1)
                    activeThemeIndex = 1;
                else
                    activeThemeIndex = 0;

            }
            catch (Exception e)
            {
                CustomConsole.Log("Failed to load in LanguageThemes");
                CustomConsole.Log(e.Message);
                return;
            }

        }

        public static void PrintKeyworldColours()
        {
        }

        public static void UpdateKeywordColour(string a_keyword, Color a_newColour)
        {
        }

        public static void ColourCodeFragment(ref CustomRichTextBox a_richTextBox, int a_start, int a_end)
        {
            string str = a_richTextBox.Text;
            int selectionStart = a_start;
            int selectionEnd = a_end;
            int currentIndex = selectionStart;
            bool nextWordIsClassName = false;
            bool stringIsLiteralString = false;
            bool nextIsSpace = false;

            //Console.WriteLine(str[selectionStart]);
            //Console.WriteLine("Start: {0}, End: {1}", selectionStart, selectionEnd);

            a_richTextBox.SelectionStart = a_start;
            a_richTextBox.SelectionLength = a_end - a_start;
            a_richTextBox.SelectionColor = Color.Black;

            // Colour keywords
            while (currentIndex < selectionEnd)
            {
                int tempIndx = 0;
                string newString = "";

                while (str[currentIndex + tempIndx] != ' ' && str[currentIndex + tempIndx] != '\n' && str[currentIndex + tempIndx] != '\t' && str[currentIndex + tempIndx] != '{' && str[currentIndex + tempIndx] != '}' 
                    && str[currentIndex + tempIndx] != '"' && str[currentIndex + tempIndx] != '(' && str[currentIndex + tempIndx] != ')' && str[currentIndex + tempIndx] != ':' && str[currentIndex + tempIndx] != '*' && str[currentIndex + tempIndx] != '&'
                    && str[currentIndex + tempIndx] != '-' && str[currentIndex + tempIndx] != '>')
                {
                    newString += str[currentIndex + tempIndx];
                    tempIndx++;

                    if (currentIndex + tempIndx >= str.Length)
                        break;
                    else
                        continue;
                }

                if (nextWordIsClassName)
                {
                    allLanguageThemes[activeThemeIndex].AddClass(newString);
                    nextWordIsClassName = false;
                }

                if (newString == "class")
                    nextWordIsClassName = true;

                Color col;
                if (allLanguageThemes[activeThemeIndex].GetColourFromKeyword(newString, out col))
                {
                    a_richTextBox.SelectionStart = currentIndex;
                    a_richTextBox.SelectionLength = newString.Length;
                    a_richTextBox.SelectionColor = col;
                    a_richTextBox.SelectionLength = 0;
                    a_richTextBox.SelectionColor = Color.Black;
                }

                currentIndex += (tempIndx + 1);
            }

            currentIndex = selectionStart;
            // Colour literal strings
            while (currentIndex < selectionEnd)
            {
                bool lookForEndOfString = false;
                int stringStartIndx = 0;

                while (currentIndex < selectionEnd)
                {
                    if (str[currentIndex] == '"' && lookForEndOfString)
                    {
                        Color col;
                        if (allLanguageThemes[activeThemeIndex].GetColourFromKeyword("literalstring", out col))
                        {
                            a_richTextBox.SelectionStart = stringStartIndx;
                            a_richTextBox.SelectionLength = (currentIndex) - stringStartIndx;
                            a_richTextBox.SelectionColor = col;
                            a_richTextBox.SelectionLength = 0;
                            a_richTextBox.SelectionColor = Color.Black;
                        }

                        lookForEndOfString = false;
                        currentIndex++;
                        continue;
                    }

                    if (str[currentIndex] == '"' && !lookForEndOfString)
                    {
                        lookForEndOfString = true;
                        stringStartIndx = currentIndex;
                    }

                    currentIndex++;
                }

            }

        }

    }
}
