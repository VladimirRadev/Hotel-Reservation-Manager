using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationManager.Web.Models.Binding
{
    public class ReservationCreateBindingModel
    {
        [Required]
        public string RoomNumber { get; set; }
        [Required]
        public string HotelUserUsername { get; set; }
        [Required]
        public DateTime DataOfIncoming { get; set; }
        [Required]
        public DateTime DateOfOutgoing { get; set; }
        [Required]
        public bool IncludedBreakfast { get; set; }
        [Required]
        public bool AllInclusive { get; set; }
        public string AllAmount { get; set; }
    }
}
