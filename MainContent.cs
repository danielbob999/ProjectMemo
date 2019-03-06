using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UniversityNoteProgram
{
    static class MainContent
    {
        public static Dictionary<string, string[]> codeFragments = new Dictionary<string, string[]>();
        public static int nextId = 0;
        public static SaveData saveData;

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

            if (codeFrags != _c)
            {
                return false;
            }

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
