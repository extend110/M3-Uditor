using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace M3Controls
{
    public class ItemClickedEventArgs : EventArgs
    {
        public ListBoxItem Item;
        public int IconIndex;
        public Rectangle IconRectangle;
    }
    public class ExtendedListBox : ListBox
    {
        //Events
        public event EventHandler<ItemClickedEventArgs> IconClicked;
        //public event EventHandler<ListBoxItem> IconClicked;

        //Properties
        [Category("M3 - Controls")]
        public MStatusBar StatusBar {  get; set; }

        [Category("M3 - Controls")]
        public int ItemMargin
        {
            get
            {
                return _ItemMargin;
            }
            set
            {
                _ItemMargin = value;
            }
        }

        [Category("M3 - Controls")]
        public Font DescriptionFont
        {
            get
            {
                if (_DescriptionFont == null)
                {
                    return SystemFonts.DefaultFont;
                }
                return _DescriptionFont;
            }
            set
            {
                _DescriptionFont = value;
            }
        }

        [Category("M3 - Controls")]
        public bool HighlightHover { get { return _HighlightHover; } set { _HighlightHover = value; } }

        [Category("M3 - Controls")]
        public Color HighlightColor { get { return _HighlightColor; } set { _HighlightColor = value; } }

        [Category("M3 - Controls")]
        public float HighlightOpacity 
        { 
            get { return _HighlightOpacity; } 
            set 
            {
                if (value > 1.0f)
                {
                    _HighlightOpacity = 1.0f;
                }
                else if (value < 0.0f)
                {
                    _HighlightOpacity = 0.0f;
                }
                else
                {
                    _HighlightOpacity = value;
                }
            } 
        }

        [Category("M3 - Controls")]
        public bool HandleIconClick
        {
            get => _handleIconClick;
            set { _handleIconClick = value; }
        }

        [Category("M3 - Controls")]
        public int IconCount { get; set; }
        [Category("M3 - Controls")]
        public Size IconSize { get; set; }

        private int _ItemMargin = 15;
        private Font _DescriptionFont;

        private bool _HighlightHover;
        private Color _HighlightColor;
        private float _HighlightOpacity;

        private bool _handleIconClick = false;

        public ExtendedListBox()
        {
            this.SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint,
                true);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if ( DesignMode || e.Index == -1 || Items.Count == 0) return;
            
            // get the item to draw
            ListBoxItem item = Items[e.Index] as ListBoxItem;

            string Title = item.Title;
            string Description = item.Description;

            //TODO Truncate for display
            int descriptionLength = TextRenderer.MeasureText(Description + "...", _DescriptionFont).Width;
            int maxTextWidth = Width - (32 * (IconCount * 2));
            if (descriptionLength > maxTextWidth)
            {
                int i = Description.Length;
                while (TextRenderer.MeasureText(Description + "...", _DescriptionFont).Width > maxTextWidth)
                {
                    Description = Description.Substring(0, --i);
                    if (i == 0) break;
                }
                Description = Description + "...";
            }

            // draw background
            e.DrawBackground();

            // draw this if item is selected
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new LinearGradientBrush(e.Bounds, Color.RoyalBlue, Color.Transparent, 180f), e.Bounds);
                e.Graphics.DrawString(Title, this.Font, Brushes.White, e.Bounds.Left + 10, e.Bounds.Top + ItemMargin - (Font.Height / 2));
                e.Graphics.DrawString(Description, this.DescriptionFont, Brushes.LightGray, e.Bounds.Left + 10, e.Bounds.Top + ItemMargin + (DescriptionFont.Height / 2), StringFormat.GenericTypographic);
            }
            else
            {
                //e.Graphics.FillRectangle(new LinearGradientBrush(e.Bounds, item.BackColor, Color.Transparent, 0f), e.Bounds);

                // highlight item on mousehover
                if (e.Bounds.Contains(PointToClient(Cursor.Position)))
                {
                    using (LinearGradientBrush br = new LinearGradientBrush(e.Bounds, Color.FromArgb((int)(_HighlightOpacity * 255), _HighlightColor), Color.Transparent, 180))
                    {
                        if (_HighlightHover)
                            e.Graphics.FillRectangle(br, e.Bounds.X + 5, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                    }
                }

                // draw the item title and item description
                using (SolidBrush br = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(Title, this.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top + ItemMargin - (Font.Height / 2));
                    e.Graphics.DrawString(Description, this.DescriptionFont, Brushes.LightGray, e.Bounds.Left, e.Bounds.Top + ItemMargin + (DescriptionFont.Height / 2));
                }
            }

            // draw the focus rectangle if appropriate
            e.DrawFocusRectangle();

            // call method for overriding
            //item.OnDrawItem(e);

            // base drawing
            base.OnDrawItem(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle clipRectangle = e.ClipRectangle;
            Region iRegion = new Region(clipRectangle);

            e.Graphics.FillRegion(new SolidBrush(this.BackColor), iRegion);

            if (this.Items.Count > 0)
            {
                int idx1 = IndexFromPoint(ClientRectangle.Location);
                int idx2 = IndexFromPoint(ClientRectangle.Location.X, ClientRectangle.Location.Y + ClientRectangle.Height - 5);

                if ( idx2 == -1 ) idx2 = Items.Count - 1;

                for (int i = idx1; i <= idx2; i++)
                {
                    Rectangle irect = this.GetItemRectangle(i);

                    if (e.ClipRectangle.IntersectsWith(irect))
                    {
                        if ((this.SelectionMode == SelectionMode.One && this.SelectedIndex == i)
                        || (this.SelectionMode == SelectionMode.MultiSimple && this.SelectedIndices.Contains(i))
                        || (this.SelectionMode == SelectionMode.MultiExtended && this.SelectedIndices.Contains(i)))
                        {
                            OnDrawItem(new DrawItemEventArgs(e.Graphics, this.Font,
                                irect, i,
                                DrawItemState.Selected, this.ForeColor,
                                this.BackColor));
                        }
                        else
                        {                           
                            OnDrawItem(new DrawItemEventArgs(e.Graphics, this.Font,
                                irect, i,
                                DrawItemState.Default, this.ForeColor,
                                this.BackColor));                           
                        }
                        iRegion.Complement(irect);
                    }
                }
            }
            base.OnPaint(e);
        }
        protected override void OnResize(EventArgs e)
        {
            if ( StatusBar != null )
            {
                StatusBar.Location = new Point(this.Location.X, this.Location.Y + Height - 1 );
                StatusBar.Width = Width;
            }
            base.OnResize(e);
        }
        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            // Get the item.           
            string txt = DesignMode ? this.Name : this.Items[e.Index].ToString();

            // Measure the string.
            SizeF txt_size = e.Graphics.MeasureString(txt, this.Font);

            // Set the required size.
            e.ItemHeight = (int)txt_size.Height + 2 * ItemMargin;
            e.ItemWidth = (int)txt_size.Width;
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (_handleIconClick)
            {
                int index = IndexFromPoint(e.Location);
                if (Items.Count == 0 || index < 0) { return; }

                ListBoxItem item = Items[index] as ListBoxItem;
                Rectangle _iconRect = GetItemRectangle(index);

                for (int i = 0; i <= IconCount; ++i)
                {
                    Rectangle clickedIconRect = new Rectangle(_iconRect.Right - IconSize.Width * 2 * i, 
                                              _iconRect.Top + ItemMargin, 
                                              IconSize.Width, IconSize.Height);

                    clickedIconRect.Inflate(10, 10);
                    if (e.Button == MouseButtons.Left)
                    {
                        if (clickedIconRect.Contains(e.Location))
                        {
                            OnIconClicked(item, i, clickedIconRect);
                            break;
                        }
                    }
                }
            }
            base.OnMouseClick(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (Items.Count > 0)
            {
                int index = IndexFromPoint(e.Location);
                if (index == -1) return;

                Rectangle rectangle = GetItemRectangle(index);
                Rectangle icon = new Rectangle(rectangle.Right - 32, rectangle.Top + ItemMargin, IconSize.Width, IconSize.Height);

                for (int i = 0; i <= IconCount; ++i)
                {
                    icon = new Rectangle(rectangle.Right - IconSize.Width * 2 * i,
                                         rectangle.Top + ItemMargin,
                                         IconSize.Width, IconSize.Height);

                    icon.Inflate(10, 10);
                    if (icon.Contains(e.Location) && _handleIconClick)
                    {
                        Cursor = Cursors.Hand;
                        break;
                    }
                    else
                    {
                        Cursor = Cursors.Default;
                    }                 
                }
                Invalidate(ClientRectangle);
            }
            base.OnMouseMove(e);
        }
        
        private void OnIconClicked(ListBoxItem item, int iconIndex, Rectangle rect)
        {
            var handler = IconClicked;
            if (handler != null)
            {
                ItemClickedEventArgs args = new ItemClickedEventArgs() { Item = item, IconIndex = iconIndex, IconRectangle = rect };
                handler(this, args);
            }
        }

    }
}
