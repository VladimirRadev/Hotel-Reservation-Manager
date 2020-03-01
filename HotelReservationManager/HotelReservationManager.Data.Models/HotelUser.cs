using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationManager.Data.Models
{
    public class HotelUser:IdentityUser
    {
        
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string PersonalInditification { get; set; }
        public DateTime DateOfEmployed { get; set; }
        public bool Isactive { get; set; }
        public DateTime Dateofleavingcompany { get; set; }







    }
}
