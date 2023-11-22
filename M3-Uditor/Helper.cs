using M3_Uditor.Properties;
using M3Controls;
using M3U8;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;

namespace M3_Uditor
{
    public class Helper
    {
        public const string FilterM3 = "M3-Uditor (*.m3)|*.m3|All Files (*.*)|*.*";
        public const string FilterM3U = "Playlist File (*.m3u, *.m3u8)|*.m3u;*.m3u8|Text File (*.txt)|*.txt|All Files (*.*)|*.*";
        public static List<int> SearchStreamResults = new List<int>();
        public static int SearchStreamSelectedIndex = 0;

        //DragDrop
        public static Size dragSize = SystemInformation.DragSize;
        public static Rectangle dragBoxFromMouseDown;

        public static DialogResult MessageBoxPlaylistChanges(Playlist playlist)
        {
            return MessageBox.Show("Save changes?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
        public static void UpdateListBox(ListBox listBox)
        {
            object datasource = listBox.DataSource;
            listBox.DataSource = null;
            listBox.DataSource = datasource;
        }
        public static void ResetControlsOnForm(Form form)
        {
            ResetControl(form.Controls);
        }
        public static void CreateDragBox(Point atLocation)
        {
            dragBoxFromMouseDown = new Rectangle(new Point(atLocation.X - dragSize.Width / 2, atLocation.Y - dragSize.Height / 2), dragSize);
        }    
        public static void StartVlcPlayer(string url)
        {
            Process process = new Process();
            ProcessStartInfo info = new ProcessStartInfo();

            info.FileName = Settings.Default.VlcPath;
            info.Arguments = url;

            process.StartInfo = info;
            process.Start();
        }
        public static Image DownloadImageFromUrl(string url)
        {
            try
            {
                WebClient webClient = new WebClient();

                //byte[] data = webClient.DownloadDataTaskAsync(url).Result;
                byte[] data = webClient.DownloadData(new Uri(url));

                System.IO.MemoryStream ms = new System.IO.MemoryStream(data);

                Bitmap img = new Bitmap(Image.FromStream(ms), 148, 71);
                return img;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static void AddRecentFile(string filename)
        {
            if ( !Settings.Default.RecentFiles.Contains(filename) )
            {
                Settings.Default.RecentFiles.Insert(0, filename);
                Settings.Default.Save();
            }
        }

        private static void ResetControl(Control.ControlCollection control)
        {
            foreach (Control c in control)
            {
                if (c.HasChildren)
                    ResetControl(c.Controls);

                if (c.GetType() == typeof(TextBox))
                {
                    TextBox textBox = (TextBox)c;
                    if (!c.Name.Contains("textBoxSearch")) textBox.Clear();
                }
                if (c.GetType() == typeof(ExtendedListBox))
                {
                    ExtendedListBox extendedListBox = (ExtendedListBox)c;
                    extendedListBox.DataSource = null;
                }
            }
        }


    }
}
