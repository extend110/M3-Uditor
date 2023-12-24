namespace M3_Uditor.Forms
{
    partial class FormAddGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddGroup));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.textBoxGroupName = new M3Controls.MTextBox();
            this.headerText1 = new M3Controls.HeaderText();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(381, 136);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 29);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOk.Location = new System.Drawing.Point(462, 136);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 29);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // textBoxGroupName
            // 
            this.textBoxGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGroupName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.textBoxGroupName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxGroupName.BackgroundColor = System.Drawing.Color.Empty;
            this.textBoxGroupName.BorderColor = System.Drawing.Color.RoyalBlue;
            this.textBoxGroupName.BorderFocusColor = System.Drawing.Color.LightSteelBlue;
            this.textBoxGroupName.BorderSize = 2;
            this.textBoxGroupName.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.textBoxGroupName.ClearButton = false;
            this.textBoxGroupName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGroupName.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxGroupName.Icon = null;
            this.textBoxGroupName.Image = ((System.Drawing.Image)(resources.GetObject("textBoxGroupName.Image")));
            this.textBoxGroupName.Location = new System.Drawing.Point(14, 92);
            this.textBoxGroupName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxGroupName.Multiline = false;
            this.textBoxGroupName.Name = "textBoxGroupName";
            this.textBoxGroupName.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxGroupName.PasswordChar = false;
            this.textBoxGroupName.Placeholder = "";
            this.textBoxGroupName.ReadOnly = false;
            this.textBoxGroupName.ShowPlaceholder = false;
            this.textBoxGroupName.Size = new System.Drawing.Size(523, 29);
            this.textBoxGroupName.TabIndex = 1;
            // 
            // headerText1
            // 
            this.headerText1.Animate = false;
            this.headerText1.BottomLineHeight = 1;
            this.headerText1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerText1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerText1.ForeColor = System.Drawing.Color.White;
            this.headerText1.GradientColor = System.Drawing.Color.RoyalBlue;
            this.headerText1.Location = new System.Drawing.Point(0, 0);
            this.headerText1.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.headerText1.Name = "headerText1";
            this.headerText1.Size = new System.Drawing.Size(549, 74);
            this.headerText1.TabIndex = 4;
            this.headerText1.TabStop = false;
            this.headerText1.Text = "Create Group";
            // 
            // FormAddGroup
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(549, 177);
            this.Controls.Add(this.headerText1);
            this.Controls.Add(this.textBoxGroupName);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(358, 216);
            this.Name = "FormAddGroup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "M3-Uditor";
            this.Load += new System.EventHandler(this.FormAddGroup_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private M3Controls.MTextBox textBoxGroupName;
        private M3Controls.HeaderText headerText1;
    }
}