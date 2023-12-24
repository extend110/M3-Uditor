using M3_Uditor.Properties;
using M3U8;
using System;
using System.Windows.Forms;
using XmlTv;

namespace M3_Uditor.Forms
{
    public partial class FormSettings : Form
    {
        Playlist _playlist;
        int _tabPage;

        string XmlUrl;
        FormWaitingEpgDownload _FormWaiting;

        public FormSettings(Playlist playlist, int tabPage = 0)
        {
            InitializeComponent();
            _playlist = playlist;
            _tabPage = tabPage;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            tabControlSetting.SelectTab(_tabPage);

            checkBoxAskBeforeDeleteGroup.Checked = Settings.Default.AskDeleteGroup;
            checkBoxAskBeforeDeleteStream.Checked = Settings.Default.AskDeleteStream;
            mTextBoxVlcPath.Text = Settings.Default.VlcPath;
            numericUpDownStreamRequestTimeout.Value = Settings.Default.StreamRequestTimeout;
            checkBoxCheckLinkAsync.Checked = Settings.Default.CheckLinksAsync;
            checkBoxExportInactive.Checked = Settings.Default.ExportInactiveStreams;
            checkBoxRemoveCountryTag.Checked = Settings.Default.RemoveCountryTag;
            checkBoxShowStartDialog.Checked = Settings.Default.ShowStartDialog;

            // playlist specific
            if (_playlist.Credentials.ServerUri != string.Empty)
                mTextBoxServerPort.Text = string.Format("{0}:{1}", _playlist.Credentials.ServerUri, _playlist.Credentials.Port);

            mTextBoxUsername.Text = _playlist.Credentials.Username;
            mTextBoxPassword.Text = _playlist.Credentials.Password;
            mTextBoxXmlTvUrl.Text = _playlist.XmlTvUrl;

            XmlUrl = _playlist.XmlTvUrl;
            EpgParser.ProcessingStatusChanged += EpgParser_ProcessingStatusChanged;
        }

        private void EpgParser_ProcessingStatusChanged(object sender, ProcessingEventArgs e)
        {
            if (e.Status != EpgParser.ProcessingStatus.Started)
            {
                _FormWaiting.Close();
                this.Close();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            // remove events
            EpgParser.ProcessingStatusChanged -= EpgParser_ProcessingStatusChanged;

            // playlist specific
            if (mTextBoxServerPort.Text.Contains(":"))
            {
                _playlist.Credentials.ServerUri = mTextBoxServerPort.Text.Substring(0, mTextBoxServerPort.Text.LastIndexOf(":"));
                _playlist.Credentials.Port = int.Parse(mTextBoxServerPort.Text.Substring(mTextBoxServerPort.Text.LastIndexOf(":") + 1));
            }
            _playlist.Credentials.Username = mTextBoxUsername.Text;
            _playlist.Credentials.Password = mTextBoxPassword.Text;
            _playlist.XmlTvUrl = mTextBoxXmlTvUrl.Text;

            // general
            Settings.Default.AskDeleteGroup = checkBoxAskBeforeDeleteGroup.Checked;
            Settings.Default.AskDeleteStream = checkBoxAskBeforeDeleteStream.Checked;
            Settings.Default.VlcPath = mTextBoxVlcPath.Text;
            Settings.Default.StreamRequestTimeout = (int)numericUpDownStreamRequestTimeout.Value;
            Settings.Default.CheckLinksAsync = checkBoxCheckLinkAsync.Checked;
            Settings.Default.ExportInactiveStreams = checkBoxExportInactive.Checked;
            Settings.Default.RemoveCountryTag = checkBoxRemoveCountryTag.Checked;
            Settings.Default.ShowStartDialog = checkBoxShowStartDialog.Checked;

            Settings.Default.Save();
        }

        private void checkBoxExportInactive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mTextBoxVlcPath_ButtonClicked(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "vlc.exe (*.*)|vlc.exe";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    mTextBoxVlcPath.Text = openFileDialog.FileName;
                }
            }
        }

        private void mTextBoxXmlTvUrl_ButtonClicked(object sender, EventArgs e)
        {
            XmlUrl = mTextBoxXmlTvUrl.Text;
            _FormWaiting = new FormWaitingEpgDownload();

            EpgData.GetData(XmlUrl);
            _FormWaiting.ShowDialog();
        }

        private void mTextBoxXmlTvUrl__TextChanged(object sender, EventArgs e)
        {
            mTextBoxXmlTvUrl.ClearButton = mTextBoxXmlTvUrl.Text != _playlist.XmlTvUrl || EpgData.EpgItemList.Count == 0;

            if (mTextBoxXmlTvUrl.Text.Length == 0 || !mTextBoxXmlTvUrl.Text.IsValidURL())
            {
                mTextBoxXmlTvUrl.ClearButton = false;
            }
        }
    }
}
