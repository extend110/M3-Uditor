namespace M3_Uditor.Forms
{
    partial class FormRemoveStreams
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
            this.progressBarRemoveStatus = new M3Controls.MProgressBar();
            this.SuspendLayout();
            // 
            // headerText1
            // 
            this.headerText1.Animate = true;
            this.headerText1.BottomLineHeight = 2;
            this.headerText1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerText1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerText1.ForeColor = System.Drawing.Color.White;
            this.headerText1.GradientColor = System.Drawing.Color.RoyalBlue;
            this.headerText1.Location = new System.Drawing.Point(0, 0);
            this.headerText1.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.headerText1.Name = "headerText1";
            this.headerText1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.headerText1.Size = new System.Drawing.Size(558, 98);
            this.headerText1.TabIndex = 0;
            this.headerText1.Text = "Removing Streams";
            // 
            // progressBarRemoveStatus
            // 
            this.progressBarRemoveStatus.Location = new System.Drawing.Point(12, 112);
            this.progressBarRemoveStatus.Name = "progressBarRemoveStatus";
            this.progressBarRemoveStatus.ProgressBarColor = System.Drawing.Color.RoyalBlue;
            this.progressBarRemoveStatus.ProgressBarFont = new System.Drawing.Font("Segoe UI", 8F);
            this.progressBarRemoveStatus.Size = new System.Drawing.Size(534, 26);
            this.progressBarRemoveStatus.TabIndex = 1;
            // 
            // FormRemoveStreams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(558, 152);
            this.Controls.Add(this.progressBarRemoveStatus);
            this.Controls.Add(this.headerText1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRemoveStreams";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "M3-Uditor";
            this.Shown += new System.EventHandler(this.FormRemoveStreams_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private M3Controls.HeaderText headerText1;
        private M3Controls.MProgressBar progressBarRemoveStatus;
    }
}