using M3U8;
using XmlTv;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;

namespace M3_Uditor.Forms
{

    public partial class FormEpgMapper : Form
    {
        public static event EventHandler<FinishedMappingEventArgs> FinishedMapping;

        private Playlist g_Playlist;
        private Group g_Group;

        private List<string> _MappedChannels;

        private Size _FormSizeCollapsed = new Size(533, 268);
        private Size _FormSizeNotCollapsed = new Size(533, 647);

        private bool CancelMapping = false;

        public FormEpgMapper()
        {
            InitializeComponent(); 
        }

        public FormEpgMapper(Playlist g_Playlist, Group group) : this()
        {
            this.g_Playlist = g_Playlist;
            this.g_Group = group;
        }

        private void FormEpgMapper_Load(object sender, EventArgs e)
        {
            _MappedChannels = new List<string>();
        }

        private async void MapChannels(int TaskRound = 1, string redo = "")
        {
            int CurrentTask = TaskRound;
            string MoreThanOneRound = redo;

            multiInfoPanel1.TextLeft = string.Empty;
            multiInfoPanel1.TextBottom = string.Empty;
            listBoxMappedChannels.DataSource = null;
            panelLabels.Visible = false;

            List<Channel> CurrentEpgChannels = EpgParser.Channels.ToList();

            multiInfoPanel1.TextRight = redo + "Task " + CurrentTask.ToString();

            await Task.Run(() =>
            {
                // pass 1
                multiInfoPanel1.TextLeft = "Mapping Channels...(Pass 1)";

                foreach (Stream stream in g_Group.Streams)
                {
                    foreach (XmlTv.Channel epgChannel in CurrentEpgChannels)
                    {
                        if (stream.Name == epgChannel.Name)
                        {
                            if (!g_Playlist.HasChanges) g_Playlist.HasChanges = true;

                            stream.TvgId = epgChannel.ID;
                            stream.TvgName = epgChannel.Name;
                            _MappedChannels.Add(string.Format("{0} ({1}) => {2}", stream.Name, stream.Group, epgChannel.ID));
                            break;
                        }
                    }
                }
                BeginInvoke(new MethodInvoker(() => mProgressBarStreams.Value = 50 ));

                // pass 2
                multiInfoPanel1.TextLeft = "Mapping Channels...(Pass 2)";
                var selectedStreams = g_Group.Streams.Where(s => s.TvgId?.Length == 0);
                foreach (Stream stream in selectedStreams)
                {
                    foreach (XmlTv.Channel epgChannel in CurrentEpgChannels)
                    {
                        if (epgChannel.Name.Contains(stream.Name))
                        {
                            stream.TvgName = epgChannel.Name;
                            stream.TvgId = epgChannel.ID;
                            _MappedChannels.Add(string.Format("{0} ({1}) => {2}", stream.Name, stream.Group, epgChannel.ID));
                            break;
                        }
                    }
                }
                BeginInvoke(new MethodInvoker(() => mProgressBarStreams.Value = 100));
            });

            if (CurrentEpgChannels.Count < EpgParser.Channels.Count)
            {
                if (!CancelMapping)
                    BeginInvoke(new MethodInvoker(() => MapChannels(CurrentTask + 1, "EpgData List changed, ")));
            }

            multiInfoPanel1.TextLeft = string.Empty;
            multiInfoPanel1.TextRight = string.Empty;
            multiInfoPanel1.TextBottom = string.Format("Done Mapping ({0} Channels).", _MappedChannels.Count);

            listBoxMappedChannels.DataSource = _MappedChannels;
            panelLabels.Visible = true;
        }

        private void FormEpgMapper_Shown(object sender, EventArgs e)
        {
             MapChannels();
        }

        private void labelShowChannels_Click(object sender, EventArgs e)
        {
            if (labelShowChannels.Tag.ToString() == "show")
            {
                this.Size = _FormSizeNotCollapsed;
                labelShowChannels.Text = "Hide Channels";
                labelShowChannels.Tag = "hide";

                return;
            }

            if (labelShowChannels.Tag.ToString() == "hide")
            {
                this.Size = _FormSizeCollapsed;
                labelShowChannels.Text = "Show Channels";
                labelShowChannels.Tag = "show";
            }
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormEpgMapper_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CancelMapping == false)
            {
                e.Cancel = true;
                CancelMapping = true;
            }
        }
    }
}
