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
    public partial class FormAdditionalData : Form
    {
        private Playlist g_Playlist;

        public FormAdditionalData()
        {
            InitializeComponent();
        }

        public FormAdditionalData(Playlist g_Playlist)
        {
            InitializeComponent();
            this.g_Playlist = g_Playlist;
        }

        private void FormAdditionalData_Load(object sender, EventArgs e)
        {
            foreach (var line in g_Playlist.AdditionalExt)
            {
                mTextBoxAdditionalData.Text += line + Environment.NewLine;
            }
        }

        private void mButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormAdditionalData_FormClosing(object sender, FormClosingEventArgs e)
        {
            int oldCount = g_Playlist.AdditionalExt.Count;

            g_Playlist.AdditionalExt.Clear();
            foreach (string line in mTextBoxAdditionalData.Lines)
            {
                if (line.Length > 0)
                {
                    g_Playlist.AdditionalExt.Add(line);
                }
            }

            g_Playlist.HasChanges = oldCount != g_Playlist.AdditionalExt.Count ? true : false;
        }
    }
}
