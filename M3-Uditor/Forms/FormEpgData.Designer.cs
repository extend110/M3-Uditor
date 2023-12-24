namespace Forms.M3_Uditor
{
    partial class FormEpgData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEpgData));
            this.headerText1 = new M3Controls.HeaderText();
            this.mTextBox1 = new M3Controls.MTextBox();
            this.listBoxEpgItems = new M3Controls.ExtendedListBox();
            this.SuspendLayout();
            // 
            // headerText1
            // 
            this.headerText1.Animate = false;
            this.headerText1.BottomLineHeight = 0;
            this.headerText1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerText1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerText1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.headerText1.GradientColor = System.Drawing.Color.RoyalBlue;
            this.headerText1.Location = new System.Drawing.Point(0, 0);
            this.headerText1.Name = "headerText1";
            this.headerText1.Size = new System.Drawing.Size(800, 93);
            this.headerText1.TabIndex = 4;
            this.headerText1.Text = "EPG Data";
            // 
            // mTextBox1
            // 
            this.mTextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.mTextBox1.BackgroundColor = System.Drawing.Color.Empty;
            this.mTextBox1.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.mTextBox1.BorderFocusColor = System.Drawing.Color.RoyalBlue;
            this.mTextBox1.BorderSize = 2;
            this.mTextBox1.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.mTextBox1.ClearButton = true;
            this.mTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.mTextBox1.Icon = null;
            this.mTextBox1.Image = ((System.Drawing.Image)(resources.GetObject("mTextBox1.Image")));
            this.mTextBox1.Location = new System.Drawing.Point(11, 100);
            this.mTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBox1.Multiline = false;
            this.mTextBox1.Name = "mTextBox1";
            this.mTextBox1.Padding = new System.Windows.Forms.Padding(7);
            this.mTextBox1.PasswordChar = false;
            this.mTextBox1.Placeholder = "Search...";
            this.mTextBox1.ReadOnly = false;
            this.mTextBox1.ShowPlaceholder = true;
            this.mTextBox1.Size = new System.Drawing.Size(776, 31);
            this.mTextBox1.TabIndex = 1;
            this.mTextBox1.Text = "Search...";
            this.mTextBox1.ButtonClicked += new System.EventHandler(this.mTextBox1_ButtonClicked);
            this.mTextBox1._TextChanged += new System.EventHandler(this.mTextBox1__TextChanged);
            // 
            // listBoxEpgItems
            // 
            this.listBoxEpgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxEpgItems.AutoScroll = false;
            this.listBoxEpgItems.DescriptionColor = System.Drawing.Color.Empty;
            this.listBoxEpgItems.DescriptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxEpgItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBoxEpgItems.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxEpgItems.FormattingEnabled = true;
            this.listBoxEpgItems.HandleIconClick = false;
            this.listBoxEpgItems.HighlightColor = System.Drawing.Color.Empty;
            this.listBoxEpgItems.HighlightHover = false;
            this.listBoxEpgItems.HighlightOpacity = 0F;
            this.listBoxEpgItems.IconCount = 0;
            this.listBoxEpgItems.IconSize = new System.Drawing.Size(0, 0);
            this.listBoxEpgItems.ItemMargin = 15;
            this.listBoxEpgItems.Location = new System.Drawing.Point(12, 136);
            this.listBoxEpgItems.Name = "listBoxEpgItems";
            this.listBoxEpgItems.NoItemsMessage = null;
            this.listBoxEpgItems.ShowIndex = false;
            this.listBoxEpgItems.Size = new System.Drawing.Size(775, 414);
            this.listBoxEpgItems.TabIndex = 3;
            this.listBoxEpgItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxEpgItems_MouseDoubleClick);
            // 
            // FormEpgData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.listBoxEpgItems);
            this.Controls.Add(this.mTextBox1);
            this.Controls.Add(this.headerText1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 600);
            this.Name = "FormEpgData";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "M3-Uditor EPG";
            this.Load += new System.EventHandler(this.FormEpgData_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private M3Controls.HeaderText headerText1;
        private M3Controls.MTextBox mTextBox1;
        private M3Controls.ExtendedListBox listBoxEpgItems;
    }
}