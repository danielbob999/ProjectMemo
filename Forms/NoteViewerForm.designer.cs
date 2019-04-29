namespace ProjectMemo.Forms
{
    partial class NoteViewerForm
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
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabControlContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.default_tab = new System.Windows.Forms.TabPage();
            this.foldersGroupBox = new System.Windows.Forms.GroupBox();
            this.courseSelectorLabel = new System.Windows.Forms.Label();
            this.semesterSelector = new System.Windows.Forms.ComboBox();
            this.semesterSelectorLabel = new System.Windows.Forms.Label();
            this.courseSelector = new System.Windows.Forms.ComboBox();
            this.classTypeSelector = new System.Windows.Forms.ComboBox();
            this.mainDirectoryLabel = new System.Windows.Forms.Label();
            this.filtersGroupBox = new System.Windows.Forms.GroupBox();
            this.filterByDateCheckBox = new System.Windows.Forms.CheckBox();
            this.caseSensitiveCheckBox = new System.Windows.Forms.CheckBox();
            this.searchTermTextBox = new System.Windows.Forms.TextBox();
            this.searchTermLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toFromDateTimeLabel = new System.Windows.Forms.Label();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.resultsGroupBox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.mainFormTimer = new System.Windows.Forms.Timer(this.components);
            this.template_richTextBox = new ProjectMemo.CustomControls.CustomRichTextBox();
            this.mainTabControl.SuspendLayout();
            this.tabControlContextMenu.SuspendLayout();
            this.default_tab.SuspendLayout();
            this.foldersGroupBox.SuspendLayout();
            this.filtersGroupBox.SuspendLayout();
            this.resultsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.ContextMenuStrip = this.tabControlContextMenu;
            this.mainTabControl.Controls.Add(this.default_tab);
            this.mainTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTabControl.HotTrack = true;
            this.mainTabControl.Location = new System.Drawing.Point(12, 9);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1077, 637);
            this.mainTabControl.TabIndex = 101;
            this.mainTabControl.TabStop = false;
            // 
            // tabControlContextMenu
            // 
            this.tabControlContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.tabControlContextMenu.Name = "tabControlContextMenu";
            this.tabControlContextMenu.Size = new System.Drawing.Size(104, 26);
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
            // foldersGroupBox
            // 
            this.foldersGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.foldersGroupBox.Controls.Add(this.courseSelectorLabel);
            this.foldersGroupBox.Controls.Add(this.semesterSelector);
            this.foldersGroupBox.Controls.Add(this.semesterSelectorLabel);
            this.foldersGroupBox.Controls.Add(this.courseSelector);
            this.foldersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foldersGroupBox.Location = new System.Drawing.Point(1095, 29);
            this.foldersGroupBox.Name = "foldersGroupBox";
            this.foldersGroupBox.Size = new System.Drawing.Size(232, 95);
            this.foldersGroupBox.TabIndex = 103;
            this.foldersGroupBox.TabStop = false;
            this.foldersGroupBox.Text = "Folders:";
            // 
            // courseSelectorLabel
            // 
            this.courseSelectorLabel.Location = new System.Drawing.Point(2, 58);
            this.courseSelectorLabel.Name = "courseSelectorLabel";
            this.courseSelectorLabel.Size = new System.Drawing.Size(84, 27);
            this.courseSelectorLabel.TabIndex = 5;
            this.courseSelectorLabel.Text = "Course:";
            this.courseSelectorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // semesterSelector
            // 
            this.semesterSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.semesterSelector.FormattingEnabled = true;
            this.semesterSelector.Location = new System.Drawing.Point(90, 25);
            this.semesterSelector.Name = "semesterSelector";
            this.semesterSelector.Size = new System.Drawing.Size(136, 26);
            this.semesterSelector.TabIndex = 4;
            this.semesterSelector.SelectedIndexChanged += new System.EventHandler(this.semesterSelector_SelectedIndexChanged);
            // 
            // semesterSelectorLabel
            // 
            this.semesterSelectorLabel.Location = new System.Drawing.Point(2, 25);
            this.semesterSelectorLabel.Name = "semesterSelectorLabel";
            this.semesterSelectorLabel.Size = new System.Drawing.Size(84, 27);
            this.semesterSelectorLabel.TabIndex = 3;
            this.semesterSelectorLabel.Text = "Semester:";
            this.semesterSelectorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // courseSelector
            // 
            this.courseSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.courseSelector.FormattingEnabled = true;
            this.courseSelector.Location = new System.Drawing.Point(90, 59);
            this.courseSelector.Name = "courseSelector";
            this.courseSelector.Size = new System.Drawing.Size(136, 26);
            this.courseSelector.TabIndex = 2;
            this.courseSelector.SelectedIndexChanged += new System.EventHandler(this.courseSelector_SelectedIndexChanged);
            // 
            // classTypeSelector
            // 
            this.classTypeSelector.BackColor = System.Drawing.SystemColors.Window;
            this.classTypeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classTypeSelector.ForeColor = System.Drawing.SystemColors.WindowText;
            this.classTypeSelector.FormattingEnabled = true;
            this.classTypeSelector.Items.AddRange(new object[] {
            "All",
            "Lecture",
            "Tutorial",
            "Lab"});
            this.classTypeSelector.Location = new System.Drawing.Point(90, 72);
            this.classTypeSelector.Name = "classTypeSelector";
            this.classTypeSelector.Size = new System.Drawing.Size(139, 26);
            this.classTypeSelector.TabIndex = 1;
            this.classTypeSelector.SelectedIndexChanged += new System.EventHandler(this.classTypeSelector_SelectedIndexChanged);
            // 
            // mainDirectoryLabel
            // 
            this.mainDirectoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainDirectoryLabel.Location = new System.Drawing.Point(16, 649);
            this.mainDirectoryLabel.Name = "mainDirectoryLabel";
            this.mainDirectoryLabel.Size = new System.Drawing.Size(1066, 19);
            this.mainDirectoryLabel.TabIndex = 106;
            this.mainDirectoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // filtersGroupBox
            // 
            this.filtersGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filtersGroupBox.Controls.Add(this.filterByDateCheckBox);
            this.filtersGroupBox.Controls.Add(this.caseSensitiveCheckBox);
            this.filtersGroupBox.Controls.Add(this.searchTermTextBox);
            this.filtersGroupBox.Controls.Add(this.searchTermLabel);
            this.filtersGroupBox.Controls.Add(this.label1);
            this.filtersGroupBox.Controls.Add(this.toFromDateTimeLabel);
            this.filtersGroupBox.Controls.Add(this.toDateTimePicker);
            this.filtersGroupBox.Controls.Add(this.fromDateTimePicker);
            this.filtersGroupBox.Controls.Add(this.classTypeSelector);
            this.filtersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filtersGroupBox.Location = new System.Drawing.Point(1095, 127);
            this.filtersGroupBox.Name = "filtersGroupBox";
            this.filtersGroupBox.Size = new System.Drawing.Size(232, 185);
            this.filtersGroupBox.TabIndex = 104;
            this.filtersGroupBox.TabStop = false;
            this.filtersGroupBox.Text = "Filters:";
            // 
            // filterByDateCheckBox
            // 
            this.filterByDateCheckBox.AutoSize = true;
            this.filterByDateCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterByDateCheckBox.Location = new System.Drawing.Point(6, 50);
            this.filterByDateCheckBox.Name = "filterByDateCheckBox";
            this.filterByDateCheckBox.Size = new System.Drawing.Size(86, 17);
            this.filterByDateCheckBox.TabIndex = 10;
            this.filterByDateCheckBox.Text = "Filter by date";
            this.filterByDateCheckBox.UseVisualStyleBackColor = true;
            this.filterByDateCheckBox.CheckedChanged += new System.EventHandler(this.filterByDateCheckBox_CheckedChanged);
            // 
            // caseSensitiveCheckBox
            // 
            this.caseSensitiveCheckBox.AutoSize = true;
            this.caseSensitiveCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caseSensitiveCheckBox.Location = new System.Drawing.Point(7, 159);
            this.caseSensitiveCheckBox.Name = "caseSensitiveCheckBox";
            this.caseSensitiveCheckBox.Size = new System.Drawing.Size(96, 17);
            this.caseSensitiveCheckBox.TabIndex = 9;
            this.caseSensitiveCheckBox.Text = "Case Sensitive";
            this.caseSensitiveCheckBox.UseVisualStyleBackColor = true;
            this.caseSensitiveCheckBox.CheckedChanged += new System.EventHandler(this.caseSensitiveCheckBox_CheckedChanged);
            // 
            // searchTermTextBox
            // 
            this.searchTermTextBox.Location = new System.Drawing.Point(6, 131);
            this.searchTermTextBox.Name = "searchTermTextBox";
            this.searchTermTextBox.Size = new System.Drawing.Size(219, 24);
            this.searchTermTextBox.TabIndex = 8;
            this.searchTermTextBox.TextChanged += new System.EventHandler(this.searchTermTextBox_TextChanged);
            // 
            // searchTermLabel
            // 
            this.searchTermLabel.Location = new System.Drawing.Point(4, 106);
            this.searchTermLabel.Name = "searchTermLabel";
            this.searchTermLabel.Size = new System.Drawing.Size(100, 22);
            this.searchTermLabel.TabIndex = 7;
            this.searchTermLabel.Text = "Search Term:";
            this.searchTermLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Class Type:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toFromDateTimeLabel
            // 
            this.toFromDateTimeLabel.Location = new System.Drawing.Point(111, 25);
            this.toFromDateTimeLabel.Name = "toFromDateTimeLabel";
            this.toFromDateTimeLabel.Size = new System.Drawing.Size(11, 20);
            this.toFromDateTimeLabel.TabIndex = 2;
            this.toFromDateTimeLabel.Text = "-";
            this.toFromDateTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toDateTimePicker
            // 
            this.toDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDateTimePicker.Location = new System.Drawing.Point(127, 23);
            this.toDateTimePicker.MaxDate = new System.DateTime(3300, 12, 31, 0, 0, 0, 0);
            this.toDateTimePicker.MinDate = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            this.toDateTimePicker.Name = "toDateTimePicker";
            this.toDateTimePicker.Size = new System.Drawing.Size(102, 23);
            this.toDateTimePicker.TabIndex = 1;
            this.toDateTimePicker.ValueChanged += new System.EventHandler(this.toDateTimePicker_ValueChanged);
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDateTimePicker.Location = new System.Drawing.Point(5, 23);
            this.fromDateTimePicker.MaxDate = new System.DateTime(3300, 12, 31, 0, 0, 0, 0);
            this.fromDateTimePicker.MinDate = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(102, 23);
            this.fromDateTimePicker.TabIndex = 0;
            this.fromDateTimePicker.ValueChanged += new System.EventHandler(this.fromDateTimePicker_ValueChanged);
            // 
            // resultsGroupBox
            // 
            this.resultsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsGroupBox.Controls.Add(this.flowLayoutPanel1);
            this.resultsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultsGroupBox.Location = new System.Drawing.Point(1095, 329);
            this.resultsGroupBox.Name = "resultsGroupBox";
            this.resultsGroupBox.Size = new System.Drawing.Size(232, 317);
            this.resultsGroupBox.TabIndex = 105;
            this.resultsGroupBox.TabStop = false;
            this.resultsGroupBox.Text = "Results:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 20);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(223, 294);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // mainFormTimer
            // 
            this.mainFormTimer.Tick += new System.EventHandler(this.mainFormTimer_Tick);
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
            // NoteViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 675);
            this.Controls.Add(this.resultsGroupBox);
            this.Controls.Add(this.filtersGroupBox);
            this.Controls.Add(this.mainDirectoryLabel);
            this.Controls.Add(this.foldersGroupBox);
            this.Controls.Add(this.mainTabControl);
            this.KeyPreview = true;
            this.Name = "NoteViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NoteViewerForm";
            this.Load += new System.EventHandler(this.NoteViewerForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoteViewerForm_KeyDown);
            this.Resize += new System.EventHandler(this.NoteViewerForm_Resize);
            this.mainTabControl.ResumeLayout(false);
            this.tabControlContextMenu.ResumeLayout(false);
            this.default_tab.ResumeLayout(false);
            this.foldersGroupBox.ResumeLayout(false);
            this.filtersGroupBox.ResumeLayout(false);
            this.filtersGroupBox.PerformLayout();
            this.resultsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage default_tab;
        private ProjectMemo.CustomControls.CustomRichTextBox template_richTextBox;
        private System.Windows.Forms.GroupBox foldersGroupBox;
        private System.Windows.Forms.ComboBox semesterSelector;
        private System.Windows.Forms.Label semesterSelectorLabel;
        private System.Windows.Forms.ComboBox courseSelector;
        private System.Windows.Forms.ComboBox classTypeSelector;
        private System.Windows.Forms.Label mainDirectoryLabel;
        private System.Windows.Forms.GroupBox filtersGroupBox;
        private System.Windows.Forms.Label toFromDateTimeLabel;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.Label courseSelectorLabel;
        private System.Windows.Forms.TextBox searchTermTextBox;
        private System.Windows.Forms.Label searchTermLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox caseSensitiveCheckBox;
        private System.Windows.Forms.GroupBox resultsGroupBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Timer mainFormTimer;
        private System.Windows.Forms.CheckBox filterByDateCheckBox;
        private System.Windows.Forms.ContextMenuStrip tabControlContextMenu;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}