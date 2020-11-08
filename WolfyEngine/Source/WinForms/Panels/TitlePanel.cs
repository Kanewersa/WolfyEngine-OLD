using System;
using System.Drawing;
using System.Windows.Forms;

namespace WolfyEngine.Controls
{
    public partial class TitlePanel : UserControl
    {
        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                WindowTitle.Text = value;
            }
        }

        public TitlePanel()
        {
            InitializeComponent();

            /*GotFocus += OnGotFocus;
            LostFocus += OnLostFocus;*/
        }

        public void OnLostFocus(object sender, EventArgs e)
        {
            DraggablePanel.BackColor = Color.FromArgb(64, 64, 64);
            MinimizeButton.BackColor = Color.FromArgb(64, 64, 64);
            MaximizeButton.BackColor = Color.FromArgb(64, 64, 64);
            ExitButton.BackColor = Color.FromArgb(64, 64, 64);
        }

        public void OnGotFocus(object sender, EventArgs e)
        {
            DraggablePanel.BackColor = Color.FromArgb(48, 48, 48);
            MinimizeButton.BackColor = Color.FromArgb(48, 48, 48);
            MaximizeButton.BackColor = Color.FromArgb(48, 48, 48);
            ExitButton.BackColor = Color.FromArgb(48, 48, 48);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if(ParentForm == null)
                throw new NullReferenceException("No parent form specified for " + this);

            ParentForm.Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            if (ParentForm == null)
                throw new NullReferenceException("No parent form specified for " + this);

            ParentForm.WindowState = FormWindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            if (ParentForm == null) throw new NullReferenceException("No parent form specified for " + this);

            ParentForm.WindowState =
                ParentForm.WindowState == FormWindowState.Maximized
                    ? FormWindowState.Normal
                    : FormWindowState.Maximized;
        }

        private void OnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ParentForm == null) throw new NullReferenceException("No parent form specified for " + this);

            ParentForm.WindowState =
                ParentForm.WindowState == FormWindowState.Maximized
                    ? FormWindowState.Normal
                    : FormWindowState.Maximized;
        }
    }
}
