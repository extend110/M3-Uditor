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
    public partial class FormLoading : Form
    {
        public enum Mode
        {
            Import,
            Open
        }

        public Playlist Playlist;

        private Mode _mode;
        private string _path;
        private Thread _workingThread;

        public FormLoading(string path, Mode mode)
        {
            InitializeComponent();

            _path = path;
            _mode = mode;
            _workingThread = new Thread(LoadFile);
        }

        private void LoadFile()
        {
            if (_mode == Mode.Import)
            {
                M3U8Parser.LoadingProgressChanged += M3U8Parser_ProgressChanged;
                Playlist = M3U8Parser.LoadFromFile(_path);
            }
            if (_mode == Mode.Open)
            {
                Playlist = new Playlist();
                Playlist.ProgressChanged += Playlist_ProgressChanged;
                Playlist.Load(_path);
            }

            if ( Playlist != null)
            {
                Playlist.HasChanges = false;
                DialogResult = DialogResult.OK;
            } else
            {
                MessageBox.Show(string.Format("Couldn't import file"), "M3-Uditor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Abort;
            }
        }

        //Open M3 File
        private void Playlist_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            mProgressBar1.Value = e.ProgressPercentage;
        }
        //Import M3U file
        private void M3U8Parser_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            mProgressBar1.Value = e.ProgressPercentage;
        }

        private void FormLoading_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_mode == Mode.Import)
            {
                M3U8Parser.AbortLoading = true;
                M3U8Parser.LoadingProgressChanged -= M3U8Parser_ProgressChanged;
            }

            if (_mode == Mode.Open)
            {
                Playlist.AbortLoading = true;
            }

            if ( _workingThread.ThreadState == ThreadState.Running )
                _workingThread.Abort();
        }

        private void FormLoading_Load(object sender, EventArgs e)
        {
            _workingThread.Start();
        }
    }
}
