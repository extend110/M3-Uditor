using System;
using System.Windows.Forms;
using M3U8;
using M3Controls;
using M3Controls.Dialogs;
using System.ComponentModel;
using M3_Uditor.Forms;
using System.Net;
using System.Drawing;
using M3_Uditor.Properties;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Threading;
using MessageBox = System.Windows.Forms.MessageBox;
using Forms.M3_Uditor;
using XmlTv;

namespace M3_Uditor
{
    public partial class FormMain : Form
    {
        enum ClickedIcon
        {
            OnlineStatus = 1,
            Export = 2,
            Favorite = 3,
            Play = 4
        }

        Playlist g_Playlist;
        
        string openFilename = string.Empty;

        public FormMain()
        {
            InitializeComponent();
        }
        public FormMain(string filename) : this()
        {
            openFilename = filename;

            if (openFilename == null)
                openFilename = string.Empty;
        }
        private void OpenRecentFile(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            if (!System.IO.File.Exists(item.Text))
            {
                MessageBox.Show("File not found.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Helper.RemoveRecentFile(item.Text);
                GetRecentFiles();
                return;
            }

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

            string content = string.Empty;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(item.Text))
            {
                content = reader.ReadLine();
            }
            if (content == null)
                return;

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

            Helper.LoadFlags();
            EpgData.StartListening();

            g_Playlist = new Playlist();
           
            listBoxGroups.DataSource = g_Playlist.Groups;
            listBoxGroups.SelectedIndex = 0;

            // setup events
            textBoxSearchGroup.ButtonClicked += TextBoxClearButtonClicked;
            textBoxSearchStreams.ButtonClicked += TextBoxClearButtonClicked;

            englishToolStripMenuItem.Click += SetGroupLanguage;
            germanToolStripMenuItem.Click += SetGroupLanguage;
            italianToolStripMenuItem.Click += SetGroupLanguage;
            frenchToolStripMenuItem.Click += SetGroupLanguage;

            EpgParser.ProcessingStatusChanged += EpgParser_ProcessingStatusChanged;
        }

