namespace M3_Uditor.Forms
{
    partial class FormEpgMapper
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
            this.mProgressBarStreams = new M3Controls.MProgressBar();
            this.multiInfoPanel1 = new M3Controls.InfoPanels.MultiInfoPanel();
            this.headerText1 = new M3Controls.HeaderText();
            this.panelLabels = new System.Windows.Forms.FlowLayoutPanel();
            this.labelShowChannels = new System.Windows.Forms.Label();
            this.labelClose = new System.Windows.Forms.Label();
            this.listBoxMappedChannels = new System.Windows.Forms.ListBox();
            this.panelLabels.SuspendLayout();
            this.SuspendLayout();
            // 
            // mProgressBarStreams
            // 
            this.mProgressBarStreams.Location = new System.Drawing.Point(12, 139);
            this.mProgressBarStreams.Name = "mProgressBarStreams";
            this.mProgressBarStreams.ProgressBarColor = System.Drawing.Color.RoyalBlue;
            this.mProgressBarStreams.ProgressBarFont = new System.Drawing.Font("Segoe UI", 8F);
            this.mProgressBarStreams.Size = new System.Drawing.Size(493, 31);
            this.mProgressBarStreams.TabIndex = 4;
            // 
            // multiInfoPanel1
            // 
            this.multiInfoPanel1.BoundsTextLeft = new System.Drawing.Rectangle(5, 5, 0, 0);
            this.multiInfoPanel1.BoundsTextRight = new System.Drawing.Rectangle(495, 5, 0, 0);
            this.multiInfoPanel1.ClickedColor = System.Drawing.Color.Empty;
            this.multiInfoPanel1.DrawBorder = false;
            this.multiInfoPanel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.multiInfoPanel1.HoverColor = System.Drawing.Color.Empty;
            this.multiInfoPanel1.Image = null;
            this.multiInfoPanel1.ImageSize = 75;
            this.multiInfoPanel1.Location = new System.Drawing.Point(7, 102);
            this.multiInfoPanel1.Maximum = 100;
            this.multiInfoPanel1.Name = "multiInfoPanel1";
            this.multiInfoPanel1.ProgressValue = 0;
            this.multiInfoPanel1.ProgressVisible = false;
            this.multiInfoPanel1.Size = new System.Drawing.Size(505, 85);
            this.multiInfoPanel1.TabIndex = 2;
            this.multiInfoPanel1.Text = "multiInfoPanel1";
            this.multiInfoPanel1.TextBottom = "";
            this.multiInfoPanel1.TextLeft = "";
            this.multiInfoPanel1.TextRight = null;
            this.multiInfoPanel1.Truncate = false;
            // 
            // headerText1
            // 
            this.headerText1.Animate = false;
            this.headerText1.BottomLineHeight = 1;
            this.headerText1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerText1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerText1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.headerText1.GradientColor = System.Drawing.Color.RoyalBlue;
            this.headerText1.Location = new System.Drawing.Point(0, 0);
            this.headerText1.Margin = new System.Windows.Forms.Padding(4);
            this.headerText1.Name = "headerText1";
            this.headerText1.Size = new System.Drawing.Size(517, 94);
            this.headerText1.TabIndex = 0;
            this.headerText1.Text = "EPG Auto-Mapper";
            // 
            // panelLabels
            // 
            this.panelLabels.Controls.Add(this.labelShowChannels);
            this.panelLabels.Controls.Add(this.labelClose);
            this.panelLabels.Location = new System.Drawing.Point(184, 209);
            this.panelLabels.Name = "panelLabels";
            this.panelLabels.Size = new System.Drawing.Size(149, 22);
            this.panelLabels.TabIndex = 5;
            this.panelLabels.Visible = false;
            // 
            // labelShowChannels
            // 
            this.labelShowChannels.AutoSize = true;
            this.labelShowChannels.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelShowChannels.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelShowChannels.Location = new System.Drawing.Point(3, 0);
            this.labelShowChannels.Name = "labelShowChannels";
            this.labelShowChannels.Size = new System.Drawing.Size(95, 17);
            this.labelShowChannels.TabIndex = 0;
            this.labelShowChannels.Tag = "show";
            this.labelShowChannels.Text = "Show Channels";
            this.labelShowChannels.Click += new System.EventHandler(this.labelShowChannels_Click);
            // 
            // labelClose
            // 
            this.labelClose.AutoSize = true;
            this.labelClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelClose.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelClose.Location = new System.Drawing.Point(104, 0);
            this.labelClose.Name = "labelClose";
            this.labelClose.Size = new System.Drawing.Size(40, 17);
            this.labelClose.TabIndex = 1;
            this.labelClose.Text = "Close";
            this.labelClose.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // listBoxMappedChannels
            // 
            this.listBoxMappedChannels.FormattingEnabled = true;
            this.listBoxMappedChannels.ItemHeight = 17;
            this.listBoxMappedChannels.Location = new System.Drawing.Point(12, 239);
            this.listBoxMappedChannels.Name = "listBoxMappedChannels";
            this.listBoxMappedChannels.Size = new System.Drawing.Size(493, 361);
            this.listBoxMappedChannels.TabIndex = 6;
            // 
            // FormEpgMapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(517, 230);
            this.Controls.Add(this.listBoxMappedChannels);
            this.Controls.Add(this.panelLabels);
            this.Controls.Add(this.mProgressBarStreams);
            this.Controls.Add(this.multiInfoPanel1);
            this.Controls.Add(this.headerText1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEpgMapper";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Auto-Mapper (experimental)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEpgMapper_FormClosing);
            this.Load += new System.EventHandler(this.FormEpgMapper_Load);
            this.Shown += new System.EventHandler(this.FormEpgMapper_Shown);
            this.panelLabels.ResumeLayout(false);
            this.panelLabels.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private M3Controls.HeaderText headerText1;
        private M3Controls.InfoPanels.MultiInfoPanel multiInfoPanel1;
        private M3Controls.MProgressBar mProgressBarStreams;
        private System.Windows.Forms.FlowLayoutPanel panelLabels;
        private System.Windows.Forms.Label labelShowChannels;
        private System.Windows.Forms.Label labelClose;
        private System.Windows.Forms.ListBox listBoxMappedChannels;
    }
}