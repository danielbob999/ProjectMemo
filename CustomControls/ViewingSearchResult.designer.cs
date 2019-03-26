namespace ProjectMemo.CustomControls
{
    partial class ViewingSearchResult
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.searchTermLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(4, 4);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(181, 23);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "[159102] 2019-03-17_Lecture.rtf";
            this.titleLabel.DoubleClick += new System.EventHandler(this.CombinedOnDoubleClick);
            // 
            // searchTermLabel
            // 
            this.searchTermLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTermLabel.Location = new System.Drawing.Point(7, 17);
            this.searchTermLabel.Name = "searchTermLabel";
            this.searchTermLabel.Size = new System.Drawing.Size(178, 16);
            this.searchTermLabel.TabIndex = 1;
            this.searchTermLabel.Text = "... and BLOCKCHAIN is ...";
            this.searchTermLabel.DoubleClick += new System.EventHandler(this.CombinedOnDoubleClick);
            // 
            // ViewingSearchResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.searchTermLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "ViewingSearchResult";
            this.Size = new System.Drawing.Size(190, 36);
            this.Load += new System.EventHandler(this.ViewingSearchResult_Load);
            this.DoubleClick += new System.EventHandler(this.CombinedOnDoubleClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label searchTermLabel;
    }
}
