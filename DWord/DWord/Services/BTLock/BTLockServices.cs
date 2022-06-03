using DWord.Constant;
using DWord.Model;
using DWord.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text; 

namespace DWord.Services.BTLock
{
    class BTLockServices
    {
        public static ResultReadCard StartSession()
        {
            int status, nCom, readerModel;
            ResultReadCard result = new ResultReadCard();
            nCom = int.Parse( ConfigurationManager.AppSettings["Port"].ToString() );
            readerModel = int.Parse( ConfigurationManager.AppSettings["ReaderModel"].ToString() );
            Helper.WriteLog("Starting ConnecToLock");

            status = BTLockSDK.Reader_Alarm(nCom, readerModel, 1);
            Helper.WriteLog("status: " + status);
            Helper.WriteLog("Com: " + nCom);
            Helper.WriteLog("Reader Model: " + readerModel);

            if (status != 0)
            {
                result.mess = "Success";
                result.status = true;
            }
            else
            {
                result.mess = ResultToMess(status);
                result.status = false;
            }

            return result;
        }

        public static ResultReadCard WriteCard(Card card, bool isOnlyWritecard = false)
        {
            Helper.WriteLog("___WRITECARD___ ");
            
            ResultReadCard result = new ResultReadCard();
            int status, nCom, readerModel, sectorNo;
            StringBuilder roomCode = new StringBuilder(card.RoomNo);
            StringBuilder startDate = new StringBuilder(card.ArrivalDateTime.Value.ToString("yyMMddHHmm"));
            StringBuilder endDate = new StringBuilder(card.DepartureDateTime.Value.ToString("yyMMddHHmm")); 
            
            string value = ConfigurationManager.AppSettings["SystemCode"].ToString();
            string systemPassword = value.ToString();
            nCom = int.Parse(ConfigurationManager.AppSettings["Port"].ToString());
            readerModel = int.Parse(ConfigurationManager.AppSettings["ReaderModel"].ToString());
            sectorNo = int.Parse(ConfigurationManager.AppSettings["SectorNo"].ToString());
            StringBuilder pubDoor = new StringBuilder("00000000");
            StringBuilder suitDoor = new StringBuilder("0000");
            var guestSN = BTLockSDK.SerialNo_FromNow();
            bool isActivedLift = bool.Parse(ConfigurationManager.AppSettings["isActivedLift"].ToString());
            bool isActivedSwitch = bool.Parse(ConfigurationManager.AppSettings["isActivedSwitch"].ToString());

            status = BTLockSDK.Write_Guest_Card(
                nCom, 
                readerModel, 
                sectorNo, 
                systemPassword, 
                (guestSN + 1), 
                guestSN,1, 
                roomCode, 
                suitDoor, 
                pubDoor, 
                startDate, 
                endDate);
           
            Helper.WriteLog("nCom: " + nCom.ToString());
            Helper.WriteLog("readerModel: " + readerModel.ToString());
            Helper.WriteLog("sectorNo: " + sectorNo.ToString());
            Helper.WriteLog("systemPassword: " + systemPassword.ToString());
            Helper.WriteLog("guestSN: " + guestSN.ToString());
            Helper.WriteLog("roomCode: " + roomCode.ToString());
            Helper.WriteLog("suitDoor: " + suitDoor.ToString());
            Helper.WriteLog("pubDoor: " + pubDoor.ToString());
            Helper.WriteLog("p_startDate: " + startDate.ToString());
            Helper.WriteLog("p_endDatee: " + endDate.ToString());
            Helper.WriteLog("result: " + status.ToString()); 

            if (status == 0)
            {
                Helper.WriteLog("Write card suceesed"); 

                if (isActivedLift && (!isOnlyWritecard) )
                {
                    WriteLift(card);
                }

                if (isActivedSwitch && !isOnlyWritecard)
                {
                    WriteSwitch(card);
                }
                    
                result.mess = "Success";
                result.status = true;
                result.card = new Card { CardNo = card.RoomNo };
                BTLockSDK.Reader_Alarm(nCom, readerModel, 1);
            }
            else
            {
                result.mess = ResultToMess(status);
                result.status = false;
                Helper.WriteLog("Write card fail: " + status + " " + result.mess.ToString());
            }

            return result;
        }

