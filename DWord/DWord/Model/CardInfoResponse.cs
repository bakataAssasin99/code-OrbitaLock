using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DWord.Model
{
    public class CardInfoResponse
    {
        public int Result { get; set; } //0:success;1:fail
        public string RoomName { get; set; }
        public string TravellerName { get; set; }
        public string TravellerId { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public DateTime? DepartureDate { get; set; }
        public string cardNumber { get; set; }
        public string Message { get; set; }
    }
}
