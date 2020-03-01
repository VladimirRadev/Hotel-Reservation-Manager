using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationManager.Data.Models
{
    public class Client
    {
        
        public string Id { get; set;}
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set;}
        public bool isAdult { get; set; }
    }
}
