using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProjectMemo.Formatting
{
    public class LanguageTheme
    {
        private string mName;
        private Dictionary<string, Color> keywordColours = new Dictionary<string, Color>();
        private List<string> classNames = new List<string>();

        public LanguageTheme(string a_name)
        {
            mName = a_name;
        }

        public void AddKeywordColour(string a_word, Color a_colour)
        {
            if (!keywordColours.ContainsKey(a_word))
            {
                keywordColours.Add(a_word, a_colour);
                return;
            }

            ProjectMemo.ProjectMemoConsole.CustomConsole.Log("Failed to add new keyword colour to LanguageTheme: " + mName + ". Keyword already exists");
        }

        public void AddClass(string a_class)
        {
            if (!classNames.Contains(a_class))
            {
                classNames.Add(a_class);
                return;
            }

            ProjectMemo.ProjectMemoConsole.CustomConsole.Log("Failed to add class name to LanguageTheme: " + mName + ". The class name already exists");
        }

        public bool GetColourFromKeyword(string a_keyword, out Color a_out_colour)
        {
            if (classNames.Contains(a_keyword))
            {
                a_out_colour = keywordColours["__classname"];
                return true;
            }

            if (keywordColours.ContainsKey(a_keyword))
            {
                a_out_colour = keywordColours[a_keyword];
                return true;
            }

            a_out_colour = Color.Black;
            return false;
        }

        public string GetName()
        {
            return mName;
        }

    }
}
