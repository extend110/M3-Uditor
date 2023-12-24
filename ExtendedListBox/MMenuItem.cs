using M3Controls.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M3Controls
{
    public class MenuItemRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderMenuItemBackground(e);
            if (e.Item.Tag?.ToString() == "RecentFile")
            {
                Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                Rectangle imageLocation = new Rectangle(rc.Width - e.Item.Height, 5, e.Item.Height - 10, e.Item.Height - 10);

                e.Graphics.DrawImage(Resources.RemoveButton, imageLocation);
            }
        }
    }
    public class MMenuItem : ToolStripMenuItem
    {
        public MMenuItem() { 
            
        }
        public MMenuItem(string text) : base(text)
        {
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            e.Graphics.FillRectangle(Brushes.Yellow, this.Bounds);
            e.Graphics.DrawString(this.Text, this.Font, Brushes.Red, Bounds);

            base.OnPaint(e);
        }
    }
}
