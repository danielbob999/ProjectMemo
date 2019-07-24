using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ProjectMemo.CustomControls;
using ProjectMemo.ProjectMemoConsole;

namespace ProjectMemo.Formatting
{
    static class RtfCodeFormatter
    {
        public const string THEME_FOLDER_PATH = "language_themes/";
        public const string THEME_FILE_EXTENSION = ".lgt";

        private static int activeThemeIndex;
        private static List<LanguageTheme> sAllLanguageThemes = new List<LanguageTheme>();

        public static LanguageTheme[] LoadedLanguageThemes
        {
            get { return sAllLanguageThemes.ToArray(); }
        }

        public static void LoadLanguageThemes() {
            sAllLanguageThemes.Clear();
            sAllLanguageThemes.Add(new LanguageTheme("Default"));

            try {
                string[] languageFiles = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\language_themes");
                int count = 0;

                for (int i = 0; i < languageFiles.Length; i++) {
                    BinaryFormatter formatter = new BinaryFormatter();
                    FileStream fs = File.Open(languageFiles[i], FileMode.Open);

                    LanguageTheme newTheme = (LanguageTheme)formatter.Deserialize(fs);

                    sAllLanguageThemes.Add(newTheme);
                    Console.WriteLine("Loaded new theme Name: " + newTheme.Name);
                    count++;

                    fs.Close();
                }

                CustomConsole.Log("Loaded " + count + " LanguageThemes");
            }
            catch (Exception e) {
                CustomConsole.Log("Failed to load in LanguageThemes");
                CustomConsole.Log(e.Message);
                return;
            }
        }

        public static void FormatCodeFragment(string a_languageName, ref CustomRichTextBox a_richTextBox, int a_start, int a_end)
        {
            LanguageTheme activeTheme = null;

            foreach (LanguageTheme theme in sAllLanguageThemes) {
                if (theme.Name == a_languageName)
                    activeTheme = theme;
            }

            if (activeTheme == null)
                activeTheme = sAllLanguageThemes[0];

            a_richTextBox.SelectionColor = Color.Black;

            foreach (SingleKeywordDesign keyword in activeTheme.Keywords)
                ColourSingleKeyword(keyword, ref a_richTextBox, a_start, a_end);

            foreach (MultiwordDesign multiword in activeTheme.MultiWordDesigns)
                FormatMultiwords(multiword, ref a_richTextBox, a_start, a_end);

            /*
            LanguageTheme activeTheme = null;

            foreach (LanguageTheme theme in allLanguageThemes)
            {
                if (theme.GetName() == a_languageName)
                    activeTheme = theme;
            }

            if (activeTheme == null)
                activeTheme = allLanguageThemes[0];

            string str = a_richTextBox.Text;
            int selectionStart = a_start;
            int selectionEnd = a_end;
            int currentIndex = selectionStart;
            bool nextWordIsClassName = false;

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

            ColourLiteralStrings(activeTheme, ref a_richTextBox, a_start, a_end);
            ColourComments(activeTheme, ref a_richTextBox, a_start, a_end);
            */
        }

        private static void FormatMultiwords(MultiwordDesign aMultiword, ref CustomRichTextBox aRichTextBox, int aStart, int aEnd) {
            string lastWord = "";
            char nextChar = 'A';
            int startingCharIndex = aStart, currentCharIndex = aStart;
            bool lookingForEndingString;

            string regexStatement = "(";

            foreach (char startChar in aMultiword.StartString) {
                regexStatement += "[" + startChar + "]";
            }

            regexStatement += ").*(";

            foreach (char endChar in aMultiword.EndString) {
                regexStatement += "[" + endChar + "]";
            }

            regexStatement += ")";

            string inputStr = aRichTextBox.Text.Substring(aStart, (aEnd - aStart));

            MatchCollection stringMatches = Regex.Matches(@inputStr, @regexStatement);

            //Console.WriteLine("Looking for Regex matches based on pattern: " + regexStatement);
            //Console.WriteLine("From input: " + inputStr);
            //Console.WriteLine("Found " + stringMatches.Count + " matches");

            foreach (Match match in stringMatches) {
                aRichTextBox.SelectionStart = aStart + match.Index;
                aRichTextBox.SelectionLength = match.Length + 1;
                aRichTextBox.SelectionColor = aMultiword.Colour;
                aRichTextBox.SelectionLength = 0;
            }
        }

