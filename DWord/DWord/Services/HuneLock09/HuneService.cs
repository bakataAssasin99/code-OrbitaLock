using DWord.Constant;
using DWord.Model;
using DWord.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace DWord.Services.ProUsb
{
    public class Hune09Service
    { 
        public static ResultReadCard WriteCard(Card card, bool isOverWrite)
        { 
            ResultReadCard result = new ResultReadCard(), resultReadCard = new ResultReadCard();
            int status;  

            Helper.WriteLog("___WRITECARD___ ");
            StringBuilder DTPSDInVar = new StringBuilder(string.Format("{0:yy-MM-dd}", card.ArrivalDateTime).ToString());
            StringBuilder DTPSDOutVar = new StringBuilder(string.Format("{0:yy-MM-dd}", card.DepartureDateTime).ToString());
            StringBuilder DTPSTInVar = new StringBuilder(card.ArrivalDateTime.Value.ToString("HH:mm:ss"));
            StringBuilder DTPSTOutVar = new StringBuilder(card.DepartureDateTime.Value.ToString("HH:mm:ss"));
            int com = Int32.Parse(Settings.Default.COMPort);
            int Encrypt = 88;
            int nBlock = 8;
            StringBuilder CardPass = new StringBuilder("33AA9C2693F8");
            StringBuilder SystemCode = new StringBuilder(ConfigurationManager.AppSettings["SystemCode"]);
            StringBuilder HotelCode = new StringBuilder(ConfigurationManager.AppSettings["HotelCode"]);
            StringBuilder RoomPass = new StringBuilder(CompactCipherTime(DateTime.Now));
            StringBuilder Address = new StringBuilder(card.RoomNo);
            int CardNo = Int32.Parse(card.Holder);
            int TerminateOld = 1;// (isOverWrite) ? 0 : 1;
            int LevelPass = 3;                     //Default 3
            int PassMode = 2;                      //Default 1, if Terminate old card then PassMode= 2
            int AddressMode = 0;                   //Default 0
            int AddressQty = 1;                    //Default 1
            int TimeMode = 0;                      //Default 0
            int V8 = 255;                          //Default 255
            int V16 = 255;                         //Default 255
            int V24 = 255;                         //Default 255
            int AlwaysOpen = 0;                    //Default 0
            int OpenBolt = 0;                      //Default 0 
            int ValidTimes = 255;                  //Default 255 
            Helper.WriteLog("com " + com);
            Helper.WriteLog("CardNo " + CardNo);
            Helper.WriteLog("nBlock " + nBlock);
            Helper.WriteLog("CardPass " + CardPass);
            Helper.WriteLog("SystemCode " + SystemCode);
            Helper.WriteLog("HotelCode " + HotelCode);
            Helper.WriteLog("RoomPass " + RoomPass);
            Helper.WriteLog("Address " + Address);
            Helper.WriteLog("DTPSDInVar " + DTPSDInVar);
            Helper.WriteLog("DTPSTInVar " + DTPSTInVar);
            Helper.WriteLog("DTPSDOutVar " + DTPSDOutVar);
            Helper.WriteLog("DTPSTOutVar " + DTPSTOutVar); 
            
            status = Hune09LockSDK.KeyCard(com, CardNo, nBlock, Encrypt, CardPass, SystemCode, HotelCode, RoomPass, Address, DTPSDInVar, DTPSTInVar, DTPSDOutVar, DTPSTOutVar, LevelPass, PassMode, AddressMode, AddressQty, TimeMode, V8, V16, V24, AlwaysOpen, OpenBolt, TerminateOld, ValidTimes);
             
            if (status == 0)
            {
                result.mess = "Success";
                result.status = true;
                result.card = new Card { CardNo = card.RoomNo };
                Helper.WriteLog("Write card suceesed");
            }
            else
            {
                result.mess = "Write data failed,Error: " + status.ToString();
                result.status = false;
                Helper.WriteLog("Write card fail: " + status + " "+ result.mess.ToString());
            }

            return result;
        }

        public static String CompactCipherTime(DateTime DTVar)
        {
            long DW1 = 0;
            String DW2 = "";
            long Year = DTVar.Year;
            long Month = DTVar.Month;
            long Day = DTVar.Day;
            long Hour = DTVar.Hour;
            long Min = DTVar.Minute;
            long Sec = DTVar.Second;
            DW1 = (Min >> 4) + (Hour << 4) + (Day << 9) + (Month << 14) + ((((Year - 8) % 1000) % 63) << 18);
            DW2 = Convert.ToString(DW1, 16);
            return DW2.ToUpper();
        }
         
        public unsafe static ResultReadCard ReadCard()
        {
            Helper.WriteLog("___ReadCard___ "); 
            Card card = new Card();
            ResultReadCard result = new ResultReadCard();
            int com = Int32.Parse(Settings.Default.COMPort);
            int status;
            int cardNo = 0;
            int cardType = 0;
            int cardLevel = 0;
            int Encrypt = 88;
            int nBlock = 8;
            StringBuilder CardPass = new StringBuilder("33AA9C2693F8");
            StringBuilder SystemCode = new StringBuilder(ConfigurationManager.AppSettings["SystemCode"]);
            StringBuilder Address = new StringBuilder("");
            StringBuilder Datetime = new StringBuilder("");

            status = Hune09LockSDK.ReadMessage(com, nBlock, Encrypt, &cardNo, &cardType, &cardLevel, CardPass, SystemCode, Address, Datetime);
            
            Helper.WriteLog("result: " + result.ToString());
            Helper.WriteLog("Address: " + Address);
            Helper.WriteLog("cardNo: " + cardNo);
            Helper.WriteLog("SystemCode: " + SystemCode);
            Helper.WriteLog("Date: " + Datetime);
             
            if (status == 0)
            {
                Helper.WriteLog("ReadCard status " + status);
                card.CardNo = cardNo.ToString();
                card.RoomNo = card.CardNo;
                result.card = card;
                result.mess = "Success";
                result.status = true;
                Helper.WriteLog("card.CardNo " + card.CardNo);
            }
            else
            {
                result.mess = "Read data failed,Error: " + status.ToString();
                result.status = false;
            }

            return result;
        }

        public static ResultReadCard DeleteCard()
        {
            ResultReadCard result = new ResultReadCard();
            var cardInformation = new char[200];
            Card card = new Card();
            card.ArrivalDateTime = DateTime.Now;
            card.DepartureDateTime = DateTime.Now;
            ResultReadCard rq = WriteCard(card, true); // ProUsbLockSDK.CardErase(ProGetDLLVersion(), getHotelId(), cardInformation);

            if (rq.status)
            {
                result.mess = "Success";
                result.status = true;
            }
            else
            {
                result.mess = rq.mess;
                result.status = false;
            }

            return result;
        }

        public static string ResultToMess(int status)
        {
            string mess = "";

            switch (status)
            {
                case 1:
                    mess = "Successful Operation";
                    break;
                case -1:
                    mess = "Card is not detected";
                    break;
                case -2:
                    mess = "Card reader is not detected";
                    break;
                case -3:
                    mess = "Invalid card";
                    break;
                case -4:
                    mess = "Wrong card type";
                    break;
                case -5:
                    mess = "Read/write wong";
                    break;
                case -6:
                    mess = "Port is not open";
                    break;
                case -7:
                    mess = "End of data card";
                    break;
                case -8:
                    mess = "Invalid parameter";
                    break;
                case -9:
                    mess = "Invalid operation";
                    break;
                case -10:
                    mess = "Other error";
                    break;
                case -11:
                    mess = "Port is in use";
                    break;
                case -12:
                    mess = "Communication error";
                    break;
                case -20:
                    mess = "Wrong client code";
                    break;
                case -29:
                    mess = "Not registered";
                    break;
                case -30:
                    mess = "No Authorization Card data";
                    break;
                case -31:
                    mess = "Rooms are over the available sector";
                    break;
            }

            return mess;
        }

        public static bool CheckConnectAccessFile(string url)
        {
            string password = ConstFileAccess.HUNE09_PASS;
            string fileDb = ConstFileAccess.HUNE09_FILE_PASS;
            var queryString = "SELECT TOP 1 HotelCode, ComNumber, DllDir FROM H_MSC";
            var ConnectionString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={url}" + fileDb + ";Jet OLEDB:Database Password=" + password + ";";

            Helper.WriteLog("CommunicationClass.ConnectionString 1: " + ConnectionString);

            using (var connection = new OleDbConnection(ConnectionString))
            using (var command = new OleDbCommand(queryString, connection))
            {
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    
                    Helper.WriteLog("Connect DB SUCCESS");
                    while (reader.Read())
                    {
                        Helper.WriteLog("reader[0].ToString() " + reader[0].ToString());
                        Settings.Default.ConnectionString = ConnectionString;
                        Settings.Default.LockFolder = url;
                        Settings.Default.InitSuccess = true;


                        if (Settings.Default.HotelCode != reader[0].ToString())
                        {
                            Settings.Default.HotelCode = reader[0].ToString();
                            Settings.Default.COMPort = reader[1].ToString();
                        }

                        Settings.Default.Save();
                    }
                    reader.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("err:" + ex.ToString());
                    return false;
                }
            }
        }

        private static string GetLockNoAccessFile(string roomName)
        {
            var lockNo = "";
            var queryString = "SELECT RoomAddr,RoomName FROM H_Room where RoomName='" + roomName + "'";
            var connectString = Settings.Default.ConnectionString;
            Helper.WriteLog("queryString: " + queryString);
            using (var connection = new OleDbConnection(connectString))
            using (var command = new OleDbCommand(queryString, connection))
            {
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        //string BldNo = reader[0].ToString(); 
                        lockNo = reader[0].ToString(); 
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("err:" + ex.ToString());
                    return null;
                }
            }

            Helper.WriteLog("lockNo: " + lockNo);
            return lockNo;
        }

        public static ResultReadCard Cardbuilder(CardInfo request)
        {
            Helper.WriteLog("___Cardbuilder___");
            var card = new Card();
            var result = new ResultReadCard { status = true };
            var resultgetInfoRoom = new ResultReadCard { status = true };
            var addMinuteTimeCheckout = int.Parse(ConfigurationManager.AppSettings["addMinuteTimeCheckout"].ToString());

            // GET RoomNo CommonDoor LiftFloor
            var isMapRoomName = bool.Parse(ConfigurationManager.AppSettings["isMapRoomName"]);
            if (isMapRoomName)
            {
                request.RoomName = CardInfoService.MapRoomName(request.RoomName);
            }
             
            string cardno = GetLockNoAccessFile(request.RoomName);
            if (cardno != null && cardno.Length > 0)
            {
                card.RoomNo = cardno;
            }
            else
            {
                return resultgetInfoRoom;
            }

            var isMapRoomNo = bool.Parse(ConfigurationManager.AppSettings["isMapRoomNo"]);
            Helper.WriteLog("isMapRoomNo " + isMapRoomNo);
            if (isMapRoomNo)
            {
                card.RoomNo = CardInfoService.MapCardNo(request.RoomName, card.RoomNo);
            }

            Helper.WriteLog("card.RoomNo " + card.RoomNo);
            // GET Holder
            card.Holder = request.TravellerName;

            card.IDNo = "null";
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

            if(request.ArrivalDate < DateTime.Now)
            {
                //request.ArrivalDate = DateTime.Now;
            }
            card.Holder = request.TravellerId;
            card.ArrivalDateTime = request.ArrivalDate;
            card.DepartureDateTime = request.DepartureDate;
            card.DepartureDate = string.Format("{0:yy-MM-dd}", request.DepartureDate).ToString();//request.DepartureDate.ToString("yy-MM-dd");
            card.ArrivalDate = string.Format("{0:yy-MM-dd}", request.ArrivalDate).ToString();// request.ArrivalDate.ToString("yy-MM-dd");
            result.card = card;
            return result;
        }
         
    }
}
