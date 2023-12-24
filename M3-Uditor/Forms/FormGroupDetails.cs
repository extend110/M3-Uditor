using M3U8;
using System;
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
    public partial class FormGroupDetails : Form
    {
        Group group;
        public FormGroupDetails()
        {
            InitializeComponent();
        }
        public FormGroupDetails(Group group) : this()
        {
            this.group = group;
        }

        private void FormGroupDetails_Load(object sender, EventArgs e)
        {
            mTextBoxDetails.Text += "Group Name: " + group.Name + "\r\n";
            mTextBoxDetails.Text += "Stream Count: " + group.CountStreams.ToString() + "\r\n";
        }
    }
}
