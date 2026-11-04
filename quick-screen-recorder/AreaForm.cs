using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace quick_screen_recorder
{
    public partial class AreaForm : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private Point startPos;
        private Size curSize;
        private System.Timers.Timer resizeTimer = new System.Timers.Timer();
        private int maxWidth = 4096;
        private int maxHeight = 4096;

        public AreaForm()
        {
            InitializeComponent();

            resizeTimer.Elapsed += new ElapsedEventHandler(resizeTimer_Elapsed);
            resizeTimer.Interval = 40;
        }

        private void resizeTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (this.IsDisposed || !this.IsHandleCreated) return;
            try
            {
                this.BeginInvoke((MethodInvoker)(() =>
                {
                    if (this.IsDisposed) return;
                    Point curPos = this.PointToClient(Cursor.Position);

                    int newWidth = curSize.Width + curPos.X - startPos.X;
                    int newHeight = curSize.Height + curPos.Y - startPos.Y;

                    if (newWidth < 160) newWidth = 160;
                    if (newHeight < 160) newHeight = 160;
                    if (newWidth > maxWidth) newWidth = maxWidth;
                    if (newHeight > maxHeight) newHeight = maxHeight;

                    MainForm ownerMain = this.Owner as MainForm;
                    if (ownerMain != null)
                    {
                        ownerMain.SetAreaWidth(newWidth);
                        ownerMain.SetAreaHeight(newHeight);
                    }
                }));
            }
            catch { }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
        }

        private void AreaForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point downPos = this.PointToClient(Cursor.Position);
                if (downPos.X > dragBtn.Location.X && downPos.X < dragBtn.Location.X + dragBtn.Width &&
                    downPos.Y > dragBtn.Location.Y && downPos.Y < dragBtn.Location.Y + dragBtn.Height)
                {
                    Cursor.Current = Cursors.SizeNWSE;
                    startPos = downPos;
                    curSize = this.Size;
                    resizeTimer.Start();
                }
                else
                {
                    Cursor.Current = Cursors.SizeAll;
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }

        private void AreaForm_MouseUp(object sender, MouseEventArgs e)
        {
            resizeTimer.Stop();
            Cursor.Current = Cursors.Default;
        }

        private void AreaForm_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                this.Refresh();
                MainForm ownerMain = this.Owner as MainForm;
                if (ownerMain != null)
                {
                    ownerMain.SetMaximumX(Math.Max(0, maxWidth - this.Width));
                    ownerMain.SetMaximumY(Math.Max(0, maxHeight - this.Height));
                }
            }
            catch { }
        }

        private void AreaForm_LocationChanged(object sender, EventArgs e)
        {
            try
            {
                MainForm ownerMain = this.Owner as MainForm;
                if (ownerMain != null)
                {
                    ownerMain.SetAreaX(this.Left);
                    ownerMain.SetAreaY(this.Top);
                }
            }
            catch { }
        }

        public void SetMaximumArea(int maxW, int maxH)
        {
            maxWidth = Math.Max(160, maxW);
            maxHeight = Math.Max(160, maxH);
        }

        private void AreaForm_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Left < 0) this.Left = 0;
            if (this.Top < 0) this.Top = 0;

            if (this.Left + this.Width > maxWidth) this.Left = Math.Max(0, maxWidth - this.Width);
            if (this.Top + this.Height > maxHeight) this.Top = Math.Max(0, maxHeight - this.Height);
        }
    }
}
