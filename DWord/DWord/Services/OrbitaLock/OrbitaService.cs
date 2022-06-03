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
using System.Threading.Tasks;

namespace DWord.Services.OrbitaLock
{
    class OrbitaService
    {
        
        public static bool CheckConnectAccessFile(string url)
        {
            
            var queryString = "SELECT TOP 1 auth_code FROM syspar";
            string password = ConstFileAccess.ORBITA_PASS;
            string fileDb = ConstFileAccess.ORBITA_FILE_NAME;
           
            var ConnectionString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={url}" + fileDb + ";Jet OLEDB:Database Password=" + password + ";";

            Helper.WriteLog("CommunicationClass.ConnectionString 1: " + ConnectionString);
            using (var connection = new OleDbConnection(ConnectionString))
            using (var command = new OleDbCommand(queryString, connection))
            {
                try
                {
                    Helper.WriteLog("CommunicationClass.ConnectionString 1: " + ConnectionString);
                    Settings.Default.ConnectionString = ConnectionString;
                    connection.Open();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        string textSystemCode = reader[0].ToString();
                        if (Settings.Default.SystemCode != reader[0].ToString())
                        {
                            Settings.Default.SystemCode = reader[0].ToString();
                            Settings.Default.Save();
                        }
                    }

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

        public static ResultReadCard WriteCard(Card card, bool isOnlyWritecard = false)
        {
            logReservationRoomId(card.RoomName, ((DateTime)(card.ArrivalDateTime)).ToString("yyyyMMddHHmm"),card.CardNo);

            if (card.FloorName.Length == 0)
            {
                if (card.RoomName.Length > 0) card.FloorName = card.RoomName.Substring(0, 1);
            }
            string arrival = string.Format("{0:yyyy-MM-dd HH:mm:ss}", card.ArrivalDateTime);
            string departure = string.Format("{0:yyyy-MM-dd HH:mm:ss}", card.DepartureDateTime);
            var auth = Settings.Default.SystemCode;
            var building = "01";//_floor_name; //KS co mot tang 
            var room = card.RoomName;
            var commdoors = card.CardNo;

            ResultReadCard result = new ResultReadCard();   
            var status= OrbitaSDK.dv_write_card(CharFromString(auth), CharFromString(building), CharFromString(room), CharFromString(commdoors), CharFromString(arrival), CharFromString(departure));
            if(status == 0)
            {
                Helper.WriteLog("Write card suceesed");

                result.mess = "Success";
                result.status = true;
            }
            else
            {
                result.mess = ResultToMess(status);
                result.status = false;
                Helper.WriteLog("Write card fail: " + status + " " + result.mess.ToString());
            }
            result.card = card;
            
            Helper.WriteLog("_____Create card obita_____");
            Helper.WriteLog("result: " + status);
            Helper.WriteLog("building: " + building);
            Helper.WriteLog("room: " + room);
            Helper.WriteLog("commdoors: " + commdoors);
            Helper.WriteLog("auth: " + auth);
            Helper.WriteLog("arrival: " + arrival);
            Helper.WriteLog("departure: " + departure);


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
            else
            {
                card.RoomName = request.RoomName;
            }
            var isMapRoomNo = bool.Parse(ConfigurationManager.AppSettings["isMapRoomNo"]);
            if (isMapRoomNo)
            {
                card.RoomNo = CardInfoService.MapCardNo(request.RoomName, card.RoomNo);
            }
            else
            {
                string roomNo = getRoomIDAccessFile(request.RoomName);
                if (roomNo != null && roomNo.Length > 0)
                {
                    card.RoomNo = roomNo;
                }
                else
                {
                    return resultgetInfoRoom;
                }
            }

            card.FloorName = getFloorNameAccessFile(request.RoomName);

            card.Holder = request.TravellerName;
            card.IDNo = null;
            card.CardNo = request.TravellerId;

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
                    mess = "Interface error";
                    break;
                case -2:
                    mess = "Connect encoder failed";
                    break;
                case -3:
                    mess = "Register encoder failed";
                    break;
                case -4:
                    mess = "Buzzer mute";
                    break;
                case -5:
                    mess = "Not supported card type";
                    break;
                case -6:
                    mess = "Wrong card password";
                    break;
                case -7:
                    mess = "Wrong supplier password";
                    break;
                case -8:
                    mess = "Wrong card type";
                    break;
                case -9:
                    mess = "Wrong authorization code";
                    break;
                case -10:
                    mess = "Find card request failed";
                    break;
                case -11:
                    mess = "Find card failed";
                    break;
                case -12:
                    mess = "Load card password failed";
                    break;
                case -13:
                    mess = "Read device information failed";
                    break;
                case -14:
                    mess = "Read card failed";
                    break;
                case -15:
                    mess = "Write card failed";
                    break;
            }

            return mess;
        }

        private static string getFloorNameAccessFile(string rommName)
        {
            string result = "";
            string fileDb = ConstFileAccess.ORBITA_FILE_NAME;
            string passDb = ConstFileAccess.ORBITA_PASS;
            var queryString = $"SELECT TOP 1 floor_name FROM room where room_name= '{rommName}'";
            var ConnectionString = Settings.Default.ConnectionString;

            using (var connection = new OleDbConnection(ConnectionString))
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

        private static string getRoomIDAccessFile(string rommName)
        {
            string result = "";
            string fileDb = ConstFileAccess.ORBITA_FILE_NAME;
            string passDb = ConstFileAccess.ORBITA_PASS;
            var queryString = $"SELECT TOP 1 id FROM room where room_name= '{rommName}'";
            var ConnectionString = Settings.Default.ConnectionString;

            using (var connection = new OleDbConnection(ConnectionString))
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
        public static char[] CharFromString(string str)
        {
            if (string.IsNullOrEmpty(str))
                return new char[1];
            return ASCIIEncoding.ASCII.GetChars(ASCIIEncoding.ASCII.GetBytes(str));
        }
        public static string CharToString(char[] arr)
        {
            string str = new string(arr);
            int pos = str.IndexOf('\0');
            if (pos >= 0)
                str = str.Substring(0, pos);
            return str;
        }

        public static ResultReadCard ReadCard()
        {
            var cardno = new char[6];
            var building = new char[200];
            var room = new char[4];
            var commdoors = new char[8];
            var arrival = new char[20];
            var departure = new char[20];
            //[In, Out] char[] auth, [In, Out] char[] cardno, [In, Out] char[] building, [In, Out] char[] room, [In, Out] char[] commdoors, [In, Out] char[] arrival, [In, Out] char[] departure
            int result = OrbitaSDK.dv_read_card(CharFromString(Settings.Default.SystemCode), cardno, building, room, commdoors, arrival, departure);

            Helper.WriteLog("_____Read card obita_____");
            Helper.WriteLog("result: " + result);
            Helper.WriteLog("cardNo: " + CharToString(commdoors));
            Helper.WriteLog("room: " + CharToString(room));
            Helper.WriteLog("auth: " + Settings.Default.SystemCode);
            Helper.WriteLog("cardno: " + cardno);
            Helper.WriteLog("building: " + CharToString(building));
            Helper.WriteLog("commdoors: " + CharToString(commdoors));
            Helper.WriteLog("arrival: " + CharToString(arrival));
            Helper.WriteLog("departure: " + CharToString(departure));


            //int result = dv_read_card(CharFromString( Settings.Default.SystemCode), cardno, building, room, commdoors, arrival, departure);
            var retval = new ResultReadCard();
            var card = new Card();
            if (result == 0)
            {
                retval.status = true;
                var date = new DateTime();
                var date2 = new DateTime();
                DateTime.TryParse(CharToString(arrival), out date);
                DateTime.TryParse(CharToString(departure), out date2);
                card.ArrivalDateTime = date;
                card.DepartureDateTime = date2;
                card.CardNo = CharToString(commdoors);
                card.RoomName = CharToString(room);
                retval.card = card;
                retval.mess = "Success";
            }
            else
            {
                retval.mess = ResultToMess(result);
                retval.status = false;
            }
            return retval;
        }
        public static void logReservationRoomId(string roomName, string cinTime, string reservationRoomId)
        {
            // Tao file ghi nhan thong tin ReservationRoomId
            string logFilePath = "ReservationRoomId.txt";
            if (roomName.Length == 1) roomName = "000" + roomName;
            if (roomName.Length == 2) roomName = "00" + roomName;
            if (roomName.Length == 3) roomName = "0" + roomName;
            if (roomName.Length > 4) roomName = roomName.Substring(1, 4);
            FileStream fileStream = null;
            FileInfo logFileInfo;
            logFileInfo = new FileInfo(logFilePath);

            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                //fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            string[] ReservationRoomLines = System.IO.File.ReadAllLines(logFilePath);
            string ReservationRoomValue = "";
            string sKey = roomName.Trim() + "_" + cinTime.Trim();
            bool flag = true;
            foreach (string line in ReservationRoomLines)
            {
                flag = true;
                // Use a tab to indent each line of the file.
                string[] words = line.Split('=');
                if (words.Length > 0)
                {
                    string value = "";
                    if (sKey.Trim() == words[0])
                    {
                        value = words[0] + "=" + reservationRoomId.ToString();
                        flag = false;
                    }
                    else value = line;
                    if (flag) ReservationRoomValue += "\r\n" + value;
                }

            }
                ReservationRoomValue += "\r\n" + sKey.Trim() + "=" + reservationRoomId.ToString();

            System.IO.File.WriteAllText(logFilePath, ReservationRoomValue);
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
    }
}
