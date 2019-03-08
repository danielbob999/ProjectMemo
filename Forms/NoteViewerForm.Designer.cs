namespace UniversityNoteProgram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteViewerForm));
            this.notePathLabel = new System.Windows.Forms.Label();
            this.mainNoteBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // notePathLabel
            // 
            this.notePathLabel.Location = new System.Drawing.Point(10, 644);
            this.notePathLabel.Name = "notePathLabel";
            this.notePathLabel.Size = new System.Drawing.Size(1162, 16);
            this.notePathLabel.TabIndex = 0;
            this.notePathLabel.Text = "path";
            // 
            // mainNoteBrowser
            // 
            this.mainNoteBrowser.Location = new System.Drawing.Point(11, 9);
            this.mainNoteBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.mainNoteBrowser.Name = "mainNoteBrowser";
            this.mainNoteBrowser.Size = new System.Drawing.Size(1161, 630);
            this.mainNoteBrowser.TabIndex = 1;
            // 
            // NoteViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.mainNoteBrowser);
            this.Controls.Add(this.notePathLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NoteViewerForm";
            this.Text = "University Note Viewer";
            this.Load += new System.EventHandler(this.NoteViewerForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label notePathLabel;
        private System.Windows.Forms.WebBrowser mainNoteBrowser;
    }
}