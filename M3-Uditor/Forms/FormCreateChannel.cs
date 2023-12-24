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
    public partial class FormCreateChannel : Form
    {
        public string StreamName { get { return mTextBoxStreamName.Text; } }
        public string StreamUrl { get { return mTextBoxStreamUrl.Text; } }

        public FormCreateChannel()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if ( mTextBoxStreamUrl.Text.IsValidURL())
                DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FormCreateChannel_Load(object sender, EventArgs e)
        {
            mTextBoxStreamName.Focus();
        }

        private void mTextBoxStreamUrl__TextChanged(object sender, EventArgs e)
        {
            labelInvalidUrlStream.Visible = !mTextBoxStreamUrl.Text.IsValidURL();
        }
    }
}
