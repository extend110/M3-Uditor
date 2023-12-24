namespace M3_Uditor.Forms
{
    partial class FormFavorites
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
            this.headerText1 = new M3Controls.HeaderText();
            this.extendedListBoxFavorites = new M3Controls.ExtendedListBox();
            this.SuspendLayout();
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
            this.headerText1.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.headerText1.Name = "headerText1";
            this.headerText1.Size = new System.Drawing.Size(831, 116);
            this.headerText1.TabIndex = 0;
            this.headerText1.Text = "Favorites";
            // 
            // extendedListBoxFavorites
            // 
            this.extendedListBoxFavorites.DescriptionColor = System.Drawing.SystemColors.WindowText;
            this.extendedListBoxFavorites.DescriptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extendedListBoxFavorites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extendedListBoxFavorites.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.extendedListBoxFavorites.FormattingEnabled = true;
            this.extendedListBoxFavorites.HandleIconClick = false;
            this.extendedListBoxFavorites.HighlightColor = System.Drawing.Color.Empty;
            this.extendedListBoxFavorites.HighlightHover = false;
            this.extendedListBoxFavorites.HighlightOpacity = 0F;
            this.extendedListBoxFavorites.IconCount = 0;
            this.extendedListBoxFavorites.IconSize = new System.Drawing.Size(0, 0);
            this.extendedListBoxFavorites.ItemMargin = 15;
            this.extendedListBoxFavorites.Location = new System.Drawing.Point(0, 116);
            this.extendedListBoxFavorites.Name = "extendedListBoxFavorites";
            this.extendedListBoxFavorites.NoItemsMessage = "(no favorites selected)";
            this.extendedListBoxFavorites.ShowIndex = false;
            this.extendedListBoxFavorites.Size = new System.Drawing.Size(831, 405);
            this.extendedListBoxFavorites.TabIndex = 1;
            this.extendedListBoxFavorites.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.extendedListBoxFavorites_MouseDoubleClick);
            // 
            // FormFavorites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 521);
            this.Controls.Add(this.extendedListBoxFavorites);
            this.Controls.Add(this.headerText1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFavorites";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Favorites";
            this.Load += new System.EventHandler(this.FormFavorites_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private M3Controls.HeaderText headerText1;
        private M3Controls.ExtendedListBox extendedListBoxFavorites;
    }
}