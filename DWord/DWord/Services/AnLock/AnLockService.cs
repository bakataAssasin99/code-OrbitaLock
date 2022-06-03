using DWord.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text; 

namespace DWord.Services.AnLock
{
    class AnLockService
    {
        public static ResultReadCard OpenPortUsb(int fusb)
        {
            ResultReadCard result = new ResultReadCard();

            int status =  AnLockSDK.OpenUsb(fusb);
            Helper.WriteLog("___OpenPortUsb___ ");
            if ( status == 1)
            {
                result.mess = "Kết nối thành công";
                result.status = true;
            }
            else
            {
                result.mess = ResultToMess(status); ;
                result.status = false;
            }
            Helper.WriteLog("status "+ status);

            return result;
        }
        public static ResultReadCard WriteCard(Card card)
        { 
            ResultReadCard result = new ResultReadCard();
            int CardNo = 0; 
            int status; 

            CardNo = 0;
            Helper.WriteLog("___WRITECARD___ "); 

            status = AnLockSDK.DLL_WriteCard(card.Holder);
            
            Helper.WriteLog("card.Holder " + card.Holder.ToString() + " status "+ status.ToString());
            if (status == 1)
            {
                ResultReadCard resultRead = new ResultReadCard();
                resultRead = AnLockService.ReadCard();
                
                result.mess = "Success";
                result.status = true;
                result.card = new Card { 
                    CardNo = resultRead.card.CardNo.ToString(), 
                    RoomNo = resultRead.card.RoomNo.ToString() };
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
            bool isUseDupKey = bool.Parse(ConfigurationManager.AppSettings["isUseDupKey"]);
            var card = new Card();
            var result = new ResultReadCard { status = true };
            var resultgetInfoRoom = new ResultReadCard { status = true };
            var addMinuteTimeCheckout = int.Parse(ConfigurationManager.AppSettings["addMinuteTimeCheckout"].ToString());
             
            var isMapRoomName = bool.Parse(ConfigurationManager.AppSettings["isMapRoomName"]);
            if (isMapRoomName)
            {
                request.RoomName = CardInfoService.MapRoomName(request.RoomName);
            }
            card.RoomNo = request.RoomName;
            Helper.WriteLog("card.RoomNo " + card.RoomNo);

            // GET Holder
            //card.Holder = request.TravellerName;

            card.IDNo = "null";
            card.CardNo = null;

            // GET TimeStr
            if (request.ArrivalDate < DateTime.Now)
            {
                request.ArrivalDate = DateTime.Now;
            }
            
            if (request.DepartureDate < DateTime.Now)
            {
                request.ArrivalDate = DateTime.Now;
                request.DepartureDate = DateTime.Now.AddMinutes(1 + addMinuteTimeCheckout);
            }
            else
            {
                request.DepartureDate = request.DepartureDate.AddMinutes(addMinuteTimeCheckout);
            }

            card.DepartureDate = request.DepartureDate.ToString("yyyyMMdd_HH:mm");
            card.ArrivalDate = request.ArrivalDate.ToString("yyyyMMdd_HH:mm");

            string strWrite = "";
            strWrite += "|RC" + request.RoomName;
            strWrite += (isUseDupKey) ? "|ESwitchALL" : "|EndOldCard|ESwitchALL";
            strWrite += "|StartDT"+ card.ArrivalDate + "|EndDT"+ card.DepartureDate;

            card.Holder = strWrite;
            result.card = card;
            return result;
        }

        public static ResultReadCard ReadCard()
        {
            Helper.WriteLog("___ReadCard___ ");
            Card card = new Card();
            ResultReadCard result = new ResultReadCard();

            Int32[] InfoData = new Int32[7];
            DateTime sTime, eTime; 
            char[] resultRead = new char[128];
            int status = AnLockSDK.DLL_Read(resultRead);
            string resultReadText = CharToString(resultRead);

            Helper.WriteLog("status " + status.ToString()+ "  resultRead "+ resultReadText);

            if (status == 1)
            {
                string[] cardInfoList = resultReadText.Split('|');
                

                card.CardNo = cardInfoList[1].ToString().Replace("CardNo", "");
                card.LiftFloor = "0";
                card.RoomNo = cardInfoList[3].Replace("RC", "");

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

        public static string CharToString(char[] arr)
        {
            string text = new string(arr);
            int num = text.IndexOf('\0');
            bool flag = num >= 0;
            if (flag)
            {
                text = text.Substring(0, num);
            }
            return text;
        }

        public static ResultReadCard DeleteCard()
        {
            ResultReadCard result = new ResultReadCard();
            int status; 
            status = AnLockSDK.DLL_WriteCard("");

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
                    mess = "Card Invalid";
                    break;
                case -3:
                    mess = "Card reader failure";
                    break;
                case -16:
                    mess = "Not registered";
                    break;
                case -6:
                    mess = "Not detected issuing machine";
                    break;
                case -8:
                    mess = "Designated room card does not match";
                    break;
            }

            return mess;
        }

    }
}
