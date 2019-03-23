using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityNoteProgram.CustomControls;

namespace UniversityNoteProgram
{
    static class Interpreter
    {
        enum HtmlTag
        {
            Heading_1,
            Heading_2,
            Heading_3,
            CodeFragment,
            Note,
            Bold,
            Italic,
            Underline,
            Strikeout
        }

        private static string GetHeaderHtmlCode()
        {
            string returnString = "" +
                "<html>" +
                "<header>" +
                "</header>" +
                "<body>" +
                "<div id='main-content>'";

            return returnString;
        }

        private static string GetFooterHtmlCode()
        {
            string returnString = "" +
                "</div>" +
                "</body>" +
                "</html>";

            return returnString;
        }

        private static string EndTag(HtmlTag _tag)
        {
            return "";
            if (_tag == HtmlTag.Bold)
                return "</b>";

            if (_tag == HtmlTag.CodeFragment)
                return "</code></div>";

            //if (_tag == HtmlTag.)
        }

        public static string FromRtfToHtmlString(ref CustomRichTextBox _textBox)
        {
            string returnString = "";
            returnString += GetHeaderHtmlCode();

            int textLength = _textBox.Text.Length;
            int charIndex = 0;
            HtmlTag? currentTag = null;

            while ((charIndex + 1) <= textLength)
            {
                _textBox.SelectionStart = charIndex;
                _textBox.SelectionLength = 1;

                if (MainContent.DoesFontExist(_textBox.SelectionFont, out Font outFont))
                {
                    charIndex++;
                    continue;
                }

                outFont = _textBox.SelectionFont;

                if (outFont.Bold)
                {
                    currentTag = HtmlTag.Bold;
                    returnString += "<b>" + _textBox.SelectedText;
                }

                charIndex++;
            }

            returnString += GetFooterHtmlCode();
            return returnString;
        }
    }
}
