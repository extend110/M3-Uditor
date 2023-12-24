namespace M3_Uditor.Forms
{
    partial class FormWebImporter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWebImporter));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.textBoxUrl = new M3Controls.MTextBox();
            this.progressBarDownload = new M3Controls.MProgressBar();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(272, 51);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 34);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOk.Location = new System.Drawing.Point(353, 51);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 34);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.textBoxUrl.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxUrl.BackgroundColor = System.Drawing.Color.Empty;
            this.textBoxUrl.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.textBoxUrl.BorderFocusColor = System.Drawing.Color.RoyalBlue;
            this.textBoxUrl.BorderSize = 2;
            this.textBoxUrl.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.textBoxUrl.ClearButton = false;
            this.textBoxUrl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUrl.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxUrl.Icon = null;
            this.textBoxUrl.Image = ((System.Drawing.Image)(resources.GetObject("textBoxUrl.Image")));
            this.textBoxUrl.Location = new System.Drawing.Point(13, 13);
            this.textBoxUrl.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUrl.Multiline = false;
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxUrl.PasswordChar = false;
            this.textBoxUrl.Placeholder = "Playlist Url";
            this.textBoxUrl.ReadOnly = false;
            this.textBoxUrl.ShowPlaceholder = false;
            this.textBoxUrl.Size = new System.Drawing.Size(415, 29);
            this.textBoxUrl.TabIndex = 4;
            // 
            // progressBarDownload
            // 
            this.progressBarDownload.BackColor = System.Drawing.Color.White;
            this.progressBarDownload.ForeColor = System.Drawing.Color.Red;
            this.progressBarDownload.Location = new System.Drawing.Point(13, 13);
            this.progressBarDownload.Name = "progressBarDownload";
            this.progressBarDownload.ProgressBarColor = System.Drawing.Color.RoyalBlue;
            this.progressBarDownload.ProgressBarFont = new System.Drawing.Font("Segoe UI", 8F);
            this.progressBarDownload.Size = new System.Drawing.Size(415, 31);
            this.progressBarDownload.TabIndex = 5;
            this.progressBarDownload.Visible = false;
            // 
            // FormWebImporter
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(441, 94);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.progressBarDownload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWebImporter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "M3-Uditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormWebImporter_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private M3Controls.MTextBox textBoxUrl;
        private M3Controls.MProgressBar progressBarDownload;
    }
}