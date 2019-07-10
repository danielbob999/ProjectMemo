namespace ProjectMemo.Forms
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
            this.directoryTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.noteDirGroupBox = new System.Windows.Forms.GroupBox();
            this.autoSaveIntervalInput = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.noteDirGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoSaveIntervalInput)).BeginInit();
            this.SuspendLayout();
            // 
            // directoryTextBox
            // 
            this.directoryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directoryTextBox.Location = new System.Drawing.Point(6, 19);
            this.directoryTextBox.Name = "directoryTextBox";
            this.directoryTextBox.Size = new System.Drawing.Size(568, 23);
            this.directoryTextBox.TabIndex = 0;
            // 
            // browseButton
            // 
            this.browseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseButton.Location = new System.Drawing.Point(580, 19);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(76, 23);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(561, 102);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(123, 33);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // noteDirGroupBox
            // 
            this.noteDirGroupBox.Controls.Add(this.directoryTextBox);
            this.noteDirGroupBox.Controls.Add(this.browseButton);
            this.noteDirGroupBox.Location = new System.Drawing.Point(12, 12);
            this.noteDirGroupBox.Name = "noteDirGroupBox";
            this.noteDirGroupBox.Size = new System.Drawing.Size(672, 53);
            this.noteDirGroupBox.TabIndex = 3;
            this.noteDirGroupBox.TabStop = false;
            this.noteDirGroupBox.Text = "Main Note Directory:";
            // 
            // autoSaveIntervalInput
            // 
            this.autoSaveIntervalInput.Location = new System.Drawing.Point(258, 70);
            this.autoSaveIntervalInput.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.autoSaveIntervalInput.Name = "autoSaveIntervalInput";
            this.autoSaveIntervalInput.Size = new System.Drawing.Size(52, 20);
            this.autoSaveIntervalInput.TabIndex = 4;
            this.autoSaveIntervalInput.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Auto Save Interval in Minutes (Set to 0 to disable)";
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 144);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.autoSaveIntervalInput);
            this.Controls.Add(this.noteDirGroupBox);
            this.Controls.Add(this.saveButton);
            this.Name = "PreferencesForm";
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.PreferencesForm_Load);
            this.noteDirGroupBox.ResumeLayout(false);
            this.noteDirGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoSaveIntervalInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox directoryTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.GroupBox noteDirGroupBox;
        private System.Windows.Forms.NumericUpDown autoSaveIntervalInput;
        private System.Windows.Forms.Label label1;
    }
}