        private static void ColourLiteralStrings(LanguageTheme a_theme, ref CustomRichTextBox a_richTextBox, int a_start, int a_end)
        {
            /*
            int currentIndex = 0;
            int selectionEnd = a_end;
            string str = a_richTextBox.Text;

            // Colour literal strings
            bool lookingForEndOfString = false;
            int stringStartIndx = 0;

            while (currentIndex < selectionEnd)
            {
                if (str[currentIndex] != '"')
                {
                    currentIndex++;
                    continue;
                }

                if (str[currentIndex] == '"' && !lookingForEndOfString) // If you detect a " char and it is the first one in the string
                {
                    lookingForEndOfString = true;
                    stringStartIndx = currentIndex;
                    currentIndex++;
                }
                else // If you detect a " char and it is the end of a literal string
                {
                    if (stringStartIndx > 0)
                    {
                        if (allLanguageThemes[activeThemeIndex].GetColourFromKeyword("__literalstring", out Color col))
                        {
                            a_richTextBox.SelectionStart = stringStartIndx;
                            a_richTextBox.SelectionLength = (currentIndex + 1) - stringStartIndx;
                            a_richTextBox.SelectionColor = col;
                            a_richTextBox.SelectionLength = 0;
                            a_richTextBox.SelectionColor = Color.Black;
                        }
                    }

                    currentIndex++;
                    stringStartIndx = -1;
                    lookingForEndOfString = false;
                }
            }
            */
        }

        private static void ColourComments(LanguageTheme a_theme, ref CustomRichTextBox a_richTextBox, int a_start, int a_end)
        {
            /*
            int currentIndex = a_start;
            int selectionEnd = a_end;
            int stringStartIndex = -1;
            bool lookingForNextSlash = false;
            bool foundDoubleSlash = false;
            string str = a_richTextBox.Text;

            while (currentIndex < selectionEnd)
            {
                // If you have found the first \
                if (str[currentIndex] == '/' && !lookingForNextSlash)
                {
                    lookingForNextSlash = true;
                    foundDoubleSlash = false;
                    currentIndex++;
                    continue;
                }

                // If you have found the second \
                if (str[currentIndex] == '/' && lookingForNextSlash)
                {
                    lookingForNextSlash = false;
                    foundDoubleSlash = true;
                    stringStartIndex = currentIndex - 1;
                    currentIndex++;
                    continue;
                }

                if ((str[currentIndex] == '\n' || str[currentIndex] == '\r') && foundDoubleSlash)
                {
                    if (stringStartIndex > 0)
                    {
                        if (allLanguageThemes[activeThemeIndex].GetColourFromKeyword("__comment", out Color col))
                        {
                            a_richTextBox.SelectionStart = stringStartIndex - 1;
                            a_richTextBox.SelectionLength = (currentIndex + 1) - stringStartIndex;
                            a_richTextBox.SelectionColor = col;
                            a_richTextBox.SelectionLength = 0;
                            a_richTextBox.SelectionColor = Color.Black;
                        }
                    }

                    foundDoubleSlash = false;
                    stringStartIndex = -1;
                    currentIndex++;
                    continue;
                }

                currentIndex++;
            }*/
        }

        private static void ColourSingleKeyword(SingleKeywordDesign aKeyword, ref CustomRichTextBox aRichTextBox, int aStart, int aEnd) {
            string lastWord = "";
            char nextChar = 'A';
            int startingCharIndex = aStart, currentCharIndex = aStart;

            Console.WriteLine("Looking for keyword: " + aKeyword.Keyword);

            while (currentCharIndex < aEnd) {
                //Console.WriteLine("Next character: " + aRichTextBox.Text[currentCharIndex] + ", valid: " + IsACharacterOrNumber(aRichTextBox.Text[currentCharIndex]));

                // If the word has finished (found a space)
                if (!IsACharacterOrNumber(aRichTextBox.Text[currentCharIndex])) {

                    // Set selection
                    if (lastWord != "") {
                        //Console.WriteLine("Found a word: [" + lastWord + "]");

                        int startingPosition = currentCharIndex - (lastWord.Length + 1);

                        if (startingPosition > 0) {
                            if (lastWord == aKeyword.Keyword) {
                                aRichTextBox.SelectionStart = currentCharIndex - (lastWord.Length + 1);
                                aRichTextBox.SelectionLength = lastWord.Length + 1;
                                aRichTextBox.SelectionColor = aKeyword.Colour;
                                aRichTextBox.SelectionLength = 0;
                                aRichTextBox.SelectionColor = Color.Black;

                                //Console.WriteLine("Set colour");
                            }

                            lastWord = "";
                        }
                    }

                    currentCharIndex++;
                    continue;
                }

                lastWord += aRichTextBox.Text[currentCharIndex];
                currentCharIndex++;
            }
            
        }

        private static bool IsACharacterOrNumber(char aChar) {
            if (aChar >= 48 && aChar <= 57)
                return true;

            if (aChar >= 65 && aChar <= 90)
                return true;

            if (aChar >= 97 && aChar <= 122)
                return true;

            return false;
        }

        public static string[] GetLanguageThemeTitles()
        {
            
            string[] titleArray = new string[sAllLanguageThemes.Count];
            return titleArray;
        }
    }
}
