using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M3Controls
{
    public partial class MProgressBar : ProgressBar
    {
        public Color ProgressBarColor { get; set; }
        public Font ProgressBarFont { get; set; }
       

        public MProgressBar()
        {
            ProgressBarColor = Color.RoyalBlue;
            ProgressBarFont = new Font("Segoe UI", 8);

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            Maximum = 100;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            int fillWidth = (Width * Value) / (Maximum - Minimum);
            string valueString = string.Format("{0}%", Value);
            Size stringSize = TextRenderer.MeasureText(valueString, ProgressBarFont);

            using ( SolidBrush backgroundBrush = new SolidBrush(Color.LightGray))
            using ( Pen borderPen = new Pen(Color.DarkSlateGray))
            using ( SolidBrush fillcolorBrush = new SolidBrush(ProgressBarColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, new Rectangle(0, 0, this.Width, this.Height));
                e.Graphics.FillRectangle(fillcolorBrush, 0, 0, fillWidth, this.Height);
                e.Graphics.DrawRectangle(borderPen, 0, 0, this.Width - 1, this.Height - 1);
                e.Graphics.DrawString(valueString, ProgressBarFont, Brushes.White, this.Width / 2 - stringSize.Width / 2, this.Height / 2 - stringSize.Height / 2);
            }
        }
    }
}
