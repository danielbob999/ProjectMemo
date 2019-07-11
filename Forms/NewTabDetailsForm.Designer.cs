namespace ProjectMemo.Forms
{
    partial class NewTabDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewTabDetailsForm));
            this.semesterSelector = new System.Windows.Forms.ComboBox();
            this.semesterTitle = new System.Windows.Forms.Label();
            this.courseSelector = new System.Windows.Forms.ComboBox();
            this.classTypeSelector = new System.Windows.Forms.ComboBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.courseTitle = new System.Windows.Forms.Label();
            this.classTypeTitle = new System.Windows.Forms.Label();
            this.createButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // semesterSelector
            // 
            this.semesterSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.semesterSelector.FormattingEnabled = true;
            this.semesterSelector.Location = new System.Drawing.Point(148, 51);
            this.semesterSelector.Name = "semesterSelector";
            this.semesterSelector.Size = new System.Drawing.Size(137, 21);
            this.semesterSelector.TabIndex = 4;
            this.semesterSelector.SelectedIndexChanged += new System.EventHandler(this.OnSemesterSelectedChanged);
            // 
            // semesterTitle
            // 
            this.semesterTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.semesterTitle.Location = new System.Drawing.Point(12, 47);
            this.semesterTitle.Name = "semesterTitle";
            this.semesterTitle.Size = new System.Drawing.Size(84, 27);
            this.semesterTitle.TabIndex = 3;
            this.semesterTitle.Text = "Semester:";
            this.semesterTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // courseSelector
            // 
            this.courseSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.courseSelector.FormattingEnabled = true;
            this.courseSelector.Location = new System.Drawing.Point(148, 78);
            this.courseSelector.Name = "courseSelector";
            this.courseSelector.Size = new System.Drawing.Size(137, 21);
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
            this.classTypeSelector.Location = new System.Drawing.Point(148, 105);
            this.classTypeSelector.Name = "classTypeSelector";
            this.classTypeSelector.Size = new System.Drawing.Size(137, 21);
            this.classTypeSelector.TabIndex = 1;
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(9, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(209, 39);
            this.titleLabel.TabIndex = 104;
            this.titleLabel.Text = "Create New Tab:";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // courseTitle
            // 
            this.courseTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseTitle.Location = new System.Drawing.Point(12, 74);
            this.courseTitle.Name = "courseTitle";
            this.courseTitle.Size = new System.Drawing.Size(84, 27);
            this.courseTitle.TabIndex = 105;
            this.courseTitle.Text = "Course:";
            this.courseTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // classTypeTitle
            // 
            this.classTypeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classTypeTitle.Location = new System.Drawing.Point(12, 101);
            this.classTypeTitle.Name = "classTypeTitle";
            this.classTypeTitle.Size = new System.Drawing.Size(84, 27);
            this.classTypeTitle.TabIndex = 106;
            this.classTypeTitle.Text = "Class Type:";
            this.classTypeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // createButton
            // 
            this.createButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.createButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createButton.Location = new System.Drawing.Point(148, 145);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(137, 35);
            this.createButton.TabIndex = 107;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.OnCreateButtonPressed);
            // 
            // NewTabDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 189);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.classTypeTitle);
            this.Controls.Add(this.classTypeSelector);
            this.Controls.Add(this.courseTitle);
            this.Controls.Add(this.courseSelector);
            this.Controls.Add(this.semesterSelector);
            this.Controls.Add(this.semesterTitle);
            this.Controls.Add(this.titleLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewTabDetailsForm";
            this.Text = "Create New Tab";
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox semesterSelector;
        private System.Windows.Forms.Label semesterTitle;
        private System.Windows.Forms.ComboBox courseSelector;
        private System.Windows.Forms.ComboBox classTypeSelector;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label courseTitle;
        private System.Windows.Forms.Label classTypeTitle;
        private System.Windows.Forms.Button createButton;
    }
}