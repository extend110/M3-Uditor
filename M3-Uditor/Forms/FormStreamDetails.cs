using M3U8;
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
    public partial class FormStreamDetails : Form
    {
        Stream stream;

        public FormStreamDetails(Stream stream)
        {
            InitializeComponent();

            this.stream = stream;
        }

        private void FormStreamDetails_Load(object sender, EventArgs e)
        {
            textBoxStreamName.Text = stream.Name;
            textBoxStreamUrl.Text = stream.Url;
            textBoxStreamLogo.Text = stream.Logo;
            textBoxStreamTvgId.Text = stream.TvgId;
            textBoxStreamDuration.Text = stream.Duration;
            checkBoxStreamExport.Checked = stream.Export;

            pictureBoxStreamLogo.Image = Helper.DownloadImageFromUrl(stream.Logo);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            stream.Name = textBoxStreamName.Text;
            stream.Logo = textBoxStreamLogo.Text;
            stream.TvgId = textBoxStreamTvgId.Text;
            stream.Url = textBoxStreamUrl.Text;
            stream.Duration = textBoxStreamDuration.Text;
            stream.Export = checkBoxStreamExport.Checked;

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
