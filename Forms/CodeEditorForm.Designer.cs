namespace UniversityNoteProgram
{
    partial class CodeEditorForm
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
            this.mainInputBox = new System.Windows.Forms.RichTextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.fontSizeChanger = new System.Windows.Forms.NumericUpDown();
            this.formTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeChanger)).BeginInit();
            this.SuspendLayout();
            // 
            // mainInputBox
            // 
            this.mainInputBox.Location = new System.Drawing.Point(13, 39);
            this.mainInputBox.Name = "mainInputBox";
            this.mainInputBox.Size = new System.Drawing.Size(686, 500);
            this.mainInputBox.TabIndex = 0;
            this.mainInputBox.Text = "";
            this.mainInputBox.TextChanged += new System.EventHandler(this.mainInputBox_TextChanged);
            this.mainInputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainInputBox_KeyDown);
            this.mainInputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mainInputBox_KeyPress);
            this.mainInputBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mainInputBox_KeyUp);
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(13, 4);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(468, 32);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Editing Code Fragment: 2";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fontSizeChanger
            // 
            this.fontSizeChanger.AutoSize = true;
            this.fontSizeChanger.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontSizeChanger.Location = new System.Drawing.Point(656, 46);
            this.fontSizeChanger.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.fontSizeChanger.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.fontSizeChanger.Name = "fontSizeChanger";
            this.fontSizeChanger.Size = new System.Drawing.Size(37, 21);
            this.fontSizeChanger.TabIndex = 15;
            this.fontSizeChanger.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // formTimer
            // 
            this.formTimer.Tick += new System.EventHandler(this.formTimer_Tick);
            // 
            // CodeEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 551);
            this.Controls.Add(this.fontSizeChanger);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.mainInputBox);
            this.Name = "CodeEditorForm";
            this.Text = "CodeEditorForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CodeEditorForm_FormClosing);
            this.Load += new System.EventHandler(this.CodeEditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeChanger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox mainInputBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.NumericUpDown fontSizeChanger;
        private System.Windows.Forms.Timer formTimer;
    }
}