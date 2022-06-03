using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace LockDllSample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime d1 = DateTime.Now;

            DateTime d2 = d1.AddDays(1);

            cb_software.SelectedIndex = 0;
            cb_port.SelectedIndex = 0;
            cb_breakfast.SelectedIndex = 1;
            CB_DB.SelectedIndex = 0;

            ed_date.Text = d1.ToString("yyyyMMdd1200") + d2.ToString("yyyyMMdd1200");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uint lStatus;
            string server, user;
            int LockSoftware;
            
            server = ed_server.Text;
            user = "DllUser";

            LockSoftware = cb_software.SelectedIndex + 1;

            ed_result.Text = "Executing...";

            ed_result.Refresh();

            lStatus = Win32.StartSession(LockSoftware, server, user,CB_DB.SelectedIndex);

            ed_result.Text = lStatus.ToString("X");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uint lStatus;

            ed_result.Text = "Executing...";

            ed_result.Refresh();

            lStatus = Win32.EndSession();

            ed_result.Text = lStatus.ToString("X");
        }

        private void b_newkey_Click(object sender, EventArgs e)
        {
            uint lStatus;
            int Port, CardNo, OverFlag, Breakfast;
            string RoomNo, Holder, IDNo, TimeStr;

            Port = cb_port.SelectedIndex;

            if (ck_over.Checked)
                OverFlag = 1;
            else
                OverFlag = 0;

            Breakfast = cb_breakfast.SelectedIndex;

            RoomNo = ed_room.Text;
            
            Holder = ed_holder.Text;
            IDNo = ed_idno.Text;

            TimeStr = ed_date.Text;

            CardNo = 0;

            ed_result.Text = "Executing...";

            ed_result.Refresh();

            lStatus = Win32.NewKey(Port, RoomNo, "","", TimeStr, Holder, IDNo, Breakfast, OverFlag, ref CardNo);

            ed_result.Text = lStatus.ToString("X");

            if (lStatus == 0)
                ed_cardno.Text = CardNo.ToString();

        }

        private void b_dupkey_Click(object sender, EventArgs e)
        {
            uint lStatus;
            int Port, CardNo, OverFlag, Breakfast;
            string RoomNo, Holder, IDNo, TimeStr;

            Port = cb_port.SelectedIndex;

            if (ck_over.Checked)
                OverFlag = 1;
            else
                OverFlag = 0;

            Breakfast = cb_breakfast.SelectedIndex;

            RoomNo = ed_room.Text;

            Holder = ed_holder.Text;
            IDNo = ed_idno.Text;

            TimeStr = ed_date.Text;

            CardNo = 0;

            ed_result.Text = "Executing...";

            ed_result.Refresh();

            lStatus = Win32.DupKey(Port, RoomNo, "","", TimeStr, Holder, IDNo, Breakfast, OverFlag, ref CardNo);

            ed_result.Text = lStatus.ToString("X");

            if (lStatus == 0)
                ed_cardno.Text = CardNo.ToString();
        }

        private void b_read_Click(object sender, EventArgs e)
        {
            uint lStatus;
            int Port, CardNo, Breakfast, CardStatus;

            StringBuilder RoomNo = new StringBuilder("", 64);
            StringBuilder Holder = new StringBuilder("", 64);
            StringBuilder IDNo = new StringBuilder("", 64);
            StringBuilder TimeStr = new StringBuilder("", 64);
            StringBuilder Door = new StringBuilder("", 128);
            StringBuilder Lift = new StringBuilder("", 128);

            Port = cb_port.SelectedIndex;

            CardNo = CardStatus = Breakfast = 0;

            ed_result.Text = "Executing...";

            ed_result.Refresh();

            lStatus = Win32.ReadKeyCard(Port, RoomNo, Door,Lift, TimeStr, Holder, IDNo, ref CardNo, ref CardStatus, ref Breakfast);

            ed_result.Text = lStatus.ToString("X");

            if (lStatus == 0)
            {
                ed_cardno.Text = CardNo.ToString();
                ed_status.Text = CardStatus.ToString();
                cb_breakfast.SelectedIndex = Breakfast;

                ed_room.Text = RoomNo.ToString();
                ed_holder.Text = Holder.ToString();
                ed_idno.Text = IDNo.ToString();
                ed_date.Text = TimeStr.ToString();
            }

        }

        private void b_erase_Click(object sender, EventArgs e)
        {
            uint lStatus;
            int Port, CardNo;

            Port = cb_port.SelectedIndex;

            try
            {
                CardNo = Convert.ToInt32(ed_cardno.Text);
            }
            catch
            {
                CardNo = 0;
            }

            ed_result.Text = "Executing...";

            ed_result.Refresh();

            lStatus = Win32.EraseKeyCard(Port, CardNo);

            ed_result.Text = lStatus.ToString("X");
        }

        private void b_checkout_Click(object sender, EventArgs e)
        {
            uint lStatus;
            int CardNo;
            string RoomNo;

            try
            {
                CardNo = Convert.ToInt32(ed_cardno.Text);
            }
            catch
            {
                CardNo = 0;
            }

            RoomNo = ed_room.Text;

            ed_result.Text = "Executing...";

            ed_result.Refresh();

            lStatus = Win32.CheckOut(RoomNo, CardNo);

            ed_result.Text = lStatus.ToString("X");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Win32.EndSession();
        }

        private void CB_DB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_DB.SelectedIndex == 0)
            {   if (cb_software.SelectedIndex==0)
                    ed_server.Text = "C:\\Program Files\\HONGLG\\MHA V8.0";
                else
                ed_server.Text = "C:\\Program Files\\HONGLG\\THA V8.0";
            }
            else
                ed_server.Text = "(local)";

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            uint lStatus, CardNo;
            int Port;

            Port = cb_port.SelectedIndex;

            CardNo =  0;

            ed_result.Text = "Executing...";

            ed_result.Refresh();

            lStatus = Win32.ReadCardID(Port,  ref CardNo);

            ed_result.Text = lStatus.ToString("X");
            if (lStatus == 0)
                ed_CardID.Text = CardNo.ToString("X");

        }

        private void cb_software_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_DB.SelectedIndex == 0)
            {
                if (cb_software.SelectedIndex == 0)
                    ed_server.Text = "C:\\Program Files\\HONGLG\\MHA V8.0";
                else
                    ed_server.Text = "C:\\Program Files\\HONGLG\\THA V8.0";
            }
        }

    }
}
