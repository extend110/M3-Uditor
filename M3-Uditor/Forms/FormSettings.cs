using M3_Uditor.Properties;
using System;
using System.Windows.Forms;

namespace M3_Uditor.Forms
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            checkBoxAskBeforeDeleteGroup.Checked = Settings.Default.AskDeleteGroup;
            checkBoxAskBeforeDeleteStream.Checked = Settings.Default.AskDeleteStream;
            mTextBoxVlcPath.Text = Settings.Default.VlcPath;
            numericUpDownStreamRequestTimeout.Value = Settings.Default.StreamRequestTimeout;
            checkBoxCheckLinkAsync.Checked = Settings.Default.CheckLinksAsync;
            checkBoxExportInactive.Checked = Settings.Default.ExportInactiveStreams;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            using ( OpenFileDialog openFileDialog = new OpenFileDialog() )
            {
                openFileDialog.Filter = "vlc.exe (*.*)|vlc.exe";
                if ( openFileDialog.ShowDialog() == DialogResult.OK )
                {
                    mTextBoxVlcPath.Text = openFileDialog.FileName;
                }
            }
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.AskDeleteGroup = checkBoxAskBeforeDeleteGroup.Checked;
            Settings.Default.AskDeleteStream = checkBoxAskBeforeDeleteStream.Checked;
            Settings.Default.VlcPath = mTextBoxVlcPath.Text;
            Settings.Default.StreamRequestTimeout = (int)numericUpDownStreamRequestTimeout.Value;
            Settings.Default.CheckLinksAsync = checkBoxCheckLinkAsync.Checked;
            Settings.Default.ExportInactiveStreams = checkBoxExportInactive.Checked;

            Settings.Default.Save();
        }
    }
}
