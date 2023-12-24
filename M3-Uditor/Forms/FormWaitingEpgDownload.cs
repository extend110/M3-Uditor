using M3_Uditor.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M3_Uditor.Forms
{
    public partial class FormWaitingEpgDownload : Form
    {
        private Bitmap animatedimage = Resources._74H8;
        private bool currentlyanimating = false;
        public FormWaitingEpgDownload()
        {
            InitializeComponent();
        }

        private void OnFrameChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void AnimateImage()
        {
            if ( currentlyanimating )
            {
                ImageAnimator.Animate(animatedimage, OnFrameChanged);
                currentlyanimating = false;
            }
        }

        private void FormWaiting_Paint(object sender, PaintEventArgs e)
        {
            AnimateImage();
            ImageAnimator.UpdateFrames(animatedimage);
            e.Graphics.DrawImage(animatedimage, ClientRectangle);
        }
    }
}
