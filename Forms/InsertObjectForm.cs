using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectMemo.Forms
{
    public partial class InsertObjectForm : Form
    {
        private bool valueChangedLock = false;
        private object mPastedObject;

        public object PastedObject
        {
            get { return mPastedObject; }
        }

        public InsertObjectForm() {
            InitializeComponent();
        }

        private void OnPasteButtonPressed(object sender, EventArgs e) {
            if (Clipboard.ContainsImage()) {
                Image image = Clipboard.GetImage();
                previewTextBox.Paste();
                valueChangedLock = true;
                xImageSize.Value = image.Size.Width;
                yImageSize.Value = image.Size.Height;
                valueChangedLock = false;
            }
        }

        private void OnClearButtonPressed(object sender, EventArgs e) {
            previewTextBox.Clear();
        }

        private void OnSizeChanged(object sender, EventArgs e) {
            if (valueChangedLock == false) {
                OnClearButtonPressed(this, EventArgs.Empty);

                Bitmap newImage = ResizeImage(Clipboard.GetImage(), (int)xImageSize.Value, (int)yImageSize.Value);
                Clipboard.SetImage(newImage);

                OnPasteButtonPressed(this, EventArgs.Empty);
            }
        }

        public void OnInsertButtonPressed(object sender, EventArgs e) {
            if (previewTextBox.Text == "") {
                ProjectMemoConsole.CustomConsole.Log("Tried to insert " + mainTabControl.SelectedTab.Name + " but there is nothing in the preview window.");
                return;
            }

            //mPastedObject = Clipboard.GetDataObject();
            Close();
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height) {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage)) {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes()) {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
