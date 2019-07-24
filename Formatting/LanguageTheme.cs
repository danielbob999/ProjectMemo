using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProjectMemo.Formatting
{
    [Serializable]
    public class LanguageTheme
    {
        private string mName;
        private int mColourCount = 0;
        private List<SingleKeywordDesign> mKeywords = new List<SingleKeywordDesign>();
        private List<MultiwordDesign> mMultiwordDesigns = new List<MultiwordDesign>();

        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        public int ColourCount
        {
            get { return mColourCount; }
        }

        public List<SingleKeywordDesign> Keywords
        {
            get { return mKeywords; }
        }

        public List<MultiwordDesign> MultiWordDesigns
        {
            get { return mMultiwordDesigns; }
        }

        public LanguageTheme(string aName){
            mName = aName;
        }

        public void AddKeyword(string aWord, Color aCol) {
            int indx = -1;

            for (int i = 0; i < mKeywords.Count; i++) {
                if (mKeywords[i].Keyword == aWord) {
                    indx = i;
                }
            }

            if (indx == -1) {
                mKeywords.Add(new SingleKeywordDesign(aWord, aCol));
            }
        }

        public void SetKeywordColour(string aWord, Color aCol) {
            for (int i = 0; i < mKeywords.Count; i++) {
                if (mKeywords[i].Keyword == aWord) {
                    mKeywords[i].Colour = aCol;
                }
            }
        }

        public void RemoveKeyword(string aWord) {
            int indx = -1;

            for (int i = 0; i < mKeywords.Count; i++) {
                if (mKeywords[i].Keyword == aWord) {
                    indx = i;
                }
            }

            if (indx != -1) {
                mKeywords.RemoveAt(indx);
            }
        }

        public void AddMultiword(string aName, string aStart, string aEnd, Color aCol) {
            int indx = -1;

            for (int i = 0; i < mMultiwordDesigns.Count; i++) {
                if (mMultiwordDesigns[i].Name == aName) {
                    indx = i;
                }
            }

            if (indx == -1) {
                mMultiwordDesigns.Add(new MultiwordDesign(aName, aStart, aEnd, aCol));
            }
        }

        public void RemoveMultiword(string aName) {
            int indx = -1;

            for (int i = 0; i < mMultiwordDesigns.Count; i++) {
                if (mMultiwordDesigns[i].Name == aName) {
                    indx = i;
                }
            }

            if (indx != -1) {
                mMultiwordDesigns.RemoveAt(indx);
            }
        }

        public void SetMultwordColor(string aName, Color aCol) {
            for (int i = 0; i < mMultiwordDesigns.Count; i++) {
                if (mMultiwordDesigns[i].Name == aName) {
                    mMultiwordDesigns[i].Colour = aCol;
                }
            }
        }

        public void Save(string aPath) {
            
            BinaryFormatter formatter = new BinaryFormatter();

            try {
                if (File.Exists(aPath))
                    File.Delete(aPath);

                FileStream fs = File.Create(aPath);

                formatter.Serialize(fs, this);

                fs.Close();

                ProjectMemoConsole.CustomConsole.Log("Successfully saved LanguageTheme with Name: " + mName + " to: " + aPath);
                return;
            } catch (Exception e) {
                ProjectMemoConsole.CustomConsole.Log("Failed to save LangaugeTheme to: " + aPath);
                ProjectMemoConsole.CustomConsole.Log("Error: " + e.Message);
            }
        }

        public override string ToString() {
            return mName;
        }
    }

    [Serializable]
    public class SingleKeywordDesign
    {
        private string mKeyword;
        private Color mColour;

        public string Keyword
        {
            get { return mKeyword; }
            set { mKeyword = value; }
        }

        public Color Colour
        {
            get { return mColour; }
            set { mColour = value; }
        }

        public SingleKeywordDesign(string aWord, Color aCol) {
            mKeyword = aWord;
            mColour = aCol;
        }
    }

    [Serializable]
    public class MultiwordDesign
    {
        private string mName;
        private string mStartStr;
        private string mEndStr;
        private Color mColour;

        public string Name
        {
            get { return mName; }
        }

        public String StartString
        {
            get { return mStartStr; }
        }

        public String EndString
        {
            get { return mEndStr; }
        }

        public Color Colour
        {
            get { return mColour; }
            set { mColour = value; }
        }

        public MultiwordDesign(string aName, string aStart, string aEnd, Color aCol) {
            mName = aName;
            mStartStr = aStart;
            mEndStr = aEnd;
            mColour = aCol;
        }
    }
}
