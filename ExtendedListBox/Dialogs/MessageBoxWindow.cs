using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M3Controls.Dialogs
{
    internal partial class MessageBoxWindow : Form
    {
        private Button btnOK;
        private Button btnCancel;
        private Button btnYes;
        private Button btnNo;
        private Button btnRetry;

        public MessageBoxWindow()
        {
            InitializeComponent();
            btnOK = new Button() { Text = "Ok", Size = new Size(112, 29)};
            btnCancel = new Button() { Text = "Cancel", Size = new Size(112, 29) };
            btnYes = new Button() { Text = "Yes", Size = new Size(112, 29) };
            btnNo = new Button() { Text = "No", Size = new Size(112, 29) };
            btnRetry = new Button() { Text = "Retry", Size = new Size(112, 29) };

            btnOK.Click += (sender, e) => DialogResult = DialogResult.OK;
            btnCancel.Click += (sender, e) => DialogResult = DialogResult.Cancel;
            btnYes.Click += (sender, e) => DialogResult = DialogResult.Yes;
            btnNo.Click += (sender, e) => DialogResult = DialogResult.No;
            btnRetry.Click += (sender, e) => DialogResult = DialogResult.Retry;

            labelInfoText.Left = pictureBox1.Left;
        }

        public MessageBoxWindow(string title, string description, MessageBox.Buttons buttons, Image image = null) : this()
        {
            Text = title;
            labelDescription.Text = description;
            pictureBox1.BackgroundImage = image;

            switch (buttons)
            {
                case MessageBox.Buttons.Ok:
                    flowLayoutPanelButtons.Controls.Add(btnOK);
                    break;
                case MessageBox.Buttons.YesNo:
                    flowLayoutPanelButtons.Controls.Add(btnNo);
                    flowLayoutPanelButtons.Controls.Add(btnYes);
                    break;
                case MessageBox.Buttons.YesNoCancel:
                    flowLayoutPanelButtons.Controls.Add(btnCancel);
                    flowLayoutPanelButtons.Controls.Add(btnNo);
                    flowLayoutPanelButtons.Controls.Add(btnYes);
                    break;
                case MessageBox.Buttons.YesNoRetry:
                    flowLayoutPanelButtons.Controls.Add(btnRetry);
                    flowLayoutPanelButtons.Controls.Add(btnNo);
                    flowLayoutPanelButtons.Controls.Add(btnOK);
                    break;
            }

            if (pictureBox1.BackgroundImage == null)
            {
                labelDescription.Location = pictureBox1.Location;
                pictureBox1.Visible = false;
            }
        }
    }
}
