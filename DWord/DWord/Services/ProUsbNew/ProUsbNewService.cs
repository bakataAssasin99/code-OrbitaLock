using DWord.Constant;
using DWord.Model;
using DWord.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text; 

namespace DWord.Services.ProUsbNew
{
    class ProUsbNewService
    {
        public static ResultReadCard ProInitializeUSB(int fUSB)
        {
            ResultReadCard result = new ResultReadCard();
            int status = 0;
            Helper.WriteLog("fruntion ProInitializeUSB=>before check is=" + fUSB.ToString());
            status = ProUsbNewSDK.initializeUSB(ProGetDLLVersion());

            if (status == 0)
            {
                result.mess = "Success";
                result.status = true;
                result.card = new Card { };
            }
            else
            {
                result.mess = ResultToMess(status);
                result.status = false;
            }

            Helper.WriteLog("fruntion ProInitializeUSB=>result=" + result.ToString());
            return result;
        }

        public static string CharToString(byte[] arr)
        {
            int i;
            string datastr = "";
            for (i = 0; i < 6; i++)
            {
                datastr = datastr + ((char)arr[i]).ToString();
            }

            return datastr;
        }

        public static Int32 InnitHotelId()
        {
            Int32 hotelId = 0; 
            string scardInformation = "";
            int resultReadCard;
            byte[] cardInformation = new byte[128];
            resultReadCard = ProUsbNewSDK.ReadCard(ProGetDLLVersion(), cardInformation);
            if (resultReadCard == 0)
            {
                scardInformation = CharToString(cardInformation);
                Helper.WriteLog("Function getHotelId=>cardInformation=" + CharToString(cardInformation) + ", hotelid:" + hotelId.ToString());

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
            Helper.WriteLog("Function getHotelId=> hotelid:" + hotelId.ToString());
            return hotelId;
        }
        public static ResultReadCard WriteCard(int port, Card card, bool isOverWrite)
        {
            ResultReadCard result = new ResultReadCard(), resultReadCard = new ResultReadCard();
            int status;
            byte fUSB = ProGetDLLVersion();
            Int32 dlsCoID = getHotelId();
            byte cardNo = 1;
            byte dai = 0;
            int i;
            string LockNo = card.RoomNo;
            byte llock = 1;
            byte pdoors = 1;
            var cardHexStr = new char[128];
            Helper.WriteLog("___WRITECARD___ ");
            Helper.WriteLog("fUSB " + fUSB.ToString() + "/n" +
                            "dlsCoID " + dlsCoID.ToString() + "/n" +
                            "LockNo " + LockNo.ToString() + "/n" +
                            "card.ArrivalDate " + card.ArrivalDate.ToString() + "/n" +
                            "card.DepartureDate " + card.DepartureDate.ToString() + "/n");
            byte[] cardbuf = new byte[128];
            char[] BDate = new char[10];
            char[] EDate = new char[10];
            char[] roomno = new char[8];
            //BDatestr = DateTime.Now.ToString("yyMMddHHmm");//发卡时间必须取当前时间
            for (i = 0; i < 10; i++)
            {
                BDate[i] = Convert.ToChar(card.ArrivalDate.Substring(i, 1));

            }

            for (i = 0; i < 10; i++)
            {
                EDate[i] = Convert.ToChar(card.DepartureDate.Substring(i, 1));

            }

            for (i = 0; i < 6; i++)
            {
                roomno[i] = Convert.ToChar(LockNo.Substring(i, 1));

            }

            if (isOverWrite)
            {
                status = ProUsbNewSDK.GuestCard(fUSB, dlsCoID, cardNo, dai, llock, pdoors, BDate, EDate, roomno, cardbuf);
            }
            else
            {
                status = ProUsbNewSDK.GuestCard(fUSB, dlsCoID, cardNo, dai, llock, pdoors, BDate, EDate, roomno, cardbuf);
            }

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
            byte[] cardInformation = new byte[128]; 
            byte[] lockno = new byte[16];
            ResultReadCard result = new ResultReadCard();
            int status;

            status = ProUsbNewSDK.ReadCard(ProGetDLLVersion(), cardInformation);


            if (status == 0 || status == 1)
            {
                Helper.WriteLog("ReadCard status " + status);
                status = ProUsbNewSDK.GetGuestLockNoByCardDataStr(dlsCoID, cardInformation, lockno);
                Helper.WriteLog("GetGuestLockNoByCardDataStr status " + status);
                if (status == 0)
                {
                    card.CardNo = CharToString(lockno);
                    card.RoomNo = card.CardNo;
                    result.card = card;
                    result.mess = "Success";
                    result.status = true;
                    Helper.WriteLog("card.CardNo " + card.CardNo);
                }
            }

            if (status != 0 && status != 1)
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
            byte[] cardInformation = new byte[128];
            status = ProUsbNewSDK.CardErase(ProGetDLLVersion(), getHotelId(), cardInformation);

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
            var queryString = "SELECT TOP 1 RoomNo FROM RoomInfo";
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
                    //Settings.Default.Save();
                    //if (Settings.Default.SystemCode != reader[0].ToString())
                    //{
                    Settings.Default.SystemCode = "5";//reader[0].ToString();
                    Settings.Default.Save();
                    //}

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
            var queryString = "SELECT BldNo,FlrNo,RomID  FROM RoomInfo where RoomNo='" + roomName + "'";
            Helper.WriteLog("queryString: " + queryString);
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

                        string BldNo = reader[0].ToString();
                        string FlrNo = reader[1].ToString();
                        string RomID = reader[2].ToString(); 

                        lockNo = BldNo.ToString().PadLeft(2, '0') + FlrNo.ToString().PadLeft(2, '0') +
                            RomID.ToString().PadLeft(2, '0');// +
                                                             //RomID2.ToString().PadLeft(2, '0');
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

            card.DepartureDate = request.DepartureDate.ToString("yyMMddHHmm");
            card.ArrivalDate = request.ArrivalDate.ToString("yyMMddHHmm");
            result.card = card;
            return result;
        }

        public static Int32 getHotelId()
        {
            Int32 hotelId = 0;
            hotelId = Int32.Parse(Settings.Default.HotelCode);
            Helper.WriteLog("Function getHotelId=>scardInformation=" + hotelId.ToString());
            return hotelId;
        }

        public static byte ProGetDLLVersion()
        {
            int result = 0;
            byte[] types = new byte[20];
            string versionDLL = "";
            int i, st;
            byte fUSB = 1;
            result = ProUsbNewSDK.GetDLLVersion(types);

            if (result == 0)
            {
                for (i = 0; i < 20; i++)
                {
                    versionDLL = versionDLL + ((char)types[i]).ToString();
                } 
            }
            Helper.WriteLog("Function ProGetDLLVersion=>Version=" + versionDLL);

            if (versionDLL.ToUpper().IndexOf("PROUSB") >= 0) fUSB = 1;
            else fUSB = 0;

            return fUSB;
        }

    }
}
