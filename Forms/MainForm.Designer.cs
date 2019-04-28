namespace ProjectMemo.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.langThemeCreatorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noteViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabControlContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.default_tab = new System.Windows.Forms.TabPage();
            this.formatingGroupBox = new System.Windows.Forms.GroupBox();
            this.format_languageSelector = new System.Windows.Forms.ComboBox();
            this.format_formatCodeButton = new System.Windows.Forms.Button();
            this.format_strikeoutButton = new System.Windows.Forms.Button();
            this.format_underlineButton = new System.Windows.Forms.Button();
            this.format_italicButton = new System.Windows.Forms.Button();
            this.format_boldButton = new System.Windows.Forms.Button();
            this.format_textStyleSelector = new System.Windows.Forms.ComboBox();
            this.savingGroupBox = new System.Windows.Forms.GroupBox();
            this.semesterSelector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.courseSelector = new System.Windows.Forms.ComboBox();
            this.classTypeSelector = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.mainFormTimer = new System.Windows.Forms.Timer(this.components);
            this.versionLabel = new System.Windows.Forms.Label();
            this.template_richTextBox = new ProjectMemo.CustomControls.CustomRichTextBox();
            this.mainMenuStrip.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.tabControlContextMenu.SuspendLayout();
            this.default_tab.SuspendLayout();
            this.formatingGroupBox.SuspendLayout();
            this.savingGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.windowToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1339, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.preferencesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toEditToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // toEditToolStripMenuItem
            // 
            this.toEditToolStripMenuItem.Name = "toEditToolStripMenuItem";
            this.toEditToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.toEditToolStripMenuItem.Text = "To Edit";
            this.toEditToolStripMenuItem.Click += new System.EventHandler(this.toEditToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consoleToolStripMenuItem,
            this.langThemeCreatorMenuItem,
            this.noteViewerToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // consoleToolStripMenuItem
            // 
            this.consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
            this.consoleToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.consoleToolStripMenuItem.Text = "Console";
            this.consoleToolStripMenuItem.Click += new System.EventHandler(this.consoleToolStripMenuItem_Click);
            // 
            // langThemeCreatorMenuItem
            // 
            this.langThemeCreatorMenuItem.Name = "langThemeCreatorMenuItem";
            this.langThemeCreatorMenuItem.Size = new System.Drawing.Size(208, 22);
            this.langThemeCreatorMenuItem.Text = "Language Theme Creator";
            this.langThemeCreatorMenuItem.Click += new System.EventHandler(this.langThemeCreatorMenuItem_Click);
            // 
            // noteViewerToolStripMenuItem
            // 
            this.noteViewerToolStripMenuItem.Name = "noteViewerToolStripMenuItem";
            this.noteViewerToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.noteViewerToolStripMenuItem.Text = "Note Viewer";
            this.noteViewerToolStripMenuItem.Click += new System.EventHandler(this.noteViewerToolStripMenuItem_Click);
            // 
            // mainTabControl
            // 
            this.mainTabControl.ContextMenuStrip = this.tabControlContextMenu;
            this.mainTabControl.Controls.Add(this.default_tab);
            this.mainTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTabControl.HotTrack = true;
            this.mainTabControl.Location = new System.Drawing.Point(12, 27);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1077, 637);
            this.mainTabControl.TabIndex = 100;
            this.mainTabControl.TabStop = false;
            this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.mainTabControl_SelectedIndexChanged);
            // 
            // tabControlContextMenu
            // 
            this.tabControlContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.tabControlContextMenu.Name = "tabControlContextMenu";
            this.tabControlContextMenu.Size = new System.Drawing.Size(104, 48);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // default_tab
            // 
            this.default_tab.Controls.Add(this.template_richTextBox);
            this.default_tab.Location = new System.Drawing.Point(4, 25);
            this.default_tab.Name = "default_tab";
            this.default_tab.Padding = new System.Windows.Forms.Padding(3);
            this.default_tab.Size = new System.Drawing.Size(1069, 608);
            this.default_tab.TabIndex = 0;
            this.default_tab.Text = "default_tab";
            this.default_tab.UseVisualStyleBackColor = true;
            // 
            // formatingGroupBox
            // 
            this.formatingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.formatingGroupBox.Controls.Add(this.format_languageSelector);
            this.formatingGroupBox.Controls.Add(this.format_formatCodeButton);
            this.formatingGroupBox.Controls.Add(this.format_strikeoutButton);
            this.formatingGroupBox.Controls.Add(this.format_underlineButton);
            this.formatingGroupBox.Controls.Add(this.format_italicButton);
            this.formatingGroupBox.Controls.Add(this.format_boldButton);
            this.formatingGroupBox.Controls.Add(this.format_textStyleSelector);
            this.formatingGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formatingGroupBox.Location = new System.Drawing.Point(1095, 43);
            this.formatingGroupBox.Name = "formatingGroupBox";
            this.formatingGroupBox.Size = new System.Drawing.Size(235, 125);
            this.formatingGroupBox.TabIndex = 101;
            this.formatingGroupBox.TabStop = false;
            this.formatingGroupBox.Text = "Format:";
            // 
            // format_languageSelector
            // 
            this.format_languageSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.format_languageSelector.FormattingEnabled = true;
            this.format_languageSelector.Location = new System.Drawing.Point(4, 57);
            this.format_languageSelector.Name = "format_languageSelector";
            this.format_languageSelector.Size = new System.Drawing.Size(110, 26);
            this.format_languageSelector.TabIndex = 8;
            // 
            // format_formatCodeButton
            // 
            this.format_formatCodeButton.Location = new System.Drawing.Point(120, 57);
            this.format_formatCodeButton.Name = "format_formatCodeButton";
            this.format_formatCodeButton.Size = new System.Drawing.Size(111, 28);
            this.format_formatCodeButton.TabIndex = 7;
            this.format_formatCodeButton.Text = "Format Code";
            this.format_formatCodeButton.UseVisualStyleBackColor = true;
            this.format_formatCodeButton.Click += new System.EventHandler(this.format_formatCodeButton_Click);
            // 
            // format_strikeoutButton
            // 
            this.format_strikeoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.format_strikeoutButton.Location = new System.Drawing.Point(120, 91);
            this.format_strikeoutButton.Name = "format_strikeoutButton";
            this.format_strikeoutButton.Size = new System.Drawing.Size(55, 26);
            this.format_strikeoutButton.TabIndex = 5;
            this.format_strikeoutButton.Text = "Strk";
            this.format_strikeoutButton.UseVisualStyleBackColor = true;
            this.format_strikeoutButton.Click += new System.EventHandler(this.format_strikeoutButton_Click);
            // 
            // format_underlineButton
            // 
            this.format_underlineButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.format_underlineButton.Location = new System.Drawing.Point(177, 91);
            this.format_underlineButton.Name = "format_underlineButton";
            this.format_underlineButton.Size = new System.Drawing.Size(55, 26);
            this.format_underlineButton.TabIndex = 4;
            this.format_underlineButton.Text = "Udr";
            this.format_underlineButton.UseVisualStyleBackColor = true;
            this.format_underlineButton.Click += new System.EventHandler(this.format_underlineButton_Click);
            // 
            // format_italicButton
            // 
            this.format_italicButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.format_italicButton.Location = new System.Drawing.Point(62, 91);
            this.format_italicButton.Name = "format_italicButton";
            this.format_italicButton.Size = new System.Drawing.Size(55, 26);
            this.format_italicButton.TabIndex = 3;
            this.format_italicButton.Text = "I";
            this.format_italicButton.UseVisualStyleBackColor = true;
            this.format_italicButton.Click += new System.EventHandler(this.format_italicButton_Click);
            // 
            // format_boldButton
            // 
            this.format_boldButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.format_boldButton.Location = new System.Drawing.Point(4, 91);
            this.format_boldButton.Name = "format_boldButton";
            this.format_boldButton.Size = new System.Drawing.Size(55, 26);
            this.format_boldButton.TabIndex = 2;
            this.format_boldButton.Text = "B";
            this.format_boldButton.UseVisualStyleBackColor = true;
            this.format_boldButton.Click += new System.EventHandler(this.format_boldButton_Click);
            // 
            // format_textStyleSelector
            // 
            this.format_textStyleSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.format_textStyleSelector.FormattingEnabled = true;
            this.format_textStyleSelector.Location = new System.Drawing.Point(4, 25);
            this.format_textStyleSelector.Name = "format_textStyleSelector";
            this.format_textStyleSelector.Size = new System.Drawing.Size(227, 26);
            this.format_textStyleSelector.TabIndex = 0;
            this.format_textStyleSelector.SelectedIndexChanged += new System.EventHandler(this.format_textStyleSelector_SelectedIndexChanged);
            // 
            // savingGroupBox
            // 
            this.savingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savingGroupBox.Controls.Add(this.semesterSelector);
            this.savingGroupBox.Controls.Add(this.label1);
            this.savingGroupBox.Controls.Add(this.courseSelector);
            this.savingGroupBox.Controls.Add(this.classTypeSelector);
            this.savingGroupBox.Controls.Add(this.saveButton);
            this.savingGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savingGroupBox.Location = new System.Drawing.Point(1095, 506);
            this.savingGroupBox.Name = "savingGroupBox";
            this.savingGroupBox.Size = new System.Drawing.Size(232, 156);
            this.savingGroupBox.TabIndex = 102;
            this.savingGroupBox.TabStop = false;
            this.savingGroupBox.Text = "Save As:";
            // 
            // semesterSelector
            // 
            this.semesterSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.semesterSelector.FormattingEnabled = true;
            this.semesterSelector.Location = new System.Drawing.Point(156, 20);
            this.semesterSelector.Name = "semesterSelector";
            this.semesterSelector.Size = new System.Drawing.Size(70, 26);
            this.semesterSelector.TabIndex = 4;
            this.semesterSelector.SelectedIndexChanged += new System.EventHandler(this.semesterSelector_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(66, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Semester:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // courseSelector
            // 
            this.courseSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.courseSelector.FormattingEnabled = true;
            this.courseSelector.Location = new System.Drawing.Point(66, 54);
            this.courseSelector.Name = "courseSelector";
            this.courseSelector.Size = new System.Drawing.Size(160, 26);
            this.courseSelector.TabIndex = 2;
            // 
            // classTypeSelector
            // 
            this.classTypeSelector.BackColor = System.Drawing.SystemColors.Window;
            this.classTypeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classTypeSelector.ForeColor = System.Drawing.SystemColors.WindowText;
            this.classTypeSelector.FormattingEnabled = true;
            this.classTypeSelector.Items.AddRange(new object[] {
            "Lecture",
            "Tutorial",
            "Lab"});
            this.classTypeSelector.Location = new System.Drawing.Point(66, 86);
            this.classTypeSelector.Name = "classTypeSelector";
            this.classTypeSelector.Size = new System.Drawing.Size(160, 26);
            this.classTypeSelector.TabIndex = 1;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(66, 118);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(160, 31);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // mainFormTimer
            // 
            this.mainFormTimer.Tick += new System.EventHandler(this.mainFormTimer_Tick);
            // 
            // versionLabel
            // 
            this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.versionLabel.Location = new System.Drawing.Point(1272, 27);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(62, 13);
            this.versionLabel.TabIndex = 103;
            this.versionLabel.Text = "VERSION";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // template_richTextBox
            // 
            this.template_richTextBox.AcceptsTab = true;
            this.template_richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.template_richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.template_richTextBox.HideSelection = false;
            this.template_richTextBox.Location = new System.Drawing.Point(2, 3);
            this.template_richTextBox.Name = "template_richTextBox";
            this.template_richTextBox.Size = new System.Drawing.Size(1064, 602);
            this.template_richTextBox.TabIndex = 0;
            this.template_richTextBox.Text = "Theres are some nootes!";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 686);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.savingGroupBox);
            this.Controls.Add(this.formatingGroupBox);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.mainMenuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProjectMemo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.tabControlContextMenu.ResumeLayout(false);
            this.default_tab.ResumeLayout(false);
            this.formatingGroupBox.ResumeLayout(false);
            this.savingGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consoleToolStripMenuItem;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage default_tab;
        private System.Windows.Forms.GroupBox formatingGroupBox;
        private System.Windows.Forms.GroupBox savingGroupBox;
        private System.Windows.Forms.ComboBox courseSelector;
        private System.Windows.Forms.ComboBox classTypeSelector;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toEditToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip tabControlContextMenu;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ComboBox semesterSelector;
        private System.Windows.Forms.Timer mainFormTimer;
        private CustomControls.CustomRichTextBox template_richTextBox;
        private System.Windows.Forms.Button format_strikeoutButton;
        private System.Windows.Forms.Button format_underlineButton;
        private System.Windows.Forms.Button format_italicButton;
        private System.Windows.Forms.Button format_boldButton;
        private System.Windows.Forms.ComboBox format_textStyleSelector;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.ToolStripMenuItem noteViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem langThemeCreatorMenuItem;
        private System.Windows.Forms.Button format_formatCodeButton;
        private System.Windows.Forms.ComboBox format_languageSelector;
    }
}