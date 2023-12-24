using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Navigation;
using static M3Controls.ExtendedListBox;
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
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetScrollPos(IntPtr hWnd, int nBar);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        protected static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        protected const int WM_VSCROLL = 0x115;
        public enum ScrollCommand : int { Up = 0x0, Down = 0x1, EndScroll = 0x8 }
        public enum ScrollBarDirection : int { Horizontal = 0x0, Vertical = 0x1 }
        private ScrollCommand _scrollCommand;

        Timer _scrollTimer;

        //Events
        public event EventHandler<ItemClickedEventArgs> IconClicked;

        //Properties
        public bool AutoScroll { get; set; }

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
        public Color DescriptionColor
        {
            get
            {
                if (_DescriptionFont == null)
                {
                    return SystemColors.WindowText;
                }
                return _DescriptionColor;
            }
            set
            {
                _DescriptionColor = value;
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

        public bool ShowIndex { get => _showIndex; 
            set 
            {
                _showIndex = value;
                _showIndexMargin = value == true ? 30 : 0;
            } 
        }
        public bool HasItems
        {
            get
            {
                return this.Items.Count > 0;
            }
        }
        public string NoItemsMessage { get; set; }

        private int _showIndexMargin = 0;
        private bool _showIndex = false;

        private int _ItemMargin = 15;
        private Font _DescriptionFont;

        private bool _HighlightHover;
        private Color _HighlightColor;
        private float _HighlightOpacity;

        private Color _DescriptionColor;

        private bool _handleIconClick = false;

        public ExtendedListBox()
        {
            DoubleBuffered = true;
      
            _scrollTimer = new Timer() { Interval = 20 };
            _scrollTimer.Tick += _scrollTimer_Tick;

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint,
                true);
        }

        public void Scroll(ScrollCommand scrollCommand)
        {
            if (!AutoScroll) return;

            _scrollCommand = scrollCommand;

            switch (_scrollCommand)
            {
                case ScrollCommand.Up:
                    if (!_scrollTimer.Enabled) _scrollTimer.Start();
                    break;
                case ScrollCommand.Down:
                    if (!_scrollTimer.Enabled) _scrollTimer.Start();
                    break;
                case ScrollCommand.EndScroll:
                    if (_scrollTimer.Enabled) _scrollTimer.Stop();
                    break;
            }
        }

        private void _scrollTimer_Tick(object sender, EventArgs e)
        {
            SendMessage((IntPtr)Handle, WM_VSCROLL, (IntPtr)_scrollCommand, IntPtr.Zero);
            SendMessage((IntPtr)Handle, WM_VSCROLL, (IntPtr)ScrollCommand.EndScroll, IntPtr.Zero);
        }

        private string TruncateString(string text, Font font)
        {
            string truncatedText = text;
            int descriptionLength = TextRenderer.MeasureText(truncatedText + "...", font).Width;
            int maxTextWidth = Width - (32 * (IconCount * 2));
            if (descriptionLength > maxTextWidth)
            {
                int i = truncatedText.Length;
                while (TextRenderer.MeasureText(truncatedText + "...", font).Width > maxTextWidth)
                {
                    truncatedText = truncatedText.Substring(0, --i);
                    if (i == 0) break;
                }
                truncatedText = truncatedText + "...";
            }
            return truncatedText;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if ( DesignMode || e.Index == -1 || Items.Count == 0) return;
            
            // get the item to draw
            ListBoxItem item = Items[e.Index] as ListBoxItem;
            item.Bounds = e.Bounds;

            string Title = TruncateString(item.Title, Font);
            string Description = TruncateString(item.Description, DescriptionFont);

            // draw background
            e.DrawBackground();

            // setting up brushes
            using (SolidBrush brushTitle = new SolidBrush(item.ColorTitle))
            using (SolidBrush brushDescription = new SolidBrush(item.ColorDescription))
            using (LinearGradientBrush brushHighlight = new LinearGradientBrush(e.Bounds, Color.FromArgb((int)(_HighlightOpacity * 255), _HighlightColor), Color.Transparent, 0f))
            {
                // draw this if item is selected
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    using (LinearGradientBrush backgroundBrush = new LinearGradientBrush(e.Bounds, Color.RoyalBlue, Color.Transparent, 180f))
                        e.Graphics.FillRectangle(backgroundBrush, e.Bounds);

                    if (ShowIndex)
                        e.Graphics.DrawString((e.Index + 1).ToString(), Font, Brushes.White, e.Bounds.Left, e.Bounds.Top + ItemMargin - (Font.Height / 2));

                    e.Graphics.DrawString(Title, this.Font, Brushes.White, e.Bounds.Left + 10 + _showIndexMargin, e.Bounds.Top + ItemMargin - (Font.Height / 2));
                    e.Graphics.DrawString(Description, this.DescriptionFont, Brushes.White, e.Bounds.Left + 10 + _showIndexMargin, e.Bounds.Top + ItemMargin + (DescriptionFont.Height / 2), StringFormat.GenericTypographic);
                }
                else
                {
                    // highlight item on mousehover
                    if (e.Bounds.Contains(PointToClient(Cursor.Position)))
                    {
                        if (_HighlightHover)
                            e.Graphics.FillRectangle(brushHighlight, e.Bounds.X + _showIndexMargin, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                    }

                    // draw the item title and item description
                    if ( ShowIndex )
                        e.Graphics.DrawString((e.Index + 1).ToString(), Font, brushTitle, e.Bounds.Left, e.Bounds.Top + ItemMargin - (Font.Height / 2));

                    e.Graphics.DrawString(Title, this.Font, brushTitle, e.Bounds.Left + _showIndexMargin, e.Bounds.Top + ItemMargin - (Font.Height / 2));
                    e.Graphics.DrawString(Description, this.DescriptionFont, brushDescription, e.Bounds.Left + _showIndexMargin, e.Bounds.Top + ItemMargin + (DescriptionFont.Height / 2));
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
            else
            {
                using (Font font = new Font("Segoe UI", 18f, FontStyle.Bold))
                {
                    Size textSize = TextRenderer.MeasureText(NoItemsMessage, font);
                    e.Graphics.DrawString(NoItemsMessage, font, Brushes.LightGray, ClientRectangle.Width / 2 - textSize.Width / 2, 
                                                                                   ClientRectangle.Height / 2 - textSize.Height / 2);
                }
            }
            base.OnPaint(e);
        }
        protected override void OnResize(EventArgs e)
        {
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
            if (_handleIconClick && e.Button == MouseButtons.Left)
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

        protected override void OnGiveFeedback(GiveFeedbackEventArgs gfbevent)
        {
            base.OnGiveFeedback(gfbevent);
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

        private SolidBrush InvertColor(SolidBrush brush)
        {
            return new SolidBrush(Color.FromArgb(brush.Color.ToArgb() ^ 0xffffff));
        }
    }
}
