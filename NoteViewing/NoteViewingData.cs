using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using ProjectMemo.ProjectMemoConsole;
using ProjectMemo.CustomControls;

namespace ProjectMemo.NoteViewing
{
    public class NoteViewingData
    {
        public struct NoteData
        {
            public string semester;
            public string course;
            public DateTime date;
            public string classType;
            public string fileName;
            public string noteData;
            public string fullPath;

            public static RichTextBox RTB_LOADER;

            public NoteData(string a_fullPath)
            {
                if (RTB_LOADER == null)
                {
                    RTB_LOADER = new RichTextBox();
                    RTB_LOADER.Visible = false;
                }

                string[] splitFileName = a_fullPath.Split('\\');
                fileName = splitFileName[splitFileName.Length - 1];
                semester = "\\" + splitFileName[splitFileName.Length - 4];
                course = splitFileName[splitFileName.Length - 3];

                RTB_LOADER.LoadFile(a_fullPath);
                noteData = RTB_LOADER.Text;

                fullPath = a_fullPath;

                string[] classTypeSplit = splitFileName[splitFileName.Length - 1].Split('_');
                classType = classTypeSplit[1].Split('.')[0];

                string[] dateStrSplit = classTypeSplit[0].Split('-');
                date = new DateTime(Convert.ToInt32(dateStrSplit[0]), Convert.ToInt32(dateStrSplit[1]), Convert.ToInt32(dateStrSplit[2]));
            }
        }

        public struct ResultNote
        {
            public string mMatchingString;
            public NoteData mNote;

            public ResultNote(string a_match, NoteData a_note)
            {
                mMatchingString = a_match;
                mNote = a_note;
            }
        }

        private List<NoteData> allNotes = new List<NoteData>();

        public NoteViewingData(string a_mainDir)
        {
            string[] semesterFolders = Directory.GetDirectories(a_mainDir);

            foreach (string sem in semesterFolders)
            {
                string semesterName = sem.Replace(a_mainDir, "");

                if (semesterName == "\\18_s1" || semesterName == "\\18_s2")
                    continue;

                // Check to see if the folder is a valid semester folder
                if (sem.EndsWith("_s2") || sem.EndsWith("_s1"))
                {
                    string[] courseFolders = Directory.GetDirectories(sem);

                    foreach (string course in courseFolders)
                    {
                        string[] allFiles = Directory.GetFiles(course + "\\Notes");

                        int fileNum = 0;
                        foreach (string file in allFiles)
                        {
                            if (file.EndsWith(".rtf"))
                            {
                                NoteData newNote = new NoteData(file);
                                allNotes.Add(newNote);
                                fileNum++;
                            }
                        }

                        CustomConsole.Log("Loaded " + fileNum + " notes for course " + course.Replace(a_mainDir, "") + " into a new instance of NoteViewingData");
                    }
                }
            }
        }

