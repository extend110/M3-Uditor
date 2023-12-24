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
    public partial class FormSearchReplace : Form
    {
        public enum SearchOption
        {
            Groups,
            Streams
        }
        public string SearchFor {  get; set; }
        public string ReplaceWith { get; set; }
        public bool InAllGroups { get; set; }
        public SearchOption SearchIn { get; set; }
        
        public FormSearchReplace()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            SearchFor = mTextBoxSearchFor.Text;
            ReplaceWith = mTextBoxReplaceWith.Text;

            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void checkBoxInAllGroups_CheckedChanged(object sender, EventArgs e)
        {
            InAllGroups = checkBoxInAllGroups.Checked;
        }

        private void radioButtonInGroups_CheckedChanged(object sender, EventArgs e)
        {
            if ( radioButtonInGroups.Checked )
            {
                SearchIn = SearchOption.Groups;
            }
        }

        private void radioButtonInStreams_CheckedChanged(object sender, EventArgs e)
        {
            if ( radioButtonInStreams.Checked)
            {
                checkBoxInAllGroups.Enabled = true;
                SearchIn = SearchOption.Streams;
            }
            else
            {
                checkBoxInAllGroups.Enabled = false;
            }
        }

        private void FormSearchReplace_Load(object sender, EventArgs e)
        {
            radioButtonInGroups_CheckedChanged(null, null);
        }
    }
}
