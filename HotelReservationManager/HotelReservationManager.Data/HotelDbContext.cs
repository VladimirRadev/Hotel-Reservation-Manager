using HotelReservationManager.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelReservationManager.Data
{
    public class HotelDbContext : IdentityDbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<HotelUser> HotelUsers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public object Client { get; set; }
        public object HotelUser { get; set; }

        public HotelDbContext(DbContextOptions<HotelDbContext>options):base(options)
        {

        }
    }
}
