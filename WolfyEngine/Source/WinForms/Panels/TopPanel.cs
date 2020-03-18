using System;
using System.Windows.Forms;

namespace WolfyEngine.Controls
{
    public partial class TopPanel : UserControl
    {
        public TopPanel()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if(ParentForm == null)
                throw new Exception("No parent form specified for " + this);

            ParentForm.Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            if (ParentForm == null)
                throw new Exception("No parent form specified for " + this);

            ParentForm.FormBorderStyle = FormBorderStyle.Sizable;
            ParentForm.WindowState = FormWindowState.Minimized;
        }
    }
}
