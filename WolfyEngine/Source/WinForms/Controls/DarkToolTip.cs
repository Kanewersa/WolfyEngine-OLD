using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace DarkUI.Controls
{
    public class DarkToolTip : ToolTip
    {
        /// <summary>
        /// Determines the maximum width of the popup.
        /// </summary>
        private const int MaxWidth = 300;

        /// <summary>
        /// Used not to draw text on or too close to the border.
        /// </summary>
        private const int FontDisplayOffset = 6;

        /// <summary>
        /// Offsets the popup x position.
        /// </summary>
        private const int PopupHeightOffset = -2;

        /// <summary>
        /// Width of the popup.
        /// </summary>
        private int Width { get; set; }

        /// <summary>
        /// Height of the popup.
        /// </summary>
        private int Height { get; set; }

        /// <summary>
        /// Formatted, multiline tooltip text.
        /// </summary>
        private List<string> Titles { get; set; }

        /// <summary>
        /// Count of lines in tooltip text.
        /// </summary>
        private int Rows => Titles.Count;

        /// <summary>
        /// Coordinates on which tooltip should be displayed.
        /// </summary>
        public Point Location { get; private set; }


        /// <summary>
        /// Size of the parent control.
        /// </summary>
        public Size ParentSize { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DarkToolTip(Point location = new Point(), Size parentSize = new Size())
        {
            OwnerDraw = true;

            Popup += OnPopup;
            Draw += OnDraw;

            Location = location;
            ParentSize = parentSize;
        }

        private void OnPopup(object sender, PopupEventArgs e)
        {
            // Set the target size of popup
            if (Width == 0 || Height == 0)
            {
                e.ToolTipSize = new Size(1, 1);
                return;
            }

            e.ToolTipSize = new Size(Width, Height);
        }

        private void OnDraw(object sender, DrawToolTipEventArgs e)
        {
            Graphics g = e.Graphics;

            if (Width == 0)
            {
                // Format the ToolTipText to be multiline.
                Titles = GetTitlePerRow(e.ToolTipText, e.Font);

                SizeF size = g.MeasureString(e.ToolTipText, e.Font, MaxWidth + FontDisplayOffset * 2);

                // Set width and height of popup.
                Width = (int) Math.Ceiling(size.Width);
                if (Width < MaxWidth)
                {
                    Width += FontDisplayOffset * 2;
                }

                Height = (int) Math.Ceiling(size.Height);

                // Calculate proper location
                var x = Location.X - Width / 2 + ParentSize.Width / 2;
                var y = Location.Y - Height + PopupHeightOffset;
                Location = new Point(x, y);

                // Hide and show popup again to use proper width and height.
                Hide(e.AssociatedControl);
                Show(e.ToolTipText, e.AssociatedWindow, Location);

                return;
            }

            // Set up the brushes
            Brush backgroundBrush = new SolidBrush(Color.FromArgb(47, 49, 51));
            Brush borderBrush = new SolidBrush(Color.FromArgb(34, 37, 38));
            Brush textBrush = new SolidBrush(Color.White);

            // Draw the background
            g.FillRectangle(backgroundBrush, e.Bounds);

            // Draw the border
            g.DrawRectangle(new Pen(borderBrush, 1), new Rectangle(e.Bounds.X, e.Bounds.Y,
                e.Bounds.Width - 1, e.Bounds.Height - 1));

            // Draw the formatted title
            for (int i = 0; i < Rows; i++)
            {
                // Draw the text
                g.DrawString(Titles[i], new Font(e.Font, FontStyle.Regular), textBrush,
                    new PointF(e.Bounds.X + FontDisplayOffset, Height/Rows * i));
            }
            
            // Get rid of the brushes
            backgroundBrush.Dispose();
            borderBrush.Dispose();
            textBrush.Dispose();
        }

        private List<string> GetTitlePerRow(string title, Font font)
        {
            List<string> titles = new List<string>();

            while (title.Length > 0)
            {
                string subTitle = string.Empty;

                while (TextRenderer.MeasureText(subTitle, font).Width < MaxWidth && title.Length > 0)
                {
                    subTitle += title.Substring(0, 1);

                    title = title.Remove(0, 1);
                }

                if (title.Length > 0)
                {
                    if (title[0] == ' ')
                    {
                        while (title[0] == ' ')
                        {
                            title = title.Remove(0, 1);
                        }
                    }
                    else
                    {
                        for (int j = subTitle.Length - 1; j > 0; j--)
                        {
                            if (subTitle[j] == ' ')
                            {
                                title = title.Insert(0, subTitle.Substring(j + 1, subTitle.Length - j - 1));
                                subTitle = subTitle.Remove(j, subTitle.Length - j);
                                break;
                            }
                        }
                    }
                }

                titles.Add(subTitle);
            }

            return titles;
        }
    }
}
