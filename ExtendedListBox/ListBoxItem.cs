using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace M3Controls
{
    public class ListBoxItem : object, IEquatable<ListBoxItem>
    {
        public Color BackColor {  get; set; } = Color.White;
        public string Title {  get; set; }
        public string Description {  get; set; }

        public Color ColorTitle
        {
            get
            {
                if (_titleColor.IsEmpty)
                    return SystemColors.WindowText;

                return _titleColor;
            }
            set
            {
                _titleColor = value;
            }
        }
        public Color ColorDescription
        {
            get
            {
                if (_descriptionColor.IsEmpty)
                    return Color.DimGray;

                return _descriptionColor;
            }
            set
            {
                _descriptionColor = value;
            }
        }

        public Rectangle Bounds { get; set; }

        public virtual void OnDrawItem(DrawItemEventArgs e) { }

        public bool Equals(ListBoxItem other)
        {
            return this.Title == other.Title && this.Description == other.Description;
        }

        private Color _titleColor, _descriptionColor;
    }
}
