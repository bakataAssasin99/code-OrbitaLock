using DWord.Constant;
using DWord.Model;
using DWord.Properties; 
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace DWord.Services
{
    [Obsolete]
    public class MainService : ServiceBase<CardInfo>
    { 
        protected override object Run(CardInfo request)
        { 
            var responseforPMS = new CardInfoResponse { Result = 1 }; //0: OK
            var result = new ResultReadCard();
            
            int port = int.Parse( (Settings.Default.COMPort == null || Settings.Default.COMPort == "") ? "0": Settings.Default.COMPort);
            bool isUseDupKey = bool.Parse(ConfigurationManager.AppSettings["isUseDupKey"]);
            Card card = new Card();
            int[] cardno = new int[1];
            try
            {
                switch (this.Request.PathInfo)
                {
                    case "/readcard":
                        result = LockService.ReadCard(port);
                        if (result.status)
                        {
                            responseforPMS.Result = 0;
                            responseforPMS.cardNumber = result.card.CardNo;
                            //responseforPMS.TravellerId = (Settings.Default.LockSystem == ConstLock.HUNE09_CODE) ? result.card.CardNo : CardInfoService.GetReservationRoomId(result.card.RoomNo);
                            if(Settings.Default.LockSystem == ConstLock.HUNE09_CODE)
                            {
                                responseforPMS.TravellerId = result.card.CardNo;
                            }
                            else if(Settings.Default.LockSystem == ConstLock.ORBITA_CODE)
                            {
                                responseforPMS.TravellerId = CardInfoService.getReservationRoomIdForOrbitaLock(result.card.RoomName,((DateTime)result.card.ArrivalDateTime).ToString("yyyyMMddHHmmss"));
                            }
                            else
                            {
                                responseforPMS.TravellerId = CardInfoService.GetReservationRoomId(result.card.RoomNo);
                            }
                        }
                        else
                        {
                            responseforPMS.Result = 1;
                            responseforPMS.Message = result.mess;
                        }

                        break;
                    case "/writecard":
                        #region Validation request data
                        if (!int.TryParse(request.TravellerId, out cardno[0]))
                        {
                            responseforPMS.Result = 1;
                            responseforPMS.Message = "Dữ liệu đầu vào không hợp lệ";
                            return responseforPMS;
                        }
                        #endregion
                        
                        var resultCardBuild = new ResultReadCard();
                        resultCardBuild = LockService.Cardbuilder(request);

                        if (resultCardBuild.status)
                        {

                            
                            result = LockService.WriteCard(port, resultCardBuild.card, isUseDupKey);

                            responseforPMS.Result = (result.status) ? 0 : 1;
                            responseforPMS.Message = result.mess;
                            responseforPMS.cardNumber = (result.card == null)? "" : result.card.CardNo;
                            if (result.status)
                            {
                                CardInfoService.SetReservationRoomId(resultCardBuild.card.RoomNo, request.TravellerId);
                            }
                        }
                        else
                        {
                            responseforPMS.Result = 1;
                            responseforPMS.Message = resultCardBuild.mess;
                        }
                        break;

                    case "/deletecard":
                        var resultCardBuildDelete = new ResultReadCard();
                        resultCardBuild = LockService.Cardbuilder(request);

                        result = LockService.DeleteCard(port, resultCardBuildDelete.card);
                        responseforPMS.Result = (result.status) ? 1 : 0;
                        responseforPMS.Message = result.mess;
                        
                        break;
                    default:
                        break;
                }

                Helper.WriteLog("reservationRoomId " + request.TravellerId);
            }
            catch (Exception ex)
            {
                Helper.WriteLog("err: " + ex.StackTrace + " - " + ex.ToString());
            }

            return responseforPMS;
        }
    }
}
