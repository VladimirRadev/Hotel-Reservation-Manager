using System;
using System.Collections.Generic;
using System.Linq;
using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using HotelReservationManager.Web.Models.Binding;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationManager.Web.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly HotelDbContext context;
        public ReservationsController(HotelDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public IActionResult Create(ReservationCreateBindingModel reservationCreateBindingModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            decimal sum = 0;

            var roomId = context.Rooms.SingleOrDefault(
                    r => r.Number == reservationCreateBindingModel.RoomNumber).Id;

            var priceForChild = Convert.ToDecimal(context.Rooms.FirstOrDefault(r => r.Id == roomId).PriceForBedAsChild);
            var priceForAdult = Convert.ToDecimal( context.Rooms.FirstOrDefault(r => r.Id == roomId).PriceForBedAsAdult);

            foreach (var item in context.Clients.ToList())
            {
                if (reservationCreateBindingModel.AllInclusive)
                {
                    sum+=100;
                    if (item.isAdult)
                    {
                        sum += priceForAdult;
                    }
                    else
                    {
                        sum += priceForChild;
                    }
                }
                else if(reservationCreateBindingModel.IncludedBreakfast)
                {
                    sum += 50;
                    if (item.isAdult)
                    {
                        sum += priceForAdult;
                    }
                    else
                    {
                        sum += priceForChild;
                    }
                }
                else
                {
                    sum += 150;
                      if (item.isAdult)
                    {
                        sum += priceForAdult;
                    }
                    else
                    {
                        sum += priceForChild;
                    }
                }

            }

            Reservation reservation = new Reservation
            {
                Id = Guid.NewGuid().ToString(),
                RoomId = roomId,
                HotelUserId = context.HotelUsers.SingleOrDefault(
                    r => r.UserName == reservationCreateBindingModel.HotelUserUsername).Id,
                DataOfIncoming = reservationCreateBindingModel.DataOfIncoming,
                DateOfOutgoing = reservationCreateBindingModel.DateOfOutgoing,
                includedBreakfast = reservationCreateBindingModel.IncludedBreakfast,
                allInclusive = reservationCreateBindingModel.AllInclusive,
                AllAmount = sum.ToString()

            };
            context.Add(reservation);
            context.SaveChangesAsync();
       
            return Redirect("/Identity/ReservationList");
        }
    }
}