using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationManager.Web.Areas.Identity.Pages.RoomList
{
    public class IndexModel : PageModel
    {
        private readonly HotelDbContext context;
        public IndexModel(HotelDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<RoomType> RoomTypes { get; set; }
        public async Task OnGet()
        {
            Rooms = await context.Rooms.ToListAsync();

        }
        public async Task<IActionResult> OnPostDelete(string id)
        {
            var room = await context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            context.Rooms.Remove(room);
            await context.SaveChangesAsync();
            return Redirect("/Identity/RoomList");

        }
    }
}
