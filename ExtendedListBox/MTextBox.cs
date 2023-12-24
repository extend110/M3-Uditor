using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M3Controls
{
    public partial class MTextBox : UserControl
    {
        public event EventHandler ButtonClicked;

        private TextBox textBox1;

        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(7, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(211, 15);
            this.textBox1.TabIndex = 0;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            this.textBox1.MouseEnter += new System.EventHandler(this.textBox1_MouseEnter);
            this.textBox1.MouseLeave += new System.EventHandler(this.textBox1_MouseLeave);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.BackgroundImage = global::M3Controls.Properties.Resources.RemoveButton;
            this.buttonClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonClear.FlatAppearance.BorderSize = 0;
            this.buttonClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Location = new System.Drawing.Point(224, 7);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(19, 16);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // MTextBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MTextBox";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.Size = new System.Drawing.Size(250, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private string _text;

        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 2;
        private bool underlinedStyle = false;
        private Color borderFocusColor = Color.HotPink;
        private bool isFocused = false;

        private bool showPlaceholder = false;
        private string placeHolder = "";
        private Font placeholderFont;

        private Button buttonClear;
        private Image icon;

        private bool clearButton;
        private Style borderStyle;
        private Color backgroundColor;

        private string textContent = string.Empty;
        //Constructor
        public MTextBox()
        {
            InitializeComponent();
        }

        //Events
        public event EventHandler _TextChanged;

        //Properties
        public enum Style
        {
            Normal,
            Underline,
            Gap
        }

        public new Style BorderStyle { get => borderStyle; set { borderStyle = value; Invalidate(); } }
        public Color BorderColor { get; set; } = Color.RoyalBlue;
        public Color BackgroundColor
        {
            get => backgroundColor; set
            {
                backgroundColor = value;
                textBox1.BackColor = value;
                Invalidate();
            }
        }
        [Category("M3 - Controls")]
        public new string Name
        {
            get => base.Name;
            set { base.Name = value; textBox1.Name = value; }
        }

        [Category("M3 - Controls")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text 
        { 
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        [Category("M3 - Controls")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("M3 - Controls")]
        public bool PasswordChar
        {
            get { return textBox1.UseSystemPasswordChar; }
            set { textBox1.UseSystemPasswordChar = value; }
        }

        [Category("M3 - Controls")]
        public bool Multiline
        {
            get { return textBox1.Multiline; }
            set { textBox1.Multiline = value; }
        }

        [Category("M3 - Controls")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }

        [Category("M3 - Controls")]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                textBox1.Font = value;
                placeholderFont = new Font(value, FontStyle.Italic);
                if (this.DesignMode)
                    UpdateControlHeight();
            }
        }

        [Category("M3 - Controls")]
        public Color BorderFocusColor
        {
            get { return borderFocusColor; }
            set { borderFocusColor = value; Invalidate(); }
        }

        [Category("M3 - Controls")]
        public bool ShowPlaceholder
        {
            get { return showPlaceholder; }
            set 
            {
                showPlaceholder = value;
                this.Invalidate();
            }
        }

        [Category("M3 - Controls")]
        public string Placeholder
        {
            get { return placeHolder; }
            set 
            { 
                placeHolder = value;
                this.Invalidate();
            }
        }

        [Category("M3 - Controls")]
        public bool ReadOnly
        {
            get { return textBox1.ReadOnly; }
            set
            {
                textBox1.ReadOnly = value;
                textBox1.BackColor = Color.Black;
                textBox1.ForeColor = this.ForeColor;
                textBox1.BackColor = BackColor;
                this.Invalidate();
            }
        }

        [Category("M3 - Controls")]
        public Image Icon
        {
            get { return icon; }
            set
            {
                icon = value;
            }
        }

        public string[] Lines
        {
            get
            {
                return textBox1.Lines;
            }
        }

        public Image Image { get => buttonClear.BackgroundImage; set { buttonClear.BackgroundImage = value; } }
        public bool ClearButton { get => clearButton; set { clearButton = value; buttonClear.Visible = value; OnResize(null); } }
        public AutoCompleteStringCollection AutoCompleteDataSource { get => textBox1.AutoCompleteCustomSource; set { textBox1.AutoCompleteCustomSource = value; } }
        public AutoCompleteMode AutoCompleteMode { get => textBox1.AutoCompleteMode; set { textBox1.AutoCompleteMode = value; } }

        //Overridden methods

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle bounds = new Rectangle(0, 0, Width - 1, Height - 1);

            using (SolidBrush backColor = new SolidBrush(backgroundColor))
            using (Pen borderPen = isFocused == true ? new Pen(BorderFocusColor, 1) : new Pen(BorderColor, 1))
            {
                e.Graphics.FillRectangle(backColor, ClientRectangle);

                switch (BorderStyle)
                {
                    case Style.Normal:
                        e.Graphics.DrawRectangle(borderPen, bounds);
                        break;
                    case Style.Underline:
                        e.Graphics.DrawRectangle(borderPen, 0, Height - 1, Width, 1);
                        break;
                    case Style.Gap:
                        e.Graphics.DrawRectangle(borderPen, bounds);
                        e.Graphics.FillRectangle(backColor, 0, Height / 2 - textBox1.Height / 2, Width, textBox1.Height);
                        break;
                }

            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateControlHeight();

            textBox1.Width = this.Width - Padding.Left - Padding.Right;

            buttonClear.Left = this.Width - buttonClear.Width - this.Padding.Right;

            if (clearButton)
                textBox1.Width -= buttonClear.Width;

            this.Invalidate();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (showPlaceholder) 
            {
                textBox1.Font = placeholderFont;
                textBox1.Text = placeHolder; 
            }
            UpdateControlHeight();
        }

        //Private methods
        private void UpdateControlHeight()
        {
            if (textBox1.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtHeight);
                textBox1.Multiline = false;

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            } else
            {
                textBox1.Height = this.Height - this.Padding.Top - this.Padding.Bottom;
            }
            
            buttonClear.Size = new Size(19, textBox1.Height);
        }

        //TextBox events
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)
                _TextChanged.Invoke(sender, e);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == placeHolder && showPlaceholder)
            {
                textBox1.Font = Font;
                textBox1.Text = string.Empty;
            }

            textContent = textBox1.Text;
            isFocused = true;
            this.Invalidate();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if ( textBox1.Text == string.Empty && showPlaceholder )
            {
                textBox1.Font = placeholderFont;
                textBox1.Text = placeHolder;
            }
            else if(textBox1.Text == string.Empty && textContent != string.Empty)
            {
                textBox1.Text = textContent;
            }
            isFocused = false;
            this.Invalidate();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            //textBox1.Dock = DockStyle.Left;
            if (clearButton)
            {
                textBox1.Width = this.Width - buttonClear.Width - Margin.Right;
            }
            else
            {
                //textBox1.Width = this.Width - Padding.Right;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ButtonClicked?.Invoke(this, e);
        }
        public void Clear()
        {
            textBox1.Clear();
            textBox1.Focus();
        }
    }
}
