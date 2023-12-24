using M3_Uditor.Properties;
using M3Controls;
using M3U8;
using System;
using System.Collections;
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
    public partial class FormExportSelectGroups : Form
    {
        public List<Group> GroupsForExport
        {
            get
            {
                List<Group> returnGroups = new List<Group>();
                foreach (KeyValuePair<Group, bool> kv in groups)
                {
                    if (kv.Value)
                        returnGroups.Add(kv.Key);
                }
                return returnGroups;
            }
        }

        Playlist Playlist;
        List<Group> searchResults = new List<Group>();
        Dictionary<Group, bool> groups = new Dictionary<Group, bool>();
        private ExtendedListBox Groups
        {
            get => extendedListBoxGroups;
        }
        
        public FormExportSelectGroups(Playlist playlist)
        {
            InitializeComponent();
            this.Playlist = playlist;

            foreach (Group group in Playlist.Groups)
            {
                groups.Add(group, false);
            }
        }

        private void FormExportSelectGroups_Load(object sender, EventArgs e)
        {
            Groups.DataSource = groups.Keys.ToArray();
        }

        private void mTextBoxSearch__TextChanged(object sender, EventArgs e)
        {
            if (mTextBoxSearch.Text == string.Empty || mTextBoxSearch.Text == mTextBoxSearch.Placeholder)
            {
                Groups.DataSource = groups.Keys.ToArray();
                return;
            }

            searchResults.Clear();

            foreach (Group group in groups.Keys)
            {
                if (group.Name.ToLower().Contains(mTextBoxSearch.Text.ToLower()))
                    searchResults.Add(group);
            }

            Groups.DataSource = null;
            Groups.DataSource = searchResults;
        }

        private void extendedListBoxGroups_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Group group = Groups.SelectedItem as Group;
            groups[group] = !groups[group];
        }

        private void extendedListBoxGroups_DrawItem(object sender, DrawItemEventArgs e)
        {
            bool export = groups[Groups.Items[e.Index] as Group];
            Rectangle IconBounds = new Rectangle(e.Bounds.Right - 32, e.Bounds.Top + Groups.ItemMargin, 16, 16);

            if (export)
            {
                e.Graphics.DrawImage(Resources.StreamOnline, IconBounds);
            }
        }

        private void toolStripButtonExportSelected_Click(object sender, EventArgs e)
        {
            foreach (Group group in Groups.SelectedItems)
            {
                groups[group] = true;
            }
        }

        private void toolStripButtonDoNotExportSelected_Click(object sender, EventArgs e)
        {
            foreach (Group group in Groups.SelectedItems)
            {
                groups[group] = false;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
