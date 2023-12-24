using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M3_Uditor.Properties;
using System.Windows.Forms;

namespace M3_Uditor.Forms
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        private void FormStart_Load(object sender, EventArgs e)
        {
            foreach (string recentFile in Settings.Default.RecentFiles)
            {
                listBoxRecentFiles.Items.Add(recentFile);
            }

            checkBoxShowStartDialog.Checked = Settings.Default.ShowStartDialog;
        }

        private void mSideBar1_ItemClicked(object sender, M3Controls.MSideBarItem e)
        {
            switch (e.Text)
            {
                case "New File":
                    ShowMainForm(null);
                    break;
                case "Open File":
                    using (OpenFileDialog  openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.Filter = Helper.FilterAll;
                        if ( openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            ShowMainForm(openFileDialog.FileName);
                        }
                    }          
                    break;
                case "Quit":
                    this.Close();
                    break;
            }
        }

        private void listBoxRecentFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowMainForm(listBoxRecentFiles.SelectedItem.ToString());
        }

        private void ShowMainForm(string filename)
        {
            using (FormMain formMain = new FormMain(filename))
            {
                this.Hide();
                formMain.ShowDialog();
                this.Show();
            }
        }

        private void FormStart_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void checkBoxShowStartDialog_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.ShowStartDialog = checkBoxShowStartDialog.Checked;
            Settings.Default.Save();
        }
    }
}
