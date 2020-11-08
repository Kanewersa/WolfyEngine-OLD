using System;
using System.Drawing;
using System.Windows.Forms;


namespace WolfyEngine.Controls
{
    class DraggablePanel : Panel
    {
        private Point dragOffset;

        public DraggablePanel()
        {
            base.Dock = DockStyle.Top;
            base.Location = new Point(0, 0);
            base.Margin = new Padding(0);
            base.Height = 26;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                dragOffset = this.PointToScreen(e.Location);
                var form = FindForm();
                if (form == null)
                    throw new NullReferenceException("No parent form specified for " + this);
                
                var formLocation = form.Location;
                dragOffset.X -= formLocation.X;
                dragOffset.Y -= formLocation.Y;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Left)
            {
                var form = FindForm();
                if(form == null) throw new NullReferenceException("No parent form specified for " + this);
                Point newLocation = this.PointToScreen(e.Location);

                newLocation.X -= dragOffset.X;
                newLocation.Y -= dragOffset.Y;

                form.Location = newLocation;

                if (form.WindowState == FormWindowState.Maximized)
                    form.WindowState = FormWindowState.Normal;
                
            }
        }
    }
}
