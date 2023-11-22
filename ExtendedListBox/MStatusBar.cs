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
    public class MStatusBarItemCollection : System.Collections.ObjectModel.Collection<MStatusBarItem> { }

    [Serializable]
    public class MStatusBarItem
    {
        public int Width { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
    }

    public class MStatusBar : Control
    {
        // public members
        public ListBox ParentControl {  get; set; }
        public bool InvertItems {  get; set; }
        public bool CenterText
        {
            get => _centerText;
            set
            {
                _centerText = value;
                Invalidate();
            }
        }
        public bool DrawSeperators
        {
            get => _drawSeperators;
            set
            {
                _drawSeperators = value;
                Invalidate();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public MStatusBarItemCollection Items
        {
            get 
            {
                Invalidate();
                return mStatusBarItems; 
            }
        }

        // private members
        private MStatusBarItemCollection mStatusBarItems = new MStatusBarItemCollection();
        private bool _centerText, _drawSeperators;

        public MStatusBar() 
        {
            Font = new System.Drawing.Font("Segoe UI", 8f);

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new LinearGradientBrush(Location, new Point(Right, Bottom), BackColor, Color.Red), Location.X,Location.Y, Width, Height);

            int y = GetCenterText();

            // draw bounding rectangle
            e.Graphics.DrawRectangle(Pens.DimGray, 0, 0, Width - 1, Height - 1);

            // draw text left
            e.Graphics.DrawString(Text, Font, Brushes.Black, 0, y);

            // draw text
            int xpos = 0;
            for (int i = 0; i < mStatusBarItems.Count; i++)
            {

                string text = mStatusBarItems[i].Text;
                int itemWidth = mStatusBarItems[i].Width;
                int textWidth = (int)e.Graphics.MeasureString(text, Font).Width;

                xpos += itemWidth;

                if (_centerText)
                {
                    e.Graphics.DrawString(text, Font, Brushes.Black, (Width - xpos) + (itemWidth/2) - (textWidth/2), y);
                }
                else
                {
                    e.Graphics.DrawString(text, Font, Brushes.Black, Width - xpos, y);
                }
                
            }
        }

        private int GetCenterText()
        {
            return (Height / 2) - ( Font.Height / 2 );
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }
    }
}
