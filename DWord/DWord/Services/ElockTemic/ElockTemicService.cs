using DWord.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text; 

namespace DWord.Services.ElockTemic
{
    class ElockTemicService
    {
        public static ResultReadCard StartSession()
        {
            int status;
            ResultReadCard result = new ResultReadCard();

            Helper.WriteLog("Starting ConnecToLock");
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            StringBuilder stringBuilder3 = new StringBuilder();
            StringBuilder stringBuilder4 = new StringBuilder();
            StringBuilder stringBuilder5 = new StringBuilder();
            StringBuilder stringBuilder6 = new StringBuilder();
            string text = ConfigurationManager.AppSettings["HotelCode"].ToString();
            StringBuilder hotelID = new StringBuilder(text);
            status = ElockTemicSDK.ReadCard(hotelID, stringBuilder, stringBuilder2, stringBuilder3, stringBuilder4, stringBuilder5, stringBuilder6);
            Helper.WriteLog("result: " + result.ToString());
            Helper.WriteLog("hotelApp: " + text);
            Helper.WriteLog("cardtype: " + stringBuilder.ToString());
            Helper.WriteLog("cardid: " + stringBuilder2.ToString());
            Helper.WriteLog("changkai: " + stringBuilder3.ToString());
            Helper.WriteLog("roomcd: " + stringBuilder4.ToString());
            Helper.WriteLog("begdate: " + stringBuilder5.ToString());
            Helper.WriteLog("enddate: " + stringBuilder6.ToString()); 

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

        public static ResultReadCard WriteCard(Card card, bool isOverWrite)
        {
            ResultReadCard result = new ResultReadCard(), resultReadCard = new ResultReadCard();
            int status;

            Helper.WriteLog("___WRITECARD___ ");
/*
            StringBuilder roomCode = new StringBuilder(card.RoomNo.ToString());
            StringBuilder startDate = new StringBuilder(card.ArrivalDateTime.Value.ToString("yyMMddHHmm"));
            StringBuilder endDate = new StringBuilder(card.DepartureDateTime.Value.ToString("yyMMddHHmm"));
            StringBuilder cardType = new StringBuilder("G");
            StringBuilder cardId = new StringBuilder("FFFFFF");
            StringBuilder changKai = new StringBuilder("Y");
            StringBuilder value = new StringBuilder(ConfigurationManager.AppSettings["HotelCode"].ToString());
            StringBuilder hotelId = new StringBuilder(value.ToString());*/
            string roomCode = card.RoomNo.ToString();
            string startDate = card.ArrivalDateTime.Value.ToString("yyMMddHHmm");
            string endDate = card.DepartureDateTime.Value.ToString("yyMMddHHmm");
            string cardType = "G";
            string cardId = "FFFFFF";
            string changKai = "Y";
            string value = ConfigurationManager.AppSettings["HotelCode"].ToString();
            string hotelId = value.ToString();

            status = ElockTemicSDK.WriteCard(hotelId, cardType, cardId, changKai, roomCode, startDate, endDate);

            Helper.WriteLog("result: " + result.ToString());
            Helper.WriteLog("p_hotelApp: " + hotelId.ToString());
            Helper.WriteLog("p_roomCode: " + roomCode.ToString());
            Helper.WriteLog("p_startDate: " + startDate.ToString());
            Helper.WriteLog("p_endDatee: " + endDate.ToString());
            Helper.WriteLog("cardtype: " + cardType.ToString());
            Helper.WriteLog("cardid: " + cardId.ToString());
            Helper.WriteLog("changkai: " + changKai.ToString()); 
              
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
                Helper.WriteLog("Write card fail: " + status + " " + result.mess.ToString());
            }

            return result;
        }

