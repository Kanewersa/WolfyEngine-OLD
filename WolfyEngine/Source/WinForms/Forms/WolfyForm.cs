using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DarkUI.Forms;
using WolfyCore.Controllers;

namespace WolfyEngine.Forms
{
    public partial class WolfyForm : DarkForm
    {
        public WolfyForm()
        {
            (new DropShadow()).ApplyShadows(this);

            InitializeComponent();

            //this.DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);

            // Don't load animations in design mode.
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            ControlBox = false;

            if (ProjectsController.Instance.Settings.SmoothForms)
            {
                Opacity = 0;
                FormHelper.Instance.FadeIn(this);

                FormClosing += delegate (object sender, FormClosingEventArgs e)
                {
                    if (Opacity != 0)
                    {
                        e.Cancel = true;
                        FormHelper.Instance.FadeOut(this, true);
                    }
                };
            }

            LoadTitle();
        }

        protected override void OnActivated(EventArgs e)
        {
            TitlePanel.OnGotFocus(this, e);
        }

        protected override void OnDeactivate(EventArgs e)
        {
            TitlePanel.OnLostFocus(this, e);
        }

        protected void LoadTitle()
        {
            TitlePanel.Title = Text;
        }

        const int WS_MINIMIZEBOX = 0x20000;
        const int CS_DBLCLKS = 0x8;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Transparent, Top());
            e.Graphics.FillRectangle(Brushes.Transparent, Left());
            e.Graphics.FillRectangle(Brushes.Transparent, Right());
            e.Graphics.FillRectangle(Brushes.Transparent, Bottom());
        }

        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTTOPLEFT = 13;
        private const int HTTOPRIGHT = 14;
        private const int HTBOTTOM = 15;
        private const int HTBOTTOMLEFT = 16;
        private const int HTBOTTOMRIGHT = 17;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x84)
            {
                var mp = this.PointToClient(Cursor.Position);

                if (TopLeft().Contains(mp))
                    m.Result = (IntPtr)HTTOPLEFT;
                else if (TopRight().Contains(mp))
                    m.Result = (IntPtr)HTTOPRIGHT;
                else if (BottomLeft().Contains(mp))
                    m.Result = (IntPtr)HTBOTTOMLEFT;
                else if (BottomRight().Contains(mp))
                    m.Result = (IntPtr)HTBOTTOMRIGHT;
                else if (Top().Contains(mp))
                    m.Result = (IntPtr)HTTOP;
                else if (Left().Contains(mp))
                    m.Result = (IntPtr)HTLEFT;
                else if (Right().Contains(mp))
                    m.Result = (IntPtr)HTRIGHT;
                else if (Bottom().Contains(mp))
                    m.Result = (IntPtr)HTBOTTOM;
            }
        }

        const int ImaginaryBorderSize = 8;

        public new Rectangle Top()
        {
            return new Rectangle(0, 0, this.ClientSize.Width, ImaginaryBorderSize);
        }

        public new Rectangle Left()
        {
            return new Rectangle(0, 0, ImaginaryBorderSize, this.ClientSize.Height);
        }

        public new Rectangle Bottom()
        {
            return new Rectangle(0, this.ClientSize.Height - ImaginaryBorderSize, this.ClientSize.Width, ImaginaryBorderSize);
        }

        public new Rectangle Right()
        {
            return new Rectangle(this.ClientSize.Width - ImaginaryBorderSize, 0, ImaginaryBorderSize, this.ClientSize.Height);
        }

        public Rectangle TopLeft()
        {
            return new Rectangle(0, 0, ImaginaryBorderSize, ImaginaryBorderSize);
        }

        public Rectangle TopRight()
        {
            return new Rectangle(this.ClientSize.Width - ImaginaryBorderSize, 0, ImaginaryBorderSize, ImaginaryBorderSize);
        }

        public Rectangle BottomLeft()
        {
            return new Rectangle(0, this.ClientSize.Height - ImaginaryBorderSize, ImaginaryBorderSize, ImaginaryBorderSize);
        }

        public Rectangle BottomRight()
        {
            return new Rectangle(this.ClientSize.Width - ImaginaryBorderSize, this.ClientSize.Height - ImaginaryBorderSize, ImaginaryBorderSize, ImaginaryBorderSize);
        }

        public class DropShadow
        {
            #region Shadowing

            #region Fields

            private bool _isAeroEnabled = false;
            private bool _isDraggingEnabled = false;
            private const int WM_NCHITTEST = 0x84;
            private const int WS_MINIMIZEBOX = 0x20000;
            private const int HTCLIENT = 0x1;
            private const int HTCAPTION = 0x2;
            private const int CS_DBLCLKS = 0x8;
            private const int CS_DROPSHADOW = 0x00020000;
            private const int WM_NCPAINT = 0x0085;
            private const int WM_ACTIVATEAPP = 0x001C;

            #endregion

            #region Structures

            [EditorBrowsable(EditorBrowsableState.Never)]
            public struct MARGINS
            {
                public int leftWidth;
                public int rightWidth;
                public int topHeight;
                public int bottomHeight;
            }

            #endregion

            #region Methods

            #region Public

            [DllImport("dwmapi.dll")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

            [DllImport("dwmapi.dll")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

            [DllImport("dwmapi.dll")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

            [EditorBrowsable(EditorBrowsableState.Never)]
            public static bool IsCompositionEnabled()
            {
                if (Environment.OSVersion.Version.Major < 6) return false;

                bool enabled;
                DwmIsCompositionEnabled(out enabled);

                return enabled;
            }

            #endregion

            #region Private

            [DllImport("dwmapi.dll")]
            private static extern int DwmIsCompositionEnabled(out bool enabled);

            [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
            private static extern IntPtr CreateRoundRectRgn
            (
                int nLeftRect,
                int nTopRect,
                int nRightRect,
                int nBottomRect,
                int nWidthEllipse,
                int nHeightEllipse
             );

            private bool CheckIfAeroIsEnabled()
            {
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    int enabled = 0;
                    DwmIsCompositionEnabled(ref enabled);

                    return (enabled == 1) ? true : false;
                }
                return false;
            }

            #endregion

            #region Overrides

            public void ApplyShadows(Form form)
            {
                var v = 2;

                DwmSetWindowAttribute(form.Handle, 2, ref v, 4);

                MARGINS margins = new MARGINS()
                {
                    bottomHeight = 1,
                    leftWidth = 0,
                    rightWidth = 0,
                    topHeight = 0
                };

                DwmExtendFrameIntoClientArea(form.Handle, ref margins);
            }

            #endregion

            #endregion

            #endregion
        }
    }
}
