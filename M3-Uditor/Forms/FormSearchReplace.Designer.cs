namespace M3_Uditor.Forms
{
    partial class FormSearchReplace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearchReplace));
            this.headerTextSearchReplace = new M3Controls.HeaderText();
            this.mTextBoxSearchFor = new M3Controls.MTextBox();
            this.mTextBoxReplaceWith = new M3Controls.MTextBox();
            this.labelSearchFor = new System.Windows.Forms.Label();
            this.labelReplaceWith = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxInAllGroups = new System.Windows.Forms.CheckBox();
            this.radioButtonInGroups = new System.Windows.Forms.RadioButton();
            this.radioButtonInStreams = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // headerTextSearchReplace
            // 
            this.headerTextSearchReplace.Animate = false;
            this.headerTextSearchReplace.BottomLineHeight = 1;
            this.headerTextSearchReplace.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerTextSearchReplace.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerTextSearchReplace.ForeColor = System.Drawing.Color.White;
            this.headerTextSearchReplace.GradientColor = System.Drawing.Color.RoyalBlue;
            this.headerTextSearchReplace.Location = new System.Drawing.Point(0, 0);
            this.headerTextSearchReplace.Name = "headerTextSearchReplace";
            this.headerTextSearchReplace.Size = new System.Drawing.Size(498, 80);
            this.headerTextSearchReplace.TabIndex = 0;
            this.headerTextSearchReplace.Text = "Search & Replace";
            // 
            // mTextBoxSearchFor
            // 
            this.mTextBoxSearchFor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mTextBoxSearchFor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mTextBoxSearchFor.BackColor = System.Drawing.SystemColors.Window;
            this.mTextBoxSearchFor.BackgroundColor = System.Drawing.Color.Empty;
            this.mTextBoxSearchFor.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.mTextBoxSearchFor.BorderFocusColor = System.Drawing.Color.RoyalBlue;
            this.mTextBoxSearchFor.BorderSize = 2;
            this.mTextBoxSearchFor.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.mTextBoxSearchFor.ClearButton = false;
            this.mTextBoxSearchFor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTextBoxSearchFor.ForeColor = System.Drawing.Color.DimGray;
            this.mTextBoxSearchFor.Icon = null;
            this.mTextBoxSearchFor.Image = ((System.Drawing.Image)(resources.GetObject("mTextBoxSearchFor.Image")));
            this.mTextBoxSearchFor.Location = new System.Drawing.Point(13, 114);
            this.mTextBoxSearchFor.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBoxSearchFor.Multiline = false;
            this.mTextBoxSearchFor.Name = "mTextBoxSearchFor";
            this.mTextBoxSearchFor.Padding = new System.Windows.Forms.Padding(7);
            this.mTextBoxSearchFor.PasswordChar = false;
            this.mTextBoxSearchFor.Placeholder = "";
            this.mTextBoxSearchFor.ReadOnly = false;
            this.mTextBoxSearchFor.ShowPlaceholder = false;
            this.mTextBoxSearchFor.Size = new System.Drawing.Size(472, 31);
            this.mTextBoxSearchFor.TabIndex = 1;
            // 
            // mTextBoxReplaceWith
            // 
            this.mTextBoxReplaceWith.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mTextBoxReplaceWith.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mTextBoxReplaceWith.BackColor = System.Drawing.SystemColors.Window;
            this.mTextBoxReplaceWith.BackgroundColor = System.Drawing.Color.Empty;
            this.mTextBoxReplaceWith.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.mTextBoxReplaceWith.BorderFocusColor = System.Drawing.Color.RoyalBlue;
            this.mTextBoxReplaceWith.BorderSize = 2;
            this.mTextBoxReplaceWith.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.mTextBoxReplaceWith.ClearButton = false;
            this.mTextBoxReplaceWith.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTextBoxReplaceWith.ForeColor = System.Drawing.Color.DimGray;
            this.mTextBoxReplaceWith.Icon = null;
            this.mTextBoxReplaceWith.Image = ((System.Drawing.Image)(resources.GetObject("mTextBoxReplaceWith.Image")));
            this.mTextBoxReplaceWith.Location = new System.Drawing.Point(13, 170);
            this.mTextBoxReplaceWith.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBoxReplaceWith.Multiline = false;
            this.mTextBoxReplaceWith.Name = "mTextBoxReplaceWith";
            this.mTextBoxReplaceWith.Padding = new System.Windows.Forms.Padding(7);
            this.mTextBoxReplaceWith.PasswordChar = false;
            this.mTextBoxReplaceWith.Placeholder = "";
            this.mTextBoxReplaceWith.ReadOnly = false;
            this.mTextBoxReplaceWith.ShowPlaceholder = false;
            this.mTextBoxReplaceWith.Size = new System.Drawing.Size(472, 31);
            this.mTextBoxReplaceWith.TabIndex = 2;
            // 
            // labelSearchFor
            // 
            this.labelSearchFor.AutoSize = true;
            this.labelSearchFor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearchFor.Location = new System.Drawing.Point(12, 93);
            this.labelSearchFor.Name = "labelSearchFor";
            this.labelSearchFor.Size = new System.Drawing.Size(68, 17);
            this.labelSearchFor.TabIndex = 3;
            this.labelSearchFor.Text = "Search for";
            // 
            // labelReplaceWith
            // 
            this.labelReplaceWith.AutoSize = true;
            this.labelReplaceWith.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReplaceWith.Location = new System.Drawing.Point(12, 149);
            this.labelReplaceWith.Name = "labelReplaceWith";
            this.labelReplaceWith.Size = new System.Drawing.Size(81, 17);
            this.labelReplaceWith.TabIndex = 4;
            this.labelReplaceWith.Text = "Replace with";
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(411, 226);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 32);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "&Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(330, 226);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 32);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkBoxInAllGroups
            // 
            this.checkBoxInAllGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxInAllGroups.AutoSize = true;
            this.checkBoxInAllGroups.Enabled = false;
            this.checkBoxInAllGroups.Location = new System.Drawing.Point(97, 241);
            this.checkBoxInAllGroups.Name = "checkBoxInAllGroups";
            this.checkBoxInAllGroups.Size = new System.Drawing.Size(128, 17);
            this.checkBoxInAllGroups.TabIndex = 7;
            this.checkBoxInAllGroups.Text = "Search in all groups";
            this.checkBoxInAllGroups.UseVisualStyleBackColor = true;
            this.checkBoxInAllGroups.CheckedChanged += new System.EventHandler(this.checkBoxInAllGroups_CheckedChanged);
            // 
            // radioButtonInGroups
            // 
            this.radioButtonInGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonInGroups.AutoSize = true;
            this.radioButtonInGroups.Checked = true;
            this.radioButtonInGroups.Location = new System.Drawing.Point(15, 218);
            this.radioButtonInGroups.Name = "radioButtonInGroups";
            this.radioButtonInGroups.Size = new System.Drawing.Size(76, 17);
            this.radioButtonInGroups.TabIndex = 8;
            this.radioButtonInGroups.TabStop = true;
            this.radioButtonInGroups.Text = "In Groups";
            this.radioButtonInGroups.UseVisualStyleBackColor = true;
            this.radioButtonInGroups.CheckedChanged += new System.EventHandler(this.radioButtonInGroups_CheckedChanged);
            // 
            // radioButtonInStreams
            // 
            this.radioButtonInStreams.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonInStreams.AutoSize = true;
            this.radioButtonInStreams.Location = new System.Drawing.Point(97, 218);
            this.radioButtonInStreams.Name = "radioButtonInStreams";
            this.radioButtonInStreams.Size = new System.Drawing.Size(78, 17);
            this.radioButtonInStreams.TabIndex = 9;
            this.radioButtonInStreams.Text = "In Streams";
            this.radioButtonInStreams.UseVisualStyleBackColor = true;
            this.radioButtonInStreams.CheckedChanged += new System.EventHandler(this.radioButtonInStreams_CheckedChanged);
            // 
            // FormSearchReplace
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(498, 270);
            this.Controls.Add(this.radioButtonInStreams);
            this.Controls.Add(this.radioButtonInGroups);
            this.Controls.Add(this.checkBoxInAllGroups);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelReplaceWith);
            this.Controls.Add(this.labelSearchFor);
            this.Controls.Add(this.mTextBoxReplaceWith);
            this.Controls.Add(this.mTextBoxSearchFor);
            this.Controls.Add(this.headerTextSearchReplace);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(16, 291);
            this.Name = "FormSearchReplace";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "M3-Uditor";
            this.Load += new System.EventHandler(this.FormSearchReplace_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private M3Controls.HeaderText headerTextSearchReplace;
        private M3Controls.MTextBox mTextBoxSearchFor;
        private M3Controls.MTextBox mTextBoxReplaceWith;
        private System.Windows.Forms.Label labelSearchFor;
        private System.Windows.Forms.Label labelReplaceWith;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxInAllGroups;
        private System.Windows.Forms.RadioButton radioButtonInGroups;
        private System.Windows.Forms.RadioButton radioButtonInStreams;
    }
}