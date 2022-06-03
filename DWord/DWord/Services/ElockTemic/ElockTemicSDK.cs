using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text; 

namespace DWord.Services.ElockTemic
{
    class ElockTemicSDK
    {
        [DllImport("cyrf32.dll")]
        public static extern int ReadCard(StringBuilder HotelID, StringBuilder cardtype, StringBuilder cardid, StringBuilder changkai, StringBuilder roomcode, StringBuilder begindate, StringBuilder enddate);
        [DllImport("cyrf32.dll")]
        public static extern int WriteCard(string HotelID, string cardtype, string cardid, string changkai, string roomcode, string begindate, string enddate);
        //public static extern int WriteCard(StringBuilder HotelID, StringBuilder cardtype, StringBuilder cardid, StringBuilder changkai, StringBuilder roomcode, StringBuilder begindate, StringBuilder enddate);
        //public static extern int WriteCard(char* HotelID, char* CardType, char* CardID, char* NormalOpenClose, char* RoomCD, char* CardBeginDateTime, char* CardEndDateTime)
    }
}
