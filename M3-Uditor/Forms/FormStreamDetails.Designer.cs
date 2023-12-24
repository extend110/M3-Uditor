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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStreamDetails));
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
            this.labelInvalidUrlStream = new System.Windows.Forms.Label();
            this.textBoxStreamTvgName = new M3Controls.MTextBox();
            this.labelStreamTvgName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStreamLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxStreamExport
            // 
            this.checkBoxStreamExport.AutoSize = true;
            this.checkBoxStreamExport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxStreamExport.Location = new System.Drawing.Point(13, 390);
            this.checkBoxStreamExport.Name = "checkBoxStreamExport";
            this.checkBoxStreamExport.Size = new System.Drawing.Size(65, 21);
            this.checkBoxStreamExport.TabIndex = 24;
            this.checkBoxStreamExport.Text = "Export";
            this.checkBoxStreamExport.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(402, 454);
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
            this.buttonOk.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOk.Location = new System.Drawing.Point(483, 454);
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
            this.labelStreamDuration.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStreamDuration.Location = new System.Drawing.Point(10, 332);
            this.labelStreamDuration.Name = "labelStreamDuration";
            this.labelStreamDuration.Size = new System.Drawing.Size(58, 17);
            this.labelStreamDuration.TabIndex = 21;
            this.labelStreamDuration.Text = "Duration";
            // 
            // labelStreamTvgId
            // 
            this.labelStreamTvgId.AutoSize = true;
            this.labelStreamTvgId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStreamTvgId.Location = new System.Drawing.Point(10, 277);
            this.labelStreamTvgId.Name = "labelStreamTvgId";
            this.labelStreamTvgId.Size = new System.Drawing.Size(49, 17);
            this.labelStreamTvgId.TabIndex = 19;
            this.labelStreamTvgId.Text = "TVG-ID";
            // 
            // labelStreamLogo
            // 
            this.labelStreamLogo.AutoSize = true;
            this.labelStreamLogo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStreamLogo.Location = new System.Drawing.Point(10, 222);
            this.labelStreamLogo.Name = "labelStreamLogo";
            this.labelStreamLogo.Size = new System.Drawing.Size(38, 17);
            this.labelStreamLogo.TabIndex = 17;
            this.labelStreamLogo.Text = "Logo";
            this.labelStreamLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStreamUrl
            // 
            this.labelStreamUrl.AutoSize = true;
            this.labelStreamUrl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStreamUrl.Location = new System.Drawing.Point(10, 167);
            this.labelStreamUrl.Name = "labelStreamUrl";
            this.labelStreamUrl.Size = new System.Drawing.Size(31, 17);
            this.labelStreamUrl.TabIndex = 15;
            this.labelStreamUrl.Text = "URL";
            // 
            // labelStreamName
            // 
            this.labelStreamName.AutoSize = true;
            this.labelStreamName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStreamName.Location = new System.Drawing.Point(10, 112);
            this.labelStreamName.Name = "labelStreamName";
            this.labelStreamName.Size = new System.Drawing.Size(43, 17);
            this.labelStreamName.TabIndex = 12;
            this.labelStreamName.Text = "Name";
            // 
            // headerTextStreamDetails
            // 
            this.headerTextStreamDetails.Animate = false;
            this.headerTextStreamDetails.BottomLineHeight = 1;
            this.headerTextStreamDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerTextStreamDetails.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerTextStreamDetails.ForeColor = System.Drawing.Color.White;
            this.headerTextStreamDetails.GradientColor = System.Drawing.Color.RoyalBlue;
            this.headerTextStreamDetails.Location = new System.Drawing.Point(0, 0);
            this.headerTextStreamDetails.Name = "headerTextStreamDetails";
            this.headerTextStreamDetails.Size = new System.Drawing.Size(570, 79);
            this.headerTextStreamDetails.TabIndex = 25;
            this.headerTextStreamDetails.Text = "Stream Details";
            // 
            // textBoxStreamDuration
            // 
            this.textBoxStreamDuration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStreamDuration.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.textBoxStreamDuration.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxStreamDuration.BackgroundColor = System.Drawing.Color.Empty;
            this.textBoxStreamDuration.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.textBoxStreamDuration.BorderFocusColor = System.Drawing.Color.RoyalBlue;
            this.textBoxStreamDuration.BorderSize = 2;
            this.textBoxStreamDuration.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.textBoxStreamDuration.ClearButton = false;
            this.textBoxStreamDuration.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStreamDuration.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxStreamDuration.Icon = null;
            this.textBoxStreamDuration.Image = ((System.Drawing.Image)(resources.GetObject("textBoxStreamDuration.Image")));
            this.textBoxStreamDuration.Location = new System.Drawing.Point(13, 352);
            this.textBoxStreamDuration.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxStreamDuration.Multiline = false;
            this.textBoxStreamDuration.Name = "textBoxStreamDuration";
            this.textBoxStreamDuration.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxStreamDuration.PasswordChar = false;
            this.textBoxStreamDuration.Placeholder = "";
            this.textBoxStreamDuration.ReadOnly = false;
            this.textBoxStreamDuration.ShowPlaceholder = false;
            this.textBoxStreamDuration.Size = new System.Drawing.Size(545, 32);
            this.textBoxStreamDuration.TabIndex = 22;
            // 
            // textBoxStreamTvgId
            // 
            this.textBoxStreamTvgId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.textBoxStreamTvgId.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxStreamTvgId.BackgroundColor = System.Drawing.Color.Empty;
            this.textBoxStreamTvgId.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.textBoxStreamTvgId.BorderFocusColor = System.Drawing.Color.RoyalBlue;
            this.textBoxStreamTvgId.BorderSize = 2;
            this.textBoxStreamTvgId.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.textBoxStreamTvgId.ClearButton = true;
            this.textBoxStreamTvgId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStreamTvgId.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxStreamTvgId.Icon = null;
            this.textBoxStreamTvgId.Image = global::M3_Uditor.Properties.Resources.epg_icon;
            this.textBoxStreamTvgId.Location = new System.Drawing.Point(13, 297);
            this.textBoxStreamTvgId.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxStreamTvgId.Multiline = false;
            this.textBoxStreamTvgId.Name = "textBoxStreamTvgId";
            this.textBoxStreamTvgId.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxStreamTvgId.PasswordChar = false;
            this.textBoxStreamTvgId.Placeholder = "";
            this.textBoxStreamTvgId.ReadOnly = false;
            this.textBoxStreamTvgId.ShowPlaceholder = false;
            this.textBoxStreamTvgId.Size = new System.Drawing.Size(270, 32);
            this.textBoxStreamTvgId.TabIndex = 20;
            this.textBoxStreamTvgId.ButtonClicked += new System.EventHandler(this.textBoxStreamTvgId_ButtonClicked);
            // 
            // textBoxStreamLogo
            // 
            this.textBoxStreamLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStreamLogo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.textBoxStreamLogo.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxStreamLogo.BackgroundColor = System.Drawing.Color.Empty;
            this.textBoxStreamLogo.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.textBoxStreamLogo.BorderFocusColor = System.Drawing.Color.RoyalBlue;
            this.textBoxStreamLogo.BorderSize = 2;
            this.textBoxStreamLogo.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.textBoxStreamLogo.ClearButton = false;
            this.textBoxStreamLogo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStreamLogo.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxStreamLogo.Icon = null;
            this.textBoxStreamLogo.Image = ((System.Drawing.Image)(resources.GetObject("textBoxStreamLogo.Image")));
            this.textBoxStreamLogo.Location = new System.Drawing.Point(13, 242);
            this.textBoxStreamLogo.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxStreamLogo.Multiline = false;
            this.textBoxStreamLogo.Name = "textBoxStreamLogo";
            this.textBoxStreamLogo.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxStreamLogo.PasswordChar = false;
            this.textBoxStreamLogo.Placeholder = "";
            this.textBoxStreamLogo.ReadOnly = false;
            this.textBoxStreamLogo.ShowPlaceholder = false;
            this.textBoxStreamLogo.Size = new System.Drawing.Size(545, 32);
            this.textBoxStreamLogo.TabIndex = 18;
            // 
            // textBoxStreamUrl
            // 
            this.textBoxStreamUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStreamUrl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.textBoxStreamUrl.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxStreamUrl.BackgroundColor = System.Drawing.Color.Empty;
            this.textBoxStreamUrl.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.textBoxStreamUrl.BorderFocusColor = System.Drawing.Color.RoyalBlue;
            this.textBoxStreamUrl.BorderSize = 2;
            this.textBoxStreamUrl.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.textBoxStreamUrl.ClearButton = false;
            this.textBoxStreamUrl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStreamUrl.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxStreamUrl.Icon = null;
            this.textBoxStreamUrl.Image = ((System.Drawing.Image)(resources.GetObject("textBoxStreamUrl.Image")));
            this.textBoxStreamUrl.Location = new System.Drawing.Point(13, 187);
            this.textBoxStreamUrl.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxStreamUrl.Multiline = false;
            this.textBoxStreamUrl.Name = "textBoxStreamUrl";
            this.textBoxStreamUrl.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxStreamUrl.PasswordChar = false;
            this.textBoxStreamUrl.Placeholder = "";
            this.textBoxStreamUrl.ReadOnly = false;
            this.textBoxStreamUrl.ShowPlaceholder = false;
            this.textBoxStreamUrl.Size = new System.Drawing.Size(545, 32);
            this.textBoxStreamUrl.TabIndex = 16;
            this.textBoxStreamUrl._TextChanged += new System.EventHandler(this.textBoxStreamUrl__TextChanged);
            // 
            // textBoxStreamName
            // 
            this.textBoxStreamName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStreamName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.textBoxStreamName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxStreamName.BackgroundColor = System.Drawing.Color.Empty;
            this.textBoxStreamName.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.textBoxStreamName.BorderFocusColor = System.Drawing.Color.RoyalBlue;
            this.textBoxStreamName.BorderSize = 2;
            this.textBoxStreamName.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.textBoxStreamName.ClearButton = false;
            this.textBoxStreamName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStreamName.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxStreamName.Icon = null;
            this.textBoxStreamName.Image = ((System.Drawing.Image)(resources.GetObject("textBoxStreamName.Image")));
            this.textBoxStreamName.Location = new System.Drawing.Point(13, 132);
            this.textBoxStreamName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxStreamName.Multiline = false;
            this.textBoxStreamName.Name = "textBoxStreamName";
            this.textBoxStreamName.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxStreamName.PasswordChar = false;
            this.textBoxStreamName.Placeholder = "";
            this.textBoxStreamName.ReadOnly = false;
            this.textBoxStreamName.ShowPlaceholder = false;
            this.textBoxStreamName.Size = new System.Drawing.Size(545, 32);
            this.textBoxStreamName.TabIndex = 14;
            // 
            // pictureBoxStreamLogo
            // 
            this.pictureBoxStreamLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxStreamLogo.InitialImage = null;
            this.pictureBoxStreamLogo.Location = new System.Drawing.Point(13, 416);
            this.pictureBoxStreamLogo.Name = "pictureBoxStreamLogo";
            this.pictureBoxStreamLogo.Size = new System.Drawing.Size(148, 71);
            this.pictureBoxStreamLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxStreamLogo.TabIndex = 26;
            this.pictureBoxStreamLogo.TabStop = false;
            // 
            // labelInvalidUrlStream
            // 
            this.labelInvalidUrlStream.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelInvalidUrlStream.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvalidUrlStream.ForeColor = System.Drawing.Color.Red;
            this.labelInvalidUrlStream.Location = new System.Drawing.Point(483, 170);
            this.labelInvalidUrlStream.Name = "labelInvalidUrlStream";
            this.labelInvalidUrlStream.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelInvalidUrlStream.Size = new System.Drawing.Size(75, 16);
            this.labelInvalidUrlStream.TabIndex = 27;
            this.labelInvalidUrlStream.Text = "Invalid Url";
            this.labelInvalidUrlStream.Visible = false;
            // 
            // textBoxStreamTvgName
            // 
            this.textBoxStreamTvgName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStreamTvgName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.textBoxStreamTvgName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxStreamTvgName.BackgroundColor = System.Drawing.Color.Empty;
            this.textBoxStreamTvgName.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.textBoxStreamTvgName.BorderFocusColor = System.Drawing.Color.RoyalBlue;
            this.textBoxStreamTvgName.BorderSize = 2;
            this.textBoxStreamTvgName.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.textBoxStreamTvgName.ClearButton = false;
            this.textBoxStreamTvgName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStreamTvgName.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxStreamTvgName.Icon = null;
            this.textBoxStreamTvgName.Image = global::M3_Uditor.Properties.Resources.epg_icon;
            this.textBoxStreamTvgName.Location = new System.Drawing.Point(288, 297);
            this.textBoxStreamTvgName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxStreamTvgName.Multiline = false;
            this.textBoxStreamTvgName.Name = "textBoxStreamTvgName";
            this.textBoxStreamTvgName.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxStreamTvgName.PasswordChar = false;
            this.textBoxStreamTvgName.Placeholder = "";
            this.textBoxStreamTvgName.ReadOnly = false;
            this.textBoxStreamTvgName.ShowPlaceholder = false;
            this.textBoxStreamTvgName.Size = new System.Drawing.Size(270, 32);
            this.textBoxStreamTvgName.TabIndex = 30;
            // 
            // labelStreamTvgName
            // 
            this.labelStreamTvgName.AutoSize = true;
            this.labelStreamTvgName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStreamTvgName.Location = new System.Drawing.Point(285, 277);
            this.labelStreamTvgName.Name = "labelStreamTvgName";
            this.labelStreamTvgName.Size = new System.Drawing.Size(72, 17);
            this.labelStreamTvgName.TabIndex = 29;
            this.labelStreamTvgName.Text = "TVG-Name";
            // 
            // FormStreamDetails
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(570, 499);
            this.Controls.Add(this.textBoxStreamTvgName);
            this.Controls.Add(this.labelStreamTvgName);
            this.Controls.Add(this.labelInvalidUrlStream);
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
            this.Text = "M3-Uditor";
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
        private System.Windows.Forms.Label labelInvalidUrlStream;
        private M3Controls.MTextBox textBoxStreamTvgName;
        private System.Windows.Forms.Label labelStreamTvgName;
    }
}