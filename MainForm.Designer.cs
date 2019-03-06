namespace UniversityNoteProgram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainInputTextBox = new System.Windows.Forms.TextBox();
            this.mainFormattingPanel = new System.Windows.Forms.Panel();
            this.formatEditCode = new System.Windows.Forms.Button();
            this.formatTextColourChoice = new System.Windows.Forms.ComboBox();
            this.formatTextColor = new System.Windows.Forms.Button();
            this.formatItalic = new System.Windows.Forms.Button();
            this.formatHeadingChoice = new System.Windows.Forms.ComboBox();
            this.formatHeading = new System.Windows.Forms.Button();
            this.boldButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoryLabel = new System.Windows.Forms.Label();
            this.titleLabelL = new System.Windows.Forms.Label();
            this.mainFormLoop = new System.Windows.Forms.Timer(this.components);
            this.versionLabel = new System.Windows.Forms.Label();
            this.mainFormattingPanel.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainInputTextBox
            // 
            this.mainInputTextBox.Location = new System.Drawing.Point(12, 86);
            this.mainInputTextBox.Multiline = true;
            this.mainInputTextBox.Name = "mainInputTextBox";
            this.mainInputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mainInputTextBox.Size = new System.Drawing.Size(886, 513);
            this.mainInputTextBox.TabIndex = 0;
            this.mainInputTextBox.TextChanged += new System.EventHandler(this.mainInputTextBox_TextChanged);
            // 
            // mainFormattingPanel
            // 
            this.mainFormattingPanel.Controls.Add(this.formatEditCode);
            this.mainFormattingPanel.Controls.Add(this.formatTextColourChoice);
            this.mainFormattingPanel.Controls.Add(this.formatTextColor);
            this.mainFormattingPanel.Controls.Add(this.formatItalic);
            this.mainFormattingPanel.Controls.Add(this.formatHeadingChoice);
            this.mainFormattingPanel.Controls.Add(this.formatHeading);
            this.mainFormattingPanel.Controls.Add(this.boldButton);
            this.mainFormattingPanel.Location = new System.Drawing.Point(904, 86);
            this.mainFormattingPanel.Name = "mainFormattingPanel";
            this.mainFormattingPanel.Size = new System.Drawing.Size(245, 435);
            this.mainFormattingPanel.TabIndex = 1;
            // 
            // formatEditCode
            // 
            this.formatEditCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formatEditCode.Location = new System.Drawing.Point(0, 244);
            this.formatEditCode.Name = "formatEditCode";
            this.formatEditCode.Size = new System.Drawing.Size(245, 42);
            this.formatEditCode.TabIndex = 6;
            this.formatEditCode.Text = "Format: Edit Code";
            this.formatEditCode.UseVisualStyleBackColor = true;
            this.formatEditCode.Click += new System.EventHandler(this.formatEditCode_Click);
            // 
            // formatTextColourChoice
            // 
            this.formatTextColourChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formatTextColourChoice.FormattingEnabled = true;
            this.formatTextColourChoice.Items.AddRange(new object[] {
            "red",
            "green",
            "blue",
            "orange",
            "pink",
            "purple",
            "yellow"});
            this.formatTextColourChoice.Location = new System.Drawing.Point(4, 217);
            this.formatTextColourChoice.Name = "formatTextColourChoice";
            this.formatTextColourChoice.Size = new System.Drawing.Size(237, 21);
            this.formatTextColourChoice.TabIndex = 5;
            // 
            // formatTextColor
            // 
            this.formatTextColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formatTextColor.Location = new System.Drawing.Point(1, 170);
            this.formatTextColor.Name = "formatTextColor";
            this.formatTextColor.Size = new System.Drawing.Size(245, 42);
            this.formatTextColor.TabIndex = 4;
            this.formatTextColor.Text = "Format: Text Colour";
            this.formatTextColor.UseVisualStyleBackColor = true;
            this.formatTextColor.Click += new System.EventHandler(this.formatTextColor_Click);
            // 
            // formatItalic
            // 
            this.formatItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formatItalic.Location = new System.Drawing.Point(0, 122);
            this.formatItalic.Name = "formatItalic";
            this.formatItalic.Size = new System.Drawing.Size(245, 42);
            this.formatItalic.TabIndex = 3;
            this.formatItalic.Text = "Format: Italic";
            this.formatItalic.UseVisualStyleBackColor = true;
            this.formatItalic.Click += new System.EventHandler(this.formatItalic_Click);
            // 
            // formatHeadingChoice
            // 
            this.formatHeadingChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formatHeadingChoice.FormattingEnabled = true;
            this.formatHeadingChoice.Items.AddRange(new object[] {
            "h1",
            "h2",
            "h3"});
            this.formatHeadingChoice.Location = new System.Drawing.Point(4, 47);
            this.formatHeadingChoice.Name = "formatHeadingChoice";
            this.formatHeadingChoice.Size = new System.Drawing.Size(237, 21);
            this.formatHeadingChoice.TabIndex = 2;
            // 
            // formatHeading
            // 
            this.formatHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formatHeading.Location = new System.Drawing.Point(0, 0);
            this.formatHeading.Name = "formatHeading";
            this.formatHeading.Size = new System.Drawing.Size(245, 42);
            this.formatHeading.TabIndex = 1;
            this.formatHeading.Text = "Format: Heading";
            this.formatHeading.UseVisualStyleBackColor = true;
            this.formatHeading.Click += new System.EventHandler(this.formatHeading_Click);
            // 
            // boldButton
            // 
            this.boldButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boldButton.Location = new System.Drawing.Point(0, 74);
            this.boldButton.Name = "boldButton";
            this.boldButton.Size = new System.Drawing.Size(245, 42);
            this.boldButton.TabIndex = 0;
            this.boldButton.Text = "Format: Bold";
            this.boldButton.UseVisualStyleBackColor = true;
            this.boldButton.Click += new System.EventHandler(this.boldButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(904, 527);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(245, 37);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.pathTextBox.Location = new System.Drawing.Point(908, 568);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.ReadOnly = true;
            this.pathTextBox.Size = new System.Drawing.Size(237, 23);
            this.pathTextBox.TabIndex = 3;
            this.pathTextBox.Text = "lovely";
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(77, 26);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(432, 31);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "19-03-02_Lecture.html";
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1157, 24);
            this.mainMenuStrip.TabIndex = 9;
            this.mainMenuStrip.Text = "MainMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // directoryLabel
            // 
            this.directoryLabel.Location = new System.Drawing.Point(12, 605);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(886, 23);
            this.directoryLabel.TabIndex = 11;
            this.directoryLabel.Text = "label1";
            // 
            // titleLabelL
            // 
            this.titleLabelL.AutoSize = true;
            this.titleLabelL.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabelL.Location = new System.Drawing.Point(12, 24);
            this.titleLabelL.Name = "titleLabelL";
            this.titleLabelL.Size = new System.Drawing.Size(71, 31);
            this.titleLabelL.TabIndex = 12;
            this.titleLabelL.Text = "File:";
            // 
            // mainFormLoop
            // 
            this.mainFormLoop.Tick += new System.EventHandler(this.mainFormLoop_Tick);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.Location = new System.Drawing.Point(1111, 24);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(46, 17);
            this.versionLabel.TabIndex = 13;
            this.versionLabel.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 627);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.titleLabelL);
            this.Controls.Add(this.directoryLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.mainFormattingPanel);
            this.Controls.Add(this.mainInputTextBox);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "University Note Taker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainFormattingPanel.ResumeLayout(false);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox mainInputTextBox;
        private System.Windows.Forms.Panel mainFormattingPanel;
        private System.Windows.Forms.Button boldButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Button formatEditCode;
        private System.Windows.Forms.ComboBox formatTextColourChoice;
        private System.Windows.Forms.Button formatTextColor;
        private System.Windows.Forms.Button formatItalic;
        private System.Windows.Forms.ComboBox formatHeadingChoice;
        private System.Windows.Forms.Button formatHeading;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Label directoryLabel;
        private System.Windows.Forms.Label titleLabelL;
        private System.Windows.Forms.Timer mainFormLoop;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Label versionLabel;
    }
}

