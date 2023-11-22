namespace Tests
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.mStatusBar1 = new M3Controls.MStatusBar();
            this.extendedListBox1 = new M3Controls.ExtendedListBox();
            this.extendedListBox3 = new M3Controls.ExtendedListBox();
            this.extendedListBox2 = new M3Controls.ExtendedListBox();
            this.mTextBox1 = new M3Controls.MTextBox();
            this.mProgressBar1 = new M3Controls.MProgressBar();
            this.headerText1 = new M3Controls.HeaderText();
            this.mButton2 = new M3Controls.MButton();
            this.mButton1 = new M3Controls.MButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(369, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add Group";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(369, 213);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Add Stream";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // mStatusBar1
            // 
            this.mStatusBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.mStatusBar1.CenterText = true;
            this.mStatusBar1.DrawSeperators = true;
            this.mStatusBar1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mStatusBar1.InvertItems = false;
            this.mStatusBar1.Items.Add(((M3Controls.MStatusBarItem)(resources.GetObject("mStatusBar1.Items"))));
            this.mStatusBar1.Items.Add(((M3Controls.MStatusBarItem)(resources.GetObject("mStatusBar1.Items1"))));
            this.mStatusBar1.Location = new System.Drawing.Point(70, 419);
            this.mStatusBar1.Name = "mStatusBar1";
            this.mStatusBar1.ParentControl = this.extendedListBox1;
            this.mStatusBar1.Size = new System.Drawing.Size(293, 446);
            this.mStatusBar1.TabIndex = 8;
            // 
            // extendedListBox1
            // 
            this.extendedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.extendedListBox1.DescriptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extendedListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.extendedListBox1.FormattingEnabled = true;
            this.extendedListBox1.HandleIconClick = false;
            this.extendedListBox1.HighlightColor = System.Drawing.Color.Empty;
            this.extendedListBox1.HighlightHover = false;
            this.extendedListBox1.HighlightOpacity = 0F;
            this.extendedListBox1.IconCount = 0;
            this.extendedListBox1.IconSize = new System.Drawing.Size(0, 0);
            this.extendedListBox1.ItemHeight = 18;
            this.extendedListBox1.ItemMargin = 15;
            this.extendedListBox1.Location = new System.Drawing.Point(70, 178);
            this.extendedListBox1.Name = "extendedListBox1";
            this.extendedListBox1.Size = new System.Drawing.Size(293, 242);
            this.extendedListBox1.StatusBar = this.mStatusBar1;
            this.extendedListBox1.TabIndex = 0;
            this.extendedListBox1.SelectedIndexChanged += new System.EventHandler(this.extendedListBox1_SelectedIndexChanged);
            // 
            // extendedListBox3
            // 
            this.extendedListBox3.DescriptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extendedListBox3.FormattingEnabled = true;
            this.extendedListBox3.HandleIconClick = false;
            this.extendedListBox3.HighlightColor = System.Drawing.Color.Empty;
            this.extendedListBox3.HighlightHover = false;
            this.extendedListBox3.HighlightOpacity = 0F;
            this.extendedListBox3.IconCount = 0;
            this.extendedListBox3.IconSize = new System.Drawing.Size(0, 0);
            this.extendedListBox3.ItemHeight = 16;
            this.extendedListBox3.ItemMargin = 15;
            this.extendedListBox3.Location = new System.Drawing.Point(595, 183);
            this.extendedListBox3.Name = "extendedListBox3";
            this.extendedListBox3.Size = new System.Drawing.Size(120, 84);
            this.extendedListBox3.StatusBar = null;
            this.extendedListBox3.TabIndex = 7;
            // 
            // extendedListBox2
            // 
            this.extendedListBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.extendedListBox2.DescriptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extendedListBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.extendedListBox2.FormattingEnabled = true;
            this.extendedListBox2.HandleIconClick = false;
            this.extendedListBox2.HighlightColor = System.Drawing.Color.Empty;
            this.extendedListBox2.HighlightHover = false;
            this.extendedListBox2.HighlightOpacity = 0F;
            this.extendedListBox2.IconCount = 0;
            this.extendedListBox2.IconSize = new System.Drawing.Size(0, 0);
            this.extendedListBox2.ItemHeight = 18;
            this.extendedListBox2.ItemMargin = 15;
            this.extendedListBox2.Location = new System.Drawing.Point(449, 184);
            this.extendedListBox2.Name = "extendedListBox2";
            this.extendedListBox2.Size = new System.Drawing.Size(140, 242);
            this.extendedListBox2.StatusBar = null;
            this.extendedListBox2.TabIndex = 6;
            // 
            // mTextBox1
            // 
            this.mTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.mTextBox1.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.mTextBox1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.mTextBox1.BorderSize = 2;
            this.mTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.mTextBox1.Icon = null;
            this.mTextBox1.Location = new System.Drawing.Point(70, 140);
            this.mTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBox1.Multiline = false;
            this.mTextBox1.Name = "mTextBox1";
            this.mTextBox1.Padding = new System.Windows.Forms.Padding(7);
            this.mTextBox1.PasswordChar = false;
            this.mTextBox1.Placeholder = "";
            this.mTextBox1.ReadOnly = true;
            this.mTextBox1.ShowIcon = false;
            this.mTextBox1.ShowPlaceholder = false;
            this.mTextBox1.Size = new System.Drawing.Size(242, 31);
            this.mTextBox1.TabIndex = 3;
            this.mTextBox1.UnderlinedStyle = false;
            // 
            // mProgressBar1
            // 
            this.mProgressBar1.BackColor = System.Drawing.Color.White;
            this.mProgressBar1.BarColorCenter = System.Drawing.Color.Blue;
            this.mProgressBar1.BarColorOutside = System.Drawing.Color.Lime;
            this.mProgressBar1.ForeColor = System.Drawing.Color.Red;
            this.mProgressBar1.Location = new System.Drawing.Point(449, 146);
            this.mProgressBar1.Name = "mProgressBar1";
            this.mProgressBar1.Size = new System.Drawing.Size(339, 31);
            this.mProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.mProgressBar1.TabIndex = 2;
            this.mProgressBar1.Value = 50;
            // 
            // headerText1
            // 
            this.headerText1.Animate = false;
            this.headerText1.BottomLineHeight = 1;
            this.headerText1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerText1.GradientColor = System.Drawing.Color.RoyalBlue;
            this.headerText1.Location = new System.Drawing.Point(0, 0);
            this.headerText1.Name = "headerText1";
            this.headerText1.Size = new System.Drawing.Size(800, 110);
            this.headerText1.TabIndex = 1;
            this.headerText1.Text = "headerText1";
            // 
            // mButton2
            // 
            this.mButton2.BackColor = System.Drawing.Color.DarkBlue;
            this.mButton2.BorderColor = System.Drawing.Color.Empty;
            this.mButton2.FlatAppearance.BorderSize = 0;
            this.mButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton2.ForeColor = System.Drawing.Color.White;
            this.mButton2.Location = new System.Drawing.Point(449, 432);
            this.mButton2.Name = "mButton2";
            this.mButton2.Radius = 5;
            this.mButton2.Size = new System.Drawing.Size(120, 33);
            this.mButton2.TabIndex = 10;
            this.mButton2.Text = "mButton2";
            this.mButton2.UseVisualStyleBackColor = false;
            // 
            // mButton1
            // 
            this.mButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.mButton1.BorderColor = System.Drawing.Color.Empty;
            this.mButton1.FlatAppearance.BorderSize = 0;
            this.mButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton1.ForeColor = System.Drawing.Color.White;
            this.mButton1.Location = new System.Drawing.Point(595, 282);
            this.mButton1.Name = "mButton1";
            this.mButton1.Radius = 10;
            this.mButton1.Size = new System.Drawing.Size(120, 42);
            this.mButton1.TabIndex = 11;
            this.mButton1.Text = "mButton1";
            this.mButton1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 535);
            this.Controls.Add(this.mButton1);
            this.Controls.Add(this.mButton2);
            this.Controls.Add(this.mStatusBar1);
            this.Controls.Add(this.extendedListBox3);
            this.Controls.Add(this.extendedListBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mTextBox1);
            this.Controls.Add(this.mProgressBar1);
            this.Controls.Add(this.headerText1);
            this.Controls.Add(this.extendedListBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private M3Controls.ExtendedListBox extendedListBox1;
        private M3Controls.HeaderText headerText1;
        private M3Controls.MProgressBar mProgressBar1;
        private M3Controls.MTextBox mTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private M3Controls.ExtendedListBox extendedListBox2;
        private M3Controls.ExtendedListBox extendedListBox3;
        private System.Windows.Forms.ImageList imageList1;
        private M3Controls.MStatusBar mStatusBar1;
        private M3Controls.MButton mButton2;
        private M3Controls.MButton mButton1;
    }
}

