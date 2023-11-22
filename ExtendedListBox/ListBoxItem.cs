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
    public class ListBoxItem : object
    {
        public Color BackColor {  get; set; } = Color.White;
        public string Title {  get; set; }
        public string Description;

        public virtual void OnDrawItem(DrawItemEventArgs e) { }
    }
}
