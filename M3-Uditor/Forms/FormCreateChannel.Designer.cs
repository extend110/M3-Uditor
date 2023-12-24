namespace M3_Uditor.Forms
{
    partial class FormCreateChannel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateChannel));
            this.mTextBoxStreamName = new M3Controls.MTextBox();
            this.labelStreamUrl = new System.Windows.Forms.Label();
            this.mTextBoxStreamUrl = new M3Controls.MTextBox();
            this.labelStreamName = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.headerTextCreateChannel = new M3Controls.HeaderText();
            this.labelInvalidUrlStream = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mTextBoxStreamName
            // 
            this.mTextBoxStreamName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mTextBoxStreamName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mTextBoxStreamName.BackColor = System.Drawing.SystemColors.Window;
            this.mTextBoxStreamName.BackgroundColor = System.Drawing.Color.Empty;
            this.mTextBoxStreamName.BorderColor = System.Drawing.Color.RoyalBlue;
            this.mTextBoxStreamName.BorderFocusColor = System.Drawing.Color.LightSteelBlue;
            this.mTextBoxStreamName.BorderSize = 2;
            this.mTextBoxStreamName.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.mTextBoxStreamName.ClearButton = false;
            this.mTextBoxStreamName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTextBoxStreamName.ForeColor = System.Drawing.Color.DimGray;
            this.mTextBoxStreamName.Icon = null;
            this.mTextBoxStreamName.Image = ((System.Drawing.Image)(resources.GetObject("mTextBoxStreamName.Image")));
            this.mTextBoxStreamName.Location = new System.Drawing.Point(14, 112);
            this.mTextBoxStreamName.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBoxStreamName.Multiline = false;
            this.mTextBoxStreamName.Name = "mTextBoxStreamName";
            this.mTextBoxStreamName.Padding = new System.Windows.Forms.Padding(7);
            this.mTextBoxStreamName.PasswordChar = false;
            this.mTextBoxStreamName.Placeholder = "";
            this.mTextBoxStreamName.ReadOnly = false;
            this.mTextBoxStreamName.ShowPlaceholder = false;
            this.mTextBoxStreamName.Size = new System.Drawing.Size(515, 29);
            this.mTextBoxStreamName.TabIndex = 0;
            // 
            // labelStreamUrl
            // 
            this.labelStreamUrl.AutoSize = true;
            this.labelStreamUrl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStreamUrl.Location = new System.Drawing.Point(12, 152);
            this.labelStreamUrl.Name = "labelStreamUrl";
            this.labelStreamUrl.Size = new System.Drawing.Size(25, 17);
            this.labelStreamUrl.TabIndex = 4;
            this.labelStreamUrl.Text = "Url";
            this.labelStreamUrl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mTextBoxStreamUrl
            // 
            this.mTextBoxStreamUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mTextBoxStreamUrl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mTextBoxStreamUrl.BackColor = System.Drawing.SystemColors.Window;
            this.mTextBoxStreamUrl.BackgroundColor = System.Drawing.Color.Empty;
            this.mTextBoxStreamUrl.BorderColor = System.Drawing.Color.RoyalBlue;
            this.mTextBoxStreamUrl.BorderFocusColor = System.Drawing.Color.LightSteelBlue;
            this.mTextBoxStreamUrl.BorderSize = 2;
            this.mTextBoxStreamUrl.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.mTextBoxStreamUrl.ClearButton = false;
            this.mTextBoxStreamUrl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTextBoxStreamUrl.ForeColor = System.Drawing.Color.DimGray;
            this.mTextBoxStreamUrl.Icon = null;
            this.mTextBoxStreamUrl.Image = ((System.Drawing.Image)(resources.GetObject("mTextBoxStreamUrl.Image")));
            this.mTextBoxStreamUrl.Location = new System.Drawing.Point(14, 172);
            this.mTextBoxStreamUrl.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBoxStreamUrl.Multiline = false;
            this.mTextBoxStreamUrl.Name = "mTextBoxStreamUrl";
            this.mTextBoxStreamUrl.Padding = new System.Windows.Forms.Padding(7);
            this.mTextBoxStreamUrl.PasswordChar = false;
            this.mTextBoxStreamUrl.Placeholder = "";
            this.mTextBoxStreamUrl.ReadOnly = false;
            this.mTextBoxStreamUrl.ShowPlaceholder = false;
            this.mTextBoxStreamUrl.Size = new System.Drawing.Size(515, 29);
            this.mTextBoxStreamUrl.TabIndex = 1;
            this.mTextBoxStreamUrl._TextChanged += new System.EventHandler(this.mTextBoxStreamUrl__TextChanged);
            // 
            // labelStreamName
            // 
            this.labelStreamName.AutoSize = true;
            this.labelStreamName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStreamName.Location = new System.Drawing.Point(12, 92);
            this.labelStreamName.Name = "labelStreamName";
            this.labelStreamName.Size = new System.Drawing.Size(43, 17);
            this.labelStreamName.TabIndex = 2;
            this.labelStreamName.Text = "Name";
            this.labelStreamName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(373, 210);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 33);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOk.Location = new System.Drawing.Point(454, 210);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 33);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // headerTextCreateChannel
            // 
            this.headerTextCreateChannel.Animate = false;
            this.headerTextCreateChannel.BottomLineHeight = 2;
            this.headerTextCreateChannel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerTextCreateChannel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerTextCreateChannel.ForeColor = System.Drawing.Color.White;
            this.headerTextCreateChannel.GradientColor = System.Drawing.Color.RoyalBlue;
            this.headerTextCreateChannel.Location = new System.Drawing.Point(0, 0);
            this.headerTextCreateChannel.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.headerTextCreateChannel.Name = "headerTextCreateChannel";
            this.headerTextCreateChannel.Size = new System.Drawing.Size(542, 79);
            this.headerTextCreateChannel.TabIndex = 26;
            this.headerTextCreateChannel.TabStop = false;
            this.headerTextCreateChannel.Text = "Create Channel";
            // 
            // labelInvalidUrlStream
            // 
            this.labelInvalidUrlStream.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInvalidUrlStream.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvalidUrlStream.ForeColor = System.Drawing.Color.Red;
            this.labelInvalidUrlStream.Location = new System.Drawing.Point(430, 152);
            this.labelInvalidUrlStream.Name = "labelInvalidUrlStream";
            this.labelInvalidUrlStream.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelInvalidUrlStream.Size = new System.Drawing.Size(100, 17);
            this.labelInvalidUrlStream.TabIndex = 27;
            this.labelInvalidUrlStream.Text = "Invalid Url";
            // 
            // FormCreateChannel
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(542, 252);
            this.Controls.Add(this.labelInvalidUrlStream);
            this.Controls.Add(this.headerTextCreateChannel);
            this.Controls.Add(this.labelStreamUrl);
            this.Controls.Add(this.mTextBoxStreamUrl);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelStreamName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.mTextBoxStreamName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(476, 291);
            this.Name = "FormCreateChannel";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "M3-Uditor";
            this.Load += new System.EventHandler(this.FormCreateChannel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private M3Controls.MTextBox mTextBoxStreamName;
        private System.Windows.Forms.Label labelStreamUrl;
        private M3Controls.MTextBox mTextBoxStreamUrl;
        private System.Windows.Forms.Label labelStreamName;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private M3Controls.HeaderText headerTextCreateChannel;
        private System.Windows.Forms.Label labelInvalidUrlStream;
    }
}