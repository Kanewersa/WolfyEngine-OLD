using System;
using System.Drawing;
using System.Windows.Forms;

namespace DarkUI.Controls
{
    public partial class ToolTipButton : UserControl
    {
        private DarkToolTip ToolTip { get; set; }
        private Point ToolTipPosition { get; set; }

        public string ToolTipText { get; set; }
        

        public ToolTipButton()
        {
            InitializeComponent();

            ToolTipPosition = Location;

            ToolTip = new DarkToolTip(ToolTipPosition, Size);

            MouseEnter += ToolTipButton_MouseEnter;
            MouseLeave += ToolTipButton_MouseLeave;
        }

        private void ToolTipButton_MouseLeave(object sender, EventArgs e)
        {
            ToolTip.Hide(this);
        }

        private void ToolTipButton_MouseEnter(object sender, EventArgs e)
        {
            ToolTip.Show(ToolTipText, this, ToolTip.Location);
        }
    }
}
