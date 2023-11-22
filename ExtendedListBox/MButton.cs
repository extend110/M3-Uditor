using M3Controls.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M3Controls
{
    public class MButton : Button
    {
        public int Radius {  get; set; }
        public Color BorderColor 
        {
            get => _borderColor;
            set
            {
                _borderColor  = value;
                Invalidate();
            }
        }

        private int _offset = 5;
        private Color _borderColor;
        private GraphicsPath _graphicsPath
        {
            get
            {
                return GraphicsExtension.RoundedRect(ClientRectangle, Radius);
            }
        }

        public MButton() 
        {
            
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rectSurface = new Rectangle(0, 0, Width, Height);
            Rectangle rectBorder = new Rectangle(1, 1, Width - 1, Height - 1);

            using (GraphicsPath pathSurface = GraphicsExtension.RoundedRect(rectSurface, Radius))
            using (GraphicsPath pathBorder = GraphicsExtension.RoundedRect(rectBorder, Radius))
            using (Pen penSurface = new Pen(this.Parent.BackColor))
            using (Pen penBorder = new Pen(_borderColor, 1))
            {
                penBorder.Alignment = PenAlignment.Inset;
                this.Region = new Region(pathSurface);
                e.Graphics.DrawPath(penSurface, pathSurface);
                e.Graphics.DrawPath(penBorder, pathBorder);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
           
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += Parent_BackColorChanged;
        }

        private void Parent_BackColorChanged(object sender, EventArgs e)
        {
            if (DesignMode)
                Invalidate();
        }
    }
}
