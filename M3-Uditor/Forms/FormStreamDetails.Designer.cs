namespace M3_Uditor.Forms
{
    partial class FormStreamDetails
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
            this.checkBoxStreamExport = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelStreamDuration = new System.Windows.Forms.Label();
            this.labelStreamTvgId = new System.Windows.Forms.Label();
            this.labelStreamLogo = new System.Windows.Forms.Label();
            this.labelStreamUrl = new System.Windows.Forms.Label();
            this.labelStreamName = new System.Windows.Forms.Label();
            this.headerTextStreamDetails = new M3Controls.HeaderText();
            this.textBoxStreamDuration = new M3Controls.MTextBox();
            this.textBoxStreamTvgId = new M3Controls.MTextBox();
            this.textBoxStreamLogo = new M3Controls.MTextBox();
            this.textBoxStreamUrl = new M3Controls.MTextBox();
            this.textBoxStreamName = new M3Controls.MTextBox();
            this.pictureBoxStreamLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStreamLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxStreamExport
            // 
            this.checkBoxStreamExport.AutoSize = true;
            this.checkBoxStreamExport.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxStreamExport.Location = new System.Drawing.Point(13, 390);
            this.checkBoxStreamExport.Name = "checkBoxStreamExport";
            this.checkBoxStreamExport.Size = new System.Drawing.Size(64, 20);
            this.checkBoxStreamExport.TabIndex = 24;
            this.checkBoxStreamExport.Text = "Export";
            this.checkBoxStreamExport.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(240, 454);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 33);
            this.buttonCancel.TabIndex = 23;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOk.Location = new System.Drawing.Point(321, 454);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 33);
            this.buttonOk.TabIndex = 13;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelStreamDuration
            // 
            this.labelStreamDuration.AutoSize = true;
            this.labelStreamDuration.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStreamDuration.Location = new System.Drawing.Point(10, 332);
            this.labelStreamDuration.Name = "labelStreamDuration";
            this.labelStreamDuration.Size = new System.Drawing.Size(55, 16);
            this.labelStreamDuration.TabIndex = 21;
            this.labelStreamDuration.Text = "Duration";
            // 
            // labelStreamTvgId
            // 
            this.labelStreamTvgId.AutoSize = true;
            this.labelStreamTvgId.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStreamTvgId.Location = new System.Drawing.Point(10, 277);
            this.labelStreamTvgId.Name = "labelStreamTvgId";
            this.labelStreamTvgId.Size = new System.Drawing.Size(49, 16);
            this.labelStreamTvgId.TabIndex = 19;
            this.labelStreamTvgId.Text = "TVG-ID";
            // 
            // labelStreamLogo
            // 
            this.labelStreamLogo.AutoSize = true;
            this.labelStreamLogo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStreamLogo.Location = new System.Drawing.Point(10, 222);
            this.labelStreamLogo.Name = "labelStreamLogo";
            this.labelStreamLogo.Size = new System.Drawing.Size(35, 16);
            this.labelStreamLogo.TabIndex = 17;
            this.labelStreamLogo.Text = "Logo";
            this.labelStreamLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStreamUrl
            // 
            this.labelStreamUrl.AutoSize = true;
            this.labelStreamUrl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStreamUrl.Location = new System.Drawing.Point(10, 167);
            this.labelStreamUrl.Name = "labelStreamUrl";
            this.labelStreamUrl.Size = new System.Drawing.Size(32, 16);
            this.labelStreamUrl.TabIndex = 15;
            this.labelStreamUrl.Text = "URL";
            // 
            // labelStreamName
            // 
            this.labelStreamName.AutoSize = true;
            this.labelStreamName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStreamName.Location = new System.Drawing.Point(10, 112);
            this.labelStreamName.Name = "labelStreamName";
            this.labelStreamName.Size = new System.Drawing.Size(41, 16);
            this.labelStreamName.TabIndex = 12;
            this.labelStreamName.Text = "Name";
            // 
            // headerTextStreamDetails
            // 
            this.headerTextStreamDetails.Animate = false;
            this.headerTextStreamDetails.BottomLineHeight = 2;
            this.headerTextStreamDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerTextStreamDetails.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerTextStreamDetails.ForeColor = System.Drawing.Color.White;
            this.headerTextStreamDetails.GradientColor = System.Drawing.Color.RoyalBlue;
            this.headerTextStreamDetails.Location = new System.Drawing.Point(0, 0);
            this.headerTextStreamDetails.Name = "headerTextStreamDetails";
            this.headerTextStreamDetails.Size = new System.Drawing.Size(408, 79);
            this.headerTextStreamDetails.TabIndex = 25;
            this.headerTextStreamDetails.Text = "Stream Details";
            // 
            // textBoxStreamDuration
            // 
            this.textBoxStreamDuration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStreamDuration.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxStreamDuration.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.textBoxStreamDuration.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textBoxStreamDuration.BorderSize = 2;
            this.textBoxStreamDuration.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStreamDuration.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxStreamDuration.Icon = null;
            this.textBoxStreamDuration.Location = new System.Drawing.Point(13, 352);
            this.textBoxStreamDuration.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxStreamDuration.Multiline = false;
            this.textBoxStreamDuration.Name = "textBoxStreamDuration";
            this.textBoxStreamDuration.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxStreamDuration.PasswordChar = false;
            this.textBoxStreamDuration.Placeholder = "";
            this.textBoxStreamDuration.ShowIcon = false;
            this.textBoxStreamDuration.ShowPlaceholder = false;
            this.textBoxStreamDuration.Size = new System.Drawing.Size(383, 31);
            this.textBoxStreamDuration.TabIndex = 22;
            this.textBoxStreamDuration.UnderlinedStyle = false;
            // 
            // textBoxStreamTvgId
            // 
            this.textBoxStreamTvgId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStreamTvgId.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxStreamTvgId.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.textBoxStreamTvgId.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textBoxStreamTvgId.BorderSize = 2;
            this.textBoxStreamTvgId.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStreamTvgId.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxStreamTvgId.Icon = null;
            this.textBoxStreamTvgId.Location = new System.Drawing.Point(13, 297);
            this.textBoxStreamTvgId.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxStreamTvgId.Multiline = false;
            this.textBoxStreamTvgId.Name = "textBoxStreamTvgId";
            this.textBoxStreamTvgId.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxStreamTvgId.PasswordChar = false;
            this.textBoxStreamTvgId.Placeholder = "";
            this.textBoxStreamTvgId.ShowIcon = false;
            this.textBoxStreamTvgId.ShowPlaceholder = false;
            this.textBoxStreamTvgId.Size = new System.Drawing.Size(383, 31);
            this.textBoxStreamTvgId.TabIndex = 20;
            this.textBoxStreamTvgId.UnderlinedStyle = false;
            // 
            // textBoxStreamLogo
            // 
            this.textBoxStreamLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStreamLogo.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxStreamLogo.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.textBoxStreamLogo.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textBoxStreamLogo.BorderSize = 2;
            this.textBoxStreamLogo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStreamLogo.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxStreamLogo.Icon = null;
            this.textBoxStreamLogo.Location = new System.Drawing.Point(13, 242);
            this.textBoxStreamLogo.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxStreamLogo.Multiline = false;
            this.textBoxStreamLogo.Name = "textBoxStreamLogo";
            this.textBoxStreamLogo.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxStreamLogo.PasswordChar = false;
            this.textBoxStreamLogo.Placeholder = "";
            this.textBoxStreamLogo.ShowIcon = false;
            this.textBoxStreamLogo.ShowPlaceholder = false;
            this.textBoxStreamLogo.Size = new System.Drawing.Size(383, 31);
            this.textBoxStreamLogo.TabIndex = 18;
            this.textBoxStreamLogo.UnderlinedStyle = false;
            // 
            // textBoxStreamUrl
            // 
            this.textBoxStreamUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStreamUrl.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxStreamUrl.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.textBoxStreamUrl.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textBoxStreamUrl.BorderSize = 2;
            this.textBoxStreamUrl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStreamUrl.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxStreamUrl.Icon = null;
            this.textBoxStreamUrl.Location = new System.Drawing.Point(13, 187);
            this.textBoxStreamUrl.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxStreamUrl.Multiline = false;
            this.textBoxStreamUrl.Name = "textBoxStreamUrl";
            this.textBoxStreamUrl.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxStreamUrl.PasswordChar = false;
            this.textBoxStreamUrl.Placeholder = "";
            this.textBoxStreamUrl.ShowIcon = false;
            this.textBoxStreamUrl.ShowPlaceholder = false;
            this.textBoxStreamUrl.Size = new System.Drawing.Size(383, 31);
            this.textBoxStreamUrl.TabIndex = 16;
            this.textBoxStreamUrl.UnderlinedStyle = false;
            // 
            // textBoxStreamName
            // 
            this.textBoxStreamName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStreamName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxStreamName.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.textBoxStreamName.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textBoxStreamName.BorderSize = 2;
            this.textBoxStreamName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStreamName.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxStreamName.Icon = null;
            this.textBoxStreamName.Location = new System.Drawing.Point(13, 132);
            this.textBoxStreamName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxStreamName.Multiline = false;
            this.textBoxStreamName.Name = "textBoxStreamName";
            this.textBoxStreamName.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxStreamName.PasswordChar = false;
            this.textBoxStreamName.Placeholder = "";
            this.textBoxStreamName.ShowIcon = false;
            this.textBoxStreamName.ShowPlaceholder = false;
            this.textBoxStreamName.Size = new System.Drawing.Size(383, 31);
            this.textBoxStreamName.TabIndex = 14;
            this.textBoxStreamName.UnderlinedStyle = false;
            // 
            // pictureBoxStreamLogo
            // 
            this.pictureBoxStreamLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxStreamLogo.Location = new System.Drawing.Point(13, 416);
            this.pictureBoxStreamLogo.Name = "pictureBoxStreamLogo";
            this.pictureBoxStreamLogo.Size = new System.Drawing.Size(148, 71);
            this.pictureBoxStreamLogo.TabIndex = 26;
            this.pictureBoxStreamLogo.TabStop = false;
            // 
            // FormStreamDetails
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(408, 499);
            this.Controls.Add(this.pictureBoxStreamLogo);
            this.Controls.Add(this.headerTextStreamDetails);
            this.Controls.Add(this.checkBoxStreamExport);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxStreamDuration);
            this.Controls.Add(this.labelStreamDuration);
            this.Controls.Add(this.textBoxStreamTvgId);
            this.Controls.Add(this.labelStreamTvgId);
            this.Controls.Add(this.textBoxStreamLogo);
            this.Controls.Add(this.labelStreamLogo);
            this.Controls.Add(this.textBoxStreamUrl);
            this.Controls.Add(this.labelStreamUrl);
            this.Controls.Add(this.textBoxStreamName);
            this.Controls.Add(this.labelStreamName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(424, 538);
            this.Name = "FormStreamDetails";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormStreamDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStreamLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxStreamExport;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private M3Controls.MTextBox textBoxStreamDuration;
        private System.Windows.Forms.Label labelStreamDuration;
        private M3Controls.MTextBox textBoxStreamTvgId;
        private System.Windows.Forms.Label labelStreamTvgId;
        private M3Controls.MTextBox textBoxStreamLogo;
        private System.Windows.Forms.Label labelStreamLogo;
        private M3Controls.MTextBox textBoxStreamUrl;
        private System.Windows.Forms.Label labelStreamUrl;
        private M3Controls.MTextBox textBoxStreamName;
        private System.Windows.Forms.Label labelStreamName;
        private M3Controls.HeaderText headerTextStreamDetails;
        private System.Windows.Forms.PictureBox pictureBoxStreamLogo;
    }
}