using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProjectMemo.CustomControls {
    public partial class CustomFilesListBox : ListBox {

        public long TimeSinceLastUpdate { get; set; }

        public CustomFilesListBox() {

            InitializeComponent();
        }

        protected override void OnDrawItem(DrawItemEventArgs e) {
            //base.OnDrawItem(e);

            e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);

            /*
            if (SelectedIndex == e.Index) {
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), e.Bounds);
            }*/

            if (e.Index < 0 || e.Index >= Items.Count) {
                return;
            }

            string dir = (string)Items[e.Index];

            Icon icon = Icon.ExtractAssociatedIcon(dir);

            Rectangle iconRect = new Rectangle(0, 0, 24, 24);
            float spacing = (e.Bounds.Height - iconRect.Height) / 2.0f;
            iconRect.X = e.Bounds.X + 3;
            iconRect.Y = e.Bounds.Y + (int)spacing;
            e.Graphics.DrawIcon(icon, iconRect);

            RectangleF stringRect = e.Bounds;
            stringRect.Width -= (iconRect.X + iconRect.Width + 5);
            stringRect.X += (iconRect.X + iconRect.Width + 5);
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;

            string[] stringSplit = ((string)Items[e.Index]).Split('\\');

            e.Graphics.DrawString(stringSplit[stringSplit.Length - 1], Font, Brushes.Black, stringRect, format);
        }

        protected override void OnSelectedIndexChanged(EventArgs e) {
            base.OnSelectedIndexChanged(e);
        }

        protected override void OnDoubleClick(EventArgs e) {
            base.OnDoubleClick(e);

            if (SelectedItem == null) {
                return;
            }

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C start " + (string)Items[SelectedIndex];
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            process.StartInfo = startInfo;
            process.Start();

            string outputString = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            ProjectMemoConsole.CustomConsole.Log("Using CMD to open resource file");
            Console.WriteLine("[ " + outputString + " ]");
        }
    }
}
