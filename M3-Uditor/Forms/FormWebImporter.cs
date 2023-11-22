using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M3_Uditor.Forms
{
    public partial class FormWebImporter : Form
    {
        public string Url
        {
            get { return _url; }
        }
        public string TempFile = "tmp";

        private WebClient _webClient;
        private string _url;

        public FormWebImporter()
        {
            InitializeComponent();
            _webClient = new WebClient();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            _url = textBoxUrl.Text;
            
            buttonOk.Visible = false;
            progressBarDownload.Visible = true;

            _webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            _webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
            _webClient.DownloadFileAsync(new Uri(_url), TempFile);

            textBoxUrl.Visible = false;
            progressBarDownload.Visible = true;
        }

        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            DialogResult = DialogResult.OK;      
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBarDownload.Value = e.ProgressPercentage;
            textBoxUrl.Text = string.Format("Downloading: {0}", e.ProgressPercentage.ToString());
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormWebImporter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_webClient.IsBusy)
            {
                _webClient.CancelAsync();
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
