namespace M3_Uditor.Forms
{
    partial class FormStart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStart));
            this.mSideBar1 = new M3Controls.MSideBar();
            this.listBoxRecentFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxShowStartDialog = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // mSideBar1
            // 
            this.mSideBar1.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.mSideBar1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mSideBar1.HeaderSpace = 100;
            this.mSideBar1.HeaderText = "Choose Option";
            this.mSideBar1.Items.Add(((M3Controls.MSideBarItem)(resources.GetObject("mSideBar1.Items"))));
            this.mSideBar1.Items.Add(((M3Controls.MSideBarItem)(resources.GetObject("mSideBar1.Items1"))));
            this.mSideBar1.Items.Add(((M3Controls.MSideBarItem)(resources.GetObject("mSideBar1.Items2"))));
            this.mSideBar1.Items.Add(((M3Controls.MSideBarItem)(resources.GetObject("mSideBar1.Items3"))));
            this.mSideBar1.Location = new System.Drawing.Point(0, 0);
            this.mSideBar1.Name = "mSideBar1";
            this.mSideBar1.Size = new System.Drawing.Size(551, 326);
            this.mSideBar1.TabIndex = 0;
            this.mSideBar1.Text = "mSideBar1";
            this.mSideBar1.VerticalSpacing = 2;
            this.mSideBar1.ItemClicked += new System.EventHandler<M3Controls.MSideBarItem>(this.mSideBar1_ItemClicked);
            // 
            // listBoxRecentFiles
            // 
            this.listBoxRecentFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxRecentFiles.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxRecentFiles.FormattingEnabled = true;
            this.listBoxRecentFiles.ItemHeight = 17;
            this.listBoxRecentFiles.Location = new System.Drawing.Point(12, 384);
            this.listBoxRecentFiles.Name = "listBoxRecentFiles";
            this.listBoxRecentFiles.Size = new System.Drawing.Size(527, 123);
            this.listBoxRecentFiles.TabIndex = 1;
            this.listBoxRecentFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxRecentFiles_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(7, 356);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Recent Files";
            // 
            // checkBoxShowStartDialog
            // 
            this.checkBoxShowStartDialog.AutoSize = true;
            this.checkBoxShowStartDialog.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxShowStartDialog.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxShowStartDialog.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.checkBoxShowStartDialog.Location = new System.Drawing.Point(12, 513);
            this.checkBoxShowStartDialog.Name = "checkBoxShowStartDialog";
            this.checkBoxShowStartDialog.Size = new System.Drawing.Size(152, 17);
            this.checkBoxShowStartDialog.TabIndex = 3;
            this.checkBoxShowStartDialog.Text = "Show this dialog at start";
            this.checkBoxShowStartDialog.UseVisualStyleBackColor = false;
            this.checkBoxShowStartDialog.CheckedChanged += new System.EventHandler(this.checkBoxShowStartDialog_CheckedChanged);
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(551, 536);
            this.Controls.Add(this.checkBoxShowStartDialog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxRecentFiles);
            this.Controls.Add(this.mSideBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "M3-Uditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormStart_FormClosing);
            this.Load += new System.EventHandler(this.FormStart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private M3Controls.MSideBar mSideBar1;
        private System.Windows.Forms.ListBox listBoxRecentFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxShowStartDialog;
    }
}