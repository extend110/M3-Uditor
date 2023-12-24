using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M3Controls
{
    public class MStatusBarItemCollection : System.Collections.ObjectModel.Collection<MStatusBarItem> 
    {
    }

    [Serializable]
    public class MStatusBarItem
    {
        public enum Alignment
        {
            Left,
            Right
        }
        public enum ItemType
        {
            Text,
            Button,
            Link
        }

        public MStatusBarItem() 
        {
            ForeColor = Color.Black;
            BackColor = Color.Transparent;
            Type = ItemType.Text;
            Visible = true;

            Name = this.Name;
        }

        public Color ForeColor 
        {
            get
            {
                if (_foreColor.IsEmpty)
                    return Color.Black;

                return _foreColor;
            }
            set => _foreColor = value;
        }
        public Color BackColor
        {
            get
            {
                return _backColor;
            }
            set => _backColor = value;
        }
        public Alignment Float { get; set; }

        public string Text { get => _text; set { _text = value; Parent.Invalidate(); } }
        public string Name { get; set; }
        public bool Visible { get; set; }

        public Padding Padding { get; set; }
        public ItemType Type { get; set; }

        private Color _foreColor, _backColor;

        internal Rectangle Bounds;
        internal bool OnHover;
        internal string _text;

        [NonSerialized]
        internal MStatusBar Parent;
    }

    public class MStatusBar : StatusBar
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public MStatusBarItemCollection Items
        {
            get 
            {
                Invalidate();
                return mStatusBarItems; 
            }
        }

        public Color Bordercolor { get; set; }
        public Color BackgroundColor { get; set; }
        public int BorderWidth { get; set; }
        public bool BorderLeft { get; set; }
        public bool BorderRight { get; set; }
        public bool BorderTop { get; set; }
        public bool BorderBottom { get; set; }

        // private members
        private MStatusBarItemCollection mStatusBarItems = new MStatusBarItemCollection();

        public MStatusBar() 
        {
            Font = new System.Drawing.Font("Segoe UI", 8f);
            Bordercolor = Color.Silver;
            BorderTop = true;
            BorderWidth = 2;

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        public MStatusBarItem GetItem(string name)
        {
            return mStatusBarItems.Where(item => item.Name == name).FirstOrDefault();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

            using (SolidBrush brushBackgroundColor = new SolidBrush(BackgroundColor))
                e.Graphics.FillRectangle(brushBackgroundColor, ClientRectangle);

            int _textCenter = GetCenterText();

            int _posFloatLeft = 0;
            int _posFloatRight = Width;

            using ( Pen pen = new Pen(Bordercolor, BorderWidth))
            {
                if (BorderTop) e.Graphics.DrawLine(pen, 0, 0, Width, 0);
                if (BorderBottom) e.Graphics.DrawLine(pen, 0, Height - 1, Width, Height - 1);
                if (BorderLeft) e.Graphics.DrawLine(pen, 0, 0, 0, Height - 1);
                if (BorderRight) e.Graphics.DrawLine(pen, Width, 0, Width, Height - 1);
            }

            for (int i = 0; i < mStatusBarItems.Count; i++)
            {
                MStatusBarItem item = mStatusBarItems[i];
                Size _itemSize = TextRenderer.MeasureText(item.Text, Font);

                item.Parent = this;

                if (!item.Visible)
                    continue;

                using (SolidBrush brushBackColor = new SolidBrush(item.BackColor))
                using (SolidBrush brushForeColor = new SolidBrush(item.ForeColor))
                {
                    if (item.Float == MStatusBarItem.Alignment.Left)
                    {
                        item.Bounds = new Rectangle(_posFloatLeft, 0 + BorderWidth - 1, _itemSize.Width + item.Padding.Left, this.Height - BorderWidth);

                        if ( item.OnHover )
                            brushBackColor.Color = ControlPaint.Light(item.BackColor);

                        e.Graphics.FillRectangle(brushBackColor, item.Bounds);

                        switch (item.Type)
                        {
                            case MStatusBarItem.ItemType.Text:
                                e.Graphics.DrawString(item.Text, Font, brushForeColor, _posFloatLeft + item.Padding.Left / 2, _textCenter);
                                break;
                            case MStatusBarItem.ItemType.Button:
                                e.Graphics.DrawString(item.Text, Font, brushForeColor, _posFloatLeft + item.Padding.Left / 2, _textCenter);
                                break;
                            case MStatusBarItem.ItemType.Link:
                                e.Graphics.DrawString(item.Text, Font, Brushes.Blue, _posFloatLeft + item.Padding.Left / 2, _textCenter);
                                e.Graphics.DrawLine(Pens.Blue, _posFloatLeft + item.Padding.Left / 2, _textCenter + _itemSize.Height, _itemSize.Width + item.Padding.Left / 2, _textCenter + _itemSize.Height);
                                break;
                            default:
                                break;
                        }

                        _posFloatLeft += item.Bounds.Width;
                    }
                    else if (item.Float == MStatusBarItem.Alignment.Right)
                    {
                        _posFloatRight -= _itemSize.Width + item.Padding.Left;
                        item.Bounds = new Rectangle(_posFloatRight, 0 + BorderWidth - 1, _itemSize.Width + item.Padding.Left, this.Height - BorderWidth);

                        e.Graphics.FillRectangle(brushBackColor, item.Bounds);
                        e.Graphics.DrawString(item.Text, Font, brushForeColor, _posFloatRight + item.Padding.Left / 2, _textCenter);
                    }
                }
            }

            ControlPaint.DrawSizeGrip(e.Graphics, DefaultBackColor, ClientRectangle.Width - 10, 0, 10, ClientRectangle.Height);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Cursor = Cursors.Default;
            foreach (MStatusBarItem item in mStatusBarItems)
            {
                item.OnHover = false;
                if (item.Bounds.Contains(e.Location))
                {
                    switch (item.Type)
                    {
                        case MStatusBarItem.ItemType.Text:
                            Cursor = Cursors.Default;
                            break;
                        case MStatusBarItem.ItemType.Button:
                            item.OnHover = true;
                            break;
                        case MStatusBarItem.ItemType.Link:
                            Cursor = Cursors.Hand;
                            break;
                    }
                }
            }

            Invalidate();
        }

        private int GetCenterText()
        {
            return (Height / 2) - ( Font.Height / 2 );
        }
    }
}
