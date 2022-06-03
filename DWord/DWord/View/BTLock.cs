using DWord.Constant;
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
    public partial class BTLock : Form
    {
        public BTLock()
        {
            InitializeComponent();

            if (Settings.Default.InitSuccess)
            {
                txtServer.Text = Settings.Default.LockFolder;
                SelectInstallationFolder();
            }
        }
        private void Form_Load(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var folder = folderBrowserDialog1.ShowDialog();
            if (folder == DialogResult.OK)
            { 
                Settings.Default.LockFolder = folderBrowserDialog1.SelectedPath;
                Settings.Default.Save();
                SelectInstallationFolder();
            }
        }

        void SelectInstallationFolder()
        {
            txtServer.Text = Settings.Default.LockFolder;

            if (!txtServer.Text.EndsWith("\\"))
                txtServer.Text += "\\";

            if (!LockService.CheckConnectAccessFile(txtServer.Text))
            {
                //Not correct folder
                MessageBox.Show("Thư mục khóa chưa đúng. Mời bạn chọn");
                this.lblStatus.Text = "Vui lòng chọn thư mục khóa chứa file " + ConstFileAccess.BT_FILE_NAME;
                lblStatus.ForeColor = Color.Red;
                return;
            }
            else
            { 
                this.lblStatus.Text = "Kết nối dữ liệu thành công";
                lblStatus.ForeColor = Color.Green;
                Settings.Default.InitSuccess = true;
                Settings.Default.LockFolder = txtServer.Text;
                Settings.Default.Save();
            }
             
        }
    }
}
