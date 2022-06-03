using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices; // 用DllImport 需用此命名空间   
using System.Reflection; // 使用Assembly 类需用此命名空间   
using System.Reflection.Emit; // 使用ILGenerator 需用此命名空间  

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string lpFileName);
        [DllImport("hunerf.dll", SetLastError = true)]
        public static unsafe extern int ReadMessage(int Com, int nBlock, int Encrypt, int* DBCardNo, int* DBCardtype, int* DBPassLevel, string CardPass, string DBSystemcode, string DBAddress, string SDateTime);


        [DllImport("hunerf.dll", SetLastError = true)]
        public static extern int KeyCard(int Com, int CardNo, int nBlock, int Encrypt, string CardPass, string SystemCode, string HotelCode, string Pass, string Address, string SDIn,
           string STIn, string SDOut, string STOut, int LEVEL_Pass, int PassMode, int AddressMode, int AddressQty, int TimeMode, int V8, int V16, int V24, int AlwaysOpen, int OpenBolt, int TerminateOld, int ValidTimes);
        private IntPtr hModule = IntPtr.Zero;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hModule = LoadLibrary("hunerf.dll");
            if (hModule == IntPtr.Zero)
                MessageBox.Show("Repatriate a dynamic library hunerf.dll failed!", "Information");
            DTPSDOut.Value = DateTime.Now.AddDays(1);
            DTPSTOut.Value = DateTime.Now.AddHours(1);
        }



        private string GoDateTime(DateTime DTVar)
        {
            long DW1 = 0;
            string DW2 = "";
            long Year = DTVar.Year;
            long Month = DTVar.Month;
            long Day = DTVar.Day;
            long Hour = DTVar.Hour;
            long Min = DTVar.Minute;
            long Sec = DTVar.Second;
            DW1 = (Min >> 4) + (Hour << 4) + (Day << 9) + (Month << 14) + ((((Year-8) % 1000) % 63) << 18);
            DW2 = Convert.ToString(DW1, 16);
            return DW2.ToUpper();
        }

        private void button1_Click(object sender, EventArgs e)//制
        {
            if (textBoxSystemCode.Text == "" || textBoxHotelCode.Text == "")
            {
                MessageBox.Show("Please input information!");
                return;
            }

            int Com = int.Parse(textBoxCom.Text);
            int CardNo = int.Parse(textBoxGuestCard.Text);     //卡号                        
            int nBlock = int.Parse(textBoxnBlock.Text);                         //卡片块号，一般4
            int Encrypt = int.Parse(textBoxEncrypt.Text);        // 一般1
            string CardPass = textBoxCardPass.Text;              //卡片密钥，一般'82A094FFFFFF'
            string SystemCode = textBoxSystemCode.Text;         //SystemCode来自门锁数据库msc表，数据库默认路径D:\HUNELOCK\DATA\HData,需厂家打开数据库
            string HotelCode = textBoxHotelCode.Text;          //HotelCode来自门锁数据库msc表，数据库默认路径D:\HUNELOCK\DATA\HData,需厂家打开数据库
            string RoomPass = textBoxPass.Text;                  //房间密码，由公式算得
            string Address = textBoxAddress.Text;                //房间地址,11位, "01"固定值，+Building(2位)+Floor(2位)+Room(2位)+ Door (2位).参见房间管理的表
            string DTPSDInVar = string.Format("{0:yy-MM-dd}", DTPSDIn.Value).ToString();                 //入住日期，日期格式"yy-mm-dd",不能用 "yyyy-mm-dd"
            string DTPSTInVar = DTPSTIn.Text;                  //入住时间，时间格式"hh:nn:ss"
            string DTPSDOutVar = string.Format("{0:yy-MM-dd}", DTPSDOut.Value).ToString();              //退房日期，日期格式"yy-mm-dd",不能用 "yyyy-mm-dd"                  /
            string DTPSTOutVar = DTPSTOut.Text;                //退房时间，时间格式"hh:nn:ss"

            int LevelPass = int.Parse(textBoxLevelPass.Text);                       //默认3
            int PassMode = int.Parse(textBoxPassMode.Text);                       //默认1
            int AddressMode = int.Parse(textBoxAddressMode.Text);                   //默认0
            int AddressQty = int.Parse(textBoxAddressQty.Text);                       //默认1
            int TimeMode = int.Parse(textBoxTimeMode.Text);                         //默认0
            int V8 = int.Parse(textBoxV8.Text);                                //默认255
            int V16 = int.Parse(textBoxV16.Text);                              //默认255
            int V24 = int.Parse(textBoxV24.Text);                              //默认255
            int AlwaysOpen = int.Parse(textBoxAlwaysOpen.Text);                         //默认0
            int OpenBolt = int.Parse(textBoxOpenBolt.Text);                         //默认0
            int TerminateOld = 0;
            if (cBTerminateOld.Checked)
            {
                TerminateOld = 1;
                RoomPass = GoDateTime(DateTime.Now);
                textBoxPass.Text = RoomPass;
            }               
            int ValidTimes = int.Parse(textBoxValidTimes.Text);                       //默认255         
            try
            {
               int Ret = KeyCard(Com,CardNo,nBlock,Encrypt,CardPass,SystemCode,HotelCode,RoomPass,Address,DTPSDInVar,DTPSTInVar,DTPSDOutVar,DTPSTOutVar
                    ,LevelPass,PassMode,AddressMode,AddressQty,TimeMode,V8,V16,V24,AlwaysOpen,OpenBolt,TerminateOld,ValidTimes);
                if (Ret == 0)
                {
                    MessageBox.Show("Write data successfully!", "Information");
                }
                else
                {
                    MessageBox.Show("Write data failed,Error：" + Ret.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private unsafe void button2_Click(object sender, EventArgs e)//读
        {
            int Com = int.Parse(textBoxCom.Text);
            int nBlock = int.Parse(textBoxnBlock.Text);
            int Encrypt = int.Parse(textBoxEncrypt.Text);            
            int CardNumber = 0;
            int CardType = 0;
            int PassLevel = 0;
            string CardPass = textBoxCardPass.Text;    
            string SystemCode = textBoxSystemCode.Text;
            string Address = "";
            string Datetime = "";
          
            try
            {
                int Ret = ReadMessage(Com, nBlock, Encrypt, &CardNumber, &CardType, &PassLevel, CardPass, SystemCode, Address, Datetime);
                if (Ret == 0)
                {
                    MessageBox.Show("CardNumber:" + CardNumber.ToString() + " Add:" + Datetime + " Room:" + PassLevel.ToString(), "Read Card Successfully");
                }
                else
                {
                    MessageBox.Show("Read card failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

   
       

   
    }
}