        public unsafe static ResultReadCard ReadCard()
        {
            Helper.WriteLog("___ReadCard___ ");
            Card card = new Card();
            ResultReadCard result = new ResultReadCard();

            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder cardId = new StringBuilder();
            StringBuilder changKai = new StringBuilder();
            StringBuilder beginDate = new StringBuilder();
            StringBuilder roomCode = new StringBuilder();
            StringBuilder endDate = new StringBuilder();
            string text = ConfigurationManager.AppSettings["HotelCode"].ToString();
            StringBuilder hotelID = new StringBuilder(text);
            int status = ElockTemicSDK.ReadCard(hotelID, stringBuilder, cardId, changKai, roomCode, beginDate, endDate); 
             
            Helper.WriteLog("result: " + result.ToString()); 
            Helper.WriteLog("hotelApp: " + text);
            Helper.WriteLog("cardtype: " + stringBuilder.ToString());
            Helper.WriteLog("cardid: " + cardId.ToString());
            Helper.WriteLog("changkai: " + changKai.ToString());
            Helper.WriteLog("roomcd: " + roomCode.ToString());
            Helper.WriteLog("begdate: " + beginDate.ToString());
            Helper.WriteLog("enddate: " + endDate.ToString());

            if (status == 0)
            {
                Helper.WriteLog("ReadCard status " + status);
                card.CardNo = cardId.ToString();
                card.RoomNo = roomCode.ToString();
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

            Helper.WriteLog("_____DeleteCard_____"); 

            /*StringBuilder roomCode = new StringBuilder("");
            StringBuilder startDate = new StringBuilder(DateTime.Now.ToString("yyMMddHHmm"));
            StringBuilder endDate = new StringBuilder(DateTime.Now.AddDays(1.0).ToString("yyMMddHHmm"));
            StringBuilder cardType = new StringBuilder("Q");
            StringBuilder cardId = new StringBuilder("FFFFFF");
            StringBuilder changKai = new StringBuilder("N");
            StringBuilder value = new StringBuilder(ConfigurationManager.AppSettings["HotelCode"].ToString());
            StringBuilder hotelId = new StringBuilder(value.ToString());*/

            string roomCode = "";
            string startDate = DateTime.Now.ToString("yyMMddHHmm");
            string endDate = DateTime.Now.AddDays(1.0).ToString("yyMMddHHmm");
            string cardType = "Q";
            string cardId = "FFFFFF";
            string changKai = "N";
            string value = ConfigurationManager.AppSettings["HotelCode"].ToString();
            string hotelId = value.ToString();

            int status = ElockTemicSDK.WriteCard(hotelId, cardType, cardId, changKai, roomCode, startDate, endDate);

            Helper.WriteLog("result: " + result.ToString()); 

            if (status==0)
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
             

            var isMapRoomNo = bool.Parse(ConfigurationManager.AppSettings["isMapRoomNo"]);
            Helper.WriteLog("isMapRoomNo " + isMapRoomNo);
            if (isMapRoomNo)
            {
                card.RoomNo = CardInfoService.MapCardNo(request.RoomName, card.RoomNo);
            }
            else
            {
                string cardno = GetRoomCode(request.RoomName);
                if (cardno != null && cardno.Length > 0)
                {
                    card.RoomNo = cardno;
                }
                else
                {
                    return resultgetInfoRoom;
                }
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

        public static string GetRoomCode(string roomName)
        {
            roomName = roomName.Trim();
            string result = "";
            string[] array = File.ReadAllLines(ConfigurationManager.AppSettings["roomCodeFile"]);
            char[] separator = new char[]
            {
        '\t'
            };
            string[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                string text = array2[i];
                string[] array3 = text.Split(separator);
                bool flag = array3.Length >= 2;
                if (flag)
                {
                    bool flag2 = roomName == array3[0].Trim();
                    if (flag2)
                    {
                        result = array3[1].Trim();
                        break;
                    }
                }
            } 

            result = "010100008900";
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
                case 11:
                    mess = "not connected to the Card Encoder";
                    break;
                case 12:
                    mess = "card data error";
                    break;
                case 13:
                    mess = "card password checksum error or not put the card";
                    break;
                case 14:
                    mess = "Error";
                    break;
                case 15:
                    mess = "write the data length is out of range";
                    break;
                case 16:
                    mess = "Card Encoder unresponsive";
                    break;
                case 17:
                    mess = "Illegal Operation";
                    break;
                case 18:
                    mess = "written to the card data checksum error/non-local hotel guest card";
                    break;
                case 19:
                    mess = "card data error";
                    break;
            }

            return mess;
        }
    }
}
