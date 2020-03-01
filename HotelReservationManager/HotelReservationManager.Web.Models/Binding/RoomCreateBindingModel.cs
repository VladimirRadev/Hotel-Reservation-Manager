using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelReservationManager.Web.Models.Binding
{
    public class RoomCreateBindingModel
    {
        [Required]
        public string Capacity { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public bool isFree { get; set; }

        [Required]
        [MaxLength(5, ErrorMessage = "PriceForAdult must be 5 digits or less"), MinLength(1)]
        public string PriceForAdult{ get; set; }

        [Required]
        [MaxLength(5, ErrorMessage = "PriceForChild must be 5 digits or less"), MinLength(1)]
        public string PriceForChild { get; set; }
        [Required]
        [MaxLength(3, ErrorMessage = "Number of room must be 3 digits"), MinLength(3)]
        public string Number { get; set; }
    }
}