        public void DisplayResults(ref FlowLayoutPanel a_layoutPanel, string a_sem, string a_course, DateTime a_fromDate, DateTime a_toDate, bool a_filterByDate, string a_classType, string a_term, bool a_caseSensitive)
        {
            List<NoteData> finalResultsList = new List<NoteData>(allNotes);
            List<NoteData> finalResultTemp = new List<NoteData>(finalResultsList);
            Dictionary<int, ResultNote> finalResults = new Dictionary<int, ResultNote>();

            //Console.WriteLine(finalResultsList.Count);

            // Filter out the notes from invalid semesters
            foreach (NoteData note in finalResultsList)
            {
                //Console.WriteLine(note.semester);
                if (note.semester != a_sem)
                {
                    //Console.WriteLine("{0} != {1}", note.semester, a_sem);
                    finalResultTemp.Remove(note);
                }
            }

            finalResultsList = new List<NoteData>(finalResultTemp);
            //Console.WriteLine(finalResultsList.Count);

            // Filter out the notes from the wrong course
            foreach (NoteData note in finalResultsList)
            {
                //Console.WriteLine("[{0}], [{1}]", note.course, a_course);
                if (a_course == "All")
                    break;

                if (note.course != a_course)
                {
                    //Console.WriteLine("{0} != {1}", note.course, a_course);
                    finalResultTemp.Remove(note);
                }
            }

            finalResultsList = new List<NoteData>(finalResultTemp);
            //Console.WriteLine(finalResultsList.Count);

            // Filter out the notes that are outside of the time period
            foreach (NoteData note in finalResultsList)
            {
                //Console.WriteLine("{0}, {1}, {2}, {3}", note.date, a_fromDate, a_toDate, a_filterByDate);
                if (!a_filterByDate)
                    break;

                if (note.date < a_fromDate || note.date > a_toDate)
                {
                    //Console.WriteLine("{0} < {1} || {2} > {3}", note.date, a_fromDate, note.date, a_toDate);
                    finalResultTemp.Remove(note);
                }
            }

            finalResultsList = new List<NoteData>(finalResultTemp);
            //Console.WriteLine(finalResultsList.Count);

            // Filter out the notes that aren't the correct classType
            foreach (NoteData note in finalResultsList)
            {
                //Console.WriteLine("{0}, {1}", note.classType, a_classType);
                if (a_classType == "All")
                    break;

                if (note.classType != a_classType)
                {
                    //Console.WriteLine("{0} != {1}", note.classType, a_classType);
                    finalResultTemp.Remove(note);
                }
            }

            finalResultsList = new List<NoteData>(finalResultTemp);
            //Console.WriteLine(finalResultsList.Count);

            // Look for search term
            foreach (NoteData note in finalResultsList)
            {
                //Console.WriteLine("[{0}]", a_term);
                if (string.IsNullOrEmpty(a_term))
                {
                    //finalResults.Add("NULL_" + finalResults.Count, note);
                    finalResults.Add(finalResults.Count, new ResultNote("", note));
                    continue;
                }

                // Look for term with respect to capital letters
                if (a_caseSensitive)
                {
                    string noteDataWithCapitals = note.noteData;

                    if (noteDataWithCapitals.Contains(a_term))
                    {
                        // We need to get the word before and after the matched term
                        GetTheLastAndNextWordFromString(noteDataWithCapitals, a_term, out string lastWord, out string nextWord);

                        //finalResults.Add(string.Format("{0} {1} {2}", lastWord, a_term, nextWord), note);

                        finalResults.Add(finalResults.Count, new ResultNote(string.Format("{0} {1} {2}", lastWord, a_term, nextWord), note));
                    }
                }
                else // Convert note data and term into lower case (ignore case type)
                {
                    string noteDataWithNoCapitals = note.noteData.ToLower();

                    if (noteDataWithNoCapitals.Contains(a_term.ToLower()))
                    {
                        // We need to get the word before and after the matched term
                        GetTheLastAndNextWordFromString(noteDataWithNoCapitals, a_term.ToLower(), out string lastWord, out string nextWord);

                        finalResults.Add(finalResults.Count, new ResultNote(string.Format("{0} {1} {2}", lastWord, a_term, nextWord), note));
                    }
                }
            }

            // Remove all the children controls of the layoutpanel
            a_layoutPanel.Controls.Clear();

            // Add each matched result to the layoutpanel
            foreach (KeyValuePair<int, ResultNote> pair in finalResults)
            {
                ViewingSearchResult newResult = new ViewingSearchResult(pair.Value.mNote, pair.Value.mMatchingString);
                a_layoutPanel.Controls.Add(newResult);
                newResult.Width = a_layoutPanel.Width - newResult.Location.X - SystemInformation.VerticalScrollBarWidth - 2;
            }
        }

        public void GetTheLastAndNextWordFromString(string a_strToFindFrom, string a_middleWord, out string a_lastWord, out string a_nextWord)
        {
            // Cycle back throught the string to find the last space
            int spaces = 0;
            string lastWord = "";
            string nextWord = "";
            int indexOfFind = a_strToFindFrom.IndexOf(a_middleWord);

            for (int i = indexOfFind - 1; i > 0; i--)
            {
                if (spaces == 2)
                    break;

                if (a_strToFindFrom[i] == ' ')
                {
                    spaces++;
                    continue;
                }

                lastWord = lastWord.Insert(0, a_strToFindFrom[i].ToString());
            }

            //lastWord.Reverse();
            //Console.WriteLine("Found Last Word: " + lastWord);
            a_lastWord = lastWord;

            spaces = 0;

            for (int i = (indexOfFind + a_middleWord.Length); i < a_strToFindFrom.Length; i++)
            {
                if (spaces == 2)
                    break;

                if (a_strToFindFrom[i] == ' ')
                {
                    spaces++;
                    continue;
                }

                nextWord += a_strToFindFrom[i];
            }

            //Console.WriteLine("Found next word: " + nextWord);
            a_nextWord = nextWord;
        }
    }
}
