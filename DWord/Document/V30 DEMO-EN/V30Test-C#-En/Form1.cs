using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices; //    
using System.Reflection; //     
using System.Reflection.Emit; //    

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
      
        [DllImport("HNAccessG.dll", SetLastError = true)]
        private static unsafe extern int ReadMessage(int Com, int nBlock, int Encrypt, int* DBCardNo, int* DBCardtype, int* DBPassLevel, StringBuilder CardPass, StringBuilder DBSystemcode, StringBuilder DBAddress, StringBuilder SDateTime);


        [DllImport("HNAccessG.dll", SetLastError = true)]
        private static extern int KeyCard(int Com, int CardNo, int nBlock, int Encrypt, StringBuilder CardPass, StringBuilder SystemCode, StringBuilder HotelCode, StringBuilder Pass, StringBuilder Address, StringBuilder SDIn,
           StringBuilder STIn, StringBuilder SDOut, StringBuilder STOut, int LEVEL_Pass, int PassMode, int AddressMode, int AddressQty, int TimeMode, int V8, int V16, int V24, int AlwaysOpen, int OpenBolt, int TerminateOld, int ValidTimes);
        private IntPtr hModule = IntPtr.Zero;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            DTPSDOut.Value = DateTime.Now.AddDays(1);
            DTPSTOut.Value = DateTime.Now.AddHours(1);
        }



        private String CompactCipherTime(DateTime DTVar)
        {
            long DW1 = 0;
            String DW2 = "";
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

        private void button1_Click(object sender, EventArgs e) // Write Card
        {
            if (textBoxSystemCode.Text == "" || textBoxHotelCode.Text == "")
            {
                MessageBox.Show("Please input information!");
                return;
            }

            int Com = int.Parse(textBoxCom.Text);
            int CardNo = int.Parse(textBoxGuestCard.Text);     //Card Number                       
            int nBlock = int.Parse(textBoxnBlock.Text);          //Block Default 8
            int Encrypt = int.Parse(textBoxEncrypt.Text);        // Default 88
            StringBuilder CardPass = new StringBuilder(textBoxCardPass.Text);              //Default '33AA9C2693F8'
            StringBuilder SystemCode = new StringBuilder(textBoxSystemCode.Text);          //Have to send the database "HData" to the supplier to get the SystemCode and HotelCode. "HData" directory "D:\HUNELOCK\DATA\"
            StringBuilder HotelCode = new StringBuilder(textBoxHotelCode.Text);            //Have to send the database "HData" to the supplier to get the SystemCode and HotelCode. "HData" directory "D:\HUNELOCK\DATA\"
            StringBuilder RoomPass = new StringBuilder(textBoxPass.Text);                  //Room password，get it from the funciton CompactCipherTime
            StringBuilder Address = new StringBuilder(textBoxAddress.Text);                //Room Address,11 Decimal Code,"01"(fixed value)+Building(2 number)+Floor(2 number)+Room(3number)+ Door (2 number).
            StringBuilder DTPSDInVar = new StringBuilder(string.Format("{0:yy-MM-dd}", DTPSDIn.Value).ToString());                 //Checkin Date, format "yy-mm-dd", cannot use "yyyy-mm-dd".
            StringBuilder DTPSTInVar = new StringBuilder(DTPSTIn.Text);                    // Checkin Time, format "hh:nn:ss".:ss"
            StringBuilder DTPSDOutVar = new StringBuilder(string.Format("{0:yy-MM-dd}", DTPSDOut.Value).ToString());              //Checkout Date,  format "yy-mm-dd", cannot use "yyyy-mm-dd".                  /
            string DTPSTOutVar = DTPSTOut.Text;                                            // Checkout Time, format "hh:nn:ss".

            int LevelPass = int.Parse(textBoxLevelPass.Text);                              //Default 3
            int PassMode = int.Parse(textBoxPassMode.Text);                                //Default 1, if Terminate old card then PassMode= 2
            int AddressMode = int.Parse(textBoxAddressMode.Text);                          //Default 0
            int AddressQty = int.Parse(textBoxAddressQty.Text);                            //Default1
            int TimeMode = int.Parse(textBoxTimeMode.Text);                                //Default 0
            int V8 = int.Parse(textBoxV8.Text);                                            //Default 255
            int V16 = int.Parse(textBoxV16.Text);                                          //Default 255
            int V24 = int.Parse(textBoxV24.Text);                                          //Default 255
            int AlwaysOpen = int.Parse(textBoxAlwaysOpen.Text);                            //Default 0
            int OpenBolt = int.Parse(textBoxOpenBolt.Text);                                //Default 0
            int TerminateOld = 0;
            if (cBTerminateOld.Checked)
            {
                TerminateOld = 1;
                RoomPass = new StringBuilder(CompactCipherTime(DateTime.Now));
                textBoxPass.Text = RoomPass.ToString();
                PassMode = 2;
            }               
            int ValidTimes = int.Parse(textBoxValidTimes.Text);                           //Default 255         
            try
            {
               int Ret = KeyCard(Com,CardNo,nBlock,Encrypt,CardPass,SystemCode,HotelCode,RoomPass,Address,DTPSDInVar,DTPSTInVar,DTPSDOutVar, new StringBuilder(DTPSTOutVar)
                    , LevelPass,PassMode,AddressMode,AddressQty,TimeMode,V8,V16,V24,AlwaysOpen,OpenBolt,TerminateOld,ValidTimes);
                if (Ret == 0)
                {
                    MessageBox.Show("Write data successfully!", "Information");
                }
                else
                {
                    MessageBox.Show("Write data failed,Error: " + Ret.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private unsafe void button2_Click(object sender, EventArgs e)//Read Card
        {
            int Com = int.Parse(textBoxCom.Text);
            int nBlock = int.Parse(textBoxnBlock.Text);
            int Encrypt = int.Parse(textBoxEncrypt.Text);            
            int CardNumber = 0;
            int CardType = 0;
            int PassLevel = 0;
            StringBuilder CardPass = new StringBuilder(textBoxCardPass.Text);    
            StringBuilder SystemCode = new StringBuilder(textBoxSystemCode.Text);
            StringBuilder Address = new StringBuilder("");
            StringBuilder Datetime = new StringBuilder("");
          
            try
            {
                int Ret = ReadMessage(Com, nBlock, Encrypt, &CardNumber, &CardType, &PassLevel, CardPass, SystemCode, Address, Datetime);
                if (Ret == 0)
                {
                    MessageBox.Show("CardNumber:  " + CardNumber.ToString() + " SystemCode "+ SystemCode.ToString() + " CardType "+ CardType.ToString() + " PassLevel "+ PassLevel.ToString() + " CardPass "+ CardPass.ToString()+ " Address "+ Address.ToString(), "Read Card Successfully");
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