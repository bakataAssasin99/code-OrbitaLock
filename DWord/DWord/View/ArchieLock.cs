using DWord.Model;
using DWord.Properties;
using DWord.Services;
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
    public partial class ArchieLock : Form
    {
        public ArchieLock()
        {
            InitializeComponent();
        }
        private void Form_Load(object sender, EventArgs e)
        {
            Software.SelectedIndex = 0;
            lblStatus.Text = "ddddddddd" + Software.SelectedIndex;
            if (Settings.Default.InitSuccess)
            {
                txtServer.Text = Settings.Default.LockFolder;
                Software.SelectedIndex = int.Parse(Settings.Default.Software);
                cboComPort.Value = int.Parse(Settings.Default.COMPort);
                //SelectInstallationFolder(sender, e);
            }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            ResultReadCard result = new ResultReadCard();
            result = LockService.StartSession(int.Parse(Software.SelectedItem.ToString()), "" , (int) cboComPort.Value );

            if (result.status)
            {
                lblStatus.Text = result.mess;
                lblStatus.ForeColor = Color.Blue;
            }
            else
            {
                lblStatus.Text = result.mess + Software.SelectedIndex; ;
                lblStatus.ForeColor = Color.Red;
            }
        }
    }
}