        private void EpgParser_ProcessingStatusChanged(object sender, ProcessingEventArgs e)
        {
            if (e.Status == EpgParser.ProcessingStatus.Success)
                textBoxEpgCode.AutoCompleteDataSource = EpgData.ToAutoCompleteStringCollection();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            if (openFilename.Length > 0)
            {
                string content = string.Empty;
                using (System.IO.StreamReader reader = new System.IO.StreamReader(openFilename))
                {
                    content = reader.ReadLine();
                }

                if (content.Contains("#EXTM3U"))
                {
                    OpenFile(openFilename, FormLoading.Mode.Import, false);
                    //return;
                }
                else if (content.Contains("M3-Uditor"))
                {
                    OpenFile(openFilename, FormLoading.Mode.Open, false);
                    //return;
                }
            }
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
                        MMenuItem item = new MMenuItem(recentFileString);
                        item.Tag = "RecentFile";
                        item.Click += new EventHandler(OpenRecentFile);
                        recentFilesToolStripMenuItem.DropDownItems.Add(item);
                    }
                }
            }
        }
        private void listBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (g_Playlist == null) return;

            if ( listBoxGroups.SelectedItems.Count > 1)
            {
                listBoxStreams.Visible = false;
                groupBoxStream.Visible = false;
                return;
            }

            listBoxStreams.Visible = true;
            groupBoxStream.Visible = true;

            Group selectedGroup = listBoxGroups.SelectedItem as Group;
            if (selectedGroup == null) return;

            textBoxSearchStreams.Text = "Search Stream...";

            listBoxStreams.DataSource = null;
            listBoxStreams.DataSource = selectedGroup.Streams;
            textBoxGroupname.Text = selectedGroup.Name;

            if (selectedGroup.CountStreams == 0)
            {
                streamToolStripMenuItem.Visible = false;
                checkLinksToolStripButton.Enabled = false;
                checkLinksToolStripMenuItem.Enabled = false;

                toolStripButtonStreamRemove.Enabled = false;
                groupBoxStream.Visible = false;
            } 
            else
            {
                streamToolStripMenuItem.Visible = true;
                checkLinksToolStripButton.Enabled = true;
                checkLinksToolStripMenuItem.Enabled = true;
            }
            //listBoxStreams.Invalidate(); //Bleibt??
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
            if (stream == null || listBoxStreams.SelectedItems.Count > 1)
            {
                groupBoxStream.Visible = false;
                return;
            }

            groupBoxStream.Visible = true;

            textBoxId.Text = string.Format("ID: {0}", stream.Id);
            textBoxStreamGroup.Text = stream.Group;
            textBoxEpgCode.Text = stream.TvgId;
            textBoxStreamName.Text = stream.Name;
            textBoxStreamUrl.Text = stream.Url;
            checkBoxExportStream.Checked = stream.Export;
            checkBoxStreamFavorite.Checked = stream.Favorite;
            streamNameToolStripMenuItem.Text = string.Format("[{0}]", stream.Name);
            groupBoxStream.Text = string.Format("Stream ({0}) Last checked: {1}", stream.Status.ToString(), stream.LastChecked);

            Console.WriteLine("Stream TVG-ID: " + stream.TvgId);
        }   
        private void ChangeGroupTitle()
        {
            Group group = listBoxGroups.SelectedItem as Group;

            if ( textBoxGroupname.Text == string.Empty)
            {
                textBoxGroupname.Text = group.Name;
                return;
            }

            group.Name = textBoxGroupname.Text;

            int streamIndex = listBoxStreams.SelectedIndex;
            if (streamIndex != -1)
            {
                listBoxStreams.SelectedItem = null;
                listBoxStreams.SelectedIndex = streamIndex;
            }

            g_Playlist.HasChanges = true;
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
            stream.TvgId = textBoxEpgCode.Text;

            g_Playlist.HasChanges = true;
            listBoxStreams.Invalidate();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (g_Playlist.HasFilename && !g_Playlist.IsM3U)
            {
                g_Playlist.Save(g_Playlist.Filename);
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
                openFileDialog.Filter = Helper.FilterM3;
                DialogResult result = openFileDialog.ShowDialog();
                if ( result == DialogResult.OK )
                {
                    if (OpenFile(openFileDialog.FileName, FormLoading.Mode.Open))
                    {
                        Helper.AddRecentFile(openFileDialog.FileName);
                    }

                    Thread.Sleep(500);
                }
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
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
        private void checkBoxExportStream_CheckedChanged(object sender, EventArgs e)
        {
            Stream stream = listBoxStreams.SelectedItem as Stream;

            stream.Export = checkBoxExportStream.Checked;
            listBoxStreams.Invalidate();
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
            EpgData.ResetData();

            listBoxGroups.DataSource = g_Playlist.Groups;
            listBoxGroups.SelectedIndex = 0;
        }
        #region "Group Listbox MouseEvents & DragDrop"
        private void listBoxGroups_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBoxGroups.Items.Count == 0) return;

            listBoxGroups.SetSelected(listBoxGroups.IndexFromPoint(e.Location), true);

            //Create Offset for DragDrop
            if ( e.Button == MouseButtons.Left ) Helper.CreateDragBox(e.Location);

            if ( e.Button == MouseButtons.Right)
            {
                contextMenuStripGroups.Show(MousePosition);
            }
        }
        private void listBoxGroups_MouseMove(object sender, MouseEventArgs e)
        {
            if (listBoxGroups.Items.Count == 0) return;

            if ((e.Button & MouseButtons.Left) == MouseButtons.Left && Helper.dragBoxFromMouseDown != Rectangle.Empty && !Helper.dragBoxFromMouseDown.Contains(e.Location))
            {
                DoDragDrop(typeof(Group).ToString(), DragDropEffects.All);
            }
        }
        private void listBoxGroups_DragOver(object sender, DragEventArgs e)
        {
            string str = (string)e.Data.GetData(DataFormats.StringFormat);

            if (str == typeof(Stream).ToString() || str == typeof(Group).ToString())
            {
                e.Effect = DragDropEffects.All;
                listBoxGroups.Invalidate();
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void listBoxGroups_DragDrop(object sender, DragEventArgs e)
        {
            int cursorIndex = listBoxGroups.IndexFromPoint(listBoxGroups.PointToClient(Cursor.Position));

            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                listBoxGroups.BeginUpdate();

                string str = (string)e.Data.GetData(DataFormats.StringFormat);
                if (str == typeof(Group).ToString())
                {
                    Group group = listBoxGroups.SelectedItem as Group;
                    Group indexEndGroup = listBoxGroups.Items[cursorIndex] as Group;

                    if (indexEndGroup.Index != group.Index)
                    {
                        g_Playlist.MoveGroup(group, indexEndGroup.Index);
                        g_Playlist.HasChanges = true;
                    }
                    textBoxSearchGroup_TextChanged(sender, e);
                    listBoxGroups.SetSelected(cursorIndex, true);
                }

                if (str == typeof(Stream).ToString())
                {
                    Stream stream = listBoxStreams.SelectedItem as Stream;
                    Group oldGroup = g_Playlist.FindGroup(stream.Group);
                    Group newGroup = listBoxGroups.Items[cursorIndex] as Group;

                    if (oldGroup.Name != newGroup.Name)
                    {
                        oldGroup.RemoveStream(stream);
                        newGroup.AddStream(stream);
                        g_Playlist.HasChanges = true;

                        if (listBoxStreams.Items.Count == 0)
                            groupBoxStream.Visible = false;

                        listBoxGroups.Refresh();
                    }
                }

                listBoxGroups.EndUpdate();
            }
        }
        private void listBoxGroups_IconClicked(object sender, ItemClickedEventArgs e)
        {
            Group group = e.Item as Group;
            group.Export = !group.Export;
            g_Playlist.HasChanges = true;
        }
        #endregion
        #region "Stream Listbox MouseEvents & DragDrop"
        private void listBoxStreams_MouseUp(object sender, MouseEventArgs e)
        {

        }
        private void listBoxStreams_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBoxStreams.Items.Count == 0) return;
            //Create Offset for DragDrop
            Helper.CreateDragBox(e.Location);
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

            if (str == typeof(Stream).ToString())
            {
                e.Effect = DragDropEffects.All;

                // auto-scroll TODO!
                
                Rectangle topRect = new Rectangle(0, 0, listBoxStreams.ClientRectangle.Width, 100);
                Rectangle bottomRect = new Rectangle(0, listBoxStreams.ClientRectangle.Height - 100,
                                                     listBoxStreams.ClientRectangle.Width, 100);
                int scrollPos = ExtendedListBox.GetScrollPos(listBoxStreams.Handle, (int)ExtendedListBox.ScrollBarDirection.Vertical);
                Console.WriteLine(scrollPos);

                if (bottomRect.Contains(listBoxStreams.PointToClient(MousePosition)))
                {
                    listBoxStreams.Scroll(ExtendedListBox.ScrollCommand.Down);
                }
                else if (topRect.Contains(listBoxStreams.PointToClient(MousePosition)))
                {
                    if ( scrollPos > 0 )
                        listBoxStreams.Scroll(ExtendedListBox.ScrollCommand.Up);
                } else
                {
                    listBoxStreams.Scroll(ExtendedListBox.ScrollCommand.EndScroll);
                }
                
                listBoxStreams.Invalidate();
            } 
            else
            {
                e.Effect = DragDropEffects.None;
            }               
        }
        private void listBoxStreams_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                listBoxStreams.BeginUpdate();

                string str = (string)e.Data.GetData(DataFormats.StringFormat);
                if (str != typeof(Stream).ToString()) return;

                int newIndex = listBoxStreams.IndexFromPoint(listBoxStreams.PointToClient(Cursor.Position));
                if (newIndex != listBoxStreams.SelectedIndex)
                {
                    Group group = listBoxGroups.SelectedItem as Group;
                    Stream stream = listBoxStreams.SelectedItem as Stream;

                    if (group != null)
                    {
                        group.ReorderStream(stream, newIndex);
                        g_Playlist.HasChanges = true;
                    }
                    else
                    {
                        if (stream.Favorite)
                            MessageBox.Show("Invalid operation");
                    }
                }

                listBoxStreams.EndUpdate();
                listBoxStreams.SetSelected(newIndex, true);
            }
        }
        private void listBoxStreams_IconClicked(object sender, ItemClickedEventArgs e)
        {
            Stream stream = e.Item as Stream;
            //stream.Export = !stream.Export;
            if (e.IconIndex == (int)ClickedIcon.OnlineStatus)
            {
                linkLabelCheckUrl_LinkClicked(null, null);
                g_Playlist.HasChanges = true;
            }

            if (e.IconIndex == (int)ClickedIcon.Export)
            {
                stream.Export = !stream.Export;
                g_Playlist.HasChanges = true;
                listBoxStreams.Invalidate();
            }

            if (e.IconIndex == (int)ClickedIcon.Play)
            {
               if ( stream.Status == Stream.OnlineStatus.Online ) 
                    buttonPlay_Click(null, null);
            }
        }
        #endregion
        #region "Keyboard Events Listboxes"
        private void listBoxStreams_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    toolStripButtonStreamRemove_Click(null, null);
                    //toolStripButtonStreamRemove.PerformClick();
                    break;
                default:
                    break;
            }
        }
        #endregion
        #region "TextBoxes"
        private void textBoxSearchGroup_TextChanged(object sender, EventArgs e)
        {          
            if (textBoxSearchGroup.Text == string.Empty || textBoxSearchGroup.Text == textBoxSearchGroup.Placeholder)
            {
                listBoxGroups.DataSource = g_Playlist?.Groups;
                return;
            }

            List<Group> groupsFiltered = g_Playlist.Groups.Where(group => group.Name.ToLower().Contains(textBoxSearchGroup.Text.ToLower())).ToList();
            listBoxGroups.DataSource = groupsFiltered;
        }
        private void textBoxGroupname_KeyDown(object sender, KeyEventArgs e)
        { 
            if ( e.KeyCode == Keys.Enter )
            {
                e.SuppressKeyPress = true;
                ChangeGroupTitle();
            }
        }
        #endregion
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
                    } else
                    {
                        g_Playlist.HasChanges = true;
                    }
                    listBoxGroups.SelectedItem = g_Playlist.FindGroup(str);
                }
            }
        }
        private void toolStripButtonGroupsRemove_Click(object sender, EventArgs e)
        {
            if (listBoxGroups.SelectedItem == null)
            {
                listBoxStreams.DataSource = null;
                return;
            }

            Group group = listBoxGroups.SelectedItem as Group;
            if (Settings.Default.AskDeleteGroup)
            {
                if (MessageBox.Show(string.Format("Delete Group: {0} ?", group.Name), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            Helper.UndoStack.Push(new StackObject() { Command = "RemoveGroup", Container = group });
            Helper.BeginUpdate(new ListBox[] { listBoxGroups, listBoxStreams });

            g_Playlist.RemoveGroup(group);
            g_Playlist.HasChanges = true;

            listBoxStreams.DataSource = (listBoxGroups.SelectedItem as Group).Streams;
            textBoxSearchGroup_TextChanged(null, null);
            
            Helper.EndUpdate(new ListBox[] { listBoxGroups, listBoxStreams });
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
                    g_Playlist.HasChanges = true;
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
            EpgData.ResetData();

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
                    g_Playlist.HasChanges = false;
                    listBoxGroups.DataSource = g_Playlist.Groups;

                    if (addRecent) Helper.AddRecentFile(fileName);

                    if (g_Playlist.XmlTvUrl?.Length > 0)
                        EpgData.GetData(g_Playlist.XmlTvUrl);

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

            Helper.UndoStack.Push(new StackObject() { Command = "RemoveStream", Container = Stream.DeepClone(stream) });

            group.RemoveStream(stream);
            g_Playlist.HasChanges = true;

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
            this.Text = g_Playlist.HasFilename ? Application.ProductName + " - " + g_Playlist.Filename : Application.ProductName;

            mStatusBar.GetItem("EPG").Visible = EpgData.EpgItemList.Count > 0;
            mStatusBar.GetItem("Filename").Visible = g_Playlist.HasFilename;
            mStatusBar.GetItem("Filename").Text = g_Playlist.HasChanges ? g_Playlist.Filename + " *" : g_Playlist.Filename;
            mStatusBar.GetItem("IsM3U").Text = g_Playlist.IsM3U ? "M3U File" : string.Empty;
            mStatusBar.GetItem("DateTime").Text = DateTime.Now.ToString();
            mStatusBar.GetItem("Groups").Text = string.Format("Groups: {0}", g_Playlist.CountGroups.ToString());
            mStatusBar.GetItem("Streams").Text = string.Format("Streams: {0}", g_Playlist.CountStreams.ToString());

            toolStripButtonGroupsRemove.Enabled = listBoxGroups.Items.Count > 1;

            undoToolStripMenuItem.Enabled = Helper.UndoStack.Count > 0;
            refreshEPGDataToolStripMenuItem.Enabled = EpgData.EpgItemList.Count > 0;
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
            buttonStreamDetails_Click(null, null);
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using ( FormSettings formSettings = new FormSettings(g_Playlist) )
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
                g_Playlist.HasChanges = true;
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
                if ( formUrlCheck.OnlineCount == 0)
                {
                    MessageBox.Show("No active streams found in this group!", Application.ProductName, MessageBoxButtons.OK);
                }
                g_Playlist.HasChanges = true;
                listBoxStreams.Invalidate();
                listBoxStreams.SetSelected(index, true);
            }
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
        private void removeInactiveLinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Group group = listBoxGroups.SelectedItem as Group;

            Helper.BeginUpdate();

            listBoxStreams.DataSource = null;
            listBoxGroups.DataSource = null;

            for (int i = group.Streams.Count - 1; i >= 0; i--)
            {
                Stream stream = group.Streams[i];
                if (stream.Status == Stream.OnlineStatus.Offline)
                {
                    Helper.UndoStack.Push(new StackObject() { Command = "RemoveStream", Container = Stream.DeepClone(stream) });
                    group.RemoveStream(stream);
                }
            }

            Helper.EndUpdate();
            textBoxSearchGroup_TextChanged(null, null);
        }
        private void textBoxSearchStreams__TextChanged(object sender, EventArgs e)
        {
            textBoxSearchStreams.ForeColor = Color.DimGray;

            if (textBoxSearchStreams.Text == string.Empty ||
                textBoxSearchStreams.Text == "Search Stream...")
            {
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

            if (Helper.SearchStreamResults.Count > 0)
            {
                listBoxStreams.SetSelected(Helper.SearchStreamResults[0], true);
            } 
            else
            {
                textBoxSearchStreams.ForeColor = Color.Red;
            }
        }
        private void listBoxGroups_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (g_Playlist.Groups.Count == 0)
                return;

            Group group = listBoxGroups.Items[e.Index] as Group;//g_Playlist.Groups[e.Index];
            Rectangle IconBounds = new Rectangle(e.Bounds.Right - 32, e.Bounds.Top + listBoxGroups.ItemMargin, 16, 16);
            Rectangle FlagBounds = new Rectangle(e.Bounds.Right - 32 * 2, e.Bounds.Top + listBoxGroups.ItemMargin, 16, 16);

            if (group.Export)
            {
                e.Graphics.DrawImage(Resources.group_visible, IconBounds);
            } 
            else
            {
                e.Graphics.DrawImage(Resources.group_not_visible, IconBounds);
            }

            foreach (string flagTag in Helper.Flags.Keys)
            {
                    if (group.Name.StartsWith(flagTag))
                    {
                        e.Graphics.DrawImage(Helper.Flags[flagTag], FlagBounds);
                    }
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

            Rectangle FavoriteIconBounds = new Rectangle(e.Bounds.Right - iconSize.Width * 2 * (int)ClickedIcon.Favorite,
                                                 e.Bounds.Top + listBoxStreams.ItemMargin,
                                                 iconSize.Width, iconSize.Height);

            Rectangle PlayIconBounds = new Rectangle(e.Bounds.Right - iconSize.Width * 2 * (int)ClickedIcon.Play,
                                                 e.Bounds.Top + listBoxStreams.ItemMargin,
                                                 iconSize.Width, iconSize.Height);

            if ( stream.Status == Stream.OnlineStatus.Online )
            {
                e.Graphics.DrawImage(Resources.PlayButton, PlayIconBounds);
                e.Graphics.DrawImage(Resources.StreamOnline, OnlineStatusIconBounds);
            } 
            else if (stream.Status == Stream.OnlineStatus.Offline)
            {
                e.Graphics.DrawImage(Resources.StreamOffline, OnlineStatusIconBounds);
            }
            else
            {
                e.Graphics.DrawImage(Resources.StreamUnkown, OnlineStatusIconBounds);
            }

            if ( stream.Export )
            {
                e.Graphics.DrawImage(Resources.Export, ExportIconBounds);
            }
            if (stream.Favorite)
            {
                e.Graphics.DrawImage(Resources.FavoritesYellow, FavoriteIconBounds);
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
            Group group = listBoxGroups.SelectedItem as Group;
            Stream[] streams = group.Streams.ToArray();

            Helper.BeginUpdate();

            List<Stream> distinctList = streams.Distinct(new StreamComparer()).ToList();

            int removedStreams = streams.Length - distinctList.Count;
            string displayMessage = removedStreams == 1 ? "stream." : "streams.";

            group.Streams.Clear();
            foreach (Stream stream in distinctList)
            {
                group.AddStream(stream);
            }
            Helper.EndUpdate();
            if (removedStreams > 0) g_Playlist.HasChanges = true;
            MessageBox.Show(string.Format("Removed {0} duplicate {1}", removedStreams, displayMessage), Application.ProductName);
        }
        private void toolStripButtonPreviousStreamResult_Click(object sender, EventArgs e)
        {
            Helper.SearchStreamSelectedIndex--;
            if (Helper.SearchStreamSelectedIndex < 0) Helper.SearchStreamSelectedIndex = Helper.SearchStreamResults.Count - 1;

            listBoxStreams.SetSelected(Helper.SearchStreamResults[Helper.SearchStreamSelectedIndex], true);
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
        private void exportAsM3UtoolStripButton_Click(object sender, EventArgs e)
        {
            exportM3UToolStripMenuItem_Click(null, null);
        }
        private void settingsToolStripButton_Click(object sender, EventArgs e)
        {
            settingsToolStripMenuItem_Click(null, null);
        }
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(null, null);
        }
        private void textBoxStreamName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                buttonSaveStream_Click(null, null);
            }
        }
        private void textBoxStreamUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                buttonSaveStream_Click(null, null);
            }
        }
        private void checkLinksToolStripButton_Click(object sender, EventArgs e)
        {
            checkLinksToolStripMenuItem_Click(null, null);
        }
        private void listBoxGroups_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Delete && listBoxGroups.Items.Count > 1)
            {
                toolStripButtonGroupsRemove_Click(null, null);
                listBoxGroups.SetSelected(listBoxGroups.SelectedIndex, true);
            }
        }
        private void checkBoxExportStream_Click(object sender, EventArgs e)
        {
            g_Playlist.HasChanges = true;
        }
        private void groupDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Group group = listBoxGroups.SelectedItem as Group;
            using (FormGroupDetails formGroupDetails = new FormGroupDetails(group))
                formGroupDetails.ShowDialog();
        }
        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonPlay_Click(null, null);
        }
        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            buttonStreamDetails_Click(null, null);
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButtonStreamRemove_Click(null, null);
        }
        private void menuStrip1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StackObject stackObject = Helper.UndoStack.Pop();

            switch (stackObject.Command)
            {
                case "RemoveGroup":
                    Group group = stackObject.Container as Group;
                    g_Playlist.AddGroup(group);
                    break;
                case "RemoveStream":
                    int index = (int)(stackObject.Container as List<object>)[0];
                    Stream stream = (stackObject.Container as List<object>)[1] as Stream;

                    g_Playlist.InsertStream(stream, index);
                    break;
            }

            Helper.RefreshControls(this);
        }
        private void toolStripButtonGroupsExportAll_Click(object sender, EventArgs e)
        {
            g_Playlist.ShowAllGroups();
            listBoxGroups.Invalidate();
        }
        private void toolStripButtonGroupsExportNone_Click(object sender, EventArgs e)
        {
            g_Playlist.HideAllGroups();
            listBoxGroups.Invalidate();
        }
        private void searchReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using ( FormSearchReplace formSearchReplace = new FormSearchReplace() )
            {
                Helper.BeginUpdate();
                if ( formSearchReplace.ShowDialog() == DialogResult.OK )
                {
                    if (formSearchReplace.SearchIn == FormSearchReplace.SearchOption.Groups)
                    {
                        g_Playlist.GroupReplaceString(formSearchReplace.SearchFor, formSearchReplace.ReplaceWith);
                        textBoxSearchGroup_TextChanged(null, null);
                    }

                    if (formSearchReplace.SearchIn == FormSearchReplace.SearchOption.Streams)
                    {
                        if (formSearchReplace.InAllGroups)
                        {
                            foreach (Group group in g_Playlist.Groups)
                            {
                                foreach (Stream stream in group.Streams)
                                {
                                    stream.Name = stream.Name.Replace(formSearchReplace.SearchFor, formSearchReplace.ReplaceWith).Trim();
                                }
                            }
                        }
                        else
                        {
                            foreach (Stream stream in (listBoxGroups.SelectedItem as Group).Streams)
                            {
                                stream.Name = stream.Name.Replace(formSearchReplace.SearchFor, formSearchReplace.ReplaceWith).Trim();
                            }
                        }
                    }
                }
                Helper.EndUpdate();
            }
        }
        private void refreshEPGDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ( g_Playlist.XmlTvUrl?.Length == 0)
            {
                MessageBox.Show("No XMLTV-Url found. Go to Settings->IPTV for setup.");
                return;
            }

            using (FormEpgMapper formEpgMapper = new FormEpgMapper(g_Playlist, listBoxGroups.SelectedItem as Group))
            {
                if ( listBoxStreams.HasItems )
                    formEpgMapper.ShowDialog();
            }
        }
        private void textBoxEpgCode_ButtonClicked(object sender, EventArgs e)
        {
            ShowEpgWindow();
        }
        private void TextBoxClearButtonClicked(object sender, EventArgs e)
        {
            MTextBox textBox = (MTextBox)sender;
            textBox.Clear();
        }
        private void textBoxEpgCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Stream stream = listBoxStreams.SelectedItem as Stream;
                e.SuppressKeyPress = true;

                if (textBoxEpgCode.Text == string.Empty)
                {
                    stream.TvgId = string.Empty;
                    stream.TvgName = string.Empty;
                }
                else
                {
                    EpgItem epgItem = EpgData.GetItemByChannelId(textBoxEpgCode.Text);

                    stream.TvgId = epgItem?.EpgId ?? textBoxEpgCode.Text;
                    stream.TvgName = epgItem?.Name ?? stream.Name;
                }
                buttonSaveStream_Click(null, null);
            }
        }
        private void checkBoxStreamFavorite_Click(object sender, EventArgs e)
        {
            Stream stream = listBoxStreams.SelectedItem as Stream;

            stream.Favorite = checkBoxStreamFavorite.Checked;
            if (checkBoxStreamFavorite.Checked)
            {
                g_Playlist.Favorites.Add(stream.Id);
            }
            else
            {
                g_Playlist.Favorites.Remove(stream.Id);
            }

            g_Playlist.HasChanges = true;
            listBoxStreams.Invalidate();
        }
        private void toolStripButtonFavorites_Click(object sender, EventArgs e)
        {
            using (FormFavorites formFavorites = new FormFavorites(g_Playlist))
            {
                formFavorites.ShowDialog();
            }
        }
        private void checkBoxStreamFavorite_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        private void SetGroupLanguage(object sender, EventArgs e)
        {
            Group group = listBoxGroups.SelectedItem as Group;
            ToolStripMenuItem languageItem = (ToolStripMenuItem)sender;

            group.Name = group.Name.Insert(0, languageItem.Tag.ToString() + " ");
        }
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripButtonGroupsRemove_Click(sender, e);
        }
        private void ShowEpgWindow()
        {
            using (FormEpgData formEpgData = new FormEpgData())
            {
                DialogResult dr = formEpgData.ShowDialog();
                Stream stream = listBoxStreams.SelectedItem as Stream;

                if (stream != null && dr == DialogResult.OK)
                {
                    stream.TvgId = formEpgData.SelectedItem.EpgId;
                    stream.TvgName = formEpgData.SelectedItem.Name;
                    g_Playlist.HasChanges = true;
                }

                if (listBoxStreams.SelectedIndex >= 0)
                    listBoxStreams.SetSelected(listBoxStreams.SelectedIndex, true);
            }
        }
        private void playlistSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(FormSettings formSettings = new FormSettings(g_Playlist, 2))
            {
                formSettings.ShowDialog();
            }
        }
        private void selectGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormExportSelectGroups formExportSelectGroups = new FormExportSelectGroups(g_Playlist))
            {
                if (formExportSelectGroups.ShowDialog() == DialogResult.OK && formExportSelectGroups.GroupsForExport.Count > 0)
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = Helper.FilterM3U;
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            g_Playlist.Export(saveFileDialog.FileName, Settings.Default.RemoveCountryTag, formExportSelectGroups.GroupsForExport.ToArray());
                        }
                    }
                }
            }
        }
    }
}
