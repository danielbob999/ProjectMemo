using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ProjectMemo.Formatting;

namespace ProjectMemo.Forms
{
    public partial class LanguageThemeCreatorForm : Form
    {
        private List<LanguageTheme> mLoadedThemes = new List<LanguageTheme>();
        private LanguageTheme mSelectedTheme;

        public LanguageThemeCreatorForm() {
            mLoadedThemes.Clear();
            mLoadedThemes.AddRange(RtfCodeFormatter.LoadedLanguageThemes);

            InitializeComponent();
        }

        public void OnFormLoad(object sender, EventArgs e) {
            singleKeywordListBox.DrawMode = DrawMode.OwnerDrawFixed;
            multiwordListBox.DrawMode = DrawMode.OwnerDrawFixed;

            RefreshThemeListBox();
        }

        public void OnThemeListIndexChanged(object sender, EventArgs e) {
            ListBox thisBox = sender as ListBox;

            if (thisBox.SelectedItem != null) {
                mSelectedTheme = (LanguageTheme)thisBox.SelectedItem;
                themeNameInput.Text = mSelectedTheme.Name;
            }

            RefreshSingleKeywordListBox();
            RefreshMultiwordListBox();
        }

        public void OnSingleKeywordListBoxDrawItem(object sender, DrawItemEventArgs e) {
            e.DrawBackground();

            string renderString = ((SingleKeywordDesign)(((ListBox)sender).Items[e.Index])).Keyword;
            e.Graphics.DrawString(renderString, e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);

            int leftover = e.Bounds.Height - 10;
            e.Graphics.FillRectangle(new SolidBrush(((SingleKeywordDesign)(((ListBox)sender).Items[e.Index])).Colour), new Rectangle(e.Bounds.Location.X + (e.Bounds.Width - 35), e.Bounds.Location.Y + (leftover / 2), 30, 10));
            e.Graphics.DrawRectangle(new Pen(Brushes.Black), new Rectangle(e.Bounds.Location.X + (e.Bounds.Width - 35), e.Bounds.Location.Y + (leftover / 2), 30, 10));

            e.DrawFocusRectangle();
        }

        public void OnMultiwordListBoxDrawItem(object sender, DrawItemEventArgs e) {
            e.DrawBackground();

            string renderString = ((MultiwordDesign)(((ListBox)sender).Items[e.Index])).Name + "    " + ((MultiwordDesign)(((ListBox)sender).Items[e.Index])).StartString + "    " + ((MultiwordDesign)(((ListBox)sender).Items[e.Index])).EndString;
            e.Graphics.DrawString(renderString, e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);

            int leftover = e.Bounds.Height - 10;
            e.Graphics.FillRectangle(new SolidBrush(((MultiwordDesign)(((ListBox)sender).Items[e.Index])).Colour), new Rectangle(e.Bounds.Location.X + (e.Bounds.Width - 35), e.Bounds.Location.Y + (leftover / 2), 30, 10));
            e.Graphics.DrawRectangle(new Pen(Brushes.Black), new Rectangle(e.Bounds.Location.X + (e.Bounds.Width - 35), e.Bounds.Location.Y + (leftover / 2), 30, 10));

            e.DrawFocusRectangle();
        }

        public void OnAddSingleKeywordButtonPressed(object sender, EventArgs e) {
            mSelectedTheme.AddKeyword(newKeywordInput.Text, Color.Black);
            newKeywordInput.Text = "";

            RefreshSingleKeywordListBox();
        }

        public void OnChangeSingleKeywordColourButtonPressed(object sender, EventArgs e) {
            ListBox thisBox = singleKeywordListBox;
            ColorDialog cdiag = new ColorDialog();
            cdiag.AllowFullOpen = true;
            cdiag.Color = ((SingleKeywordDesign)thisBox.SelectedItem).Colour;
            DialogResult result = cdiag.ShowDialog();

            if (result == DialogResult.OK) {
                ((SingleKeywordDesign)thisBox.SelectedItem).Colour = cdiag.Color;
            }

            RefreshSingleKeywordListBox();
        }

