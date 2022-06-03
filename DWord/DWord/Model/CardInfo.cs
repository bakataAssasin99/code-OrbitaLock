using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DWord.Model
{
    public class CardInfo
    {
        public string RoomName { get; set; }
        public string TravellerName { get; set; }
        public string TravellerId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public bool OverrideOldCards { get; set; }
    }
}
