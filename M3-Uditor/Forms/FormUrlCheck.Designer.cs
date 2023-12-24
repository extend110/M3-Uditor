namespace M3_Uditor.Forms
{
    partial class FormUrlCheck
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.multiInfoPanel1 = new M3Controls.InfoPanels.MultiInfoPanel();
            this.headerText1 = new M3Controls.HeaderText();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(456, 183);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(91, 30);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // multiInfoPanel1
            // 
            this.multiInfoPanel1.BoundsTextLeft = new System.Drawing.Rectangle(74, 5, 0, 0);
            this.multiInfoPanel1.BoundsTextRight = new System.Drawing.Rectangle(533, 5, 0, 0);
            this.multiInfoPanel1.ClickedColor = System.Drawing.Color.Empty;
            this.multiInfoPanel1.DrawBorder = false;
            this.multiInfoPanel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.multiInfoPanel1.HoverColor = System.Drawing.Color.Empty;
            this.multiInfoPanel1.Image = global::M3_Uditor.Properties.Resources.CheckLinks;
            this.multiInfoPanel1.ImageSize = 64;
            this.multiInfoPanel1.Location = new System.Drawing.Point(12, 103);
            this.multiInfoPanel1.Maximum = 100;
            this.multiInfoPanel1.Name = "multiInfoPanel1";
            this.multiInfoPanel1.ProgressValue = 0;
            this.multiInfoPanel1.ProgressVisible = true;
            this.multiInfoPanel1.Size = new System.Drawing.Size(543, 74);
            this.multiInfoPanel1.TabIndex = 4;
            this.multiInfoPanel1.Text = "multiInfoPanel1";
            this.multiInfoPanel1.TextBottom = null;
            this.multiInfoPanel1.TextLeft = null;
            this.multiInfoPanel1.TextRight = null;
            this.multiInfoPanel1.Truncate = true;
            // 
            // headerText1
            // 
            this.headerText1.Animate = true;
            this.headerText1.BottomLineHeight = 1;
            this.headerText1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerText1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerText1.ForeColor = System.Drawing.Color.White;
            this.headerText1.GradientColor = System.Drawing.Color.RoyalBlue;
            this.headerText1.Location = new System.Drawing.Point(0, 0);
            this.headerText1.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.headerText1.Name = "headerText1";
            this.headerText1.Size = new System.Drawing.Size(567, 97);
            this.headerText1.TabIndex = 3;
            this.headerText1.Text = "IPTV Linkcheck";
            // 
            // FormUrlCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(567, 225);
            this.Controls.Add(this.multiInfoPanel1);
            this.Controls.Add(this.headerText1);
            this.Controls.Add(this.buttonCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUrlCheck";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "M3-Uditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUrlCheck_FormClosing);
            this.Shown += new System.EventHandler(this.FormUrlCheck_Shown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonCancel;
        private M3Controls.HeaderText headerText1;
        private M3Controls.InfoPanels.MultiInfoPanel multiInfoPanel1;
    }
}