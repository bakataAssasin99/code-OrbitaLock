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
        public static ResultReadCard ProInitializeUSB(int fUSB)
        {
            ResultReadCard result = new ResultReadCard();
            int status = 0;
            Helper.WriteLog("fruntion ProInitializeUSB=>before check is=" + fUSB.ToString());
            status = ProUsbLockSDK.initializeUSB(ProGetDLLVersion());

            if (status == 0)
            {
                result.mess = "Success";
                result.status = true;
                result.card = new Card {};
            }
            else
            {
                result.mess = ResultToMess(status);
                result.status = false;
            }

            Helper.WriteLog("fruntion ProInitializeUSB=>result=" + result.ToString());
            return result;
        }
        public static Int32 InnitHotelId()
        {
            Int32 hotelId = 0;
            var cardInformation = new char[128];
            string scardInformation = "";
            int resultReadCard;
            resultReadCard = ProUsbLockSDK.ReadCard(ProGetDLLVersion(), cardInformation);
            if (resultReadCard == 0 )
            {
                scardInformation = CardInfoService.CharToString(cardInformation);
                Helper.WriteLog("Function getHotelId=>cardInformation=" + CardInfoService.CharToString(cardInformation) + ", hotelid:" + hotelId.ToString());
                 
                if (scardInformation.Length > 30)
                {
                    if (scardInformation.Substring(24, 8) == "FFFFFFFF")
                    {
                        hotelId = 0;
                    }
                    else
                    {
                        var s = scardInformation.Substring(10, 4);
                        var i = Convert.ToInt32(s, 16) % 16384;
                        s = scardInformation.Substring(8, 2);
                        i = i + (Convert.ToInt32(s, 16) * 65536);
                        hotelId = i;
                    }
                }
            }
            else
            {
                hotelId = 0;
            }
            Helper.WriteLog("Function getHotelId=> hotelid:" + hotelId.ToString() );
            return hotelId;
        }
        public static ResultReadCard WriteCard(Card card, bool isOverWrite)
        { 
            ResultReadCard result = new ResultReadCard(), resultReadCard = new ResultReadCard();
            int status;  
            string LockNo = card.RoomNo; 
            var cardHexStr = new char[128];
            Helper.WriteLog("___WRITECARD___ "); 

            string DTPSDInVar = card.ArrivalDate;
            string DTPSDOutVar = card.DepartureDate;

            int com = Settings.Default.COMPort;
            int Encrypt = 1;
            int nBlock = 4;
            string CardPass = "";
            string SystemCode = "";
            string HotelCode = "";
            string RoomPass = "";
            string Address = "";
            int CardNo = 0;
            int TerminateOld = (isOverWrite) ? 0 : 1;
            string DTPSTInVar = "";
            string DTPSTOutVar = "";
            int LevelPass = 3;                     //Default 3
            int PassMode = 1;                      //Default 1
            int AddressMode = 0;                   //Default 0
            int AddressQty = 1;                    //Default 1
            int TimeMode = 0;                      //Default 0
            int V8 = 255;                          //Default 255
            int V16 = 255;                         //Default 255
            int V24 = 255;                         //Default 255
            int AlwaysOpen = 0;                    //Default 0
            int OpenBolt = 0;                      //Default 0 
            int ValidTimes = 255;                  //Default 255 

            Hune09LockSDK.KeyCard(com, CardNo, nBlock, Encrypt, 
                CardPass, SystemCode, HotelCode, RoomPass, Address, 
                DTPSDInVar, DTPSTInVar, DTPSDOutVar, DTPSTOutVar, 
                LevelPass, PassMode, AddressMode, AddressQty, 
                TimeMode, V8, V16, V24, 
                AlwaysOpen, OpenBolt, TerminateOld, ValidTimes);

            
             
            if (status == 0 || status == 1)
            {
                resultReadCard = ReadCard();
                
                if (resultReadCard.status)
                {
                    result.mess = "Success";
                    result.status = true;
                    result.card = new Card { CardNo = resultReadCard.card.CardNo };
                    Helper.WriteLog("Write card suceesed");
                } 
                else
                {
                    result.mess = "Write card suceesed!, But cannot read card " + resultReadCard.mess;
                    Helper.WriteLog("Write card suceesed!, But cannot read card: " + result.mess.ToString());
                    result.status = false;
                }
            }
            else
            {
                result.mess = ResultToMess(status);
                result.status = false;
                Helper.WriteLog("Write card fail: " + result.mess.ToString());
            }

            return result;
        }
         
        public static ResultReadCard ReadCard()
        {
            Helper.WriteLog("___ReadCard___ ");
            int dlsCoID = getHotelId();
            Card card = new Card();
            var cardInformation = new char[128];
            var LockNoChar = new char[128];
            ResultReadCard result = new ResultReadCard();
            int status;

            status = ProUsbLockSDK.ReadCard(ProGetDLLVersion(), cardInformation);
            

            if (status == 0 || status == 1)
            {
                Helper.WriteLog("ReadCard status " + status);
                status = ProUsbLockSDK.GetGuestLockNoByCardDataStr(dlsCoID, cardInformation, LockNoChar);
                Helper.WriteLog("GetGuestLockNoByCardDataStr status " + status);
                if (status == 0)
                {
                    card.CardNo = CardInfoService.CharToString(LockNoChar);
                    card.RoomNo = card.CardNo;
                    result.card = card;
                    result.mess = "Success";
                    result.status = true;
                    Helper.WriteLog("card.CardNo " + card.CardNo);
                }
            }

            if(status != 0 && status != 1)
            {
                result.mess = ResultToMess(status);
                result.status = false;
            }

            return result;
        }

        public static ResultReadCard DeleteCard()
        {
            ResultReadCard result = new ResultReadCard();
            int status;
            var cardInformation = new char[200];
            status = ProUsbLockSDK.CardErase(ProGetDLLVersion(), getHotelId(), cardInformation);

            if (status == 0)
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
            string password = ConstFileAccess.PROUSB_PASS;
            string fileDb = ConstFileAccess.PROUSB_FILE_NAME;
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
                    Settings.Default.ConnectionString = ConnectionString;
                    Settings.Default.LockFolder = url; 

                    if (Settings.Default.HotelCode != reader[0].ToString())
                    {
                        Settings.Default.HotelCode = reader[0].ToString();
                        Settings.Default.COMPort = reader[1].ToString();
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

            card.DepartureDate = request.DepartureDate.ToString("0:yy-MM-dd");
            card.ArrivalDate = request.ArrivalDate.ToString("0:yy-MM-dd");
            result.card = card;
            return result;
        }
         
    }
}
