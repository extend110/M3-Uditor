namespace M3_Uditor.Forms
{
    partial class FormSettings
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
            this.headerTextStreamDetails = new M3Controls.HeaderText();
            this.tabControlSetting = new System.Windows.Forms.TabControl();
            this.tabPageSettingsMain = new System.Windows.Forms.TabPage();
            this.checkBoxCheckLinkAsync = new System.Windows.Forms.CheckBox();
            this.numericUpDownStreamRequestTimeout = new System.Windows.Forms.NumericUpDown();
            this.labelStreamRequestTimeout = new System.Windows.Forms.Label();
            this.buttonChooseFile = new System.Windows.Forms.Button();
            this.mTextBoxVlcPath = new M3Controls.MTextBox();
            this.labelVlcPath = new System.Windows.Forms.Label();
            this.checkBoxAskBeforeDeleteStream = new System.Windows.Forms.CheckBox();
            this.checkBoxAskBeforeDeleteGroup = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBoxExportInactive = new System.Windows.Forms.CheckBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.tabControlSetting.SuspendLayout();
            this.tabPageSettingsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStreamRequestTimeout)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
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
            this.headerTextStreamDetails.Size = new System.Drawing.Size(550, 79);
            this.headerTextStreamDetails.TabIndex = 26;
            this.headerTextStreamDetails.Text = "Settings";
            // 
            // tabControlSetting
            // 
            this.tabControlSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSetting.Controls.Add(this.tabPageSettingsMain);
            this.tabControlSetting.Controls.Add(this.tabPage2);
            this.tabControlSetting.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlSetting.Location = new System.Drawing.Point(12, 85);
            this.tabControlSetting.Name = "tabControlSetting";
            this.tabControlSetting.SelectedIndex = 0;
            this.tabControlSetting.Size = new System.Drawing.Size(526, 318);
            this.tabControlSetting.TabIndex = 27;
            // 
            // tabPageSettingsMain
            // 
            this.tabPageSettingsMain.Controls.Add(this.checkBoxCheckLinkAsync);
            this.tabPageSettingsMain.Controls.Add(this.numericUpDownStreamRequestTimeout);
            this.tabPageSettingsMain.Controls.Add(this.labelStreamRequestTimeout);
            this.tabPageSettingsMain.Controls.Add(this.buttonChooseFile);
            this.tabPageSettingsMain.Controls.Add(this.mTextBoxVlcPath);
            this.tabPageSettingsMain.Controls.Add(this.labelVlcPath);
            this.tabPageSettingsMain.Controls.Add(this.checkBoxAskBeforeDeleteStream);
            this.tabPageSettingsMain.Controls.Add(this.checkBoxAskBeforeDeleteGroup);
            this.tabPageSettingsMain.Location = new System.Drawing.Point(4, 26);
            this.tabPageSettingsMain.Name = "tabPageSettingsMain";
            this.tabPageSettingsMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettingsMain.Size = new System.Drawing.Size(518, 288);
            this.tabPageSettingsMain.TabIndex = 0;
            this.tabPageSettingsMain.Text = "Main";
            this.tabPageSettingsMain.UseVisualStyleBackColor = true;
            // 
            // checkBoxCheckLinkAsync
            // 
            this.checkBoxCheckLinkAsync.AutoSize = true;
            this.checkBoxCheckLinkAsync.Location = new System.Drawing.Point(19, 199);
            this.checkBoxCheckLinkAsync.Name = "checkBoxCheckLinkAsync";
            this.checkBoxCheckLinkAsync.Size = new System.Drawing.Size(167, 21);
            this.checkBoxCheckLinkAsync.TabIndex = 30;
            this.checkBoxCheckLinkAsync.Text = "Multithreaded Linkcheck";
            this.checkBoxCheckLinkAsync.UseVisualStyleBackColor = true;
            // 
            // numericUpDownStreamRequestTimeout
            // 
            this.numericUpDownStreamRequestTimeout.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownStreamRequestTimeout.Location = new System.Drawing.Point(19, 168);
            this.numericUpDownStreamRequestTimeout.Name = "numericUpDownStreamRequestTimeout";
            this.numericUpDownStreamRequestTimeout.Size = new System.Drawing.Size(167, 25);
            this.numericUpDownStreamRequestTimeout.TabIndex = 29;
            // 
            // labelStreamRequestTimeout
            // 
            this.labelStreamRequestTimeout.AutoSize = true;
            this.labelStreamRequestTimeout.Location = new System.Drawing.Point(16, 148);
            this.labelStreamRequestTimeout.Name = "labelStreamRequestTimeout";
            this.labelStreamRequestTimeout.Size = new System.Drawing.Size(151, 17);
            this.labelStreamRequestTimeout.TabIndex = 5;
            this.labelStreamRequestTimeout.Text = "Stream Request Timeout";
            // 
            // buttonChooseFile
            // 
            this.buttonChooseFile.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonChooseFile.Location = new System.Drawing.Point(459, 101);
            this.buttonChooseFile.Name = "buttonChooseFile";
            this.buttonChooseFile.Size = new System.Drawing.Size(38, 31);
            this.buttonChooseFile.TabIndex = 4;
            this.buttonChooseFile.Text = "...";
            this.buttonChooseFile.UseVisualStyleBackColor = true;
            this.buttonChooseFile.Click += new System.EventHandler(this.buttonChooseFile_Click);
            // 
            // mTextBoxVlcPath
            // 
            this.mTextBoxVlcPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mTextBoxVlcPath.BackColor = System.Drawing.SystemColors.Window;
            this.mTextBoxVlcPath.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.mTextBoxVlcPath.BorderFocusColor = System.Drawing.Color.HotPink;
            this.mTextBoxVlcPath.BorderSize = 2;
            this.mTextBoxVlcPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTextBoxVlcPath.ForeColor = System.Drawing.Color.DimGray;
            this.mTextBoxVlcPath.Icon = null;
            this.mTextBoxVlcPath.Location = new System.Drawing.Point(19, 101);
            this.mTextBoxVlcPath.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBoxVlcPath.Multiline = false;
            this.mTextBoxVlcPath.Name = "mTextBoxVlcPath";
            this.mTextBoxVlcPath.Padding = new System.Windows.Forms.Padding(7);
            this.mTextBoxVlcPath.PasswordChar = false;
            this.mTextBoxVlcPath.Placeholder = "";
            this.mTextBoxVlcPath.ShowIcon = false;
            this.mTextBoxVlcPath.ShowPlaceholder = false;
            this.mTextBoxVlcPath.Size = new System.Drawing.Size(437, 31);
            this.mTextBoxVlcPath.TabIndex = 3;
            this.mTextBoxVlcPath.UnderlinedStyle = false;
            // 
            // labelVlcPath
            // 
            this.labelVlcPath.AutoSize = true;
            this.labelVlcPath.Location = new System.Drawing.Point(16, 81);
            this.labelVlcPath.Name = "labelVlcPath";
            this.labelVlcPath.Size = new System.Drawing.Size(96, 17);
            this.labelVlcPath.TabIndex = 2;
            this.labelVlcPath.Text = "VLC Executable";
            // 
            // checkBoxAskBeforeDeleteStream
            // 
            this.checkBoxAskBeforeDeleteStream.AutoSize = true;
            this.checkBoxAskBeforeDeleteStream.Location = new System.Drawing.Point(19, 48);
            this.checkBoxAskBeforeDeleteStream.Name = "checkBoxAskBeforeDeleteStream";
            this.checkBoxAskBeforeDeleteStream.Size = new System.Drawing.Size(174, 21);
            this.checkBoxAskBeforeDeleteStream.TabIndex = 1;
            this.checkBoxAskBeforeDeleteStream.Text = "Ask before delete stream";
            this.checkBoxAskBeforeDeleteStream.UseVisualStyleBackColor = true;
            // 
            // checkBoxAskBeforeDeleteGroup
            // 
            this.checkBoxAskBeforeDeleteGroup.AutoSize = true;
            this.checkBoxAskBeforeDeleteGroup.Location = new System.Drawing.Point(19, 22);
            this.checkBoxAskBeforeDeleteGroup.Name = "checkBoxAskBeforeDeleteGroup";
            this.checkBoxAskBeforeDeleteGroup.Size = new System.Drawing.Size(170, 21);
            this.checkBoxAskBeforeDeleteGroup.TabIndex = 0;
            this.checkBoxAskBeforeDeleteGroup.Text = "Ask before delete group";
            this.checkBoxAskBeforeDeleteGroup.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkBoxExportInactive);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(518, 288);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Export";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkBoxExportInactive
            // 
            this.checkBoxExportInactive.AutoSize = true;
            this.checkBoxExportInactive.Location = new System.Drawing.Point(19, 22);
            this.checkBoxExportInactive.Name = "checkBoxExportInactive";
            this.checkBoxExportInactive.Size = new System.Drawing.Size(162, 21);
            this.checkBoxExportInactive.TabIndex = 0;
            this.checkBoxExportInactive.Text = "Export inactive streams";
            this.checkBoxExportInactive.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(445, 409);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(89, 35);
            this.buttonClose.TabIndex = 28;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 455);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.tabControlSetting);
            this.Controls.Add(this.headerTextStreamDetails);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(566, 494);
            this.Name = "FormSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.tabControlSetting.ResumeLayout(false);
            this.tabPageSettingsMain.ResumeLayout(false);
            this.tabPageSettingsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStreamRequestTimeout)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private M3Controls.HeaderText headerTextStreamDetails;
        private System.Windows.Forms.TabControl tabControlSetting;
        private System.Windows.Forms.TabPage tabPageSettingsMain;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.CheckBox checkBoxAskBeforeDeleteStream;
        private System.Windows.Forms.CheckBox checkBoxAskBeforeDeleteGroup;
        private M3Controls.MTextBox mTextBoxVlcPath;
        private System.Windows.Forms.Label labelVlcPath;
        private System.Windows.Forms.Button buttonChooseFile;
        private System.Windows.Forms.NumericUpDown numericUpDownStreamRequestTimeout;
        private System.Windows.Forms.Label labelStreamRequestTimeout;
        private System.Windows.Forms.CheckBox checkBoxCheckLinkAsync;
        private System.Windows.Forms.CheckBox checkBoxExportInactive;
    }
}