        public void OnDeleteSingleKeywordButtonPressed(object sender, EventArgs e) {
            ListBox thisBox = singleKeywordListBox;
            mSelectedTheme.RemoveKeyword(((SingleKeywordDesign)thisBox.SelectedItem).Keyword);

            RefreshSingleKeywordListBox();
        }

        public void OnNewMultiwordButtonPressed(object sender, EventArgs e) {
            ListBox thisBox = singleKeywordListBox;
            mSelectedTheme.AddMultiword(multiwordNameInput.Text, multiwordStartInput.Text, multiwordEndInput.Text, Color.Black);

            RefreshMultiwordListBox();
        }

        public void OnDeleteMultiwordButtonPressed(object sender, EventArgs e) {
            ListBox thisBox = multiwordListBox;
            mSelectedTheme.RemoveMultiword(((MultiwordDesign)thisBox.SelectedItem).Name);

            RefreshMultiwordListBox();
        }

        public void OnChangeMultiwordColourButtonPressed(object sender, EventArgs e) {
            ListBox thisBox = multiwordListBox;
            ColorDialog cdiag = new ColorDialog();
            cdiag.AllowFullOpen = true;
            cdiag.Color = ((MultiwordDesign)thisBox.SelectedItem).Colour;
            DialogResult result = cdiag.ShowDialog();

            if (result == DialogResult.OK) {
                ((MultiwordDesign)thisBox.SelectedItem).Colour = cdiag.Color;
            }

            RefreshMultiwordListBox();
        }

        public void OnThemeNameInputKeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Return) {
                ((LanguageTheme)themeListBox.SelectedItem).Name = themeNameInput.Text;
                RefreshThemeListBox();
            }
        }

        public void OnNewThemeButtonPressed(object sender, EventArgs e) {
            mLoadedThemes.Add(new LanguageTheme("NewTheme"));
            RefreshThemeListBox();
        }

        public void OnSaveThemeButtonPressed(object sender, EventArgs e) {
            if (mSelectedTheme != null) {
                try {
                    mSelectedTheme.Save(System.IO.Directory.GetCurrentDirectory() + "\\language_themes\\" + mSelectedTheme.Name + ".lgt");
                    themeSaveStatusLabel.Text = "Successfully saved theme: " + mSelectedTheme.Name;
                } catch (Exception ex) {

                }

            }

            RtfCodeFormatter.LoadLanguageThemes();
            mLoadedThemes.Clear();
            mLoadedThemes.AddRange(RtfCodeFormatter.LoadedLanguageThemes);
            RefreshThemeListBox();
        }

        public void OnDeleteThemeButtonPressed(object sender, EventArgs e) {
            mLoadedThemes.Remove(mSelectedTheme);
            RefreshThemeListBox();
        }

        public void OnFormClose(object sender, FormClosingEventArgs e) {

        }

        private void RefreshSingleKeywordListBox() {
            singleKeywordListBox.Items.Clear();
            if (mSelectedTheme != null) {
                singleKeywordListBox.Items.AddRange(mSelectedTheme.Keywords.ToArray());
                singleKeywordGroupbox.Text = "Single Keyword Colours (" + mSelectedTheme.Keywords.Count + ")";
            } else {
                singleKeywordGroupbox.Text = "Single Keyword Colours";
            }
        }

        private void RefreshMultiwordListBox() {
            multiwordListBox.Items.Clear();

            if (mSelectedTheme != null) {
                multiwordListBox.Items.AddRange(mSelectedTheme.MultiWordDesigns.ToArray());
                multiWordGroupBox.Text = "Multi-word Colours (" + mSelectedTheme.MultiWordDesigns.Count + ")";
            } else {
                multiWordGroupBox.Text = "Multi-word Colours";
            }
        }

        private void RefreshThemeListBox() {
            themeListBox.Items.Clear();
            themeListBox.Items.AddRange(mLoadedThemes.ToArray());
        }
    }
}
