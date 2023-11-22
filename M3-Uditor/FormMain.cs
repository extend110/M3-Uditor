using System;
using System.Windows.Forms;
using M3U8;
using M3Controls;
using System.ComponentModel;
using M3_Uditor.Forms;
using System.Net;
using System.Drawing;
using M3_Uditor.Properties;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;

namespace M3_Uditor
{
    public partial class FormMain : Form
    {
        enum ClickedIcon
        {
            OnlineStatus = 1,
            Export = 2,
            Play = 3
        }

        Playlist g_Playlist;

        public FormMain()
        {
            InitializeComponent();
        }

        private void OpenRecentFile(object sender, EventArgs e)
        {
            if (g_Playlist.HasChanges)
            {
                DialogResult result = Helper.MessageBoxPlaylistChanges(g_Playlist);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                else if (result == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(null, null);
                }
            }
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            string content = string.Empty;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(item.Text))
            {
                content = reader.ReadLine();
            }

            if ( content.Contains("#EXTM3U") )
            {
                OpenFile(item.Text, FormLoading.Mode.Import, false);
                return;
            }
            if ( content.Contains("M3-Uditor") )
            {
                OpenFile(item.Text, FormLoading.Mode.Open, false);
                return;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //Get and setup recent files
            GetRecentFiles();

            g_Playlist = new Playlist();
           
            listBoxGroups.DataSource = g_Playlist.Groups;
            listBoxGroups.SelectedIndex = 0;
        }

        private void GetRecentFiles()
        {
            for (int i = recentFilesToolStripMenuItem.DropDownItems.Count - 1; i > 1; --i)
            {
                recentFilesToolStripMenuItem.DropDownItems.RemoveAt(i);
            }

            if (Settings.Default.RecentFiles == null)
                Settings.Default.RecentFiles = new System.Collections.Specialized.StringCollection();

            if (Settings.Default.RecentFiles != null)
            {
                if (Settings.Default.RecentFiles.Count == 0)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem("(No recent files)");
                    item.Enabled = false;
                    recentFilesToolStripMenuItem.DropDownItems.Add(item);
                }
                else
                {
                    foreach (string recentFileString in Settings.Default.RecentFiles)
                    {
                        ToolStripMenuItem item = new ToolStripMenuItem(recentFileString);
                        item.Click += new EventHandler(OpenRecentFile);

                        recentFilesToolStripMenuItem.DropDownItems.Add(item);

                    }
                }
            }
        }

        private void listBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (g_Playlist == null) return;
            if ( g_Playlist.CountGroups == 1 )
            {
                toolStripButtonGroupsRemove.Enabled = false;
            }
            else
            {
                toolStripButtonGroupsRemove.Enabled = true;
            }

            Group selectedGroup = listBoxGroups.SelectedItem as Group;
            if (selectedGroup == null) return;

            textBoxSearchStreams.Text = "Search Stream...";

            listBoxStreams.DataSource = selectedGroup.Streams;
            textBoxGroupname.Text = selectedGroup.Name;

