using M3_Uditor;
using M3_Uditor.Properties;
using M3U8;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms.M3_Uditor
{
    public partial class FormEpgData : Form
    {
        private List<EpgItem> searchResults = new List<EpgItem>();
        public EpgItem SelectedItem { get; set; }
        public FormEpgData()
        {
            InitializeComponent();
        }

        private void FormEpgData_Load(object sender, EventArgs e)
        {
            listBoxEpgItems.Items.Clear();
        }

        private void mTextBox1__TextChanged(object sender, EventArgs e)
        {
            if (mTextBox1.Text == string.Empty || mTextBox1.Text == mTextBox1.Placeholder)
            {
                listBoxEpgItems.DataSource = EpgData.EpgItemList;
                return;
            }

            searchResults.Clear();


                foreach (EpgItem item in EpgData.EpgItemList)
                {
                    if (item.Name.ToLower().Contains(mTextBox1.Text.ToLower()))
                        searchResults.Add(item);
                }

            listBoxEpgItems.DataSource = null;
            listBoxEpgItems.DataSource = searchResults;
        }

        private void listBoxEpgItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectedItem = listBoxEpgItems.SelectedItem as EpgItem;
            DialogResult = DialogResult.OK;
        }

        private void mTextBox1_ButtonClicked(object sender, EventArgs e)
        {
            mTextBox1.Clear();
        }
    }
}