        public static ResultReadCard WriteLift(Card card)
        {
            Helper.WriteLog("___WRITELIFT___ ");

            ResultReadCard result = new ResultReadCard(), resultReadCard = new ResultReadCard();
            int status, nCom, readerModel, sectorNo;
            StringBuilder roomCode = new StringBuilder(card.RoomNo);
            StringBuilder startDate = new StringBuilder(card.ArrivalDateTime.Value.ToString("yyMMddHHmm"));
            StringBuilder endDate = new StringBuilder(card.DepartureDateTime.Value.ToString("yyMMddHHmm"));
            string value = ConfigurationManager.AppSettings["SystemCode"].ToString();
            string systemPassword = value.ToString();
            nCom = int.Parse(ConfigurationManager.AppSettings["Port"].ToString());
            readerModel = int.Parse(ConfigurationManager.AppSettings["ReaderModel"].ToString());
            sectorNo = int.Parse(ConfigurationManager.AppSettings["SectorNo"].ToString());
            StringBuilder pubDoor = new StringBuilder("00000000");
            StringBuilder suitDoor = new StringBuilder("0000");
            var guestSN = BTLockSDK.SerialNo_FromNow();
            var CardNo = guestSN + 1; 
            var maxAddr = int.Parse(ConfigurationManager.AppSettings["MaxAddr"].ToString());
            var beginAddr = int.Parse(ConfigurationManager.AppSettings["BeginAddr"].ToString());
            var endAddr = int.Parse(ConfigurationManager.AppSettings["EndAddr"].ToString());
            StringBuilder liftData = new StringBuilder(BinaryStringToHexString(card.LiftFloor));

            status = BTLockSDK.Write_Guest_Lift(nCom, readerModel, sectorNo, systemPassword, CardNo, beginAddr, endAddr, maxAddr, startDate, endDate, liftData);
            
            Helper.WriteLog("result: " + status.ToString());
            Helper.WriteLog("liftData: " + liftData.ToString());

            if (status == 0)
            {
                result.mess = "Success";
                result.status = true;
                result.card = new Card { CardNo = card.RoomNo };
                Helper.WriteLog("Write lift suceesed");
            }
            else
            {
                result.mess = ResultToMess(status);
                result.status = false;
                Helper.WriteLog("Write lift fail: " + status + " " + result.mess.ToString());
            }

            return result;
        }

        public static string BinaryStringToHexString(string binary)
        {
            if (string.IsNullOrEmpty(binary))
                return binary;

            StringBuilder result = new StringBuilder(binary.Length / 8 + 1);

            // TODO: check all 1's or 0's... throw otherwise

            int mod4Len = binary.Length % 8;
            if (mod4Len != 0)
            {
                // pad to length multiple of 8
                binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '0');
            }

            for (int i = 0; i < binary.Length; i += 8)
            {
                string eightBits = binary.Substring(i, 8);
                result.AppendFormat("{0:X2}", Convert.ToByte(eightBits, 2));
            }

            return result.ToString();
        }

        public static ResultReadCard WriteSwitch(Card card)
        {
            Helper.WriteLog("___WRITESWITCH___ ");

            ResultReadCard result = new ResultReadCard(), resultReadCard = new ResultReadCard();
            int status, nCom, readerModel, sectorNo, powerSwitchType;
            StringBuilder roomCode = new StringBuilder(card.RoomNo); 
            StringBuilder fullNameGuest = new StringBuilder(card.Holder); 
            StringBuilder startDate = new StringBuilder(card.ArrivalDateTime.Value.ToString("yyMMddHHmm"));
            StringBuilder endDate = new StringBuilder(card.DepartureDateTime.Value.ToString("yyMMddHHmm"));
            string value = ConfigurationManager.AppSettings["SystemCode"].ToString();
            string systemPassword = value.ToString();
            nCom = int.Parse(ConfigurationManager.AppSettings["Port"].ToString());
            readerModel = int.Parse(ConfigurationManager.AppSettings["ReaderModel"].ToString());
            sectorNo = int.Parse(ConfigurationManager.AppSettings["SectorNo"].ToString());
            var guestSN = BTLockSDK.SerialNo_FromNow();
            var CardNo = guestSN + 1;
            powerSwitchType = int.Parse(ConfigurationManager.AppSettings["PowerSitchModel"].ToString());
            string powerSwitchPwd = "FFFFFFFFFFFF";

            status = BTLockSDK.Write_Guest_PowerSwitch(nCom, readerModel, sectorNo, powerSwitchPwd,
             CardNo,  0, roomCode, fullNameGuest, startDate,
             endDate, powerSwitchType);

            Helper.WriteLog("result: " + status.ToString());
            Helper.WriteLog("systemPassword: " + systemPassword.ToString());
            Helper.WriteLog("roomCode: " + roomCode.ToString());
            Helper.WriteLog("p_startDate: " + startDate.ToString());
            Helper.WriteLog("p_endDatee: " + endDate.ToString());

            if (status == 0)
            {
                result.mess = "Success";
                result.status = true;
                result.card = new Card { CardNo = card.RoomNo };
                Helper.WriteLog("Write switch suceesed");
            }
            else
            {
                result.mess = ResultToMess(status);
                result.status = false;
                Helper.WriteLog("Write switch fail: " + status + " " + result.mess.ToString());
            }

            return result;
        }

