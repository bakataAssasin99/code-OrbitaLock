using DWord.Constant;
using DWord.Model;
using DWord.Properties;
using DWord.Services;
using DWord.Services.ProUsb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DWord.View
{
    public partial class ProUsb : Form
    {
        public ProUsb()
        {
            InitializeComponent();

            if (Settings.Default.InitSuccess)
            {
                SelectInstallationFolder();
            }
        }

        private void btn_prousb_lock_folder_Click(object sender, EventArgs e)
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

        void SelectInstallationFolder()
        {
            ProUsbServer.Text = Settings.Default.LockFolder;

            if (!ProUsbServer.Text.EndsWith("\\"))
                ProUsbServer.Text += "\\";

            if (!LockService.CheckConnectAccessFile(ProUsbServer.Text))
            {
                //Not correct folder
                MessageBox.Show("Thư mục khóa chưa đúng. Mời bạn chọn");
                this.lblStatus.Text = "Vui lòng chọn thư mục khóa chứa file "+ ConstFileAccess.PROUSB_FILE_NAME;
                lblStatus.ForeColor = Color.Red;
                return;
            }
            else
            {
                this.lblStatus.Text = "Kết nối dữ liệu thành công. Cần cập nhật hotel code ";
                lblStatus.ForeColor = Color.Orange;  
            }

            if (Settings.Default.SystemCode.Length > 0)
            {
                ResultReadCard result = LockService.StartSession(0,"");
                 
                if (result.status)
                {
                    if (String.IsNullOrEmpty(Settings.Default.HotelCode))
                    {
                        MessageBox.Show("Mời bạn đặt 1 thẻ hợp lệ vào đầu đọc và nhấn OK");

                        int HotelId = ProUsbService.InnitHotelId();
                        if (HotelId == 0)
                        {
                            Settings.Default.LockFolder = ProUsbServer.Text;
                            Settings.Default.Save();
                            MessageBox.Show("Thẻ không hợp lệ, đề nghị đưa thẻ đã tạo trên phần mềm cũ vào đầu đọc");
                        }
                        else
                        {
                            Settings.Default.HotelCode = HotelId.ToString(); 
                            Settings.Default.InitSuccess = true;
                            Settings.Default.Save();
                            hotelCode.Text = HotelId.ToString();
                            this.lblStatus.Text = "Đã kết nối, Bạn có thể tiến hành tạo khóa khách hàng!";
                            lblStatus.ForeColor = Color.Blue;
                        }
                    }
                    else
                    {

                        Helper.WriteLog("Settings.Default.HotelCode:" + Settings.Default.HotelCode);
                        hotelCode.Text = Settings.Default.HotelCode;
                        Settings.Default.InitSuccess = true;
                        Settings.Default.Save();
                        this.lblStatus.Text = "Đã kết nối, Bạn có thể tiến hành tạo khóa khách hàng!";
                        lblStatus.ForeColor = Color.Blue;
                    }
                }
                else
                { 
                    MessageBox.Show("Error SelectInstallationFolder" + result.mess);
                }
            }
        }

        private void btn_prousb_update_hotel_code_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mời bạn đặt 1 thẻ hợp lệ vào đầu đọc và nhấn OK");

            int HotelId = ProUsbService.InnitHotelId();
            if (HotelId == 0)
            {
                MessageBox.Show("Thẻ không hợp lệ, đề nghị đưa thẻ đã tạo trên phần mềm cũ vào đầu đọc");
            }
            else
            {
                Settings.Default.HotelCode = HotelId.ToString();
                Settings.Default.InitSuccess = true;
                Settings.Default.Save();

                hotelCode.Text = HotelId.ToString();
                btn_prousb_delete_card.Visible = true;

                this.lblStatus.Text = "Đã kết nối, Bạn có thể tiến hành tạo khóa khách hàng!";
                lblStatus.ForeColor = Color.Blue;
            }
        }

        private void btn_prousb_read_card_Click(object sender, EventArgs e)
        {

        }

        private void btn_prousb_delete_card_Click(object sender, EventArgs e)
        {
            ResultReadCard result = new ResultReadCard();

            result = ProUsbService.DeleteCard();

            if (result.status)
            {
                MessageBox.Show("Thẻ không hợp lệ, đề nghị đưa thẻ đã tạo trên phần mềm cũ vào đầu đọc");
            }
        }
    }
}
