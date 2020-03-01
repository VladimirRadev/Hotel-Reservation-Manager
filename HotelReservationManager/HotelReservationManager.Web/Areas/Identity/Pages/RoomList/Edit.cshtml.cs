using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelReservationManager.Web.Areas.Identity.Pages.RoomList
{
    public class EditModel : PageModel
    {
        private readonly HotelDbContext context;

        public EditModel(HotelDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Room Room { get; set; }
        public async Task OnGet(string id)
        {
            Room = await context.Rooms.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var RoomFromDb = await context.Rooms.FindAsync(Room.Id);
                RoomFromDb.Capacity = Room.Capacity;
                RoomFromDb.TypeId = Room.TypeId;
                RoomFromDb.isFree = Room.isFree;
                RoomFromDb.PriceForBedAsAdult = Room.PriceForBedAsAdult;
                RoomFromDb.PriceForBedAsChild = Room.PriceForBedAsChild;
                RoomFromDb.Number = Room.Number;


                await context.SaveChangesAsync();

                return Redirect("/Identity/RoomList");
            }
            return RedirectToPage();
        }
    }
}
