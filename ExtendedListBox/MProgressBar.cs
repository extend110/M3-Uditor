using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M3Controls
{
    public partial class MProgressBar : ProgressBar
    {
        public Color BarColorOutside { get; set; }
        public Color BarColorCenter { get; set; }

        public MProgressBar()
        {
            BarColorOutside = Color.Black;
            BarColorCenter = Color.Yellow;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            //this.SetStyle(ControlStyles.ResizeRedraw, true);

            Maximum = 100;
            this.ForeColor = Color.Red;
            this.BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            // the part that has to be filled with a colored progress:
            int fillWidth = (Width * Value) / (Maximum - Minimum);
            if (fillWidth == 0)
            {    // nothing to fill
                return;
            }

            // the two rectangles:
            Rectangle topRect = new Rectangle(0, 0, fillWidth, Height / 2);
            Rectangle bottomRect = new Rectangle(0, Height / 2, fillWidth, Height / 2);

            // Paint upper half: the gradient fills the complete topRect,
            // from background color to foreground color
            LinearGradientBrush brush = new LinearGradientBrush(topRect, BarColorOutside,
                BarColorCenter, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(brush, topRect);
            brush.Dispose();

            // paint lower half: gradient fills the complete bottomRect,
            // from foreground color to background color
            brush = new LinearGradientBrush(bottomRect, BarColorCenter, BarColorOutside,
                LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(brush, bottomRect);
            brush.Dispose();

            // we have missed one line in the center: draw a line:
            
            Pen pen = new Pen(BarColorCenter);
            e.Graphics.DrawLine(pen, new Point(0, topRect.Bottom), new Point(fillWidth, topRect.Bottom));
            pen.Dispose();
            

            // if style is blocks, draw vertical lines to simulate blocks
            if (Style == ProgressBarStyle.Blocks)
            {
                int seperatorWidth = (int)(this.Height * 0.67);
                int NrOfSeparators = (int)(fillWidth / seperatorWidth);
                Color sepColor = ControlPaint.LightLight(BarColorCenter);

                for (int i = 1; i <= NrOfSeparators; i++)
                {
                    e.Graphics.DrawLine(new Pen(sepColor, 1),
                    seperatorWidth * i, 0, seperatorWidth * i, this.Height);
                }
            }
        }
    }
}
