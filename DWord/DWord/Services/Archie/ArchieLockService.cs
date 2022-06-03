using DWord.Model;
using DWord.Model.Archie;
using DWord.Properties;
using DWord.Services.Archie;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace DWord.Services.ARCHIE
{
    class ArchieLockService
    { 
        public static ResultReadCard StartSession(int port, int Software)
        {
            ResultReadCard result = new ResultReadCard();
            int r = 6;// ArchieLockSDK.MF_Rewrite_AutCode(1);
            bool status = ArchieLockSDK.MF_OpenConnection(port, Software);

            if (r==6 && status)
            {
                result.mess = "Kết nối thành công";
                result.status = true;
            }
            else
            {
                result.mess = (r != 6)?("Xác thực thất bại. Mã lỗi "+r): "Port hiện tại Không mở được, vui lòng đặt một cổng nối khác!";
                result.status = false;
            }
            
            return result;
        }

        public static ResultReadCard WriteCard(int port, Card card, bool isOverWrite)
        {
            int DefaultBreakfast = 1,
                DefaultOverflag = 1;
            ResultReadCard result = new ResultReadCard();
            int CardNo = 0;// card.CardNo;
            int status;
            card.IDNo = "";
            card.LiftFloor = "";
            card.CommonDoor = "";

            CardNo = 0;
            Helper.WriteLog("___WRITECARD___ ");
            Int32[] InfoData = new Int32[7];
            InfoData[0] = 0;
            InfoData[1] = int.Parse(card.CardNo);
            InfoData[2] = ArchieLockSDK.MF_GetFlag(Convert.ToInt32(true),Convert.ToInt32(true) , Convert.ToInt32(true), 0);

            InfoData[3] = 0;
            InfoData[4] = int.Parse(card.LiftFloor);
            InfoData[5] = int.Parse(card.RoomNo);
            byte[] suite = new byte[8];
            suite[0] = Convert.ToByte(true);
            suite[1] = Convert.ToByte(true);
            suite[2] = Convert.ToByte(true);
            suite[3] = Convert.ToByte(true);
            suite[4] = Convert.ToByte(true);
            suite[5] = Convert.ToByte(true);
            suite[6] = Convert.ToByte(true);
            suite[7] = Convert.ToByte(true);
            InfoData[6] = ArchieLockSDK.MF_GetSuite(ref suite[0]);
            DateTime sTime = DateTime.Parse(card.ArrivalDate); // yyyy-MM-dd HH:mm:ss
            DateTime eTime = DateTime.Parse(card.DepartureDate); // yyyy-MM-dd HH:mm:ss

            if (isOverWrite)
            {
                status = ArchieLockSDK.MF_W_CommonCard(ref InfoData[0], sTime, eTime);
            }
            else
            {
                status = ArchieLockSDK.MF_W_CommonCard(ref InfoData[0], sTime, eTime);
            }

            Helper.WriteLog("status " + status.ToString() + " CardNo " + CardNo.ToString());
            if (status >= 6)
            {
                result.mess = "Success";
                result.status = true;
                result.card = new Card { CardNo = CardNo.ToString() };
            }
            else
            {
                result.mess = "Failed to write card!";
                result.status = false;
            }

            return result;
        }

        public static ResultReadCard ReadCard()
        {
            Helper.WriteLog("___ReadCard___ ");
            Card card = new Card();
            ResultReadCard result = new ResultReadCard();

            Int32[] InfoData = new Int32[7];
            DateTime sTime, eTime;
            int status = ArchieLockSDK.MF_R_CommonCard(ref InfoData[0], out sTime, out eTime);

            if (status >= 6)
            {
                card.CardNo = InfoData[1].ToString();
                card.LiftFloor = InfoData[3].ToString();
                card.RoomNo = InfoData[5].ToString();
                 
                result.card = card;
                result.mess = "Success";
                result.status = true;
                Helper.WriteLog("card.CardNo " + card.CardNo);
                Helper.WriteLog("card.RoomNo " + card.RoomNo);
            }
            else
            {
                result.mess = "Fail";
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

            // GET RoomNo CommonDoor LiftFloor
            var isMapRoomName = bool.Parse(ConfigurationManager.AppSettings["isMapRoomName"]);
            if (isMapRoomName)
            {
                request.RoomName = CardInfoService.MapRoomName(request.RoomName);
            }

            ItemRoom itemRoom = GetLockNoXML(request.RoomName);
            if (itemRoom != null)
            {
                card.RoomNo = itemRoom.roomno;
                card.CommonDoor = itemRoom.blockno;
                card.LiftFloor = itemRoom.floorno;
            }
            else
            {
                return resultgetInfoRoom;
            }

            var isMapRoomNo = bool.Parse(ConfigurationManager.AppSettings["isMapRoomNo"]);
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

            card.DepartureDate = request.DepartureDate.ToString("yyyy-MM-dd HH:mm:ss");
            card.ArrivalDate = request.ArrivalDate.ToString("yyyy-MM-dd HH:mm:ss");
            result.card = card;
            return result;
        }

        public static bool CheckConnectAccessFile(string url)
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            string str = null;
            try
            {
                FileStream fs = new FileStream(url + "lockstate.xml", FileMode.Open, FileAccess.Read);
                xmldoc.Load(fs);
                xmlnode = xmldoc.GetElementsByTagName("root");
                for (i = 0; i <= xmlnode.Count - 1; i++)
                {
                    str = xmlnode[i].ChildNodes.Item(2).InnerText.Trim();
                    if (str != null)
                    {
                        Settings.Default.LockFolder = url;
                        Settings.Default.Save();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog("err:" + ex.ToString());
            }

            return false;
        }

        public static ItemRoom GetLockNoXML(string roomName)
        {
            var lockNo = "";
            ItemRoom item = null;
            XmlReader xReader = XmlReader.Create(new StringReader(Settings.Default.LockFolder + "lockstate.xml")); 

            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            string str = null;
            FileStream fs = new FileStream(Settings.Default.LockFolder + "lockstate.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("root");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                str = xmlnode[i].ChildNodes.Item(2).InnerText.Trim();
                if(roomName.Trim().ToUpper() == str.ToUpper())
                {
                    item.blockno = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                    item.floorno = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                    item.roomno = xmlnode[i].ChildNodes.Item(2).InnerText.Trim();
                    item.currentaddress = xmlnode[i].ChildNodes.Item(11).InnerText.Trim();
                }
            }

            return item;
        }

        /*
                public static ResultReadCard EndSession()
                {
                    uint status;
                    ResultReadCard result = new ResultReadCard();

                    status = LockSDK.EndSession();

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


                public static ResultReadCard ReadCardID(int port)
                {
                    Helper.WriteLog("___ReadCardID___ ");
                    ResultReadCard result = new ResultReadCard();
                    uint status;
                    Card card = new Card();

                    status = LockSDK.ReadCardID(port, Convert.ToInt32(card.CardNo));

                    if (status == 0)
                    {
                        result.card = card;
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

                public static ResultReadCard ReadCard(int port)
                {
                    Helper.WriteLog("___ReadCard___ ");
                    Card card = new Card();
                    StringBuilder roomNo = new StringBuilder("", 64),
                        commonDoor = new StringBuilder("", 128),
                        liftFloor = new StringBuilder("", 128),
                        timeStr = new StringBuilder("", 64),
                        holder = new StringBuilder("", 64),
                        idNo = new StringBuilder("", 64);
                    int CardNo = 0, Breakfast = 0, CardStatus = 0;
                    ResultReadCard result = new ResultReadCard();
                    uint status;

                    status = LockSDK.ReadKeyCard(port, roomNo, commonDoor, liftFloor, timeStr, holder, idNo, ref CardNo, ref CardStatus, ref Breakfast);

                    if (status == 0)
                    {
                        card.RoomNo = roomNo.ToString();
                        card.CommonDoor = commonDoor.ToString();
                        card.LiftFloor = liftFloor.ToString();
                        card.TimeStr = timeStr.ToString();
                        card.Holder = holder.ToString();
                        card.IDNo = idNo.ToString();
                        card.CardNo = CardNo.ToString();
                        card.CardStatus = CardStatus;
                        card.Breakfast = Breakfast;
                        result.card = card;
                        result.mess = "Success";
                        result.status = true;
                        Helper.WriteLog("card.CardNo " + card.CardNo);
                        Helper.WriteLog("card.RoomNo " + card.RoomNo);
                    }
                    else
                    {
                        result.mess = ResultToMess(status);
                        result.status = false;
                    }

                    return result;
                }

                public static ResultReadCard DeleteCard(int port)
                {
                    ResultReadCard result = new ResultReadCard();
                    uint status;

                    status = LockSDK.EraseKeyCard(port, 0);
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

                public static string ResultToMess(uint status)
                {
                    string mess = "";

                    switch (status)
                    {
                        case 0x00000000:
                            mess = "Successful Operation";
                            break;
                        case 0x8010000C:
                            mess = "8010000C IC car not find";
                            break;
                        case 0x80100069:
                            mess = "80100069 Card removed";
                            break;
                        case 0x81100001:
                            mess = "81100001 Password erro";
                            break;
                        case 0x81100002:
                            mess = "81100002 Card damaged";
                            break;
                        case 0x81300001:
                            mess = "81300001 Communication erro";
                            break;
                        case 0xFFFF0001:
                            mess = "FFFF0001 Card type erro";
                            break;
                        case 0xFFFF0002:
                            mess = "FFFF0002 Card replaced";
                            break;
                        case 0xFFFF0003:
                            mess = "FFFF0003 Blank card";
                            break;
                        case 0xFFFF0004:
                            mess = "FFFF0004 Illegle card";
                            break;
                        case 0xFFFF0005:
                            mess = "FFFF0005 Group Card";
                            break;
                        case 0xFFFF0006:
                            mess = "FFFF0006 Blank group card";
                            break;
                        case 0xFFFF0007:
                            mess = "FFFF0007 Not blank card";
                            break;
                        case 0xFFFF0008:
                            mess = "FFFF0008 COM Port open erro";
                            break;
                        case 0xFFFF0009:
                            mess = "FFFF0009 COM Port open erro";
                            break;
                        case 0xFFFF1001:
                            mess = "FFFF1001 Initialization function was not invoked";
                            break;
                        case 0xFFFF1002:
                            mess = "FFFF1002 Defined guest not exist";
                            break;
                        case 0xFFFF1003:
                            mess = "FFFF1003 Card info not exist";
                            break;
                        case 0xFFFF1004:
                            mess = "FFFF1004 Not guest ard";
                            break;
                        case 0xFFFF1005:
                            mess = "FFFF1005 Wrong room no";
                            break;
                        case 0xFFFF1006:
                            mess = "FFFF1006 Wrong common door";
                            break;
                        case 0xFFFF3000:
                            mess = "FFFF3000 SQL execution erro";
                            break;
                        case 0xFFFF3001:
                            mess = "FFFF3001 SQL connect erro";
                            break;
                        case 0xFFFF3002:
                            mess = "FFFF3002 System Parameter not exist";
                            break;
                        case 0xFFFF3003:
                            mess = "FFFF3003 0xFFFF3003 Wrong Serial Number";
                            break;
                        case 0xFFFF4000:
                            mess = "FFFF4000 Interface authentication code not exist";
                            break;
                        case 0xFFFF4001:
                            mess = "FFFF4001 Wrong interface authentication code";
                            break;
                    }

                    return mess;
                }

                public static bool CheckConnectAccessFile(string url)
                {
                    string password = ConstFileAccess.DWORD_PASS;
                    string fileDb = ConstFileAccess.DWORD_FILE_NAME;
                    var queryString = "SELECT TOP 1 LOCKNO FROM Room";
                    var ConnectionString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={url}" + fileDb + ";Jet OLEDB:Database Password=" + password + ";";

                    Helper.WriteLog("CommunicationClass.ConnectionString 1: " + ConnectionString);

                    using (var connection = new OleDbConnection(ConnectionString))
                    using (var command = new OleDbCommand(queryString, connection))
                    {
                        try
                        {
                            connection.Open();
                            var reader = command.ExecuteReader();
                            reader.Close();
                            Helper.WriteLog("Connect DB SUCCESS");
                            Settings.Default.ConnectionString = ConnectionString;
                            Settings.Default.LockFolder = url;
                            Settings.Default.Save();

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
                    var queryString = $"Select LOCKNO from Room where PMSNO = '{roomName}'";
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

                    card.TimeStr = request.ArrivalDate.ToString("yyyyMMddHHmm") + request.DepartureDate.ToString("yyyyMMddHHmm");
                    result.card = card;
                    return result;
                }*/
    }
}
