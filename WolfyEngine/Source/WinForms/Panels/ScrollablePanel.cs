using System;
using System.Windows.Forms;

namespace WolfyEngine.Controls
{
    public class ScrollablePanel : Panel
    {
        protected override System.Drawing.Point ScrollToControl(Control activeControl)
        {
            // When there's only 1 control in the panel and the user clicks
            //  on it, .NET tries to scroll to the control. This invariably
            //  forces the panel to scroll up. This little hack prevents that.
            return this.DisplayRectangle.Location;
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            this.Invalidate();
            base.OnScroll(se);
        }
    }
}
