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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.headerTextStreamDetails = new M3Controls.HeaderText();
            this.tabControlSetting = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.checkBoxShowStartDialog = new System.Windows.Forms.CheckBox();
            this.checkBoxCheckLinkAsync = new System.Windows.Forms.CheckBox();
            this.numericUpDownStreamRequestTimeout = new System.Windows.Forms.NumericUpDown();
            this.labelStreamRequestTimeout = new System.Windows.Forms.Label();
            this.mTextBoxVlcPath = new M3Controls.MTextBox();
            this.labelVlcPath = new System.Windows.Forms.Label();
            this.checkBoxAskBeforeDeleteStream = new System.Windows.Forms.CheckBox();
            this.checkBoxAskBeforeDeleteGroup = new System.Windows.Forms.CheckBox();
            this.tabPageExport = new System.Windows.Forms.TabPage();
            this.checkBoxRemoveCountryTag = new System.Windows.Forms.CheckBox();
            this.checkBoxExportInactive = new System.Windows.Forms.CheckBox();
            this.tabPagePlaylist = new System.Windows.Forms.TabPage();
            this.mTextBoxXmlTvUrl = new M3Controls.MTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mTextBoxPassword = new M3Controls.MTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mTextBoxUsername = new M3Controls.MTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mTextBoxServerPort = new M3Controls.MTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.tabControlSetting.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStreamRequestTimeout)).BeginInit();
            this.tabPageExport.SuspendLayout();
            this.tabPagePlaylist.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerTextStreamDetails
            // 
            this.headerTextStreamDetails.Animate = false;
            this.headerTextStreamDetails.BottomLineHeight = 2;
            this.headerTextStreamDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerTextStreamDetails.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerTextStreamDetails.ForeColor = System.Drawing.Color.White;
            this.headerTextStreamDetails.GradientColor = System.Drawing.Color.RoyalBlue;
            this.headerTextStreamDetails.Location = new System.Drawing.Point(0, 0);
            this.headerTextStreamDetails.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
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
            this.tabControlSetting.Controls.Add(this.tabPageMain);
            this.tabControlSetting.Controls.Add(this.tabPageExport);
            this.tabControlSetting.Controls.Add(this.tabPagePlaylist);
            this.tabControlSetting.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlSetting.Location = new System.Drawing.Point(12, 85);
            this.tabControlSetting.Name = "tabControlSetting";
            this.tabControlSetting.SelectedIndex = 0;
            this.tabControlSetting.Size = new System.Drawing.Size(526, 318);
            this.tabControlSetting.TabIndex = 27;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.checkBoxShowStartDialog);
            this.tabPageMain.Controls.Add(this.checkBoxCheckLinkAsync);
            this.tabPageMain.Controls.Add(this.numericUpDownStreamRequestTimeout);
            this.tabPageMain.Controls.Add(this.labelStreamRequestTimeout);
            this.tabPageMain.Controls.Add(this.mTextBoxVlcPath);
            this.tabPageMain.Controls.Add(this.labelVlcPath);
            this.tabPageMain.Controls.Add(this.checkBoxAskBeforeDeleteStream);
            this.tabPageMain.Controls.Add(this.checkBoxAskBeforeDeleteGroup);
            this.tabPageMain.Location = new System.Drawing.Point(4, 26);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(518, 288);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Main";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowStartDialog
            // 
            this.checkBoxShowStartDialog.AutoSize = true;
            this.checkBoxShowStartDialog.Location = new System.Drawing.Point(9, 224);
            this.checkBoxShowStartDialog.Name = "checkBoxShowStartDialog";
            this.checkBoxShowStartDialog.Size = new System.Drawing.Size(129, 21);
            this.checkBoxShowStartDialog.TabIndex = 29;
            this.checkBoxShowStartDialog.Text = "Show start dialog";
            this.checkBoxShowStartDialog.UseVisualStyleBackColor = true;
            // 
            // checkBoxCheckLinkAsync
            // 
            this.checkBoxCheckLinkAsync.AutoSize = true;
            this.checkBoxCheckLinkAsync.Location = new System.Drawing.Point(9, 197);
            this.checkBoxCheckLinkAsync.Name = "checkBoxCheckLinkAsync";
            this.checkBoxCheckLinkAsync.Size = new System.Drawing.Size(167, 21);
            this.checkBoxCheckLinkAsync.TabIndex = 30;
            this.checkBoxCheckLinkAsync.Text = "Multithreaded Linkcheck";
            this.checkBoxCheckLinkAsync.UseVisualStyleBackColor = true;
            // 
            // numericUpDownStreamRequestTimeout
            // 
            this.numericUpDownStreamRequestTimeout.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownStreamRequestTimeout.Location = new System.Drawing.Point(9, 166);
            this.numericUpDownStreamRequestTimeout.Name = "numericUpDownStreamRequestTimeout";
            this.numericUpDownStreamRequestTimeout.Size = new System.Drawing.Size(167, 25);
            this.numericUpDownStreamRequestTimeout.TabIndex = 29;
            // 
            // labelStreamRequestTimeout
            // 
            this.labelStreamRequestTimeout.AutoSize = true;
            this.labelStreamRequestTimeout.Location = new System.Drawing.Point(6, 146);
            this.labelStreamRequestTimeout.Name = "labelStreamRequestTimeout";
            this.labelStreamRequestTimeout.Size = new System.Drawing.Size(151, 17);
            this.labelStreamRequestTimeout.TabIndex = 5;
            this.labelStreamRequestTimeout.Text = "Stream Request Timeout";
            // 
            // mTextBoxVlcPath
            // 
            this.mTextBoxVlcPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mTextBoxVlcPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mTextBoxVlcPath.BackColor = System.Drawing.SystemColors.Window;
            this.mTextBoxVlcPath.BackgroundColor = System.Drawing.Color.Empty;
            this.mTextBoxVlcPath.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.mTextBoxVlcPath.BorderFocusColor = System.Drawing.Color.RoyalBlue;
            this.mTextBoxVlcPath.BorderSize = 2;
            this.mTextBoxVlcPath.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.mTextBoxVlcPath.ClearButton = true;
            this.mTextBoxVlcPath.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTextBoxVlcPath.ForeColor = System.Drawing.Color.DimGray;
            this.mTextBoxVlcPath.Icon = null;
            this.mTextBoxVlcPath.Image = ((System.Drawing.Image)(resources.GetObject("mTextBoxVlcPath.Image")));
            this.mTextBoxVlcPath.Location = new System.Drawing.Point(7, 101);
            this.mTextBoxVlcPath.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBoxVlcPath.Multiline = false;
            this.mTextBoxVlcPath.Name = "mTextBoxVlcPath";
            this.mTextBoxVlcPath.Padding = new System.Windows.Forms.Padding(7);
            this.mTextBoxVlcPath.PasswordChar = false;
            this.mTextBoxVlcPath.Placeholder = "";
            this.mTextBoxVlcPath.ReadOnly = false;
            this.mTextBoxVlcPath.ShowPlaceholder = false;
            this.mTextBoxVlcPath.Size = new System.Drawing.Size(504, 32);
            this.mTextBoxVlcPath.TabIndex = 3;
            this.mTextBoxVlcPath.ButtonClicked += new System.EventHandler(this.mTextBoxVlcPath_ButtonClicked);
            // 
            // labelVlcPath
            // 
            this.labelVlcPath.AutoSize = true;
            this.labelVlcPath.Location = new System.Drawing.Point(6, 80);
            this.labelVlcPath.Name = "labelVlcPath";
            this.labelVlcPath.Size = new System.Drawing.Size(96, 17);
            this.labelVlcPath.TabIndex = 2;
            this.labelVlcPath.Text = "VLC Executable";
            // 
            // checkBoxAskBeforeDeleteStream
            // 
            this.checkBoxAskBeforeDeleteStream.AutoSize = true;
            this.checkBoxAskBeforeDeleteStream.Location = new System.Drawing.Point(9, 46);
            this.checkBoxAskBeforeDeleteStream.Name = "checkBoxAskBeforeDeleteStream";
            this.checkBoxAskBeforeDeleteStream.Size = new System.Drawing.Size(174, 21);
            this.checkBoxAskBeforeDeleteStream.TabIndex = 1;
            this.checkBoxAskBeforeDeleteStream.Text = "Ask before delete stream";
            this.checkBoxAskBeforeDeleteStream.UseVisualStyleBackColor = true;
            // 
            // checkBoxAskBeforeDeleteGroup
            // 
            this.checkBoxAskBeforeDeleteGroup.AutoSize = true;
            this.checkBoxAskBeforeDeleteGroup.Location = new System.Drawing.Point(9, 20);
            this.checkBoxAskBeforeDeleteGroup.Name = "checkBoxAskBeforeDeleteGroup";
            this.checkBoxAskBeforeDeleteGroup.Size = new System.Drawing.Size(170, 21);
            this.checkBoxAskBeforeDeleteGroup.TabIndex = 0;
            this.checkBoxAskBeforeDeleteGroup.Text = "Ask before delete group";
            this.checkBoxAskBeforeDeleteGroup.UseVisualStyleBackColor = true;
            // 
            // tabPageExport
            // 
            this.tabPageExport.Controls.Add(this.checkBoxRemoveCountryTag);
            this.tabPageExport.Controls.Add(this.checkBoxExportInactive);
            this.tabPageExport.Location = new System.Drawing.Point(4, 26);
            this.tabPageExport.Name = "tabPageExport";
            this.tabPageExport.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExport.Size = new System.Drawing.Size(518, 288);
            this.tabPageExport.TabIndex = 1;
            this.tabPageExport.Text = "Export";
            this.tabPageExport.UseVisualStyleBackColor = true;
            // 
            // checkBoxRemoveCountryTag
            // 
            this.checkBoxRemoveCountryTag.AutoSize = true;
            this.checkBoxRemoveCountryTag.Location = new System.Drawing.Point(19, 49);
            this.checkBoxRemoveCountryTag.Name = "checkBoxRemoveCountryTag";
            this.checkBoxRemoveCountryTag.Size = new System.Drawing.Size(145, 21);
            this.checkBoxRemoveCountryTag.TabIndex = 1;
            this.checkBoxRemoveCountryTag.Text = "Remove country-tag";
            this.checkBoxRemoveCountryTag.UseVisualStyleBackColor = true;
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
            this.checkBoxExportInactive.CheckedChanged += new System.EventHandler(this.checkBoxExportInactive_CheckedChanged);
            // 
            // tabPagePlaylist
            // 
            this.tabPagePlaylist.Controls.Add(this.mTextBoxXmlTvUrl);
            this.tabPagePlaylist.Controls.Add(this.label4);
            this.tabPagePlaylist.Controls.Add(this.mTextBoxPassword);
            this.tabPagePlaylist.Controls.Add(this.label3);
            this.tabPagePlaylist.Controls.Add(this.mTextBoxUsername);
            this.tabPagePlaylist.Controls.Add(this.label2);
            this.tabPagePlaylist.Controls.Add(this.mTextBoxServerPort);
            this.tabPagePlaylist.Controls.Add(this.label1);
            this.tabPagePlaylist.Location = new System.Drawing.Point(4, 26);
            this.tabPagePlaylist.Name = "tabPagePlaylist";
            this.tabPagePlaylist.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePlaylist.Size = new System.Drawing.Size(518, 288);
            this.tabPagePlaylist.TabIndex = 2;
            this.tabPagePlaylist.Text = "Playlist";
            this.tabPagePlaylist.UseVisualStyleBackColor = true;
            // 
            // mTextBoxXmlTvUrl
            // 
            this.mTextBoxXmlTvUrl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mTextBoxXmlTvUrl.BackColor = System.Drawing.SystemColors.Window;
            this.mTextBoxXmlTvUrl.BackgroundColor = System.Drawing.Color.Empty;
            this.mTextBoxXmlTvUrl.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.mTextBoxXmlTvUrl.BorderFocusColor = System.Drawing.Color.RoyalBlue;
            this.mTextBoxXmlTvUrl.BorderSize = 2;
            this.mTextBoxXmlTvUrl.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.mTextBoxXmlTvUrl.ClearButton = false;
            this.mTextBoxXmlTvUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTextBoxXmlTvUrl.ForeColor = System.Drawing.Color.DimGray;
            this.mTextBoxXmlTvUrl.Icon = null;
            this.mTextBoxXmlTvUrl.Image = global::M3_Uditor.Properties.Resources.ExportAsM3U;
            this.mTextBoxXmlTvUrl.Location = new System.Drawing.Point(9, 211);
            this.mTextBoxXmlTvUrl.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBoxXmlTvUrl.Multiline = false;
            this.mTextBoxXmlTvUrl.Name = "mTextBoxXmlTvUrl";
            this.mTextBoxXmlTvUrl.Padding = new System.Windows.Forms.Padding(7);
            this.mTextBoxXmlTvUrl.PasswordChar = false;
            this.mTextBoxXmlTvUrl.Placeholder = "";
            this.mTextBoxXmlTvUrl.ReadOnly = false;
            this.mTextBoxXmlTvUrl.ShowPlaceholder = false;
            this.mTextBoxXmlTvUrl.Size = new System.Drawing.Size(502, 31);
            this.mTextBoxXmlTvUrl.TabIndex = 7;
            this.mTextBoxXmlTvUrl.ButtonClicked += new System.EventHandler(this.mTextBoxXmlTvUrl_ButtonClicked);
            this.mTextBoxXmlTvUrl._TextChanged += new System.EventHandler(this.mTextBoxXmlTvUrl__TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "XMLTV Url";
            // 
            // mTextBoxPassword
            // 
            this.mTextBoxPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mTextBoxPassword.BackColor = System.Drawing.SystemColors.Window;
            this.mTextBoxPassword.BackgroundColor = System.Drawing.Color.Empty;
            this.mTextBoxPassword.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.mTextBoxPassword.BorderFocusColor = System.Drawing.Color.RoyalBlue;
            this.mTextBoxPassword.BorderSize = 2;
            this.mTextBoxPassword.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.mTextBoxPassword.ClearButton = false;
            this.mTextBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTextBoxPassword.ForeColor = System.Drawing.Color.DimGray;
            this.mTextBoxPassword.Icon = null;
            this.mTextBoxPassword.Image = ((System.Drawing.Image)(resources.GetObject("mTextBoxPassword.Image")));
            this.mTextBoxPassword.Location = new System.Drawing.Point(9, 155);
            this.mTextBoxPassword.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBoxPassword.Multiline = false;
            this.mTextBoxPassword.Name = "mTextBoxPassword";
            this.mTextBoxPassword.Padding = new System.Windows.Forms.Padding(7);
            this.mTextBoxPassword.PasswordChar = false;
            this.mTextBoxPassword.Placeholder = "";
            this.mTextBoxPassword.ReadOnly = false;
            this.mTextBoxPassword.ShowPlaceholder = false;
            this.mTextBoxPassword.Size = new System.Drawing.Size(502, 31);
            this.mTextBoxPassword.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // mTextBoxUsername
            // 
            this.mTextBoxUsername.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mTextBoxUsername.BackColor = System.Drawing.SystemColors.Window;
            this.mTextBoxUsername.BackgroundColor = System.Drawing.Color.Empty;
            this.mTextBoxUsername.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.mTextBoxUsername.BorderFocusColor = System.Drawing.Color.RoyalBlue;
            this.mTextBoxUsername.BorderSize = 2;
            this.mTextBoxUsername.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.mTextBoxUsername.ClearButton = false;
            this.mTextBoxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTextBoxUsername.ForeColor = System.Drawing.Color.DimGray;
            this.mTextBoxUsername.Icon = null;
            this.mTextBoxUsername.Image = ((System.Drawing.Image)(resources.GetObject("mTextBoxUsername.Image")));
            this.mTextBoxUsername.Location = new System.Drawing.Point(9, 99);
            this.mTextBoxUsername.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBoxUsername.Multiline = false;
            this.mTextBoxUsername.Name = "mTextBoxUsername";
            this.mTextBoxUsername.Padding = new System.Windows.Forms.Padding(7);
            this.mTextBoxUsername.PasswordChar = false;
            this.mTextBoxUsername.Placeholder = "";
            this.mTextBoxUsername.ReadOnly = false;
            this.mTextBoxUsername.ShowPlaceholder = false;
            this.mTextBoxUsername.Size = new System.Drawing.Size(502, 31);
            this.mTextBoxUsername.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username";
            // 
            // mTextBoxServerPort
            // 
            this.mTextBoxServerPort.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mTextBoxServerPort.BackColor = System.Drawing.SystemColors.Window;
            this.mTextBoxServerPort.BackgroundColor = System.Drawing.Color.Empty;
            this.mTextBoxServerPort.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.mTextBoxServerPort.BorderFocusColor = System.Drawing.Color.RoyalBlue;
            this.mTextBoxServerPort.BorderSize = 2;
            this.mTextBoxServerPort.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.mTextBoxServerPort.ClearButton = false;
            this.mTextBoxServerPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTextBoxServerPort.ForeColor = System.Drawing.Color.DimGray;
            this.mTextBoxServerPort.Icon = null;
            this.mTextBoxServerPort.Image = ((System.Drawing.Image)(resources.GetObject("mTextBoxServerPort.Image")));
            this.mTextBoxServerPort.Location = new System.Drawing.Point(9, 43);
            this.mTextBoxServerPort.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBoxServerPort.Multiline = false;
            this.mTextBoxServerPort.Name = "mTextBoxServerPort";
            this.mTextBoxServerPort.Padding = new System.Windows.Forms.Padding(7);
            this.mTextBoxServerPort.PasswordChar = false;
            this.mTextBoxServerPort.Placeholder = "";
            this.mTextBoxServerPort.ReadOnly = false;
            this.mTextBoxServerPort.ShowPlaceholder = false;
            this.mTextBoxServerPort.Size = new System.Drawing.Size(502, 31);
            this.mTextBoxServerPort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server:Port";
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
            this.BackColor = System.Drawing.Color.WhiteSmoke;
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
            this.Text = "M3-Uditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.tabControlSetting.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStreamRequestTimeout)).EndInit();
            this.tabPageExport.ResumeLayout(false);
            this.tabPageExport.PerformLayout();
            this.tabPagePlaylist.ResumeLayout(false);
            this.tabPagePlaylist.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private M3Controls.HeaderText headerTextStreamDetails;
        private System.Windows.Forms.TabControl tabControlSetting;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageExport;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.CheckBox checkBoxAskBeforeDeleteStream;
        private System.Windows.Forms.CheckBox checkBoxAskBeforeDeleteGroup;
        private M3Controls.MTextBox mTextBoxVlcPath;
        private System.Windows.Forms.Label labelVlcPath;
        private System.Windows.Forms.NumericUpDown numericUpDownStreamRequestTimeout;
        private System.Windows.Forms.Label labelStreamRequestTimeout;
        private System.Windows.Forms.CheckBox checkBoxCheckLinkAsync;
        private System.Windows.Forms.CheckBox checkBoxExportInactive;
        private System.Windows.Forms.TabPage tabPagePlaylist;
        private M3Controls.MTextBox mTextBoxPassword;
        private System.Windows.Forms.Label label3;
        private M3Controls.MTextBox mTextBoxUsername;
        private System.Windows.Forms.Label label2;
        private M3Controls.MTextBox mTextBoxServerPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxShowStartDialog;
        private System.Windows.Forms.CheckBox checkBoxRemoveCountryTag;
        private M3Controls.MTextBox mTextBoxXmlTvUrl;
        private System.Windows.Forms.Label label4;
    }
}