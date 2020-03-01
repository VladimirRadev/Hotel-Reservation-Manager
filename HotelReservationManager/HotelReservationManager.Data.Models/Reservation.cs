using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationManager.Data.Models
{
    public class Reservation
    {
        public string Id { get; set; }
        public string RoomId { get; set; }
        public string HotelUserId { get; set; }
        public List<Client> Clients { get; set; }
        public DateTime DataOfIncoming { get; set; }
        public DateTime DateOfOutgoing { get; set; }
        public bool includedBreakfast { get; set; }
        public bool allInclusive { get; set; }
        public string AllAmount { get; set; }


    }
}
