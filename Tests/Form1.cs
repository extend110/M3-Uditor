using M3Controls;
using M3U8;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Web.UI.HtmlControls;

namespace Tests
{
    public partial class Form1 : Form
    {
        Playlist playlist;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            playlist = new Playlist();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playlist.AddGroup("Test" + playlist.CountGroups + 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void extendedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            mStatusBar1.GetItem("Filename").Text = DateTime.Now.ToString();
        }

        private void mSideBar1_ItemClicked(object sender, MSideBarItem e)
        {
            Console.WriteLine(e.Text);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brushBackground = new LinearGradientBrush(this.ClientRectangle, Color.RoyalBlue, Color.White, 90f))
            {
                e.Graphics.FillRectangle(brushBackground, this.ClientRectangle);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            multiInfoPanel1.ProgressValue += 1;
            if (multiInfoPanel1.ProgressValue > 100) multiInfoPanel1.ProgressValue = 0;
        }

        private void multiInfoPanel1_ProgressCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Progress Completed!");
            timer1.Stop();
            multiInfoPanel1.TextBottom = "Progress completed!";
        }

        private void multiInfoPanel1_Click(object sender, EventArgs e)
        {
            multiInfoPanel1.TextBottom = "";
            multiInfoPanel1.ProgressValue = 0;
            timer1.Start();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            var request = (HttpWebRequest)WebRequest.Create("https://siptv.app/codes/get_list.php");

            var postData = "source=" + Uri.EscapeDataString(mTextBox1.Text);
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko)";
            request.Referer = "https://siptv.app/codes/";

            if (request.CookieContainer == null)
            {
                request.CookieContainer = new CookieContainer();
            }

            request.CookieContainer.Add(new Uri("https://siptv.app/codes/"), new Cookie("origin", "valid"));

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            mTextBox2.Text = responseString;
            return;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (mTextBox3.Text.ToLower().ContainsPattern(mTextBox4.Text.ToLower(), 5))
            {
                MessageBox.Show("Found");
            }
        }
    }
}
