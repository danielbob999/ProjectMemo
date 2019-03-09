namespace UniversityNoteProgram
{
    partial class PreferencesForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.mainDirectoryGroup = new System.Windows.Forms.GroupBox();
            this.mainDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.mainDirectoryButton = new System.Windows.Forms.Button();
            this.semesterFolderGroup = new System.Windows.Forms.GroupBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.semesterFolderPicker = new System.Windows.Forms.ComboBox();
            this.mainDirectoryGroup.SuspendLayout();
            this.semesterFolderGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Preferences:";
            // 
            // mainDirectoryGroup
            // 
            this.mainDirectoryGroup.Controls.Add(this.mainDirectoryButton);
            this.mainDirectoryGroup.Controls.Add(this.mainDirectoryTextBox);
            this.mainDirectoryGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainDirectoryGroup.Location = new System.Drawing.Point(13, 34);
            this.mainDirectoryGroup.Name = "mainDirectoryGroup";
            this.mainDirectoryGroup.Size = new System.Drawing.Size(627, 54);
            this.mainDirectoryGroup.TabIndex = 1;
            this.mainDirectoryGroup.TabStop = false;
            this.mainDirectoryGroup.Text = "Main Directory";
            // 
            // mainDirectoryTextBox
            // 
            this.mainDirectoryTextBox.Location = new System.Drawing.Point(7, 23);
            this.mainDirectoryTextBox.Name = "mainDirectoryTextBox";
            this.mainDirectoryTextBox.Size = new System.Drawing.Size(546, 23);
            this.mainDirectoryTextBox.TabIndex = 0;
            // 
            // mainDirectoryButton
            // 
            this.mainDirectoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainDirectoryButton.Location = new System.Drawing.Point(557, 23);
            this.mainDirectoryButton.Name = "mainDirectoryButton";
            this.mainDirectoryButton.Size = new System.Drawing.Size(64, 23);
            this.mainDirectoryButton.TabIndex = 1;
            this.mainDirectoryButton.Text = "Browse";
            this.mainDirectoryButton.UseVisualStyleBackColor = true;
            this.mainDirectoryButton.Click += new System.EventHandler(this.mainDirectoryButton_Click);
            // 
            // semesterFolderGroup
            // 
            this.semesterFolderGroup.Controls.Add(this.semesterFolderPicker);
            this.semesterFolderGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.semesterFolderGroup.Location = new System.Drawing.Point(13, 94);
            this.semesterFolderGroup.Name = "semesterFolderGroup";
            this.semesterFolderGroup.Size = new System.Drawing.Size(482, 54);
            this.semesterFolderGroup.TabIndex = 2;
            this.semesterFolderGroup.TabStop = false;
            this.semesterFolderGroup.Text = "Semester Folder";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(539, 109);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(101, 39);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // semesterFolderPicker
            // 
            this.semesterFolderPicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.semesterFolderPicker.FormattingEnabled = true;
            this.semesterFolderPicker.Location = new System.Drawing.Point(7, 23);
            this.semesterFolderPicker.Name = "semesterFolderPicker";
            this.semesterFolderPicker.Size = new System.Drawing.Size(466, 24);
            this.semesterFolderPicker.TabIndex = 0;
            this.semesterFolderPicker.SelectedIndexChanged += new System.EventHandler(this.semesterFolderPicker_SelectedIndexChanged);
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 153);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.semesterFolderGroup);
            this.Controls.Add(this.mainDirectoryGroup);
            this.Controls.Add(this.label1);
            this.Name = "PreferencesForm";
            this.Text = "Preferences";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreferencesForm_FormClosing);
            this.Load += new System.EventHandler(this.PreferencesForm_Load);
            this.mainDirectoryGroup.ResumeLayout(false);
            this.mainDirectoryGroup.PerformLayout();
            this.semesterFolderGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox mainDirectoryGroup;
        private System.Windows.Forms.Button mainDirectoryButton;
        private System.Windows.Forms.TextBox mainDirectoryTextBox;
        private System.Windows.Forms.GroupBox semesterFolderGroup;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ComboBox semesterFolderPicker;
    }
}