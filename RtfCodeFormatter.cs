using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using ProjectMemo.CustomControls;

namespace ProjectMemo
{
    static class RtfCodeFormatter
    {
        private static Dictionary<string, Color> keywordColours = new Dictionary<string, Color>();
        private static List<string> classNames = new List<string>();

        public static void InitKeywordColours(string a_filePath)
        {
            //keywordColours.Add("int", Color.Blue);
            //keywordColours.Add("string", Color.Red);
            
            int amount = 0;

            string[] allLines;

            try
            {
                allLines = File.ReadAllLines(a_filePath);
            }
            catch (Exception e)
            {
                CustomConsole.Log("Failed to read in all lines from file '" + a_filePath.Replace(Directory.GetCurrentDirectory(), "") + "'");
                CustomConsole.Log(e.Message);
                return;
            }

            for (int i = 1; i < allLines.Length; i++)
            {
                string line = allLines[i];
                string[] lineSplit = line.Split('=');

                if (lineSplit.Length < 2)
                {
                    CustomConsole.Log("Failed to load keyword colours. '" + a_filePath.Replace(Directory.GetCurrentDirectory(), "") + "' is empty.");
                    continue;
                }

                Color c = Color.Black;

                if (GetColourFromString(lineSplit[1], out c))
                {
                    keywordColours.Add(lineSplit[0], c);
                    amount++;
                }
            }

            CustomConsole.Log("Successfully loaded " + amount + " keyword colours from file '" + a_filePath.Replace(Directory.GetCurrentDirectory(), "") + "'");
        }

        public static void PrintKeyworldColours(ref TextBox a_textBox)
        {
            CustomConsole.Log("Keyword Colours:", true);
            foreach (KeyValuePair<string, Color> pair in keywordColours)
            {
                CustomConsole.Log(string.Format("Keyword: {0}, Colour: {1}\n", pair.Key, pair.Value.ToString()), true);
            }
        }

        public static void UpdateKeywordColour(string a_keyword, Color a_newColour)
        {
            if (keywordColours.ContainsKey(a_keyword))
            {
                keywordColours[a_keyword] = a_newColour;
                return;
            }

            keywordColours.Add(a_keyword, a_newColour);
        }

        public static bool GetKeywordColour(string a_str, out Color a_outColour)
        {
            if (keywordColours.ContainsKey(a_str))
            {
                a_outColour = keywordColours[a_str];
                return true;
            }

            a_outColour = Color.Black;
            return false;
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

            while (currentIndex < selectionEnd)
            {
                int tempIndx = 0;
                string newString = "";

                while (str[currentIndex + tempIndx] != ' ' && str[currentIndex + tempIndx] != '\n' && str[currentIndex + tempIndx] != '\t' && str[currentIndex + tempIndx] != '{' && str[currentIndex + tempIndx] != '}' && str[currentIndex + tempIndx] != '"')
                {
                    newString += str[currentIndex + tempIndx];
                    tempIndx++;

                    if (currentIndex + tempIndx >= str.Length)
                        break;
                    else
                        continue;
                }

                if (stringIsLiteralString)
                {
                    Color newC;

                    if (GetKeywordColour("literalstring", out newC))
                    {
                        a_richTextBox.SelectionStart = currentIndex;
                        a_richTextBox.SelectionLength = newString.Length;
                        a_richTextBox.SelectionColor = newC;
                        a_richTextBox.SelectionLength = 0;
                        a_richTextBox.SelectionColor = Color.Black;
                    }

                    currentIndex += (tempIndx + 1);
                    //Console.WriteLine("Literal string ends at: " + currentIndex + tempIndx);
                    continue;
                }

                //Console.WriteLine("Found keyword: [" + newString + "]");

                if (nextWordIsClassName)
                {
                    classNames.Add(newString);
                    //Console.WriteLine("Found new class name: [{0}]", newString);
                    nextWordIsClassName = false;

                    Color newC;

                    if (GetKeywordColour("classname", out newC))
                    {
                        a_richTextBox.SelectionStart = currentIndex;
                        a_richTextBox.SelectionLength = newString.Length;
                        a_richTextBox.SelectionColor = newC;
                        a_richTextBox.SelectionLength = 0;
                        a_richTextBox.SelectionColor = Color.Black;
                    }

                    currentIndex += (tempIndx + 1);
                    continue;
                }

                if (classNames.Contains(newString))
                {
                    Color newC;

                    if (GetKeywordColour("classname", out newC))
                    {
                        a_richTextBox.SelectionStart = currentIndex;
                        a_richTextBox.SelectionLength = newString.Length;
                        a_richTextBox.SelectionColor = newC;
                        a_richTextBox.SelectionLength = 0;
                        a_richTextBox.SelectionColor = Color.Black;
                    }

                    currentIndex += (tempIndx + 1);
                    continue;
                }

                if (newString == "class")
                    nextWordIsClassName = true;

                Color newColour;

                if (GetKeywordColour(newString, out newColour))
                {
                    a_richTextBox.SelectionStart = currentIndex;
                    a_richTextBox.SelectionLength = newString.Length;
                    a_richTextBox.SelectionColor = newColour;
                    a_richTextBox.SelectionLength = 0;
                    a_richTextBox.SelectionColor = Color.Black;
                }

                currentIndex += (tempIndx + 1);
            }

        }

        private static bool GetColourFromString(string a_str, out Color a_out_colour)
        {
            if (a_str == "blue")
            {
                a_out_colour = Color.FromArgb(1, 36, 28, 254);
                return true;
            }

            if (a_str == "green")
            {
                a_out_colour = Color.Green;
                return true;
            }

            if (a_str == "lightgreen")
            {
                a_out_colour = Color.LightGreen;
                return true;
            }

            if (a_str == "brown")
            {
                a_out_colour = Color.Brown;
                return true;
            }

            CustomConsole.Log("'" + a_str + "' is an invalid colour");
            a_out_colour = Color.Black;
            return false;
        }
    }
}
