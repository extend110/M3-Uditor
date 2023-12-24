using M3_Uditor.Properties;
using M3U8;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M3_Uditor.Forms
{
    public partial class FormUrlCheck : Form
    {
        public int OnlineCount = 0;

        private Thread _thread;
        private Stream[] _streams;

        int currentIndex = 0;
        int maxIndex = 0;

        public FormUrlCheck(Stream stream)
        {
            InitializeComponent();
            _streams = new Stream[1];
            _streams[0] = stream;

            maxIndex = _streams.Length;
            multiInfoPanel1.Maximum = maxIndex;
        }

        public FormUrlCheck(Stream[] streams)
        {
            InitializeComponent();
            _streams = streams;

            maxIndex = _streams.Length;
            multiInfoPanel1.Maximum = maxIndex;
        }

        public FormUrlCheck(ref Group groupToCheck)
        {
            InitializeComponent();
            _streams = groupToCheck.Streams.ToArray();

            maxIndex = _streams.Length;
            multiInfoPanel1.Maximum = maxIndex;
            
        }

        private void FormUrlCheck_Shown(object sender, EventArgs e)
        {
            if (_streams.Length == 0) return;

            _thread = new Thread(Thread_DoWork); 
            _thread.Start();
        }

        private void ProcessStream(Stream stream)
        {
            if (this.IsDisposed) return;
            if (!stream.Url.IsValidURL()) return;
            
            currentIndex++;

            try
            {
                Invoke(new Action(() => ChangeInfoText(stream)));
                HttpWebRequest webRequest = HttpWebRequest.CreateHttp(stream.Url);

                webRequest.Timeout = 1000 * Settings.Default.StreamRequestTimeout;
                webRequest.Method = "GET";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)";
                //webRequest.AllowWriteStreamBuffering = false;
                webRequest.Credentials = new NetworkCredential(stream.Parent.Credentials.Username, stream.Parent.Credentials.Password, stream.Url);
                webRequest.ServicePoint.Expect100Continue = false;

                using (WebResponse webResponse = webRequest.GetResponse())
                {
                    if (webResponse.ContentType == M3U8.Helper.MpegUrl ||
                        webResponse.ContentType == M3U8.Helper.Mpeg2Url ||
                        webResponse.ContentType == M3U8.Helper.AppleMpeg ||
                        webResponse.ContentType == M3U8.Helper.Video ||
                        webResponse.ContentType == M3U8.Helper.OctetStream && webResponse.ContentLength > 0)
                    {
                        stream.Status = Stream.OnlineStatus.Online;
                        stream.ColorDescription = Color.Green;

                        OnlineCount++;
                    }
                    else
                    {
                        stream.Status = Stream.OnlineStatus.Offline;
                        stream.ColorDescription = Color.Red;
                    }
                    webResponse.GetResponseStream().Dispose();
                }
            }
            catch (ObjectDisposedException odex) { }
            catch (WebException ex)
            {
                string status = (ex.Response as HttpWebResponse)?.StatusCode.ToString() ?? ex.Status.ToString();
                stream.Status = Stream.OnlineStatus.Offline;
                stream.ColorDescription = Color.Red;
            }
            finally
            {
                stream.LastChecked = DateTime.Now.ToShortDateString();
            }
        }

        private void Thread_DoWork()
        {
            if (Settings.Default.CheckLinksAsync)
            {
                Parallel.ForEach(_streams, new ParallelOptions() { MaxDegreeOfParallelism = 10 }, 
                                 stream => {
                                     ProcessStream(stream); 
                                 });
            } 
            else
            {
                foreach (Stream stream in _streams)
                {
                    ProcessStream(stream);
                }
            }

            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
            Invoke(new Action(() => Close()));
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ChangeInfoText(Stream stream)
        {
            multiInfoPanel1.TextRight = string.Format("{0}/{1}", currentIndex, maxIndex);
            multiInfoPanel1.TextLeft = stream.Name; //Helper.TruncateString(stream.Name, multiInfoPanel1.Font, multiInfoPanel1.BoundsTextRight.Left - multiInfoPanel1.BoundsTextLeft.X);
            multiInfoPanel1.ProgressValue = currentIndex;
        }
        private void FormUrlCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( _thread.IsAlive )
                _thread.Abort();

            //GC.Collect();
        }
    }
}
