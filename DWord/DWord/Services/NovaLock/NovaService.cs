using DWord.Constant;
using DWord.Model;
using DWord.Properties;
using Newtonsoft.Json;
using Novatek.HotelManager.RfidReader;
using Novatek.HotelManager.RfidReader.Card;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text; 

namespace DWord.Services.NovaLock
{
    public class NovaService
    {
        static RFID_Reader rfidReader = new RFID_Reader();
        public static ResultReadCard WriteCard(Card card, bool isOverWrite)
        {  
            Novatek.HotelManager.RfidReader.Card.CardInfo lastCardInfo = new Novatek.HotelManager.RfidReader.Card.CardInfo();
            ResultReadCard result = new ResultReadCard(), resultReadCard = new ResultReadCard();

            resultReadCard = ReadCard();

            if( ! resultReadCard.status)
            {
                result.mess = "Read before write data failed";
                result.status = false; 
                //return result;
            }

            Helper.WriteLog("___WRITECARD___ "); 
            Helper.WriteLog("lastCardInfo.CustomerID "+ card.Holder);

            bool isModeSetupKey = bool.Parse(ConfigurationManager.AppSettings["ModeSetupKey"]);

            lastCardInfo.BuildingID = 1; 
            lastCardInfo.UsageToTime = card.ArrivalDateTime.Value;
            lastCardInfo.CurrentTime = DateTime.Now;
            lastCardInfo.CustomerID = card.Holder;
            lastCardInfo.FloorID = "1";
            lastCardInfo.RoomID = card.RoomNo;
            lastCardInfo.Type = (CardType)(isModeSetupKey? CardTypeKey.THE_HE_THONG: CardTypeKey.THE_PHONG);
            lastCardInfo.UID = (long)Convert.ToDouble(resultReadCard.card.CardNo);

            bool status = rfidReader.WriteCardInfo(lastCardInfo);

            if (status)
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
                Helper.WriteLog("Write card fail: " + status + " " + result.mess.ToString());
            }

            return result;
        }

        public static ResultReadCard ReadCard()
        {
            Helper.WriteLog("___ReadCard___ ");
            Card card = new Card();
            ResultReadCard result = new ResultReadCard();
            
            var serialNumber = rfidReader.GetRFIDCardSerialNumber();
            var currentCardInfo = rfidReader.GetCardInfo();

            Helper.WriteLog("ReadCard " + currentCardInfo.UID + " RoomName " + currentCardInfo.RoomID);

            if (currentCardInfo.UID != -1)
            {
                Helper.WriteLog("currentCardInfo.CustomerID " + currentCardInfo.CustomerID);
                card.CardNo = currentCardInfo.UID.ToString();
                card.RoomNo = currentCardInfo.RoomID;
                result.card = card;
                result.mess = "Success";
                result.status = true;
                Helper.WriteLog("card.CardNo " + card.CardNo);
            }
            else
            {
                result.mess = "Read data failed,Error: " + currentCardInfo.UID.ToString();
                result.status = false;
            }

            return result;
        }

        public static ResultReadCard DeleteCard()
        {
            ResultReadCard result = new ResultReadCard();
            var cardInformation = new char[200];
            RFID_Reader rfidReader = new RFID_Reader();
            Card card = new Card();
            card.ArrivalDateTime = DateTime.Now;
            card.DepartureDateTime = DateTime.Now;
            //ResultReadCard rq = WriteCard(card, true);
            bool status = rfidReader.ClearCardData();
            if (status)
            {
                result.mess = "Success";
                result.status = true;
            }
            else
            {
                result.mess = "Fail";
                result.status = false;
            }

            return result;
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

        public static ResultReadCard StartSession()
        {
            int status;
            ResultReadCard result = new ResultReadCard();

            result.mess = "Success";
            result.status = true;

            return result;
        }
        
        public static ResultReadCard Cardbuilder(Model.CardInfo request)
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

            string cardno = request.RoomName;// GetLockNoAccessFile(request.RoomName);
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

            if (request.ArrivalDate < DateTime.Now)
            {
                request.ArrivalDate = DateTime.Now;
            }
            card.Holder = request.TravellerId;
            card.ArrivalDateTime = request.ArrivalDate;
            card.DepartureDateTime = request.DepartureDate;
            card.DepartureDate = string.Format("{0:yy-MM-dd}", request.DepartureDate).ToString();
            card.ArrivalDate = string.Format("{0:yy-MM-dd}", request.ArrivalDate).ToString();
            result.card = card;
            return result;
        }

        public enum CardTypeKey
        {
            THE_HE_THONG = 1,
            THE_PHONG = 2,
            THE_THOI_GIAN = 3,
            THE_XOA = 4,
            THE_TANG = 5,
            THE_TOA_NHA = 6,
            THE_MASTER = 7,
            THE_GHI_DU_LIEU = 8,
        }
    }
}
