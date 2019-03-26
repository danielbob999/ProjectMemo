using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using ProjectMemo.ProjectMemoConsole;

namespace ProjectMemo
{
    static class MainContent
    {
        public static Dictionary<string, string[]> codeFragments = new Dictionary<string, string[]>();
        public static int nextId = 0;
        public static SaveData saveData;

        // New Stuff
        private static Dictionary<string, Font> fontStyles = new Dictionary<string, Font>();
        private static float DefaultFontSize;

        // New Function
        public static void InitFontStyles(float _defaultFontSize)
        {
            DefaultFontSize = _defaultFontSize;

            // Headings
            fontStyles.Add("Heading 1", new Font("Microsoft Sans Serif", 20.0f, FontStyle.Bold));
            fontStyles.Add("Heading 2", new Font("Microsoft Sans Serif", 16.0f, FontStyle.Bold));
            fontStyles.Add("Heading 3", new Font("Microsoft Sans Serif", 13.0f, FontStyle.Bold));

            fontStyles.Add("Code Fragment", new Font("Consolas", DefaultFontSize - 1.0f, FontStyle.Regular));
            fontStyles.Add("Note", new Font("Comic Sans MS", DefaultFontSize + 1.0f, FontStyle.Regular));
        }

        public static List<string> GetFontStyleList()
        {
            List<string> list = new List<string>();

            foreach (KeyValuePair<string, Font> pair in fontStyles)
            {
                list.Add(pair.Key);
            }

            return list;
        }

        public static bool GetFontFromStyleString(string _styleStr, out Font _font)
        {
            if (fontStyles.ContainsKey(_styleStr))
            {
                _font = fontStyles[_styleStr];
                return true;
            }

            _font = new Font("Microsoft Sans Serif", DefaultFontSize, FontStyle.Regular);
            return false;
        }

        public static bool DoesFontExist(Font _compareFont, out Font _outFont)
        {
            foreach (KeyValuePair<string, Font> pair in fontStyles)
            {
                if (_compareFont == pair.Value)
                {
                    _outFont = pair.Value;
                    return true;
                }
            }

            _outFont = new Font("Microsoft Sans Serif", DefaultFontSize, FontStyle.Regular);
            return false;
        }

        public static void AddCodeFragment(string _key, string[] _content)
        {
            if (codeFragments.ContainsKey(_key))
            {
                CustomConsole.Log("There is already a code fragment with the key '" + _key + "'");
                return;
            }

            codeFragments.Add(_key, _content);
            nextId++;
        }

        public static string[] GetCodeFragment(string _key)
        {
            if (codeFragments.ContainsKey(_key))
            {
                return codeFragments[_key];
            }

            return null;
        }

        public static void EditCodeFragment(string _key, string[] _content)
        {
            if (codeFragments.ContainsKey(_key))
            {
                codeFragments[_key] = _content;
            }
            else
            {
                AddCodeFragment(_key, _content);
            }
        }

        public static string[] GetNoteTextFromFile(string _path)
        {
            string[] rawLines = File.ReadAllLines(_path);
            List<string> properStrList = new List<string>();

            foreach (string str in rawLines)
            {
                //int bodyStart = ;
            }

            return properStrList.ToArray();
        }

        public static string[] GetCodeFragmentsFromFile(string _path)
        {
            return new string[] { };
        }

        private static bool ShouldLineBeExculded(string _ln)
        {
            
            List<string> naughties = new List<string>();/*
            naughties.Add("<html>");
            naughties.Add("</html>");
            naughties.Add("<head>");
            naughties.Add("</head>");
            naughties.Add("<body>");
            naughties.Add("</body>");
            naughties.Add("<html>");
            naughties.Add("<html>");
            naughties.Add("<html>");
            naughties.Add("<html>");
            */
            foreach (string str in naughties)
            {
                if (_ln == str)
                {
                    return true;
                }
            }

            return false;

        }
    }

    public struct SaveData
    {
        public string noteText;
        public Dictionary<string, string[]> codeFrags;

        public SaveData(string _n, Dictionary<string, string[]> _c)
        {
            noteText = _n;
            codeFrags = _c;
        }

        public bool DoesCurrentDataMatch(string _t, Dictionary<string, string[]> _c)
        {
            if (_t != noteText)
            {
                return false;
            }

            if (_c.Count != codeFrags.Count)
            {
                return false;
            }

            /*
            foreach (KeyValuePair<string, string[]> pair in _c)
            {
                if (codeFrags.ContainsKey(pair.Key))
                {
                    if (codeFrags[pair.Key] != pair.Value)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }*/

            return true;
        }
    }
    
    public enum LanguageType
    {
        C,
        CS,
        CPP,
        Java
    }
}
