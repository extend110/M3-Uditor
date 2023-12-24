using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M3Controls.InfoPanels
{
    public class MultiInfoPanel : Control
    {
        public event EventHandler ProgressCompleted;

        [Category("ProgressBar")]
        public bool ProgressVisible { get => _progressVisible; set { _progressVisible = value; Invalidate(); } }
        [Category("ProgressBar")]
        public int ProgressValue 
        { 
            get => _progressValue; 
            set 
            { 
                _progressValue = value;
                if ( _progressValue < 0 ) _progressValue = 0;
                if ( _progressValue == 100 )
                {
                    ProgressCompleted?.Invoke( this, EventArgs.Empty );
                }
                Invalidate(); 
            } 
        }
        [Category("ProgressBar")]
        public int Maximum { get; set; } = 100;

        [Category("Bounds")]
        public Rectangle BoundsTextLeft { get; set; }
        public Rectangle BoundsTextRight { get; set; }

        [Category("Colors")]
        public new Color BackColor { get; set; }
        [Category("Colors")]
        public Color HoverColor { get; set; }
        [Category("Colors")]
        public Color ClickedColor { get; set; }

        [Category("Booleans")]
        public bool DrawBorder { get; set; }
        public bool Truncate { get => _truncate; set { _truncate = value; Invalidate(); } }

        [Category("Image")]
        public Image Image { get => _image; set { _image = value; CalculateHeight(); Invalidate(); } }
        public int ImageSize { get; set; }

        [Category("Strings")]
        public string TextLeft { get => _textLeft; set { _textLeft = value; CalculateHeight(); Invalidate(); } }
        [Category("Strings")]
        public string TextRight { get => _textRight; set { _textRight = value; CalculateHeight(); Invalidate(); } }
        [Category("Strings")]
        public string TextBottom { get => _textBottom; set { _textBottom = value; CalculateHeight(); Invalidate(); } }

        private Color _activeColor;
        private Image _image;
        private string _textLeft, _textRight, _textBottom;
        private int _progressValue;
        private bool _progressVisible, _truncate;

        public MultiInfoPanel()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint, true);
            BackColor = Color.White;
            Font = new Font("Segoe UI", 10f);

            _activeColor = BackColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (SolidBrush backgroundColor = new SolidBrush(_activeColor))
                e.Graphics.FillRectangle(backgroundColor, ClientRectangle);

            if (DrawBorder)
            {
                using (Pen borderPen = new Pen(Color.DarkSlateGray, 2))
                {
                    borderPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    e.Graphics.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);
                }
            }

            if (_image != null)
            {
                e.Graphics.DrawImage(_image, 5, 5, ImageSize, ImageSize);
            } 

            Size textRightOffset = TextRenderer.MeasureText(TextRight, Font);
            BoundsTextRight = new Rectangle(Width - textRightOffset.Width - 10, 5, textRightOffset.Width, textRightOffset.Height);

            if (_image != null)
            {
                
                BoundsTextLeft = new Rectangle(new Point(5 + ImageSize, 5), TextRenderer.MeasureText(_textLeft, Font));
            } 
            else
            {
                BoundsTextLeft = new Rectangle(new Point(5, 5), TextRenderer.MeasureText(_textLeft, Font));
            }

            if (_truncate)
            {
                _textLeft = TruncateString(_textLeft, this.Font, BoundsTextRight.Left - BoundsTextLeft.X);
            }

            if (_image != null)
            {
                e.Graphics.DrawString(_textLeft, Font, Brushes.Black, 10 + ImageSize, 5);
            }
            else
            {
                e.Graphics.DrawString(_textLeft, Font, Brushes.Black, 5, 5);
            }

            e.Graphics.DrawString(_textRight, Font, Brushes.Black, Width - textRightOffset.Width - 10, 5);

            e.Graphics.DrawString(_textBottom, Font, Brushes.RoyalBlue, 5, 10 + ImageSize);

            if ( ProgressVisible )
            {

                if ( _image != null )
                {
                    Rectangle progressBar = new Rectangle(10 + ImageSize, ImageSize - 10, Width - 10 - ImageSize - 10, 10);
                    int fillWidth = progressBar.Width * _progressValue / (Maximum - 0);
                    Rectangle fillRect = new Rectangle(progressBar.X, progressBar.Y, fillWidth, progressBar.Height);

                    e.Graphics.FillRectangle(Brushes.LightGray, progressBar);
                    e.Graphics.FillRectangle(Brushes.RoyalBlue, fillRect);
                    e.Graphics.DrawRectangle(Pens.DarkSlateGray, progressBar);
                }
                else
                {
                    Rectangle progressBar = new Rectangle(10, ImageSize - 10, Width - 10 - 10, 10);
                    int fillWidth = progressBar.Width * _progressValue / (100 - 0);
                    Rectangle fillRect = new Rectangle(progressBar.X, progressBar.Y, fillWidth, progressBar.Height);

                    e.Graphics.FillRectangle(Brushes.LightGray, progressBar);
                    e.Graphics.FillRectangle(Brushes.RoyalBlue, fillRect);
                    e.Graphics.DrawRectangle(Pens.DarkSlateGray, progressBar);
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _activeColor = HoverColor;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _activeColor = BackColor;
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _activeColor = ClickedColor;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (ClientRectangle.Contains(e.Location))
            {
                _activeColor = HoverColor;
            }
            else
            {
                _activeColor = BackColor;
            }
            Invalidate();
        }
        protected override void OnResize(EventArgs e)
        {
            CalculateHeight();
            Invalidate();
        }

        private void CalculateHeight()
        {
            if ( TextBottom == null)
            {
                this.Height = ImageSize + 10;
                return;
            }
            if (TextBottom.Length == 0)
            {
                this.Height = ImageSize + 10;
            }
            else
            {
                int textHeight = TextRenderer.MeasureText(TextBottom, Font).Height;
                if (InvokeRequired)
                {
                    BeginInvoke(new MethodInvoker(() => this.Height = ImageSize + 10 + textHeight + 5));
                }
                else
                {
                    this.Height = ImageSize + 10 + textHeight + 5;
                }
            }
        }

        private string TruncateString(string text, Font font, int maxWidth)
        {
            string truncatedText = text;
            int descriptionLength = TextRenderer.MeasureText(truncatedText + "...", font).Width;
            int maxTextWidth = maxWidth;

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

    }
}
