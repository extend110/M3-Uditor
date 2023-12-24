using M3Controls.Extensions;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace M3Controls
{
    public class MSideBarItemCollection : System.Collections.ObjectModel.Collection<MSideBarItem>
    {
    }

    [Serializable]
    public class MSideBarItem
    {
        public Color ForeColor { get => _forecolor; set { _forecolor = value; _forecolorOriginal = value; } }
        public Color BackgroundColor { get => _backcolor; set { _backcolor = value; _backcolorOriginal = value; } }

        public Color HighlightTextColor { get; set; }
        public Color HighlightBackgroundColor { get; set; }

        public string Text { get; set; }
        public Image Image { get; set; }

        public MSideBarItem() 
        {
            _textOffsetTarget = 15;

            BackgroundColor = Color.Transparent;
            ForeColor = Color.WhiteSmoke;
        }

        internal Rectangle Bounds { get; set; }
        internal bool Highlight { get; set; }
        internal bool HighlightBackground { get; set; }

        internal Color _forecolor, _forecolorOriginal;
        internal Color _backcolor, _backcolorOriginal;

        internal float _textOffset = 0f;
        internal float _textOffsetTarget {  get; set; }

        internal void Update()
        {
            if (Highlight)
            {
                _forecolor = GraphicsExtension.Lerp(_forecolor, HighlightTextColor, 0.08f);
                _backcolor = GraphicsExtension.Lerp(_backcolor, Color.FromArgb(180, HighlightBackgroundColor), 0.08f);
                _textOffset = MathF.Lerp(_textOffset, _textOffsetTarget, 0.5f);
            }
            else
            {
                _forecolor = GraphicsExtension.Lerp(_forecolor, _forecolorOriginal, 0.08f);
                _backcolor = GraphicsExtension.Lerp(_backcolor, _backcolorOriginal, 0.08f);
                _textOffset = MathF.Lerp(_textOffset, 0, 0.5f);
            }
        }
        internal void Render(Graphics g, Rectangle r, Font font, Size textSize)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int imageHeight = 32;

            using (SolidBrush brushBackground = new SolidBrush(_backcolor))
            using (SolidBrush brushForeground = new SolidBrush(_forecolor))
            {
                g.FillRectangle(brushBackground, r);

                if (Image != null)
                {
                    g.DrawImage(Image, 10, (r.Y + r.Height / 2) - imageHeight / 2, imageHeight, imageHeight);
                    g.DrawString(this.Text, font, brushForeground, r.Width - textSize.Width - _textOffset, (r.Y + r.Height / 2) - textSize.Height / 2);
                }
                else
                {
                    g.DrawString(this.Text, font, brushForeground, 10 + _textOffset, (r.Y + r.Height / 2) - textSize.Height / 2);
                }
            }
        }
    }

    public class MSideBar : Control
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public MSideBarItemCollection Items
        {
            get
            {
                Invalidate();
                return mSideBarItems;
            }
        }

        public string HeaderText { get; set; }
        public Color BackgroundColor 
        {
            get => backgroundColor;
            set
            {
                backgroundColor = value;
                Invalidate();
            }
        }
        public int VerticalSpacing { get; set; }
        public new int Padding { get; set; }
        public int HeaderSpace { get; set; }

        private Color backgroundColor;
        private MSideBarItemCollection mSideBarItems = new MSideBarItemCollection();

        internal Timer timer;

        // events
        public event EventHandler<MSideBarItem> ItemClicked;

        public MSideBar() 
        {
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;

            this.Font = new Font("Segoe UI", 18);
            BackgroundColor = Color.RoyalBlue;
            VerticalSpacing = 2;
            Padding = 20;

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | 
                     ControlStyles.UserPaint, true);

            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var item in mSideBarItems)
            {
                item.Update();
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (LinearGradientBrush brushBackground = new LinearGradientBrush(this.ClientRectangle, BackgroundColor, Color.Black, 90f))
            {
                e.Graphics.FillRectangle(brushBackground, this.ClientRectangle);
            }
      
            int y = HeaderSpace;
            if (HeaderSpace > 2)
            {
                float headerTextHeight = TextRenderer.MeasureText(HeaderText, Font).Height;
                e.Graphics.DrawString(HeaderText, Font, Brushes.WhiteSmoke, 10, HeaderSpace / 2 - headerTextHeight / 2);
                e.Graphics.DrawLine(new Pen(Color.DimGray, 1), 0, HeaderSpace - 2, this.Width, HeaderSpace - 2);
                e.Graphics.DrawLine(new Pen(Color.LightGray, 1), 0, HeaderSpace - 1, this.Width, HeaderSpace - 1);
                e.Graphics.DrawLine(new Pen(Color.DimGray, 1), 0, HeaderSpace, this.Width, HeaderSpace);
            }

            foreach (var item in mSideBarItems)
            {
                Size textSize = TextRenderer.MeasureText(item.Text, Font);
                Rectangle itemRect = new Rectangle(0, y, this.Width, textSize.Height + Padding);

                item.Bounds = itemRect;
                
                if ( item.Text != "{spacer}" )
                    item.Render(e.Graphics, itemRect, Font, textSize);

                y += textSize.Height + Padding + VerticalSpacing;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            foreach (var item in mSideBarItems)
            {
                item.Highlight = item.Bounds.Contains(e.Location) ? true : false;
            }
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            foreach (var item in mSideBarItems)
            {
                item.Highlight = false;
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            foreach (var item in mSideBarItems)
            {
                if ( item.Bounds.Contains(e.Location))
                {
                    ItemClicked?.DynamicInvoke(new object[] { this, item});
                }
            }
        }
    }
}
