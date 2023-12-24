using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M3Controls
{
    public class MComboBox : ComboBox
    {
        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        const int GWL_STYLE = -16;
        const int ES_LEFT = 0x0000;
        const int ES_CENTER = 0x0001;
        const int ES_RIGHT = 0x0002;
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
            public int Width { get { return Right - Left; } }
            public int Height { get { return Bottom - Top; } }
        }
        [DllImport("user32.dll")]
        public static extern bool GetComboBoxInfo(IntPtr hWnd, ref COMBOBOXINFO pcbi);

        [StructLayout(LayoutKind.Sequential)]
        public struct COMBOBOXINFO
        {
            public int cbSize;
            public RECT rcItem;
            public RECT rcButton;
            public int stateButton;
            public IntPtr hwndCombo;
            public IntPtr hwndEdit;
            public IntPtr hwndList;
        }

        private StringAlignment _textAlign = StringAlignment.Center;
        [Description("String Alignment")]
        [Category("CustomFonts")]
        [DefaultValue(typeof(StringAlignment))]
        public StringAlignment TextAlign
        {
            get { return _textAlign; }
            set
            {
                _textAlign = value;
            }
        }

        private int _textYOffset = 0;
        [Description("When using a non-centered TextAlign, you may want to use TextYOffset to manually center the Item text.")]
        [Category("CustomFonts")]
        [DefaultValue(typeof(int))]
        public int TextYOffset
        {
            get { return _textYOffset; }
            set
            {
                _textYOffset = value;
            }
        }
        public MComboBox() 
        { 
            this.DrawMode = DrawMode.OwnerDrawVariable;
            //SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        private void SetupEdit()
        {
            var info = new COMBOBOXINFO();
            info.cbSize = Marshal.SizeOf(info);
            GetComboBoxInfo(this.Handle, ref info);
            var style = GetWindowLong(info.hwndEdit, GWL_STYLE);
            style |= ES_RIGHT;
            SetWindowLong(info.hwndEdit, GWL_STYLE, style);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetupEdit();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            // Draw the background
            e.DrawBackground();

            // Draw the items
            if (e.Index >= 0)
            {
                StringFormat sf = new StringFormat();
                sf.LineAlignment = _textAlign;
                sf.Alignment = _textAlign;

                Brush brush = new SolidBrush(this.ForeColor);
                string itemText = GetItemText(Items[e.Index]);

                //TextRenderer.DrawText(e.Graphics, itemText, Font, e.Bounds, ForeColor, TextFormatFlags.Left | TextFormatFlags.HorizontalCenter);

                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    brush = SystemBrushes.HighlightText;

                e.Graphics.DrawString(this.Items[e.Index].ToString(), this.Font, brush,
                    new RectangleF(e.Bounds.X, e.Bounds.Y + _textYOffset, e.Bounds.Width, e.Bounds.Height), sf);
            }
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            base.OnMeasureItem(e);
        }
    }
}
