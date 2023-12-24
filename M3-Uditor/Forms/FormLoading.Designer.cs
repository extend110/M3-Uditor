using System;

namespace M3_Uditor.Forms
{
    partial class FormLoading
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
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.mProgressBar1 = new M3Controls.MProgressBar();
            this.headerTextLoading = new M3Controls.HeaderText();
            this.SuspendLayout();
            // 
            // mProgressBar1
            // 
            this.mProgressBar1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mProgressBar1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.mProgressBar1.Location = new System.Drawing.Point(12, 92);
            this.mProgressBar1.Name = "mProgressBar1";
            this.mProgressBar1.ProgressBarColor = System.Drawing.Color.RoyalBlue;
            this.mProgressBar1.ProgressBarFont = new System.Drawing.Font("Segoe UI", 8F);
            this.mProgressBar1.Size = new System.Drawing.Size(396, 32);
            this.mProgressBar1.TabIndex = 28;
            this.mProgressBar1.Text = "mProgressBar1";
            // 
            // headerTextLoading
            // 
            this.headerTextLoading.Animate = true;
            this.headerTextLoading.BottomLineHeight = 1;
            this.headerTextLoading.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerTextLoading.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerTextLoading.ForeColor = System.Drawing.Color.White;
            this.headerTextLoading.GradientColor = System.Drawing.Color.RoyalBlue;
            this.headerTextLoading.Location = new System.Drawing.Point(0, 0);
            this.headerTextLoading.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.headerTextLoading.Name = "headerTextLoading";
            this.headerTextLoading.Size = new System.Drawing.Size(420, 79);
            this.headerTextLoading.TabIndex = 27;
            this.headerTextLoading.Text = "Loading";
            // 
            // FormLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(420, 136);
            this.Controls.Add(this.mProgressBar1);
            this.Controls.Add(this.headerTextLoading);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLoading";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "M3-Uditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLoading_FormClosing);
            this.Load += new System.EventHandler(this.FormLoading_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private M3Controls.HeaderText headerTextLoading;
        private M3Controls.MProgressBar mProgressBar1;
    }
}