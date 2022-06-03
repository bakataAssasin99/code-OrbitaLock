using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DWord.Model
{
    public class Card
    {
        public string? CardNo { get; set; } 
        public string RoomNo { get; set; }
        public string? RoomName { get; set; }
        public string CommonDoor { get; set; }
        public string IDNo { get; set; }
        public string Holder { get; set; }
        public string LiftFloor { get; set; }
        public string TimeStr { get; set; }
        public string? ArrivalDate { get; set; }
        public DateTime? ArrivalDateTime { get; set; }
        public string? DepartureDate { get; set; }
        public DateTime? DepartureDateTime { get; set; }
        public int Breakfast { get; set; }
        public int CardStatus { get; set; }

        public string? FloorName { get; set; }

        public string? auth { get; set; }
        
    }
}
