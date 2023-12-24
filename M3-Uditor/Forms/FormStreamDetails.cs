using Forms.M3_Uditor;
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
            textBoxStreamTvgName.Text = stream.TvgName ?? string.Empty;
            textBoxStreamDuration.Text = stream.Duration;
            checkBoxStreamExport.Checked = stream.Export;

            if ( stream.Logo != string.Empty )
                pictureBoxStreamLogo.LoadAsync(stream.Logo);
            //pictureBoxStreamLogo.Image = Helper.DownloadImageFromUrl(stream.Logo);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!textBoxStreamUrl.Text.IsValidURL())
            {
                textBoxStreamUrl.Focus();
                return;
            }
            stream.Name = textBoxStreamName.Text;
            stream.Logo = textBoxStreamLogo.Text;
            stream.TvgId = textBoxStreamTvgId.Text;
            stream.TvgName = textBoxStreamTvgName.Text;
            stream.Url = textBoxStreamUrl.Text;
            stream.Duration = textBoxStreamDuration.Text;
            stream.Export = checkBoxStreamExport.Checked;

            stream.Parent.HasChanges = true;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxStreamTvgId_ButtonClicked(object sender, EventArgs e)
        {
            using (FormEpgData formEpgData = new FormEpgData())
            {
                DialogResult dr = formEpgData.ShowDialog();

                if (stream != null && dr == DialogResult.OK)
                {
                    textBoxStreamTvgId.Text = formEpgData.SelectedItem.EpgId;
                    textBoxStreamTvgName.Text = formEpgData.SelectedItem.Name;
                }
            }
        }

        private void textBoxStreamUrl__TextChanged(object sender, EventArgs e)
        {
            labelInvalidUrlStream.Visible = !textBoxStreamUrl.Text.IsValidURL();
        }
    }
}