        public unsafe static ResultReadCard ReadCard()
        {
            Helper.WriteLog("___ReadCard___ ");
            Card card = new Card();
            ResultReadCard result = new ResultReadCard();

            int status, nCom, readerModel, sectorNo; 
            string value = ConfigurationManager.AppSettings["SystemCode"].ToString();
            string systemPassword = value.ToString();
            nCom = int.Parse(ConfigurationManager.AppSettings["Port"].ToString());
            readerModel = int.Parse(ConfigurationManager.AppSettings["ReaderModel"].ToString());
            sectorNo = int.Parse(ConfigurationManager.AppSettings["SectorNo"].ToString()); 

            int CardNo = 0;
            int GuestSN = 0;
            int GuestIdx = 0;
            StringBuilder doorID = new StringBuilder();
            StringBuilder suitDoor = new StringBuilder();
            StringBuilder pubDoor = new StringBuilder();
            StringBuilder beginTime = new StringBuilder();
            StringBuilder endTime = new StringBuilder();

            status = BTLockSDK.Read_Guest_Card(nCom, readerModel, sectorNo, systemPassword, ref CardNo, ref GuestSN, ref GuestIdx, doorID, suitDoor, pubDoor, beginTime, endTime);

            if (status == 0)
            {
                Helper.WriteLog("ReadCard status " + status);
                card.CardNo = CardNo.ToString();
                card.RoomNo = doorID.ToString();
                result.card = card;
                result.mess = "Success";
                result.status = true;
                Helper.WriteLog("card.CardNo " + card.CardNo);
            }
            else
            {
                result.mess = ResultToMess(status);
                result.status = false;
            }

            return result;
        }

        public static ResultReadCard DeleteCard(Card card)
        {
            ResultReadCard result = new ResultReadCard();
            ResultReadCard resultWrite = new ResultReadCard();

            Helper.WriteLog("_____DeleteCard_____");
            card.DepartureDateTime = DateTime.Now; 
            resultWrite = WriteCard(card, true);

            Helper.WriteLog("result: " + result.ToString());

            if (resultWrite.status)
            {
                result.mess = "Success";
                result.status = true;
            }
            else
            {
                result.mess = resultWrite.mess;
                result.status = false;
            }

            return result;
        }

