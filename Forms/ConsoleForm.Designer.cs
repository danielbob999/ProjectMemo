namespace UniversityNoteProgram
{
    partial class ConsoleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsoleForm));
            this.mainConsoleTextBox = new System.Windows.Forms.TextBox();
            this.consoleTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // mainConsoleTextBox
            // 
            this.mainConsoleTextBox.Location = new System.Drawing.Point(4, 5);
            this.mainConsoleTextBox.Multiline = true;
            this.mainConsoleTextBox.Name = "mainConsoleTextBox";
            this.mainConsoleTextBox.ReadOnly = true;
            this.mainConsoleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mainConsoleTextBox.Size = new System.Drawing.Size(663, 373);
            this.mainConsoleTextBox.TabIndex = 0;
            // 
            // consoleTimer
            // 
            this.consoleTimer.Tick += new System.EventHandler(this.consoleTimer_Tick);
            // 
            // ConsoleForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(672, 381);
            this.Controls.Add(this.mainConsoleTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConsoleForm";
            this.Text = "Univeristy Note Tacker Console";
            this.Load += new System.EventHandler(this.ConsoleForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox mainConsoleTextBox;
        private System.Windows.Forms.Timer consoleTimer;
    }
}