            if (selectedGroup.CountStreams == 0)
            {
                toolStripButtonStreamRemove.Enabled = false;
                groupBoxStream.Visible = false;
            }
            listBoxStreams.Invalidate(); //Bleibt??
        }

        private void listBoxStreams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxStreams.Items.Count == 0)
            {
                toolStripButtonStreamRemove.Enabled = false;
            }
            else
            {
                toolStripButtonStreamRemove.Enabled = true;
            }

            Stream stream = (Stream)listBoxStreams.SelectedItem;
            if (stream == null)
                return;

            if ( listBoxStreams.SelectedItems.Count > 1)
            {
                groupBoxStream.Visible = false;
                return;
            }
            if ( listBoxStreams.Items.Count == 0 )
            {
                groupBoxStream.Visible = false;
                return;
            }

            groupBoxStream.Visible = true;

            textBoxId.Text = string.Format("ID: {0}", stream.Id);
            textBoxStreamGroup.Text = stream.Group;
            textBoxStreamName.Text = stream.Name;
            textBoxStreamUrl.Text = stream.Url;
            checkBoxExportStream.Checked = stream.Export;
            groupBoxStream.Text = string.Format("Stream ({0}) Last checked: {1}", stream.Status.ToString(), stream.LastChecked);
        }

        //Context Menu
        private void toolStripMenuItemDeleteGroup_Click(object sender, EventArgs e)
        {
            Group group = listBoxGroups.SelectedItem as Group;
            if ( group == null ) return;

            g_Playlist.RemoveGroup(group);
            listBoxGroups.DataSource = g_Playlist.Groups;
        }
        

        private void textBoxGroupname_TextChanged(object sender, EventArgs e)
        {
            if (listBoxGroups.SelectedItem == null) return;
            Group group = listBoxGroups.SelectedItem as Group;
            if (group.Name != textBoxGroupname.Text )
            {
                //buttonSaveGroup.Visible = true;
            } else
            {
                //buttonSaveGroup.Visible = false;
            }
        }

        private void ChangeGroupTitle()
        {
            Group group = listBoxGroups.SelectedItem as Group;

            group.Name = textBoxGroupname.Text;

            int streamIndex = listBoxStreams.SelectedIndex;
            if (streamIndex != -1)
            {
                listBoxStreams.SelectedItem = null;
                listBoxStreams.SelectedIndex = streamIndex;
            }
            //buttonSaveGroup.Visible = false;

            listBoxGroups.Invalidate();
        }
        private void buttonSaveGroup_Click(object sender, EventArgs e)
        {
            ChangeGroupTitle();
        }

        private void buttonSaveStream_Click(object sender, EventArgs e)
        {
            Stream stream = (Stream)listBoxStreams.SelectedItem;
            if (stream == null) return;

            stream.Name = textBoxStreamName.Text;
            stream.Url = textBoxStreamUrl.Text;

            listBoxStreams.Invalidate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (g_Playlist.HasFilename && !g_Playlist.IsM3U)
            {
                g_Playlist.Save(g_Playlist.Filename);
                MessageBox.Show("Playlist saved!", "M3-Uditor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (g_Playlist.HasFilename && g_Playlist.IsM3U)
            {
                g_Playlist.Export(g_Playlist.Filename);
                MessageBox.Show("Playlist saved!", "M3-Uditor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                saveAsToolStripMenuItem_Click(null, null);
            }   
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (g_Playlist.HasChanges)
            {
                DialogResult result = Helper.MessageBoxPlaylistChanges(g_Playlist);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                else if (result == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(null, null);
                }
            }
            using ( OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "M3 Uditor (*.m3)|*.m3";
                if ( openFileDialog.ShowDialog() == DialogResult.OK )
                {
                    if ( OpenFile(openFileDialog.FileName, FormLoading.Mode.Open))
                    {
                        Settings.Default.RecentFiles.Add(openFileDialog.FileName);
                        Settings.Default.Save();
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void localToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (g_Playlist.HasChanges)
            {
                DialogResult result = Helper.MessageBoxPlaylistChanges(g_Playlist);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                else if (result == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(null, null);
                }
            }
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = Helper.FilterM3U;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    OpenFile(openFileDialog.FileName, FormLoading.Mode.Import);
                }
            }
        }

        private void webToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (g_Playlist.HasChanges)
            {
                DialogResult result = Helper.MessageBoxPlaylistChanges(g_Playlist);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                else if (result == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(null, null);
                }
            }
            using (FormWebImporter webImporter = new FormWebImporter())
            {
                if ( webImporter.ShowDialog() == DialogResult.OK )
                {
                    OpenFile(webImporter.TempFile, FormLoading.Mode.Import);
                }
            }
        }

        private void listBoxGroups_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.PageUp )
            {
                int selectedIndex = listBoxGroups.SelectedIndex;
                Group group = listBoxGroups.SelectedItem as Group;
                g_Playlist.MoveGroup(group, -1);

                listBoxGroups.SelectedIndex = selectedIndex - 1;
            }
        }

        private void checkBoxExportStream_CheckedChanged(object sender, EventArgs e)
        {
            Stream stream = listBoxStreams.SelectedItem as Stream;

            stream.Export = checkBoxExportStream.Checked;
            listBoxStreams.Invalidate();
        }

        private void listBoxStreams_IconClicked(object sender, ItemClickedEventArgs e)
        {
            Stream stream = e.Item as Stream;
            //stream.Export = !stream.Export;
            if ( e.IconIndex == (int)ClickedIcon.OnlineStatus )
                linkLabelCheckUrl_LinkClicked(null, null);

            if (e.IconIndex == (int)ClickedIcon.Export)
            {
                stream.Export = !stream.Export;
                listBoxStreams.Invalidate();
            }

            if (e.IconIndex == (int)ClickedIcon.Play)
            {
               if ( stream.Status == Stream.OnlineStatus.Online ) 
                    buttonPlay_Click(null, null);
            }
        }

        private void listBoxGroups_IconClicked(object sender, ItemClickedEventArgs e)
        {
            Group group = e.Item as Group;
            group.Export = !group.Export;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ( g_Playlist.HasChanges )
            {
                DialogResult result = Helper.MessageBoxPlaylistChanges(g_Playlist);
                if ( result == DialogResult.Cancel )
                {
                    return;
                } 
                else if ( result == DialogResult.Yes )
                {
                    saveToolStripMenuItem_Click(null, null);
                }
            }

            g_Playlist = new Playlist();

            listBoxGroups.DataSource = null;
            listBoxStreams.DataSource = null;

            Helper.ResetControlsOnForm(this);

            listBoxGroups.DataSource = g_Playlist.Groups;
            listBoxGroups.SelectedIndex = 0;
        }

        private void listBoxGroups_MouseMove(object sender, MouseEventArgs e)
        {
            if (listBoxGroups.Items.Count == 0) return;

            if ((e.Button & MouseButtons.Left) == MouseButtons.Left && Helper.dragBoxFromMouseDown != Rectangle.Empty && !Helper.dragBoxFromMouseDown.Contains(e.Location))
            {
                DoDragDrop(typeof(Group).ToString(), DragDropEffects.All);
            }
        }

        private void listBoxStreams_MouseMove(object sender, MouseEventArgs e)
        {
            if (listBoxStreams.Items.Count == 0) return;

            if ( (e.Button & MouseButtons.Left) == MouseButtons.Left && Helper.dragBoxFromMouseDown != Rectangle.Empty && !Helper.dragBoxFromMouseDown.Contains(e.Location) )
            {
                string str = typeof(Stream).ToString();
                DoDragDrop(str, DragDropEffects.All);
            }
        }

        private void listBoxStreams_DragOver(object sender, DragEventArgs e)
        {
            string str = (string)e.Data.GetData(DataFormats.StringFormat);

            if (str == typeof(Group).ToString())
            {
                e.Effect = DragDropEffects.None;
            }

            if (str == typeof(Stream).ToString())
            {
                e.Effect = DragDropEffects.All;
            }

            listBoxStreams.Invalidate();
        }

        private void listBoxGroups_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
            listBoxGroups.Invalidate();
        }

        private void listBoxStreams_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                listBoxStreams.BeginUpdate();

                string str = (string)e.Data.GetData(DataFormats.StringFormat);
                if (str != typeof(Stream).ToString()) return;

                int newIndex = listBoxStreams.IndexFromPoint(listBoxStreams.PointToClient(Cursor.Position));
                if (newIndex == listBoxStreams.SelectedIndex) return;

                Group group = listBoxGroups.SelectedItem as Group;
                group.ReorderStream(listBoxStreams.SelectedItem as Stream, newIndex);

                listBoxStreams.SetSelected(newIndex, true);

                listBoxStreams.EndUpdate();
            }
        }

        private void listBoxGroups_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                listBoxGroups.BeginUpdate();

                string str = (string)e.Data.GetData(DataFormats.StringFormat);
                if (str == typeof(Group).ToString())
                {
                    Group group = listBoxGroups.SelectedItem as Group;
                    int indexEnd = listBoxGroups.IndexFromPoint(listBoxGroups.PointToClient(Cursor.Position));

                    if (indexEnd == listBoxGroups.SelectedIndex) return;

                    g_Playlist.MoveGroup(group, indexEnd);
                    listBoxGroups.SetSelected(indexEnd, true);
                }

                if (str == typeof(Stream).ToString())
                {
                    int indexStream = listBoxStreams.SelectedIndex;
                    int indexNewGroup = listBoxGroups.IndexFromPoint(listBoxGroups.PointToClient(Cursor.Position));

                    Console.WriteLine("{0},{1}", indexStream, indexNewGroup);

                    Stream stream = listBoxStreams.SelectedItem as Stream;
                    Group oldGroup = g_Playlist.FindGroup(stream.Group);
                    Group newGroup = listBoxGroups.Items[indexNewGroup] as Group;

                    if (oldGroup.Name == newGroup.Name)
                        return;

                    oldGroup.RemoveStream(stream);
                    newGroup.AddStream(stream);

                    if (listBoxStreams.Items.Count == 0)
                        groupBoxStream.Visible = false;
                }

                listBoxGroups.EndUpdate();
            }
        }

        private void listBoxStreams_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    toolStripButtonStreamRemove.PerformClick();
                    break;
                default:
                    break;
            }
        }

        private void textBoxSearchGroup_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearchGroup.Text == string.Empty)
            {
                return;
            }
            for (int i = 0; i < listBoxGroups.Items.Count; i++)
            {
                Group group = listBoxGroups.Items[i] as Group;
                if (group.Name.ToLower().Contains(textBoxSearchGroup.Text.ToLower()))
                {
                    listBoxGroups.SelectedItem = group;
                    break;
                }
            }
        }

        private void textBoxGroupname_KeyDown(object sender, KeyEventArgs e)
        { 
            if ( e.KeyCode == Keys.Enter )
            {
                e.SuppressKeyPress = true;
                ChangeGroupTitle();
            }
        }

        private void toolStripButtonGroupsCreate_Click(object sender, EventArgs e)
        {
            using (FormAddGroup formAddGroup = new FormAddGroup())
            {
                if (formAddGroup.ShowDialog() == DialogResult.OK)
                {
                    string str = formAddGroup.NewGroupname;

                    if (!g_Playlist.TryCreateGroup(str))
                    {
                        MessageBox.Show(string.Format("Group {0} already exists!", str), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    listBoxGroups.SelectedItem = g_Playlist.FindGroup(str);
                }
            }
        }

        private void toolStripButtonGroupsRemove_Click(object sender, EventArgs e)
        {
            if (listBoxGroups.SelectedItem == null) return;

            Group group = listBoxGroups.SelectedItem as Group;

            if (Settings.Default.AskDeleteGroup)
            {
                if (MessageBox.Show(string.Format("Delete Group: {0} ?", group.Name), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            g_Playlist.RemoveGroup(group);
            listBoxStreams.DataSource = (listBoxGroups.SelectedItem as Group).Streams;
        }

        private void listBoxStreams_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBoxStreams.Items.Count == 0) return;
            
            //listBoxStreams.SetSelected(listBoxStreams.IndexFromPoint(e.Location), true);

            //Create Offset for DragDrop
            Helper.CreateDragBox(e.Location);
        }

        private void toolStripButtonStreamUp_Click(object sender, EventArgs e)
        {
            if (listBoxStreams.SelectedItem == null)
                return;

            Stream stream = listBoxStreams.SelectedItem as Stream;
            Group group = g_Playlist.FindGroup(stream.Group);

            listBoxStreams.SetSelected(group.MoveStream(stream, -1), true);
        }

        private void toolStripButtonStreamDown_Click(object sender, EventArgs e)
        {
            if (listBoxStreams.SelectedItem == null)
                return;

            Stream stream = listBoxStreams.SelectedItem as Stream;
            Group group = g_Playlist.FindGroup(stream.Group);

            listBoxStreams.SetSelected(group.MoveStream(stream, 1), true);
        }

        private void toolStripButtonStreamCreate_Click(object sender, EventArgs e)
        {
            using ( FormCreateChannel formCreateChannel = new FormCreateChannel() )
            {
                if ( formCreateChannel.ShowDialog(this) == DialogResult.OK)
                {
                    Group group = listBoxGroups.SelectedItem as Group;
                    Stream stream = new Stream();

                    stream.Name = formCreateChannel.StreamName;
                    stream.Url = formCreateChannel.StreamUrl;
                    stream.Group = group.Name;

                    group.AddStream(stream);
                    listBoxStreams.SetSelected(listBoxStreams.Items.Count - 1, true);
                }
            }
        }

        private void exportM3UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using ( SaveFileDialog saveFileDialog = new SaveFileDialog() )
            {
                saveFileDialog.Filter = Helper.FilterM3U;
                if ( saveFileDialog.ShowDialog() == DialogResult.OK )
                {
                    g_Playlist.Export(saveFileDialog.FileName);
                }
            }
        }

        private bool OpenFile(string fileName, FormLoading.Mode mode, bool addRecent = true)
        {
            g_Playlist = new Playlist();
            listBoxGroups.DataSource = g_Playlist.Groups;
            listBoxStreams.DataSource = null;

            using ( FormLoading formLoading = new FormLoading(fileName, mode) )
            {
                if ( formLoading.ShowDialog() == DialogResult.OK )
                {
                    if (formLoading.Playlist == null)
                    {
                        MessageBox.Show("Error loading file!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    g_Playlist = formLoading.Playlist;
                    listBoxGroups.DataSource = g_Playlist.Groups;

                    if (addRecent) Helper.AddRecentFile(fileName);
                    return true;
                }
            }
            return false;
        }

        private void toolStripButtonStreamRemove_Click(object sender, EventArgs e)
        {
            if (listBoxGroups.SelectedItem == null || listBoxStreams.SelectedItem == null) return;

            Group group = listBoxGroups.SelectedItem as Group;
            Stream stream = listBoxStreams.SelectedItem as Stream;

            if (Settings.Default.AskDeleteStream)
            {
                if ( MessageBox.Show(string.Format("Delete Stream: {0} ?", stream.Name), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No )
                {
                    return;
                }
            }

            group.RemoveStream(stream);

            if (listBoxStreams.SelectedIndex != -1)
            {
                listBoxStreams.SetSelected(listBoxStreams.SelectedIndex, true);
            } else
            {
                toolStripButtonStreamRemove.Enabled = false;
                groupBoxStream.Visible = false;
            }
        }

        private void timerUpdateInfos_Tick(object sender, EventArgs e)
        {
            labelTotalGroups.Text = string.Format("Groups: {0}", g_Playlist.CountGroups.ToString());
            labelTotalStreams.Text = string.Format("Streams: {0}", g_Playlist.CountStreams.ToString());
               
            toolStripStatusLabelFilename.Visible = g_Playlist.HasFilename;
            toolStripStatusLabelFilename.Text = g_Playlist.Filename;

            toolStripStatusLabelIsM3U.Visible = g_Playlist.IsM3U;

            Console.WriteLine(g_Playlist.HasChanges);
        }

        private void buttonStreamDetails_Click(object sender, EventArgs e)
        {
            if (listBoxStreams.SelectedItem == null) return;

            Stream stream = listBoxStreams.SelectedItem as Stream;
            using ( FormStreamDetails formStreamDetails = new FormStreamDetails(stream) )
            {
                formStreamDetails.ShowDialog();
                listBoxStreams.Invalidate();
            }
        }

        private void listBoxStreams_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Show Streamdetails
            buttonStreamDetails.PerformClick();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using ( FormSettings formSettings = new FormSettings() )
            {
                formSettings.ShowDialog();
            }
        }

        private void linkLabelCheckUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Stream stream = listBoxStreams.SelectedItem as Stream;

            int index = listBoxStreams.SelectedIndex;
            using (FormUrlCheck formUrlCheck = new FormUrlCheck(stream))
            {
                formUrlCheck.ShowDialog();
                groupBoxStream.Text = string.Format("Stream ({0}) Last checked: {1}", stream.Status.ToString(), stream.LastChecked);
                listBoxStreams.Invalidate();
            }
            listBoxStreams.SetSelected(index, true);
        }

        private void checkLinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Group group = listBoxGroups.SelectedItem as Group;
            if (group.CountStreams == 0) return;

            int index = listBoxStreams.SelectedIndex;
            using ( FormUrlCheck formUrlCheck = new FormUrlCheck(ref group) )
            {
                formUrlCheck.ShowDialog();
                listBoxStreams.Invalidate();
            }

            listBoxStreams.SetSelected(index, true);
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            Stream stream = listBoxStreams.SelectedItem as Stream;

            if ( System.IO.File.Exists(Settings.Default.VlcPath) )
            {
                if ( stream.Status == Stream.OnlineStatus.Online || stream.Status == Stream.OnlineStatus.Unknown )
                    Helper.StartVlcPlayer(stream.Url);
            } 
            else
            {
                MessageBox.Show( "vlc.exe not found.\n\nPlease go to settings for setup.", "M3-Uditor", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            }
        }

        private void listBoxGroups_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBoxGroups.Items.Count == 0) return;

            //listBoxGroups.SetSelected(listBoxGroups.IndexFromPoint(e.Location), true);

            //Create Offset for DragDrop
            Helper.CreateDragBox(e.Location);
        }

        private void removeInactiveLinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Group group = listBoxGroups.SelectedItem as Group;
            int index = listBoxGroups.SelectedIndex;

            using (FormRemoveStreams formRemoveStreams = new FormRemoveStreams(group))
            {
                formRemoveStreams.ShowDialog();
            }

            listBoxGroups.SelectedIndex = -1;
            listBoxGroups.SelectedIndex = index;

            listBoxStreams.DataSource = null;
            listBoxStreams.DataSource = group.Streams;
        }

        private void textBoxSearchStreams__TextChanged(object sender, EventArgs e)
        {
            textBoxSearchStreams.ForeColor = Color.DimGray;

            if (textBoxSearchStreams.Text == string.Empty ||
                textBoxSearchStreams.Text == "Search Stream...")
            {
                textBoxSearchStreams.Width = listBoxStreams.Width;
                toolStripSearchStreams.Visible = false;
                toolStripStatusLabelStreamSearchResults.Visible = false;
                return;
            }

            Helper.SearchStreamSelectedIndex = 0;
            Helper.SearchStreamResults.Clear();

            for (int i = 0; i < listBoxStreams.Items.Count; i++)
            {
                Stream stream = listBoxStreams.Items[i] as Stream;
                if (stream.Name.ToLower().Contains(textBoxSearchStreams.Text.ToLower()))
                {
                    Helper.SearchStreamResults.Add(i);
                }
            }

            toolStripStatusLabelStreamSearchResults.Visible = true;
            if (Helper.SearchStreamResults.Count > 0)
            {
                textBoxSearchStreams.Width = listBoxStreams.Width - toolStripSearchStreams.Width;
                toolStripSearchStreams.Visible = true;

                toolStripStatusLabelStreamSearchResults.ForeColor = Color.Black;
                toolStripStatusLabelStreamSearchResults.Text = "Found Streams: " + Helper.SearchStreamResults.Count;
                listBoxStreams.SetSelected(Helper.SearchStreamResults[0], true);
            } 
            else
            {
                textBoxSearchStreams.ForeColor = Color.Red;
                toolStripStatusLabelStreamSearchResults.Visible = false;
                textBoxSearchStreams.Width = listBoxStreams.Width;
                toolStripSearchStreams.Visible = false;
            }
        }

        private void listBoxGroups_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (g_Playlist.Groups.Count == 0) return;

            Group group = g_Playlist.Groups[e.Index];
            Rectangle IconBounds = new Rectangle(e.Bounds.Right - 32, e.Bounds.Top + listBoxGroups.ItemMargin, 16, 16);

            if (group.Export)
            {
                e.Graphics.DrawImage(Resources.group_visible, IconBounds);
            } 
            else
            {
                e.Graphics.DrawImage(Resources.group_not_visible, IconBounds);
            }
        }

        private void listBoxStreams_DrawItem(object sender, DrawItemEventArgs e)
        {
            Stream stream = listBoxStreams.Items[e.Index] as Stream;
            Size iconSize = listBoxStreams.IconSize;

            Rectangle OnlineStatusIconBounds = new Rectangle(e.Bounds.Right - iconSize.Width * 2 * (int)ClickedIcon.OnlineStatus, 
                                                 e.Bounds.Top + listBoxStreams.ItemMargin, 
                                                 iconSize.Width, iconSize.Height);
            Rectangle ExportIconBounds = new Rectangle(e.Bounds.Right - iconSize.Width * 2 * (int)ClickedIcon.Export,
                                                 e.Bounds.Top + listBoxStreams.ItemMargin,
                                                 iconSize.Width, iconSize.Height);

            Rectangle PlayIconBounds = new Rectangle(e.Bounds.Right - iconSize.Width * 2 * (int)ClickedIcon.Play,
                                                 e.Bounds.Top + listBoxStreams.ItemMargin,
                                                 iconSize.Width, iconSize.Height);

            if ( stream.Status == Stream.OnlineStatus.Online )
            {
                e.Graphics.DrawImage(Resources.Ionic_Ionicons_Play_512, PlayIconBounds);
                e.Graphics.DrawImage(Resources.stream_online, OnlineStatusIconBounds);
            } 
            else if (stream.Status == Stream.OnlineStatus.Offline)
            {
                e.Graphics.DrawImage(Resources.stream_offline, OnlineStatusIconBounds);
            }

            if ( stream.Export )
            {
                e.Graphics.DrawImage(Resources.Pictogrammers_Material_Export_512, ExportIconBounds);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.RecentFiles.Clear();
            Settings.Default.Save();

            GetRecentFiles();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (g_Playlist.HasChanges)
            {
                DialogResult result = Helper.MessageBoxPlaylistChanges(g_Playlist);
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (result == DialogResult.Yes)
                {
                    saveToolStripMenuItem.PerformClick();
                }
            }
        }

        private void toolStripButtonNextStreamResult_Click(object sender, EventArgs e)
        {
            Helper.SearchStreamSelectedIndex++;
            if (Helper.SearchStreamSelectedIndex == Helper.SearchStreamResults.Count) Helper.SearchStreamSelectedIndex = 0;

            listBoxStreams.SetSelected(Helper.SearchStreamResults[Helper.SearchStreamSelectedIndex], true);
        }

        private void removeDuplicateEntriesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonPreviousStreamResult_Click(object sender, EventArgs e)
        {
            Helper.SearchStreamSelectedIndex--;
            if (Helper.SearchStreamSelectedIndex < 0) Helper.SearchStreamSelectedIndex = Helper.SearchStreamResults.Count - 1;

            listBoxStreams.SetSelected(Helper.SearchStreamResults[Helper.SearchStreamSelectedIndex], true);
        }

        private void RemoveDuplicateEntries()
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "M3 - File (*.m3)|*.m3";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    g_Playlist.Save(saveFileDialog.FileName);
                    g_Playlist.Filename = saveFileDialog.FileName;
                    MessageBox.Show("Playlist saved!", "M3-Uditor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void showFileinfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using ( FormAdditionalData formAdditionalData = new FormAdditionalData(g_Playlist))
            {
                formAdditionalData.ShowDialog();
            }
        }

        private void textBoxSearchStreams_KeyDown(object sender, KeyEventArgs e)
        {
            if (Helper.SearchStreamResults.Count == 0)
                return;

            switch (e.KeyCode)
            {
                case Keys.Down:
                    toolStripButtonNextStreamResult_Click(null, null);
                    break;
                case Keys.Up:
                    toolStripButtonPreviousStreamResult_Click(null, null);
                    break;
            }
            e.Handled = true;
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(null, null);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            loadToolStripMenuItem_Click(null, null);
        }
    }
}
