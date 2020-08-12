namespace ProjectMemo.Forms
{
    partial class InsertObjectForm
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
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.imageTabPage = new System.Windows.Forms.TabPage();
            this.insertButton = new System.Windows.Forms.Button();
            this.imageDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.yImageSize = new System.Windows.Forms.NumericUpDown();
            this.xImageSize = new System.Windows.Forms.NumericUpDown();
            this.pasteButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.previewTextBox = new System.Windows.Forms.RichTextBox();
            this.mainTabControl.SuspendLayout();
            this.imageTabPage.SuspendLayout();
            this.imageDetailsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yImageSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xImageSize)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.imageTabPage);
            this.mainTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTabControl.Location = new System.Drawing.Point(13, 13);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(803, 421);
            this.mainTabControl.TabIndex = 0;
            // 
            // imageTabPage
            // 
            this.imageTabPage.Controls.Add(this.insertButton);
            this.imageTabPage.Controls.Add(this.imageDetailsGroupBox);
            this.imageTabPage.Controls.Add(this.label1);
            this.imageTabPage.Controls.Add(this.previewTextBox);
            this.imageTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageTabPage.Location = new System.Drawing.Point(4, 27);
            this.imageTabPage.Name = "imageTabPage";
            this.imageTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.imageTabPage.Size = new System.Drawing.Size(795, 390);
            this.imageTabPage.TabIndex = 0;
            this.imageTabPage.Text = "Image";
            this.imageTabPage.UseVisualStyleBackColor = true;
            // 
            // insertButton
            // 
            this.insertButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.insertButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertButton.Location = new System.Drawing.Point(655, 350);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(134, 34);
            this.insertButton.TabIndex = 5;
            this.insertButton.Text = "Insert";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.OnInsertButtonPressed);
            // 
            // imageDetailsGroupBox
            // 
            this.imageDetailsGroupBox.Controls.Add(this.sizeLabel);
            this.imageDetailsGroupBox.Controls.Add(this.yImageSize);
            this.imageDetailsGroupBox.Controls.Add(this.xImageSize);
            this.imageDetailsGroupBox.Controls.Add(this.pasteButton);
            this.imageDetailsGroupBox.Controls.Add(this.clearButton);
            this.imageDetailsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageDetailsGroupBox.Location = new System.Drawing.Point(655, 44);
            this.imageDetailsGroupBox.Name = "imageDetailsGroupBox";
            this.imageDetailsGroupBox.Size = new System.Drawing.Size(134, 155);
            this.imageDetailsGroupBox.TabIndex = 4;
            this.imageDetailsGroupBox.TabStop = false;
            this.imageDetailsGroupBox.Text = "Details";
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(7, 88);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(39, 17);
            this.sizeLabel.TabIndex = 6;
            this.sizeLabel.Text = "Size:";
            // 
            // yImageSize
            // 
            this.yImageSize.Location = new System.Drawing.Point(74, 109);
            this.yImageSize.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.yImageSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.yImageSize.Name = "yImageSize";
            this.yImageSize.Size = new System.Drawing.Size(54, 23);
            this.yImageSize.TabIndex = 5;
            this.yImageSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.yImageSize.ValueChanged += new System.EventHandler(this.OnSizeChanged);
            // 
            // xImageSize
            // 
            this.xImageSize.Location = new System.Drawing.Point(8, 109);
            this.xImageSize.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.xImageSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.xImageSize.Name = "xImageSize";
            this.xImageSize.Size = new System.Drawing.Size(54, 23);
            this.xImageSize.TabIndex = 4;
            this.xImageSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.xImageSize.ValueChanged += new System.EventHandler(this.OnSizeChanged);
            // 
            // pasteButton
            // 
            this.pasteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pasteButton.Location = new System.Drawing.Point(8, 22);
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(120, 28);
            this.pasteButton.TabIndex = 2;
            this.pasteButton.Text = "Paste";
            this.pasteButton.UseVisualStyleBackColor = true;
            this.pasteButton.Click += new System.EventHandler(this.OnPasteButtonPressed);
            // 
            // clearButton
            // 
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(8, 56);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(120, 28);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.OnClearButtonPressed);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Preview:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // previewTextBox
            // 
            this.previewTextBox.Location = new System.Drawing.Point(14, 44);
            this.previewTextBox.Name = "previewTextBox";
            this.previewTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.previewTextBox.Size = new System.Drawing.Size(635, 340);
            this.previewTextBox.TabIndex = 0;
            this.previewTextBox.Text = "";
            // 
            // InsertObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 446);
            this.Controls.Add(this.mainTabControl);
            this.Name = "InsertObjectForm";
            this.Text = "InsertObjectForm";
            this.mainTabControl.ResumeLayout(false);
            this.imageTabPage.ResumeLayout(false);
            this.imageDetailsGroupBox.ResumeLayout(false);
            this.imageDetailsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yImageSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xImageSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage imageTabPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox previewTextBox;
        private System.Windows.Forms.GroupBox imageDetailsGroupBox;
        private System.Windows.Forms.Button pasteButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.NumericUpDown yImageSize;
        private System.Windows.Forms.NumericUpDown xImageSize;
        private System.Windows.Forms.Button insertButton;
    }
}