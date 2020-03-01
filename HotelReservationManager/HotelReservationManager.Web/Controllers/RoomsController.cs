using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using HotelReservationManager.Web.Models.Binding;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationManager.Web.Controllers
{
    public class RoomsController : Controller
    {
        private readonly HotelDbContext context;
        public RoomsController(HotelDbContext context)
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
        [Authorize(Roles = "Admin")]
        public IActionResult Create(RoomCreateBindingModel roomCreateBindingModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Room room = new Room
            {
                Id = Guid.NewGuid().ToString(),
                Capacity = roomCreateBindingModel.Capacity,
                TypeId = context.RoomTypes.SingleOrDefault(
                    r=>r.Name==roomCreateBindingModel.Type).Id,
                isFree = roomCreateBindingModel.isFree,
                PriceForBedAsAdult = roomCreateBindingModel.PriceForAdult,
                PriceForBedAsChild = roomCreateBindingModel.PriceForChild,
                Number=roomCreateBindingModel.Number

            };
            this.context.Add(room);
            this.context.SaveChanges();
            return Redirect("/Identity/RoomList");
        }

    }
}