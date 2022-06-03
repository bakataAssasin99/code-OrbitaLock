using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BTLock57
{
    public partial class Form1 : Form
    {
        [DllImport("btLock57L.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Write_Guest_Card(int Port, int ReaderType, int SectorNo, string HotelPwd,
            int CardNo, int GuestSN, int GuestIdx, StringBuilder DoorID, StringBuilder SuitDoor,
            StringBuilder PubDoor, StringBuilder BeginTime, StringBuilder EndTime);

        [DllImport("btLock57L.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Read_Guest_Card(int Port, int ReaderType, int SectorNo, string HotelPwd,
            ref int CardNo, ref int GuestSN, ref int GuestIdx, StringBuilder DoorID, StringBuilder SuitDoor,
            StringBuilder PubDoor, StringBuilder BeginTime, StringBuilder EndTime);


        [DllImport("btLock57L.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Read_Guest_Lift(int Port, int ReaderType, int SectorNo, string HotelPwd,
            int BeginAddr, int EndAddr, ref int CardNo, StringBuilder BeginTime, StringBuilder EndTime,
            StringBuilder LiftData);
        
        [DllImport("btLock57L.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Write_Guest_Lift(int Port, int ReaderType, int SectorNo, string HotelPwd,
            int CardNo, int BeginAddr, int EndAddr,int MaxAddr, StringBuilder BeginTime, StringBuilder EndTime, 
            StringBuilder LiftData);


        [DllImport("btLock57L.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Write_Guest_PowerSwitch(int Port, int ReaderType, int SectorNo, string PowerSwitchPwd,
            int CardNo, int GuestSex, StringBuilder DoorID, StringBuilder GuestName, StringBuilder BeginTime,
            StringBuilder EndTime, int PowerSwitchType);
        
        [DllImport("btLock57L.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Read_Guest_PowerSwitch(int Port, int ReaderType, int SectorNo, string PowerSwitchPwd,
            ref int CardNo, ref int GuestSex, StringBuilder DoorID, StringBuilder GuestName,
            StringBuilder BeginTime, StringBuilder EndTime, int PowerSwitchType);


        [DllImport("btLock57L.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Reader_Alarm(int Port, int ReaderType, int AlarmCount);
        [DllImport("btLock57L.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int SerialNo_FromNow();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            int rt = 255;

            String tmpHotelPwd = tebSystemPassword.Text;

            int tmpBeginAddr = int.Parse(textBox13.Text);

            int tmpEndAddr = int.Parse(textBox14.Text);

            int tmpCardNo = 0;

            int tmpGuestIdx = 0;

            int tmpGuestSN = 0;

            int tmpGuestSex = 0;

            int tmpSectorNo = int.Parse(tebSectorNo.Text);

            int tmpAlarmCount = int.Parse(tebRepeatTime.Text);

            StringBuilder tmpDoorID = new StringBuilder();

            StringBuilder tmpSuitDoor = new StringBuilder();

            StringBuilder tmpPubDoor = new StringBuilder();

            StringBuilder tmpBndTime = new StringBuilder();

            StringBuilder tmpEndTime = new StringBuilder();

            StringBuilder tmpLiftData = new StringBuilder();

            StringBuilder tmpGuestName = new StringBuilder();

            rt = Read_Guest_Card(comboBox2.SelectedIndex + 1, comboBox1.SelectedIndex + 1, tmpSectorNo, tmpHotelPwd,
                 ref tmpCardNo, ref tmpGuestSN, ref tmpGuestIdx, tmpDoorID, tmpSuitDoor, tmpPubDoor, tmpBndTime, tmpEndTime);
            MessageBox.Show("Read_Guest_Card:" + rt.ToString());
            if (rt == 0)
            {
                textBox1.Text = tmpCardNo.ToString();
                textBox5.Text = tmpDoorID.ToString();
                textBox2.Text = tmpSuitDoor.ToString();
                textBox6.Text = tmpPubDoor.ToString();
                textBox7.Text = tmpGuestSN.ToString();
                textBox8.Text = tmpEndTime.ToString();
                textBox3.Text = tmpGuestIdx.ToString();
                textBox4.Text = tmpBndTime.ToString();

                rt = Read_Guest_Lift(comboBox2.SelectedIndex + 1, comboBox1.SelectedIndex + 1, tmpSectorNo, tmpHotelPwd,
                 tmpBeginAddr, tmpEndAddr, ref tmpCardNo, tmpBndTime, tmpEndTime, tmpLiftData);

                if (rt == 0)
                {
                    textBox11.Text = tmpCardNo.ToString();
                    textBox9.Text = tmpEndTime.ToString();
                    textBox10.Text = tmpBndTime.ToString();
                    textBox15.Text = tmpLiftData.ToString();

                    tmpSectorNo = int.Parse(tebPowerSwitchSectorNo.Text);
                    tmpHotelPwd = tebPowerSwitchSectorID.Text;

                    rt = Read_Guest_PowerSwitch(comboBox2.SelectedIndex + 1, comboBox1.SelectedIndex + 1, tmpSectorNo,
                         tmpHotelPwd, ref tmpCardNo, ref tmpGuestSex,tmpDoorID, tmpGuestName,tmpBndTime, tmpEndTime, 
                         comboBox3.SelectedIndex + 1);

                    if (rt == 0)
                    {
                        textBox19.Text = tmpCardNo.ToString();
                        textBox17.Text = tmpDoorID.ToString();
                        textBox21.Text = tmpGuestSex.ToString();
                        textBox20.Text = tmpGuestName.ToString();
                        textBox16.Text = tmpEndTime.ToString();
                        textBox18.Text = tmpBndTime.ToString();

                        rt = Reader_Alarm(comboBox2.SelectedIndex + 1, comboBox1.SelectedIndex + 1, tmpAlarmCount);

                        if (rt == 0)
                        {
                            MessageBox.Show("Read guest card successfully:" + rt.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Reader_Alarm: Reading a guest card is unsuccessful:" + rt.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Read_Guest_PowerSwitch:  Reading a guest card is unsuccessful:" + rt.ToString()); ;
                    }
                }
                else
                {
                    MessageBox.Show("Read_Guest_Lift:Reading a guest card is unsuccessful:" + rt.ToString());
                }
            }
            else
            {
                MessageBox.Show("Read_Guest_Card: Reading a guest card is unsuccessful:" + rt.ToString());
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            int rt = 255;

            String tmpHotelPwd = tebSystemPassword.Text;

            int tmpSectorNo = int.Parse(tebSectorNo.Text);

            int tmpAlarmCount = int.Parse(tebRepeatTime.Text);

            int tmpBeginAddr = int.Parse(textBox13.Text);

            int tmpEndAddr = int.Parse(textBox14.Text);

            int tmpMaxAddr = int.Parse(textBox12.Text);

            int tmpCardNo = textBox1.Text == "" ? 0 : int.Parse(textBox1.Text);

            int tmpGuestIdx = textBox3.Text == "" ? 0 : int.Parse(textBox3.Text);

            int tmpGuestSN = textBox7.Text == "" ? 0 : int.Parse(textBox7.Text);          
            
            StringBuilder tmpDoorID = new StringBuilder(textBox5.Text);

            StringBuilder tmpSuitDoor = new StringBuilder(textBox2.Text);

            StringBuilder tmpPubDoor = new StringBuilder(textBox6.Text);

            StringBuilder tmpEndTime = new StringBuilder(textBox8.Text);

            StringBuilder tmpBndTime = new StringBuilder(textBox4.Text);

            StringBuilder tmpLiftData = new StringBuilder(textBox15.Text);

            StringBuilder tmpGuestName = new StringBuilder(textBox20.Text);

            rt = Write_Guest_Card(comboBox2.SelectedIndex + 1, comboBox1.SelectedIndex + 1, tmpSectorNo, tmpHotelPwd,
                 tmpCardNo, tmpGuestSN, tmpGuestIdx, tmpDoorID, tmpSuitDoor, tmpPubDoor, tmpBndTime, tmpEndTime);
            WriteLog.Execute("-----Write_Guest_Card------");
            WriteLog.Execute("result: " + rt);
            WriteLog.Execute("Port: " + (comboBox2.SelectedIndex + 1));
            WriteLog.Execute("ReaderType: " + (comboBox1.SelectedIndex + 1));
            WriteLog.Execute("SectorNo: " + tmpSectorNo);
            WriteLog.Execute("PowerSwitchPwd: " + tmpHotelPwd);
            WriteLog.Execute("CardNo: " + tmpCardNo);
            WriteLog.Execute("tmpGuestSN: " + tmpGuestSN);
            WriteLog.Execute("tmpGuestIdx: " + tmpGuestIdx);
            WriteLog.Execute("DoorID: " + tmpDoorID);
            WriteLog.Execute("tmpSuitDoor: " + tmpSuitDoor);
            WriteLog.Execute("tmpPubDoor: " + tmpPubDoor);
            WriteLog.Execute("beginTime: " + tmpBndTime);
            WriteLog.Execute("endTime: " + tmpEndTime);
            WriteLog.Execute("PowerSwitchType: " + (comboBox3.SelectedIndex + 1));
            MessageBox.Show("Write_Guest_Card:"+rt);


            if (rt == 0)
            {
                tmpCardNo = textBox11.Text == "" ? 0 : int.Parse(textBox11.Text);
                tmpEndTime.Replace(textBox8.Text, textBox9.Text);
                tmpBndTime.Replace(textBox4.Text, textBox10.Text);

                rt = Write_Guest_Lift(comboBox2.SelectedIndex + 1, comboBox1.SelectedIndex + 1, tmpSectorNo, tmpHotelPwd,
                     tmpCardNo, tmpBeginAddr, tmpEndAddr, tmpMaxAddr, tmpBndTime, tmpEndTime, tmpLiftData);
                WriteLog.Execute("-----Write_Guest_Lift------");
                WriteLog.Execute("result: " + rt);
                WriteLog.Execute("Port: " + (comboBox2.SelectedIndex + 1));
                WriteLog.Execute("ReaderType: " + (comboBox1.SelectedIndex + 1));
                WriteLog.Execute("SectorNo: " + tmpSectorNo);
                WriteLog.Execute("PowerSwitchPwd: " + tmpHotelPwd);
                WriteLog.Execute("CardNo: " + tmpCardNo);
                WriteLog.Execute("tmpBeginAddr: " + tmpBeginAddr);
                WriteLog.Execute("tmpEndAddr: " + tmpEndAddr);
                WriteLog.Execute("beginTime: " + tmpBndTime);
                WriteLog.Execute("endTime: " + tmpEndTime);
                WriteLog.Execute("tmpLiftData: " + tmpLiftData);


                if (rt == 0)
                {
                    tmpSectorNo = int.Parse(tebPowerSwitchSectorNo.Text);
                    tmpHotelPwd = tebPowerSwitchSectorID.Text;
                    tmpCardNo = textBox19.Text == "" ? 0 : int.Parse(textBox19.Text);
                    int tmpGuestSex = textBox21.Text == "" ? 0 : int.Parse(textBox21.Text);
                    tmpEndTime.Replace(textBox9.Text, textBox16.Text);
                    tmpBndTime.Replace(textBox10.Text, textBox18.Text);
                    tmpDoorID.Replace(textBox5.Text, textBox17.Text);

                    rt = Write_Guest_PowerSwitch(comboBox2.SelectedIndex + 1, comboBox1.SelectedIndex + 1, tmpSectorNo,
                         tmpHotelPwd, tmpCardNo, tmpGuestSex, tmpDoorID, tmpGuestName,
                         tmpBndTime, tmpEndTime, comboBox3.SelectedIndex + 1);
                   
                    WriteLog.Execute("-----Write_Guest_PowerSwitch------");
                    WriteLog.Execute("result: " + rt);
                    WriteLog.Execute("Port: " + (comboBox2.SelectedIndex + 1));
                    WriteLog.Execute("ReaderType: " + (comboBox1.SelectedIndex + 1));
                    WriteLog.Execute("SectorNo: " + tmpSectorNo);
                    WriteLog.Execute("PowerSwitchPwd: " + tmpHotelPwd);
                    WriteLog.Execute("CardNo: " + tmpCardNo);
                    WriteLog.Execute("Sex: " + tmpGuestSex);
                    WriteLog.Execute("DoorID: " + tmpDoorID);
                    WriteLog.Execute("GuestName: " + tmpGuestName);
                    WriteLog.Execute("beginTime: " + tmpBndTime);
                    WriteLog.Execute("endTime: " + tmpEndTime);
                    WriteLog.Execute("PowerSwitchType: " + (comboBox3.SelectedIndex + 1));

                    MessageBox.Show("Write_Guest_PowerSwitch:" + rt);
                    if (rt == 0)
                    {
                        rt = Reader_Alarm(comboBox2.SelectedIndex + 1, comboBox1.SelectedIndex + 1, tmpAlarmCount);
                        MessageBox.Show("Reader_Alarm:" + rt);
                        if (rt == 0)
                        {
                            MessageBox.Show("Write guest card successfully:"+rt);
                        }
                        else
                        {
                            MessageBox.Show("Write guest card unsuccessful:" + rt);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Write guest card unsuccessful:" + rt);
                    }
                }
                else
                {
                    MessageBox.Show("Write guest card unsuccessful:" + rt);
                }

            }
            else
            {
                MessageBox.Show("Write guest card unsuccessful:" + rt);
            }


        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = SerialNo_FromNow().ToString();
        }
    }
}
