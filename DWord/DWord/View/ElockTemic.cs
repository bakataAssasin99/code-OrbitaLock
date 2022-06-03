using DWord.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text; 
using System.Windows.Forms;

namespace DWord.View
{
    public partial class ElockTemic : Form
    {
        public ElockTemic()
        {
            InitializeComponent();
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://doc.ezcloud.vn:8090/pages/viewpage.action?pageId=31037008");
        }
    }
}