        public static ResultReadCard Cardbuilder(CardInfo request)
        {
            Helper.WriteLog("___Cardbuilder___");
            var card = new Card();
            var result = new ResultReadCard { status = true };
            var resultgetInfoRoom = new ResultReadCard { status = true };
            var addMinuteTimeCheckout = int.Parse(ConfigurationManager.AppSettings["addMinuteTimeCheckout"].ToString());
             
            var isMapRoomName = bool.Parse(ConfigurationManager.AppSettings["isMapRoomName"]);
            if (isMapRoomName)
            {
                request.RoomName = CardInfoService.MapRoomName(request.RoomName);
                card.RoomName = request.RoomName;
            } 
            

            var isMapRoomNo = bool.Parse(ConfigurationManager.AppSettings["isMapRoomNo"]);
            if (isMapRoomNo)
            {
                card.RoomNo = CardInfoService.MapCardNo(request.RoomName, card.RoomNo);
            }
            else
            {
                RoomAccess foundRoom = GetLockNoAccessFile(request.RoomName);
                string cardno = foundRoom.DoorID;
                if (cardno != null && cardno.Length > 0)
                {
                    card.RoomNo = cardno;
                }
                else
                {
                    return resultgetInfoRoom;
                }
            }

            var isMapLiftName = bool.Parse(ConfigurationManager.AppSettings["isMapLiftNo"]);
            string LiftFloor = "";
            if (isMapLiftName)
            {
                LiftFloor = CardInfoService.MapLiftNo(request.RoomName);
            }
            else
            {
                LiftFloor = GetLiftNoAccessFile(request.RoomName);
                if( LiftFloor == null || LiftFloor.Length == 0 )
                {
                    return resultgetInfoRoom;
                }
            }

            card.LiftFloor = LiftFloor;
            card.Holder = request.TravellerName;
            card.IDNo = null;
            card.CardNo = null;

            // GET TimeStr
            if (request.DepartureDate < DateTime.Now)
            {
                request.ArrivalDate = DateTime.Now;
                request.DepartureDate = DateTime.Now.AddMinutes(1 + addMinuteTimeCheckout);
            }
            else
            {
                request.DepartureDate = request.DepartureDate.AddMinutes(addMinuteTimeCheckout);
            }

            if (request.ArrivalDate < DateTime.Now)
            {
                //request.ArrivalDate = DateTime.Now;
            }
            card.Holder = request.TravellerId;
            card.ArrivalDateTime = request.ArrivalDate;
            card.DepartureDateTime = request.DepartureDate;
            card.DepartureDate = string.Format("{0:yy-MM-dd}", request.DepartureDate).ToString();//request.DepartureDate.ToString("yy-MM-dd");
            card.ArrivalDate = string.Format("{0:yy-MM-dd}", request.ArrivalDate).ToString();// request.ArrivalDate.ToString("yy-MM-dd");
            result.card = card;
            System.Console.WriteLine(result.card.ToString());
            return result;
        }

        public static string ResultToMess(int status)
        {
            string mess = "";

            switch (status)
            {
                case 0:
                    mess = "Success";
                    break;
                case 1:
                    mess = "Open serial com port error";
                    break;
                case 2:
                    mess = "No card error";
                    break;
                case 3:
                    mess = "Card type error";
                    break;
                case 4:
                    mess = "Read card error";
                    break;
                case 5:
                    mess = "Hotel password error ";
                    break;
                case 6:
                    mess = "Write card error";
                    break;
                case 255:
                    mess = "Failure";
                    break;
            }

            return mess;
        }

        public static bool CheckConnectAccessFile(string url)
        {
            var isMapRoomNo = bool.Parse(ConfigurationManager.AppSettings["isMapRoomNo"]);
            if (isMapRoomNo)
            {
                return true;
            }

            string fileDb = ConstFileAccess.BT_FILE_NAME;
            var queryString = "SELECT TOP 1 door_id FROM doors";
            var ConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}" + fileDb + ";", url);

            using (var connection = new OleDbConnection(ConnectionString))
            using (var command = new OleDbCommand(queryString, connection))
            {
                try
                {
                    Helper.WriteLog("CommunicationClass.ConnectionString 1: " + ConnectionString);
                    Settings.Default.ConnectionString = ConnectionString;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    reader.Close();
                    Helper.WriteLog("Connect DB SUCCESS"); 

                    return true;
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("err:" + ex.ToString());
                    return false;
                }
            }
        }

        private static RoomAccess GetLockNoAccessFile(string roomName)
        {
            var queryString = $"SELECT door_id, door_name, lock_no, door_desc  FROM doors WHERE door_name = '{roomName}'";
            var connectString = Settings.Default.ConnectionString;
            RoomAccess result = new RoomAccess();

            using (var connection = new OleDbConnection(connectString))
            using (var command = new OleDbCommand(queryString, connection))
            {
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        result.DoorID = reader[0].ToString();
                        result.DoorName = reader[1].ToString();
                        result.LockNo = reader[2].ToString();
                        result.DoorDesc = reader[3].ToString();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("err:" + ex.ToString());
                    return result;
                }
            }

            return result;
        }

        private static string GetLiftNoAccessFile(string lockNo)
        {
            var queryString = $"SELECT ctrl_code FROM lift_ctrldoors WHERE lock_no = '{lockNo}'";
            var connectString = Settings.Default.ConnectionString;
            string result = "";

            using (var connection = new OleDbConnection(connectString))
            using (var command = new OleDbCommand(queryString, connection))
            {
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        result = reader[0].ToString();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("err:" + ex.ToString());
                    return result;
                }
            }

            return result;
        }

    }
}
