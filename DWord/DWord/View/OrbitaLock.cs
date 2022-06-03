using DWord.Properties;
using System;
using DWord.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DWord.View
{
    public partial class OrbitaLock : Form
    {
        public static bool isValid = false;
        bool newlySelected = false;

        public static bool reloadRoomList = false;
        public OrbitaLock()
        {
            InitializeComponent();

            if (Settings.Default.InitSuccess)
            {
                txtLocation.Text = Settings.Default.LockFolder;
                SelectInstallationFolder();
            }
        }

        private void OrbitaLock_Load(object sender, EventArgs e)
        {

            if (Settings.Default.InitSuccess)
            {
                txtLocation.Text = Settings.Default.LockFolder;
                SelectInstallationFolder();
            }
        }
        void SelectInstallationFolder()
        {
            txtLocation.Text = Settings.Default.LockFolder;

            if (!txtLocation.Text.EndsWith("\\"))
                txtLocation.Text += "\\";
            string queryString = "SELECT TOP 1 auth_code FROM syspar";
            MessageBox.Show(Settings.Default.LockFolder.ToString());

            if (!LockService.CheckConnectAccessFile(txtLocation.Text))
            {
                //Not correct folder
                MessageBox.Show("Thư mục khóa Orbita chưa đúng. Mời bạn chọn");
                button2.ForeColor = Color.Red;
                return;
            }
            else
            {
                
                MessageBox.Show(Settings.Default.ConnectionString);
                reloadRoomList = true;
            }
            

            button2.ForeColor = Color.Black;
            int result = orbita_Connect();
            if (result == 0)
            {
                //OK
                isValid = true;
            }
            else
            {
                MessageBox.Show("Không kết nối được với đầu đọc thẻ");
                button3.Visible = true;
                isValid = true;
            }


        }

        public int orbita_Connect()
        {
            int _return;
            try
            {
                _return =  Services.OrbitaLock.OrbitaSDK.dv_connect(1000);
            }
            catch (Exception e)
            {

                throw;
            }

            return _return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var folder = folderBrowserDialog1.ShowDialog();
            if (folder == DialogResult.OK)
            {
                Settings.Default.SystemCode = "";
                Settings.Default.LockFolder = folderBrowserDialog1.SelectedPath;
                Settings.Default.Save();
                SelectInstallationFolder();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int result = orbita_Connect();
            MessageBox.Show("Ket qua ket noi:" + result.ToString());
            //int result = CommunicationClass.dv_connect(1000);
            if (result == 0)
            {
                button3.Visible = false;
                isValid = true;
            }
            else
                MessageBox.Show("Không kết nối được với đầu đọc thẻ");
        }
    }
}
