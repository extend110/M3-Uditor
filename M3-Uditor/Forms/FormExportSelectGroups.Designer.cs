namespace M3_Uditor.Forms
{
    partial class FormExportSelectGroups
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExportSelectGroups));
            this.mTextBoxSearch = new M3Controls.MTextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.extendedListBoxGroups = new M3Controls.ExtendedListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonExportSelected = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDoNotExportSelected = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mTextBoxSearch
            // 
            this.mTextBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mTextBoxSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mTextBoxSearch.BackColor = System.Drawing.SystemColors.Window;
            this.mTextBoxSearch.BackgroundColor = System.Drawing.Color.Empty;
            this.mTextBoxSearch.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.mTextBoxSearch.BorderFocusColor = System.Drawing.Color.RoyalBlue;
            this.mTextBoxSearch.BorderSize = 2;
            this.mTextBoxSearch.BorderStyle = M3Controls.MTextBox.Style.Normal;
            this.mTextBoxSearch.ClearButton = true;
            this.mTextBoxSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTextBoxSearch.ForeColor = System.Drawing.Color.DimGray;
            this.mTextBoxSearch.Icon = null;
            this.mTextBoxSearch.Image = ((System.Drawing.Image)(resources.GetObject("mTextBoxSearch.Image")));
            this.mTextBoxSearch.Location = new System.Drawing.Point(14, 17);
            this.mTextBoxSearch.Margin = new System.Windows.Forms.Padding(5);
            this.mTextBoxSearch.Multiline = false;
            this.mTextBoxSearch.Name = "mTextBoxSearch";
            this.mTextBoxSearch.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.mTextBoxSearch.PasswordChar = false;
            this.mTextBoxSearch.Placeholder = "Search Groups...";
            this.mTextBoxSearch.ReadOnly = false;
            this.mTextBoxSearch.ShowPlaceholder = true;
            this.mTextBoxSearch.Size = new System.Drawing.Size(511, 36);
            this.mTextBoxSearch.TabIndex = 1;
            this.mTextBoxSearch.Text = "Search Groups...";
            this.mTextBoxSearch._TextChanged += new System.EventHandler(this.mTextBoxSearch__TextChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(341, 485);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(88, 30);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExport.Location = new System.Drawing.Point(437, 485);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(88, 30);
            this.buttonExport.TabIndex = 3;
            this.buttonExport.Text = "&Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // extendedListBoxGroups
            // 
            this.extendedListBoxGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.extendedListBoxGroups.AutoScroll = false;
            this.extendedListBoxGroups.DescriptionColor = System.Drawing.Color.Empty;
            this.extendedListBoxGroups.DescriptionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extendedListBoxGroups.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.extendedListBoxGroups.FormattingEnabled = true;
            this.extendedListBoxGroups.HandleIconClick = false;
            this.extendedListBoxGroups.HighlightColor = System.Drawing.Color.Empty;
            this.extendedListBoxGroups.HighlightHover = false;
            this.extendedListBoxGroups.HighlightOpacity = 0F;
            this.extendedListBoxGroups.IconCount = 0;
            this.extendedListBoxGroups.IconSize = new System.Drawing.Size(0, 0);
            this.extendedListBoxGroups.ItemMargin = 15;
            this.extendedListBoxGroups.Location = new System.Drawing.Point(14, 87);
            this.extendedListBoxGroups.Name = "extendedListBoxGroups";
            this.extendedListBoxGroups.NoItemsMessage = null;
            this.extendedListBoxGroups.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.extendedListBoxGroups.ShowIndex = false;
            this.extendedListBoxGroups.Size = new System.Drawing.Size(511, 378);
            this.extendedListBoxGroups.TabIndex = 4;
            this.extendedListBoxGroups.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.extendedListBoxGroups_DrawItem);
            this.extendedListBoxGroups.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.extendedListBoxGroups_MouseDoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonExportSelected,
            this.toolStripButtonDoNotExportSelected});
            this.toolStrip1.Location = new System.Drawing.Point(14, 58);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(511, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonExportSelected
            // 
            this.toolStripButtonExportSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExportSelected.Image = global::M3_Uditor.Properties.Resources.StreamOnline;
            this.toolStripButtonExportSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExportSelected.Name = "toolStripButtonExportSelected";
            this.toolStripButtonExportSelected.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonExportSelected.Text = "toolStripButton1";
            this.toolStripButtonExportSelected.Click += new System.EventHandler(this.toolStripButtonExportSelected_Click);
            // 
            // toolStripButtonDoNotExportSelected
            // 
            this.toolStripButtonDoNotExportSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDoNotExportSelected.Image = global::M3_Uditor.Properties.Resources.StreamOffline;
            this.toolStripButtonDoNotExportSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDoNotExportSelected.Name = "toolStripButtonDoNotExportSelected";
            this.toolStripButtonDoNotExportSelected.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDoNotExportSelected.Text = "toolStripButton2";
            this.toolStripButtonDoNotExportSelected.Click += new System.EventHandler(this.toolStripButtonDoNotExportSelected_Click);
            // 
            // FormExportSelectGroups
            // 
            this.AcceptButton = this.buttonExport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(539, 528);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.extendedListBoxGroups);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.mTextBoxSearch);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormExportSelectGroups";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export Groups";
            this.Load += new System.EventHandler(this.FormExportSelectGroups_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private M3Controls.MTextBox mTextBoxSearch;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonExport;
        private M3Controls.ExtendedListBox extendedListBoxGroups;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonExportSelected;
        private System.Windows.Forms.ToolStripButton toolStripButtonDoNotExportSelected;
    }
}