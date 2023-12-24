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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mProgressBar1 = new M3Controls.MProgressBar();
            this.multiInfoPanel1 = new M3Controls.InfoPanels.MultiInfoPanel();
            this.mSideBar1 = new M3Controls.MSideBar();
            this.mStatusBar1 = new M3Controls.MStatusBar();
            this.mMenuStrip1 = new M3Controls.MMenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.mComboBox1 = new M3Controls.MComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.mTextBox1 = new M3Controls.MTextBox();
            this.mTextBox2 = new M3Controls.MTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.mTextBox3 = new M3Controls.MTextBox();
            this.mTextBox4 = new M3Controls.MTextBox();
            this.mMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // mProgressBar1
            // 
            this.mProgressBar1.Location = new System.Drawing.Point(235, 132);
            this.mProgressBar1.Name = "mProgressBar1";
            this.mProgressBar1.ProgressBarColor = System.Drawing.Color.RoyalBlue;
            this.mProgressBar1.ProgressBarFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mProgressBar1.Size = new System.Drawing.Size(637, 31);
            this.mProgressBar1.TabIndex = 6;
            this.mProgressBar1.Value = 40;
            // 
            // multiInfoPanel1
            // 
            this.multiInfoPanel1.BoundsTextLeft = new System.Drawing.Rectangle(74, 5, 111, 25);
            this.multiInfoPanel1.BoundsTextRight = new System.Drawing.Rectangle(565, 5, 62, 25);
            this.multiInfoPanel1.ClickedColor = System.Drawing.Color.Silver;
            this.multiInfoPanel1.DrawBorder = false;
            this.multiInfoPanel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiInfoPanel1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.multiInfoPanel1.Image = ((System.Drawing.Image)(resources.GetObject("multiInfoPanel1.Image")));
            this.multiInfoPanel1.ImageSize = 64;
            this.multiInfoPanel1.Location = new System.Drawing.Point(235, 27);
            this.multiInfoPanel1.Maximum = 100;
            this.multiInfoPanel1.Name = "multiInfoPanel1";
            this.multiInfoPanel1.ProgressValue = 50;
            this.multiInfoPanel1.ProgressVisible = true;
            this.multiInfoPanel1.Size = new System.Drawing.Size(637, 74);
            this.multiInfoPanel1.TabIndex = 5;
            this.multiInfoPanel1.Text = "multiInfoPanel1";
            this.multiInfoPanel1.TextBottom = "";
            this.multiInfoPanel1.TextLeft = "Information";
            this.multiInfoPanel1.TextRight = "Status";
            this.multiInfoPanel1.Truncate = false;
            this.multiInfoPanel1.ProgressCompleted += new System.EventHandler(this.multiInfoPanel1_ProgressCompleted);
            this.multiInfoPanel1.Click += new System.EventHandler(this.multiInfoPanel1_Click);
            // 
            // mSideBar1
            // 
            this.mSideBar1.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.mSideBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.mSideBar1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mSideBar1.HeaderSpace = 100;
            this.mSideBar1.HeaderText = "Choose Option";
            this.mSideBar1.Items.Add(((M3Controls.MSideBarItem)(resources.GetObject("mSideBar1.Items"))));
            this.mSideBar1.Items.Add(((M3Controls.MSideBarItem)(resources.GetObject("mSideBar1.Items1"))));
            this.mSideBar1.Items.Add(((M3Controls.MSideBarItem)(resources.GetObject("mSideBar1.Items2"))));
            this.mSideBar1.Items.Add(((M3Controls.MSideBarItem)(resources.GetObject("mSideBar1.Items3"))));
            this.mSideBar1.Location = new System.Drawing.Point(0, 24);
            this.mSideBar1.Name = "mSideBar1";
            this.mSideBar1.Size = new System.Drawing.Size(229, 492);
            this.mSideBar1.TabIndex = 4;
            this.mSideBar1.Text = "mSideBar1";
            this.mSideBar1.VerticalSpacing = 0;
            this.mSideBar1.ItemClicked += new System.EventHandler<M3Controls.MSideBarItem>(this.mSideBar1_ItemClicked);
            // 
            // mStatusBar1
            // 
            this.mStatusBar1.BackgroundColor = System.Drawing.Color.Empty;
            this.mStatusBar1.BorderBottom = false;
            this.mStatusBar1.Bordercolor = System.Drawing.Color.Silver;
            this.mStatusBar1.BorderLeft = false;
            this.mStatusBar1.BorderRight = false;
            this.mStatusBar1.BorderTop = true;
            this.mStatusBar1.BorderWidth = 3;
            this.mStatusBar1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.mStatusBar1.Location = new System.Drawing.Point(0, 516);
            this.mStatusBar1.Name = "mStatusBar1";
            this.mStatusBar1.Padding = new System.Windows.Forms.Padding(100, 0, 0, 0);
            this.mStatusBar1.Size = new System.Drawing.Size(884, 30);
            this.mStatusBar1.TabIndex = 2;
            this.mStatusBar1.Text = "mStatusBar1";
            // 
            // mMenuStrip1
            // 
            this.mMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.mMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.mMenuStrip1.Name = "mMenuStrip1";
            this.mMenuStrip1.Size = new System.Drawing.Size(884, 24);
            this.mMenuStrip1.TabIndex = 7;
            this.mMenuStrip1.Text = "mMenuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(125, 20);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(235, 181);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 9;
            // 
            // mComboBox1
            // 
            this.mComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.mComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mComboBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mComboBox1.FormattingEnabled = true;
            this.mComboBox1.ItemHeight = 25;
            this.mComboBox1.Items.AddRange(new object[] {
            "16541561",
            "5161616",
            "156165161",
            "215621165"});
            this.mComboBox1.Location = new System.Drawing.Point(235, 212);
            this.mComboBox1.Name = "mComboBox1";
            this.mComboBox1.Size = new System.Drawing.Size(269, 31);
            this.mComboBox1.TabIndex = 10;
            this.mComboBox1.TextAlign = System.Drawing.StringAlignment.Center;
            this.mComboBox1.TextYOffset = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(235, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // mTextBox1
            // 
            this.mTextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.mTextBox1.BackgroundColor = System.Drawing.Color.Empty;
            this.mTextBox1.BorderColor = System.Drawing.Color.RoyalBlue;
            this.mTextBox1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.mTextBox1.BorderSize = 2;
            this.mTextBox1.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.mTextBox1.ClearButton = false;
            this.mTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.mTextBox1.Icon = null;
            this.mTextBox1.Image = ((System.Drawing.Image)(resources.GetObject("mTextBox1.Image")));
            this.mTextBox1.Location = new System.Drawing.Point(317, 249);
            this.mTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBox1.Multiline = false;
            this.mTextBox1.Name = "mTextBox1";
            this.mTextBox1.Padding = new System.Windows.Forms.Padding(7);
            this.mTextBox1.PasswordChar = false;
            this.mTextBox1.Placeholder = "";
            this.mTextBox1.ReadOnly = false;
            this.mTextBox1.ShowPlaceholder = false;
            this.mTextBox1.Size = new System.Drawing.Size(250, 31);
            this.mTextBox1.TabIndex = 12;
            // 
            // mTextBox2
            // 
            this.mTextBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mTextBox2.BackColor = System.Drawing.SystemColors.Window;
            this.mTextBox2.BackgroundColor = System.Drawing.Color.Empty;
            this.mTextBox2.BorderColor = System.Drawing.Color.RoyalBlue;
            this.mTextBox2.BorderFocusColor = System.Drawing.Color.HotPink;
            this.mTextBox2.BorderSize = 2;
            this.mTextBox2.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.mTextBox2.ClearButton = false;
            this.mTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTextBox2.ForeColor = System.Drawing.Color.DimGray;
            this.mTextBox2.Icon = null;
            this.mTextBox2.Image = ((System.Drawing.Image)(resources.GetObject("mTextBox2.Image")));
            this.mTextBox2.Location = new System.Drawing.Point(236, 288);
            this.mTextBox2.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBox2.Multiline = true;
            this.mTextBox2.Name = "mTextBox2";
            this.mTextBox2.Padding = new System.Windows.Forms.Padding(7);
            this.mTextBox2.PasswordChar = false;
            this.mTextBox2.Placeholder = "";
            this.mTextBox2.ReadOnly = false;
            this.mTextBox2.ShowPlaceholder = false;
            this.mTextBox2.Size = new System.Drawing.Size(331, 221);
            this.mTextBox2.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(599, 219);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // mTextBox3
            // 
            this.mTextBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mTextBox3.BackColor = System.Drawing.SystemColors.Window;
            this.mTextBox3.BackgroundColor = System.Drawing.Color.Empty;
            this.mTextBox3.BorderColor = System.Drawing.Color.RoyalBlue;
            this.mTextBox3.BorderFocusColor = System.Drawing.Color.HotPink;
            this.mTextBox3.BorderSize = 2;
            this.mTextBox3.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.mTextBox3.ClearButton = false;
            this.mTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTextBox3.ForeColor = System.Drawing.Color.DimGray;
            this.mTextBox3.Icon = null;
            this.mTextBox3.Image = ((System.Drawing.Image)(resources.GetObject("mTextBox3.Image")));
            this.mTextBox3.Location = new System.Drawing.Point(599, 288);
            this.mTextBox3.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBox3.Multiline = false;
            this.mTextBox3.Name = "mTextBox3";
            this.mTextBox3.Padding = new System.Windows.Forms.Padding(7);
            this.mTextBox3.PasswordChar = false;
            this.mTextBox3.Placeholder = "";
            this.mTextBox3.ReadOnly = false;
            this.mTextBox3.ShowPlaceholder = false;
            this.mTextBox3.Size = new System.Drawing.Size(250, 31);
            this.mTextBox3.TabIndex = 15;
            this.mTextBox3.Text = "Lorem ipsum Dolim mirium";
            // 
            // mTextBox4
            // 
            this.mTextBox4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mTextBox4.BackColor = System.Drawing.SystemColors.Window;
            this.mTextBox4.BackgroundColor = System.Drawing.Color.Empty;
            this.mTextBox4.BorderColor = System.Drawing.Color.RoyalBlue;
            this.mTextBox4.BorderFocusColor = System.Drawing.Color.HotPink;
            this.mTextBox4.BorderSize = 2;
            this.mTextBox4.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.mTextBox4.ClearButton = false;
            this.mTextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTextBox4.ForeColor = System.Drawing.Color.DimGray;
            this.mTextBox4.Icon = null;
            this.mTextBox4.Image = ((System.Drawing.Image)(resources.GetObject("mTextBox4.Image")));
            this.mTextBox4.Location = new System.Drawing.Point(599, 249);
            this.mTextBox4.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBox4.Multiline = false;
            this.mTextBox4.Name = "mTextBox4";
            this.mTextBox4.Padding = new System.Windows.Forms.Padding(7);
            this.mTextBox4.PasswordChar = false;
            this.mTextBox4.Placeholder = "";
            this.mTextBox4.ReadOnly = false;
            this.mTextBox4.ShowPlaceholder = false;
            this.mTextBox4.Size = new System.Drawing.Size(250, 31);
            this.mTextBox4.TabIndex = 16;
            this.mTextBox4.Text = "mTextBox4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 546);
            this.Controls.Add(this.mTextBox4);
            this.Controls.Add(this.mTextBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.mTextBox2);
            this.Controls.Add(this.mTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mComboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.mProgressBar1);
            this.Controls.Add(this.multiInfoPanel1);
            this.Controls.Add(this.mSideBar1);
            this.Controls.Add(this.mStatusBar1);
            this.Controls.Add(this.mMenuStrip1);
            this.MainMenuStrip = this.mMenuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.mMenuStrip1.ResumeLayout(false);
            this.mMenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private M3Controls.MStatusBar mStatusBar1;
        private M3Controls.MSideBar mSideBar1;
        private M3Controls.InfoPanels.MultiInfoPanel multiInfoPanel1;
        private System.Windows.Forms.Timer timer1;
        private M3Controls.MProgressBar mProgressBar1;
        private M3Controls.MMenuStrip mMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TextBox textBox1;
        private M3Controls.MComboBox mComboBox1;
        private System.Windows.Forms.Button button1;
        private M3Controls.MTextBox mTextBox1;
        private M3Controls.MTextBox mTextBox2;
        private System.Windows.Forms.Button button2;
        private M3Controls.MTextBox mTextBox3;
        private M3Controls.MTextBox mTextBox4;
    }
}

