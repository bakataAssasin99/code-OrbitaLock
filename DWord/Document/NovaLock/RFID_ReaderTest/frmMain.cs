using Newtonsoft.Json;
using Novatek.HotelManager.RfidReader;
using Novatek.HotelManager.RfidReader.Card;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text; 
using System.Windows.Forms;

namespace RFID_ReaderTest
{
    public partial class frmMain : Form
    {
        RFID_Reader rfidReader = new RFID_Reader();
        CardInfo lastCardInfo = new CardInfo();

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnWriteCardInfo_Click(object sender, EventArgs e)
        {
            var cardInfo = JsonConvert.DeserializeObject<CardInfo>(txtCardInfoToWrite.Text);
            var writeResult = rfidReader.WriteCardInfo(cardInfo);
            txtTerminal.Text += string.Format("Write result: {0}", writeResult);
        }

        private void rfidTimer_Tick(object sender, EventArgs e)
        {
            var serialNumber = rfidReader.GetRFIDCardSerialNumber();            
            var currentCardInfo = rfidReader.GetCardInfo();
            if (currentCardInfo.UID == -1)
            {
                lastCardInfo = currentCardInfo;
                return;
            }

            if (currentCardInfo.UID != lastCardInfo.UID)
            {
                txtTerminal.Text += string.Format("New RFID card ({0}): {1} \r\n", serialNumber, JsonConvert.SerializeObject(currentCardInfo, Formatting.Indented));
            }

            lastCardInfo = currentCardInfo;
        }
    }
}
