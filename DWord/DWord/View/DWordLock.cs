

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ServiceStack;
using ServiceStack.WebHost.Endpoints;
using ServiceStack.ServiceInterface;
using DWord.Properties;
using System.IO;
using System.Configuration;
using DWord.Services;
using DWord.Model; 

namespace DWord
{
    public partial class DWordLock : Form
    {
        Dictionary<int, String> LockTypes = new Dictionary<int, string>();
        Dictionary<int, String> SoftwareList = new Dictionary<int, string>();
        Dictionary<int, String> ListPort = new Dictionary<int, string>();
        public static int handle = -1;
        public static string server = "";
        
        public DWordLock()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            cboComPort.SelectedIndex = 0;
            Software.SelectedIndex = 0;

            if (Settings.Default.InitSuccess)
            {
                txtServer.Text = Settings.Default.LockFolder;
                Software.SelectedIndex = int.Parse(Settings.Default.Software);
                cboComPort.SelectedIndex = int.Parse(Settings.Default.COMPort); 
                SelectInstallationFolder(sender, e);
            }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            ResultReadCard result = new ResultReadCard(); 
            result = LockService.StartSession(Software.SelectedIndex + 1, txtServer.Text);

            if (result.status)
            {
                btnInit.Visible = false;
                btnEndSession.Visible = true;
                btnDelete.Visible = true;
                Settings.Default.InitSuccess = true;
                Settings.Default.Database = txtServer.Text;
                Settings.Default.COMPort = cboComPort.SelectedIndex.ToString();

                this.lblStatus.Text = "Kết nối thành công.";
                lblStatus.ForeColor = Color.Blue; 
                LabelStatus.Text = "Cài đặt khóa thành công";
                lblStatus.Visible = false;
                LabelStatus.ForeColor = Color.Blue;
                Settings.Default.Save();
            }
            else
            {
                btnInit.Visible = true;
                btnEndSession.Visible = !btnInit.Visible;
                LabelStatus.Text = "Chưa tích hợp khóa thành công ("+ result.mess + ")";
                LabelStatus.ForeColor = Color.Red;
                MessageBox.Show(result.mess);
            }
        }

        private void btnEndSession_Click(object sender, EventArgs e)
        {
            ResultReadCard result = new ResultReadCard();
            result = LockService.EndSession();
             
            btnInit.Visible = true;
            btnEndSession.Visible = false;
            if(result.status == false)
            {
                MessageBox.Show("End Session Result:" + ((result.mess == null) ? "": result.mess) );
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnEndSession_Click(sender, e);
             
            Settings.Default.Software = Software.SelectedIndex.ToString();
            Settings.Default.COMPort = cboComPort.SelectedIndex.ToString();
            Settings.Default.Save(); 
        }

        private void button_SelectFolder(object sender, EventArgs e)
        {
            var folder = folderBrowserDialog1.ShowDialog();
            if (folder == DialogResult.OK)
            {
                Settings.Default.SystemCode = "";
                Settings.Default.LockFolder = folderBrowserDialog1.SelectedPath;
                Settings.Default.Save();
                SelectInstallationFolder( sender,  e);
            }
        }

        void SelectInstallationFolder(object sender, EventArgs e)
        {
            txtServer.Text = Settings.Default.LockFolder;

            if (!txtServer.Text.EndsWith("\\"))
                txtServer.Text += "\\";
             
            if (!LockService.CheckConnectAccessFile(txtServer.Text))
            {
                //Not correct folder
                MessageBox.Show("Thư mục khóa chưa đúng. Mời bạn chọn");
                this.lblStatus.Text = "Đường dẫn thư mục khóa chưa chính xác.";
                lblStatus.ForeColor = Color.Red;
                return;
            }
            else
            {
                this.lblStatus.Text = "Kết nối dữ liệu thành công";
                lblStatus.ForeColor = Color.Blue;
                Settings.Default.InitSuccess = true;
                Settings.Default.LockFolder = txtServer.Text;
                Settings.Default.Save();
            }

            btnInit_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = new ResultReadCard();
            int port = int.Parse(Settings.Default.COMPort);

            result = LockService.DeleteCard(port,new Card());
            if (result.status)
            {
                MessageBox.Show("Xóa thẻ thành công");
            } else
            {
                MessageBox.Show("Xóa thẻ không thành công "+ result.mess);
            }
        }

        private void cboComPort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    

}
