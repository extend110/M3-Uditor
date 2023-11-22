using M3Controls;
using M3U8;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tests
{
    public partial class Form1 : Form
    {
        Playlist playlist;
        BindingSource bindingSource;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            playlist = new Playlist();

            extendedListBox1.DataSource = playlist.Groups;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playlist.AddGroup("Test" + playlist.CountGroups + 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Group group = extendedListBox1.SelectedItem as Group;
            group.AddStream(new Stream());
        }

        private void extendedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Group group = playlist.Groups[extendedListBox1.SelectedIndex];
            extendedListBox2.DataSource = group.Streams;
        }
    }
}
