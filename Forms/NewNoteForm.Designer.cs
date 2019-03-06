namespace UniversityNoteProgram
{
    partial class NewNoteForm
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
            this.createButton = new System.Windows.Forms.Button();
            this.coursePicker = new System.Windows.Forms.ComboBox();
            this.classTypePicker = new System.Windows.Forms.ComboBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // createButton
            // 
            this.createButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createButton.Location = new System.Drawing.Point(6, 75);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(336, 37);
            this.createButton.TabIndex = 0;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // coursePicker
            // 
            this.coursePicker.FormattingEnabled = true;
            this.coursePicker.Items.AddRange(new object[] {
            "158.212",
            "158.244",
            "159.201",
            "159.234",
            "Blank"});
            this.coursePicker.Location = new System.Drawing.Point(6, 43);
            this.coursePicker.Name = "coursePicker";
            this.coursePicker.Size = new System.Drawing.Size(160, 21);
            this.coursePicker.TabIndex = 1;
            this.coursePicker.Text = "Select Course";
            // 
            // classTypePicker
            // 
            this.classTypePicker.FormattingEnabled = true;
            this.classTypePicker.Items.AddRange(new object[] {
            "Lecture",
            "Tutorial",
            "Lab"});
            this.classTypePicker.Location = new System.Drawing.Point(182, 43);
            this.classTypePicker.Name = "classTypePicker";
            this.classTypePicker.Size = new System.Drawing.Size(160, 21);
            this.classTypePicker.TabIndex = 2;
            this.classTypePicker.Text = "Select Class Type";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(13, 13);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(146, 20);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "Create new note:";
            // 
            // NewNoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 120);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.classTypePicker);
            this.Controls.Add(this.coursePicker);
            this.Controls.Add(this.createButton);
            this.Name = "NewNoteForm";
            this.Text = "NewNoteForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewNoteForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.ComboBox coursePicker;
        private System.Windows.Forms.ComboBox classTypePicker;
        private System.Windows.Forms.Label titleLabel;
    }
}