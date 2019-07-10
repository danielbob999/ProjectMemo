using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProjectMemo.Formatting
{
    public struct CodeBlockTheme
    {
        private Color mColour;
        private string mStartingString;
        private string mEndingString;

        public string Startingstringacter
        {
            get { return mStartingString; }
        }

        public string Endingstringacter
        {
            get { return mEndingString; }
        }

        public Color Colour
        {
            get { return mColour; }
        }

        public CodeBlockTheme(string aStart, string aEnd, Color aColour) {
            mColour = aColour;
            mStartingString = aStart;
            mEndingString = aEnd;
        }
    }
}
