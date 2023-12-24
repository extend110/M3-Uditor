namespace M3_Uditor.Forms
{
    partial class FormGroupDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGroupDetails));
            this.headerText1 = new M3Controls.HeaderText();
            this.mTextBoxDetails = new M3Controls.MTextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerText1
            // 
            this.headerText1.Animate = false;
            this.headerText1.BottomLineHeight = 1;
            this.headerText1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerText1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerText1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.headerText1.GradientColor = System.Drawing.Color.RoyalBlue;
            this.headerText1.Location = new System.Drawing.Point(0, 0);
            this.headerText1.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.headerText1.Name = "headerText1";
            this.headerText1.Size = new System.Drawing.Size(677, 118);
            this.headerText1.TabIndex = 0;
            this.headerText1.Text = "Group Details";
            // 
            // mTextBoxDetails
            // 
            this.mTextBoxDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mTextBoxDetails.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mTextBoxDetails.BackColor = System.Drawing.SystemColors.Window;
            this.mTextBoxDetails.BackgroundColor = System.Drawing.Color.Empty;
            this.mTextBoxDetails.BorderColor = System.Drawing.Color.RoyalBlue;
            this.mTextBoxDetails.BorderFocusColor = System.Drawing.Color.LightSteelBlue;
            this.mTextBoxDetails.BorderSize = 2;
            this.mTextBoxDetails.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.mTextBoxDetails.ClearButton = false;
            this.mTextBoxDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTextBoxDetails.ForeColor = System.Drawing.Color.DimGray;
            this.mTextBoxDetails.Icon = null;
            this.mTextBoxDetails.Image = ((System.Drawing.Image)(resources.GetObject("mTextBoxDetails.Image")));
            this.mTextBoxDetails.Location = new System.Drawing.Point(13, 125);
            this.mTextBoxDetails.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBoxDetails.Multiline = true;
            this.mTextBoxDetails.Name = "mTextBoxDetails";
            this.mTextBoxDetails.Padding = new System.Windows.Forms.Padding(7);
            this.mTextBoxDetails.PasswordChar = false;
            this.mTextBoxDetails.Placeholder = "";
            this.mTextBoxDetails.ReadOnly = false;
            this.mTextBoxDetails.ShowPlaceholder = false;
            this.mTextBoxDetails.Size = new System.Drawing.Size(651, 310);
            this.mTextBoxDetails.TabIndex = 1;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(581, 442);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(83, 31);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // FormGroupDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(677, 485);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.mTextBoxDetails);
            this.Controls.Add(this.headerText1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGroupDetails";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "M3-Uditor";
            this.Load += new System.EventHandler(this.FormGroupDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private M3Controls.HeaderText headerText1;
        private M3Controls.MTextBox mTextBoxDetails;
        private System.Windows.Forms.Button buttonClose;
    }
}