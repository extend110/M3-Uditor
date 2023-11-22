using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M3Controls
{
    public class HeaderText : Control
    {
        //Public Properties
        [Category("M3 - Controls")]
        public int BottomLineHeight { get => _bottomLineHeight; set { _bottomLineHeight = value; this.Invalidate(); } }
        [Category("M3 - Controls")]
        public override string Text { get => base.Text; set { base.Text = value; Invalidate(); } }
        [Category("M3 - Controls")]
        public Color GradientColor { get { return _gradientColor; } set { _gradientColor = value; Invalidate(); } }
        [Category("M3 - Controls")]
        public bool Animate 
        {
            get { return _animate; }
            set
            {
                _animate = value;
                if ( value )
                {
                    _timer.Start();
                } 
                else
                {
                    _timer.Stop();
                }
            }
        }


        //Private Properties
        private int _bottomLineHeight = 1;
        private Color _gradientColor = Color.RoyalBlue;
        private bool _animate = false;

        //Internal Members
        internal Timer _timer;
        internal string _animationText = "";

        public HeaderText() 
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer, true);

            this.Dock = DockStyle.Top;
            
            _timer = new Timer();
            _timer.Interval = 500;
            _timer.Tick += _timer_Tick;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            Invalidate();

            if (_animationText == "...")
            {
                _animationText = "";
            } 
            else
            {
                _animationText += ".";
            }  
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            Graphics g = e.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

            g.FillRectangle(new LinearGradientBrush(this.ClientRectangle, GradientColor, Color.Transparent, 0f), this.ClientRectangle);

            //Get Text Height
            Size textSize = TextRenderer.MeasureText(this.Text, this.Font);

            //Draw Text
            if (_animate)
            {
                g.DrawString(this.Text + _animationText, this.Font, new SolidBrush(this.ForeColor),
                             this.Margin.Left,
                             (this.Height / 2) - (textSize.Height / 2));
            }
            else
            {
                g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor),
                             this.Margin.Left,
                             (this.Height / 2) - (textSize.Height / 2));
            }

            //Bottom Line
            g.FillRectangle(Brushes.Black, 0, this.Height - _bottomLineHeight, this.Width, _bottomLineHeight);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }
    }
}
