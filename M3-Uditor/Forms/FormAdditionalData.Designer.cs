namespace M3_Uditor.Forms
{
    partial class FormAdditionalData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdditionalData));
            this.labelDesciption = new System.Windows.Forms.Label();
            this.mButtonClose = new System.Windows.Forms.Button();
            this.mTextBoxAdditionalData = new M3Controls.MTextBox();
            this.headerTextForm = new M3Controls.HeaderText();
            this.SuspendLayout();
            // 
            // labelDesciption
            // 
            this.labelDesciption.AutoSize = true;
            this.labelDesciption.Location = new System.Drawing.Point(12, 138);
            this.labelDesciption.Name = "labelDesciption";
            this.labelDesciption.Size = new System.Drawing.Size(252, 17);
            this.labelDesciption.TabIndex = 3;
            this.labelDesciption.Text = "Extra headers for M3U - File. One per line";
            // 
            // mButtonClose
            // 
            this.mButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mButtonClose.Location = new System.Drawing.Point(434, 438);
            this.mButtonClose.Name = "mButtonClose";
            this.mButtonClose.Size = new System.Drawing.Size(95, 36);
            this.mButtonClose.TabIndex = 4;
            this.mButtonClose.Text = "Close";
            this.mButtonClose.UseVisualStyleBackColor = true;
            this.mButtonClose.Click += new System.EventHandler(this.mButtonClose_Click);
            // 
            // mTextBoxAdditionalData
            // 
            this.mTextBoxAdditionalData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mTextBoxAdditionalData.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mTextBoxAdditionalData.BackColor = System.Drawing.SystemColors.Window;
            this.mTextBoxAdditionalData.BackgroundColor = System.Drawing.Color.Empty;
            this.mTextBoxAdditionalData.BorderColor = System.Drawing.Color.RoyalBlue;
            this.mTextBoxAdditionalData.BorderFocusColor = System.Drawing.Color.LightSteelBlue;
            this.mTextBoxAdditionalData.BorderSize = 2;
            this.mTextBoxAdditionalData.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.mTextBoxAdditionalData.ClearButton = false;
            this.mTextBoxAdditionalData.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTextBoxAdditionalData.ForeColor = System.Drawing.Color.DimGray;
            this.mTextBoxAdditionalData.Icon = null;
            this.mTextBoxAdditionalData.Image = ((System.Drawing.Image)(resources.GetObject("mTextBoxAdditionalData.Image")));
            this.mTextBoxAdditionalData.Location = new System.Drawing.Point(14, 160);
            this.mTextBoxAdditionalData.Margin = new System.Windows.Forms.Padding(5);
            this.mTextBoxAdditionalData.Multiline = true;
            this.mTextBoxAdditionalData.Name = "mTextBoxAdditionalData";
            this.mTextBoxAdditionalData.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.mTextBoxAdditionalData.PasswordChar = false;
            this.mTextBoxAdditionalData.Placeholder = "";
            this.mTextBoxAdditionalData.ReadOnly = false;
            this.mTextBoxAdditionalData.ShowPlaceholder = false;
            this.mTextBoxAdditionalData.Size = new System.Drawing.Size(515, 270);
            this.mTextBoxAdditionalData.TabIndex = 2;
            // 
            // headerTextForm
            // 
            this.headerTextForm.Animate = false;
            this.headerTextForm.BottomLineHeight = 1;
            this.headerTextForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerTextForm.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerTextForm.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.headerTextForm.GradientColor = System.Drawing.Color.RoyalBlue;
            this.headerTextForm.Location = new System.Drawing.Point(0, 0);
            this.headerTextForm.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.headerTextForm.Name = "headerTextForm";
            this.headerTextForm.Size = new System.Drawing.Size(543, 123);
            this.headerTextForm.TabIndex = 0;
            this.headerTextForm.Text = "Additional M3U Headers";
            // 
            // FormAdditionalData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(543, 486);
            this.Controls.Add(this.mButtonClose);
            this.Controls.Add(this.labelDesciption);
            this.Controls.Add(this.mTextBoxAdditionalData);
            this.Controls.Add(this.headerTextForm);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAdditionalData";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "M3-Uditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAdditionalData_FormClosing);
            this.Load += new System.EventHandler(this.FormAdditionalData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private M3Controls.HeaderText headerTextForm;
        private M3Controls.MTextBox mTextBoxAdditionalData;
        private System.Windows.Forms.Label labelDesciption;
        private System.Windows.Forms.Button mButtonClose;
    }
}