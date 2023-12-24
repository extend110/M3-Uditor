using M3U8;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M3_Uditor.Forms
{
    public partial class FormRemoveStreams : Form
    {

        private Stream[] _streams;
        private Group _group;
        private Thread _thread;
        private int _step;

        public FormRemoveStreams(Group group)
        {
            InitializeComponent();

            _group = group;
            _streams = group.Streams.ToArray();
            _thread = new Thread(RemoveStreams);

            _step = _streams.Length / 100 + 1;
            progressBarRemoveStatus.Maximum = _streams.Length;
        }

        private void RemoveStreams()
        {
            foreach (Stream stream in _streams)
            {
                if (stream.Status == Stream.OnlineStatus.Offline)
                    _group.RemoveStream(stream);

                this.Invoke(new MethodInvoker(() =>
                {
                    progressBarRemoveStatus.Value++;
                }));
            }

            Invoke(new Action(() => { Close(); }));
        }

        private void FormRemoveStreams_Shown(object sender, EventArgs e)
        {
            _thread.Start();
        }
    }
}
