using DWord.Constant;
using DWord.Model;
using DWord.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace DWord.Services
{
    public class CardInfoService
    {
        public static string GetReservationRoomId(string roomName)
        {
            string reservaionRoomId = "";
            string[] ReservationRoomLines = System.IO.File.ReadAllLines("ReservationRoomId.txt");
            foreach (string line in ReservationRoomLines)
            {
                // Use a tab to indent each line of the file.
                string[] words = line.Split('_');
                if (words.Length > 1)
                {
                    if (roomName.Trim() == words[0].Trim())
                    {
                        reservaionRoomId = words[1].Trim();
                    }
                }
            }
            return reservaionRoomId;
        }
        public static string getReservationRoomIdForOrbitaLock(string roomName, string cinTime)
        {
            string reservaionRoomId = "0";
            string[] ReservationRoomLines = System.IO.File.ReadAllLines("ReservationRoomId.txt");

            string sKey = roomName.Trim() + "_" + cinTime.Trim();

            File.AppendAllText("logs.txt", "\r\n sKey:=" + sKey, Encoding.ASCII);
            foreach (string line in ReservationRoomLines)
            {
                // Use a tab to indent each line of the file.
                string[] words = line.Split('=');
                File.AppendAllText("logs.txt", "\r\n line:=" + line + ",w0: " + words.Length.ToString(), Encoding.ASCII);
                if (words.Length > 1)
                {
                    File.AppendAllText("logs.txt", "\r\n line:=" + line + ",w0: " + words[0] + ", length:" + words[0].Length + ",w1:" + words[1], Encoding.ASCII);
                    if (sKey == words[0].Trim())
                    {
                        reservaionRoomId = words[1].Trim();
                        File.AppendAllText("logs.txt", "\r\n reservaionRoomId:=" + reservaionRoomId, Encoding.ASCII);

                    }
                }

            }
            return reservaionRoomId;
        }

        public static void SetReservationRoomId(string roomName, string reservationRoomId)
        {
            string logFilePath = "ReservationRoomId.txt";
            FileStream fileStream = null;
            FileInfo logFileInfo;
            logFileInfo = new FileInfo(logFilePath);
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
                fileStream.Close();
            }

            string[] ReservationRoomLines = System.IO.File.ReadAllLines(logFilePath);
            string ReservationRoomValue = "";
            string sKey = roomName.Trim();
            foreach (string line in ReservationRoomLines)
            {
                if (line == "")
                {
                    continue;
                }
                // Use a tab to indent each line of the file.
                string[] words = line.Split('_');
                if (words.Length > 0)
                {
                    if (words[0] != roomName)
                    {
                        ReservationRoomValue += "\r\n" + line;
                    }
                }
            }
            ReservationRoomValue += "\r\n" + sKey + "_" + reservationRoomId;
            System.IO.File.WriteAllText(logFilePath, ReservationRoomValue);
        }

        public static ResultReadCard Cardbuilder(CardInfo request)
        {
            var card = new Card();
            var result = new ResultReadCard {status = true};
            
            return result;
        }

        public static string MapRoomName(string roomName)
        {
            roomName = roomName.Trim();
            var roomAddress = "";

            try
            {
                var text = File.ReadAllText("room.json");
                var mydictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
                mydictionary.TryGetValue(roomName, out roomAddress);

                if (!string.IsNullOrEmpty(roomAddress))
                {
                    return roomAddress;
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog("Not map lockNo: " + roomName);
                Helper.WriteLog("err: " + ex.ToString());
            }

            return roomName;
        }

        public static string MapLiftNo(string liftName)
        {
            liftName = liftName.Trim();
            var liftAddress = "";

            try
            {
                var text = File.ReadAllText("liftNo.json");
                var mydictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
                mydictionary.TryGetValue(liftName, out liftAddress);

                if (!string.IsNullOrEmpty(liftAddress))
                {
                    return liftAddress;
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog("Not map LiftNo: " + liftName);
                Helper.WriteLog("err: " + ex.ToString());
            }
            return liftName;
        }

        public static string MapCardNo(string roomName, string roomNo)
        {
            roomName = roomName.Trim();
            var roomAddress = "";

            try
            {
                var text = File.ReadAllText("roomNo.json");
                var mydictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
                mydictionary.TryGetValue(roomName, out roomAddress);

                if (!string.IsNullOrEmpty(roomAddress))
                {
                    Helper.WriteLog("roomAddress: " + roomAddress);
                    return roomAddress;
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog("Not map lockNo: " + roomName);
                Helper.WriteLog("err: " + ex.ToString());
            }
            return roomNo;
        }

        

        private static ResultReadCard GetLockNoSQL(string roomName)
        {
            var lockNo = "";
            var result = new ResultReadCard { status = false, card = new Card() };

            try
            {
                string sqlconnectStr = $"Data Source={Settings.Default.Database};initial catalog=Adel9200;persist security info=True; Integrated Security=SSPI;";
                SqlConnection connection = new SqlConnection(sqlconnectStr);
                connection.Open();

                var query = "";

                if (bool.Parse(ConfigurationManager.AppSettings["SqlOldVersion"]))
                {
                    query = $"select top 1 LockNo ,CommonDoor ,LiftFloor from roominfo where Lockname like '%{roomName}'";
                }
                else
                {
                    query = $"select top(1) LockNo ,CommonDoor ,LiftFloor from roominfo where Lockname like '%{roomName}'";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        // Đọc kết quả
                        while (reader.Read())
                        {
                            result.card.RoomNo = reader[0].ToString();
                            result.card.CommonDoor = reader[1].ToString();
                            result.card.LiftFloor = reader[2].ToString();
                            result.status = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.status = false;
                result.mess = ex.StackTrace;
                Helper.WriteLog("GetLockNo err: " + ex.StackTrace);
            }

            return result;
        }

        public static string CharToString(char[] arr)
        {
            string str = new string(arr);
            int pos = str.IndexOf('\0');
            if (pos >= 0)
                str = str.Substring(0, pos);
            return str;
        }

        public static string ByteToString(byte[] arr, int lengthArray = 0)
        {
            string str = "";
            int i;
            lengthArray = lengthArray == 0 ? arr.Length : lengthArray;
            for (i = 0; i < lengthArray; i++)
            {
                if (arr[i] != null) {
                    str = str + ((char)arr[i]).ToString();
                }
            }

            return str;
        }

        public static string CharToString2(char[] arr, int number)
        {
            string str = new string(arr); 
                str = str.Substring(0, number);
            return str;
        }

        public static char[] CharFromString(string str)
        {
            if (string.IsNullOrEmpty(str))
                return new char[1];
            return ASCIIEncoding.ASCII.GetChars(ASCIIEncoding.ASCII.GetBytes(str));
        }
    }
}
