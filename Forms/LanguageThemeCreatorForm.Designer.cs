namespace ProjectMemo.Forms
{
    partial class LanguageThemeCreatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.loadedThemesGroup = new System.Windows.Forms.GroupBox();
            this.themeSaveStatusLabel = new System.Windows.Forms.Label();
            this.newThemeButton = new System.Windows.Forms.Button();
            this.saveThemeButton = new System.Windows.Forms.Button();
            this.deleteThemeButton = new System.Windows.Forms.Button();
            this.themeNameInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.detailsLabel = new System.Windows.Forms.Label();
            this.themeListBox = new System.Windows.Forms.ListBox();
            this.singleKeywordGroupbox = new System.Windows.Forms.GroupBox();
            this.newKeywordInput = new System.Windows.Forms.TextBox();
            this.addKeywordButton = new System.Windows.Forms.Button();
            this.changeKeywordColourButton = new System.Windows.Forms.Button();
            this.deleteKeywordButton = new System.Windows.Forms.Button();
            this.singleKeywordListBox = new System.Windows.Forms.ListBox();
            this.multiWordGroupBox = new System.Windows.Forms.GroupBox();
            this.multiwordListBox = new System.Windows.Forms.ListBox();
            this.addMultiwordButton = new System.Windows.Forms.Button();
            this.deleteMultiwordButton = new System.Windows.Forms.Button();
            this.changeMultiwordColourButton = new System.Windows.Forms.Button();
            this.multiwordNameInput = new System.Windows.Forms.TextBox();
            this.multiwordStartInput = new System.Windows.Forms.TextBox();
            this.multiwordEndInput = new System.Windows.Forms.TextBox();
            this.loadedThemesGroup.SuspendLayout();
            this.singleKeywordGroupbox.SuspendLayout();
            this.multiWordGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadedThemesGroup
            // 
            this.loadedThemesGroup.Controls.Add(this.themeSaveStatusLabel);
            this.loadedThemesGroup.Controls.Add(this.newThemeButton);
            this.loadedThemesGroup.Controls.Add(this.saveThemeButton);
            this.loadedThemesGroup.Controls.Add(this.deleteThemeButton);
            this.loadedThemesGroup.Controls.Add(this.themeNameInput);
            this.loadedThemesGroup.Controls.Add(this.label1);
            this.loadedThemesGroup.Controls.Add(this.detailsLabel);
            this.loadedThemesGroup.Controls.Add(this.themeListBox);
            this.loadedThemesGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadedThemesGroup.Location = new System.Drawing.Point(13, 13);
            this.loadedThemesGroup.Name = "loadedThemesGroup";
            this.loadedThemesGroup.Size = new System.Drawing.Size(664, 252);
            this.loadedThemesGroup.TabIndex = 0;
            this.loadedThemesGroup.TabStop = false;
            this.loadedThemesGroup.Text = "Loaded Themes:";
            // 
            // themeSaveStatusLabel
            // 
            this.themeSaveStatusLabel.Location = new System.Drawing.Point(368, 220);
            this.themeSaveStatusLabel.Name = "themeSaveStatusLabel";
            this.themeSaveStatusLabel.Size = new System.Drawing.Size(290, 25);
            this.themeSaveStatusLabel.TabIndex = 6;
            this.themeSaveStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // newThemeButton
            // 
            this.newThemeButton.Location = new System.Drawing.Point(555, 151);
            this.newThemeButton.Name = "newThemeButton";
            this.newThemeButton.Size = new System.Drawing.Size(103, 30);
            this.newThemeButton.TabIndex = 5;
            this.newThemeButton.Text = "New Theme";
            this.newThemeButton.UseVisualStyleBackColor = true;
            this.newThemeButton.Click += new System.EventHandler(this.OnNewThemeButtonPressed);
            // 
            // saveThemeButton
            // 
            this.saveThemeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveThemeButton.Location = new System.Drawing.Point(446, 187);
            this.saveThemeButton.Name = "saveThemeButton";
            this.saveThemeButton.Size = new System.Drawing.Size(103, 30);
            this.saveThemeButton.TabIndex = 4;
            this.saveThemeButton.Text = "Save Theme";
            this.saveThemeButton.UseVisualStyleBackColor = true;
            this.saveThemeButton.Click += new System.EventHandler(this.OnSaveThemeButtonPressed);
            // 
            // deleteThemeButton
            // 
            this.deleteThemeButton.Location = new System.Drawing.Point(555, 187);
            this.deleteThemeButton.Name = "deleteThemeButton";
            this.deleteThemeButton.Size = new System.Drawing.Size(103, 30);
            this.deleteThemeButton.TabIndex = 2;
            this.deleteThemeButton.Text = "Delete Theme";
            this.deleteThemeButton.UseVisualStyleBackColor = true;
            this.deleteThemeButton.Click += new System.EventHandler(this.OnDeleteThemeButtonPressed);
            // 
            // themeNameInput
            // 
            this.themeNameInput.Location = new System.Drawing.Point(402, 48);
            this.themeNameInput.Name = "themeNameInput";
            this.themeNameInput.Size = new System.Drawing.Size(247, 21);
            this.themeNameInput.TabIndex = 3;
            this.themeNameInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnThemeNameInputKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(343, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // detailsLabel
            // 
            this.detailsLabel.AutoSize = true;
            this.detailsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailsLabel.Location = new System.Drawing.Point(342, 21);
            this.detailsLabel.Name = "detailsLabel";
            this.detailsLabel.Size = new System.Drawing.Size(144, 20);
            this.detailsLabel.TabIndex = 1;
            this.detailsLabel.Text = "Selected Theme:";
            // 
            // themeListBox
            // 
            this.themeListBox.FormattingEnabled = true;
            this.themeListBox.ItemHeight = 15;
            this.themeListBox.Location = new System.Drawing.Point(12, 23);
            this.themeListBox.Name = "themeListBox";
            this.themeListBox.Size = new System.Drawing.Size(303, 214);
            this.themeListBox.TabIndex = 0;
            this.themeListBox.SelectedIndexChanged += new System.EventHandler(this.OnThemeListIndexChanged);
            // 
            // singleKeywordGroupbox
            // 
            this.singleKeywordGroupbox.Controls.Add(this.newKeywordInput);
            this.singleKeywordGroupbox.Controls.Add(this.addKeywordButton);
            this.singleKeywordGroupbox.Controls.Add(this.changeKeywordColourButton);
            this.singleKeywordGroupbox.Controls.Add(this.deleteKeywordButton);
            this.singleKeywordGroupbox.Controls.Add(this.singleKeywordListBox);
            this.singleKeywordGroupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleKeywordGroupbox.Location = new System.Drawing.Point(13, 271);
            this.singleKeywordGroupbox.Name = "singleKeywordGroupbox";
            this.singleKeywordGroupbox.Size = new System.Drawing.Size(322, 333);
            this.singleKeywordGroupbox.TabIndex = 1;
            this.singleKeywordGroupbox.TabStop = false;
            this.singleKeywordGroupbox.Text = "Single Keyword Colours";
            // 
            // newKeywordInput
            // 
            this.newKeywordInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newKeywordInput.Location = new System.Drawing.Point(7, 263);
            this.newKeywordInput.Name = "newKeywordInput";
            this.newKeywordInput.Size = new System.Drawing.Size(200, 24);
            this.newKeywordInput.TabIndex = 4;
            // 
            // addKeywordButton
            // 
            this.addKeywordButton.Location = new System.Drawing.Point(213, 261);
            this.addKeywordButton.Name = "addKeywordButton";
            this.addKeywordButton.Size = new System.Drawing.Size(103, 29);
            this.addKeywordButton.TabIndex = 3;
            this.addKeywordButton.Text = "Add Keyword";
            this.addKeywordButton.UseVisualStyleBackColor = true;
            this.addKeywordButton.Click += new System.EventHandler(this.OnAddSingleKeywordButtonPressed);
            // 
            // changeKeywordColourButton
            // 
            this.changeKeywordColourButton.Location = new System.Drawing.Point(107, 296);
            this.changeKeywordColourButton.Name = "changeKeywordColourButton";
            this.changeKeywordColourButton.Size = new System.Drawing.Size(100, 30);
            this.changeKeywordColourButton.TabIndex = 2;
            this.changeKeywordColourButton.Text = "Change Colour";
            this.changeKeywordColourButton.UseVisualStyleBackColor = true;
            this.changeKeywordColourButton.Click += new System.EventHandler(this.OnChangeSingleKeywordColourButtonPressed);
            // 
            // deleteKeywordButton
            // 
            this.deleteKeywordButton.Location = new System.Drawing.Point(213, 296);
            this.deleteKeywordButton.Name = "deleteKeywordButton";
            this.deleteKeywordButton.Size = new System.Drawing.Size(103, 30);
            this.deleteKeywordButton.TabIndex = 1;
            this.deleteKeywordButton.Text = "Delete Keyword";
            this.deleteKeywordButton.UseVisualStyleBackColor = true;
            this.deleteKeywordButton.Click += new System.EventHandler(this.OnDeleteSingleKeywordButtonPressed);
            // 
            // singleKeywordListBox
            // 
            this.singleKeywordListBox.FormattingEnabled = true;
            this.singleKeywordListBox.ItemHeight = 15;
            this.singleKeywordListBox.Location = new System.Drawing.Point(7, 26);
            this.singleKeywordListBox.Name = "singleKeywordListBox";
            this.singleKeywordListBox.Size = new System.Drawing.Size(309, 229);
            this.singleKeywordListBox.TabIndex = 0;
            this.singleKeywordListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.OnSingleKeywordListBoxDrawItem);
            // 
            // multiWordGroupBox
            // 
            this.multiWordGroupBox.Controls.Add(this.multiwordEndInput);
            this.multiWordGroupBox.Controls.Add(this.multiwordStartInput);
            this.multiWordGroupBox.Controls.Add(this.multiwordNameInput);
            this.multiWordGroupBox.Controls.Add(this.changeMultiwordColourButton);
            this.multiWordGroupBox.Controls.Add(this.deleteMultiwordButton);
            this.multiWordGroupBox.Controls.Add(this.addMultiwordButton);
            this.multiWordGroupBox.Controls.Add(this.multiwordListBox);
            this.multiWordGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiWordGroupBox.Location = new System.Drawing.Point(355, 271);
            this.multiWordGroupBox.Name = "multiWordGroupBox";
            this.multiWordGroupBox.Size = new System.Drawing.Size(358, 333);
            this.multiWordGroupBox.TabIndex = 2;
            this.multiWordGroupBox.TabStop = false;
            this.multiWordGroupBox.Text = "Multi-word Colours";
            // 
            // multiwordListBox
            // 
            this.multiwordListBox.FormattingEnabled = true;
            this.multiwordListBox.ItemHeight = 15;
            this.multiwordListBox.Location = new System.Drawing.Point(7, 26);
            this.multiwordListBox.Name = "multiwordListBox";
            this.multiwordListBox.Size = new System.Drawing.Size(345, 229);
            this.multiwordListBox.TabIndex = 5;
            this.multiwordListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.OnMultiwordListBoxDrawItem);
            // 
            // addMultiwordButton
            // 
            this.addMultiwordButton.Location = new System.Drawing.Point(237, 261);
            this.addMultiwordButton.Name = "addMultiwordButton";
            this.addMultiwordButton.Size = new System.Drawing.Size(115, 29);
            this.addMultiwordButton.TabIndex = 5;
            this.addMultiwordButton.Text = "Add Multi-word";
            this.addMultiwordButton.UseVisualStyleBackColor = true;
            this.addMultiwordButton.Click += new System.EventHandler(this.OnNewMultiwordButtonPressed);
            // 
            // deleteMultiwordButton
            // 
            this.deleteMultiwordButton.Location = new System.Drawing.Point(237, 296);
            this.deleteMultiwordButton.Name = "deleteMultiwordButton";
            this.deleteMultiwordButton.Size = new System.Drawing.Size(115, 29);
            this.deleteMultiwordButton.TabIndex = 6;
            this.deleteMultiwordButton.Text = "Delete Multiword";
            this.deleteMultiwordButton.UseVisualStyleBackColor = true;
            this.deleteMultiwordButton.Click += new System.EventHandler(this.OnDeleteMultiwordButtonPressed);
            // 
            // changeMultiwordColourButton
            // 
            this.changeMultiwordColourButton.Location = new System.Drawing.Point(131, 296);
            this.changeMultiwordColourButton.Name = "changeMultiwordColourButton";
            this.changeMultiwordColourButton.Size = new System.Drawing.Size(100, 30);
            this.changeMultiwordColourButton.TabIndex = 5;
            this.changeMultiwordColourButton.Text = "Change Colour";
            this.changeMultiwordColourButton.UseVisualStyleBackColor = true;
            this.changeMultiwordColourButton.Click += new System.EventHandler(this.OnChangeMultiwordColourButtonPressed);
            // 
            // multiwordNameInput
            // 
            this.multiwordNameInput.Location = new System.Drawing.Point(4, 263);
            this.multiwordNameInput.Name = "multiwordNameInput";
            this.multiwordNameInput.Size = new System.Drawing.Size(115, 21);
            this.multiwordNameInput.TabIndex = 7;
            // 
            // multiwordStartInput
            // 
            this.multiwordStartInput.Location = new System.Drawing.Point(125, 263);
            this.multiwordStartInput.Name = "multiwordStartInput";
            this.multiwordStartInput.Size = new System.Drawing.Size(50, 21);
            this.multiwordStartInput.TabIndex = 8;
            // 
            // multiwordEndInput
            // 
            this.multiwordEndInput.Location = new System.Drawing.Point(181, 263);
            this.multiwordEndInput.Name = "multiwordEndInput";
            this.multiwordEndInput.Size = new System.Drawing.Size(50, 21);
            this.multiwordEndInput.TabIndex = 9;
            // 
            // LanguageThemeCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 613);
            this.Controls.Add(this.multiWordGroupBox);
            this.Controls.Add(this.singleKeywordGroupbox);
            this.Controls.Add(this.loadedThemesGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LanguageThemeCreatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Language Theme Creator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClose);
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.loadedThemesGroup.ResumeLayout(false);
            this.loadedThemesGroup.PerformLayout();
            this.singleKeywordGroupbox.ResumeLayout(false);
            this.singleKeywordGroupbox.PerformLayout();
            this.multiWordGroupBox.ResumeLayout(false);
            this.multiWordGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox loadedThemesGroup;
        private System.Windows.Forms.GroupBox singleKeywordGroupbox;
        private System.Windows.Forms.GroupBox multiWordGroupBox;
        private System.Windows.Forms.ListBox singleKeywordListBox;
        private System.Windows.Forms.TextBox newKeywordInput;
        private System.Windows.Forms.Button addKeywordButton;
        private System.Windows.Forms.Button changeKeywordColourButton;
        private System.Windows.Forms.Button deleteKeywordButton;
        private System.Windows.Forms.ListBox themeListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label detailsLabel;
        private System.Windows.Forms.TextBox themeNameInput;
        private System.Windows.Forms.Button saveThemeButton;
        private System.Windows.Forms.Button deleteThemeButton;
        private System.Windows.Forms.Button newThemeButton;
        private System.Windows.Forms.Label themeSaveStatusLabel;
        private System.Windows.Forms.ListBox multiwordListBox;
        private System.Windows.Forms.Button changeMultiwordColourButton;
        private System.Windows.Forms.Button deleteMultiwordButton;
        private System.Windows.Forms.Button addMultiwordButton;
        private System.Windows.Forms.TextBox multiwordEndInput;
        private System.Windows.Forms.TextBox multiwordStartInput;
        private System.Windows.Forms.TextBox multiwordNameInput;
    }
}