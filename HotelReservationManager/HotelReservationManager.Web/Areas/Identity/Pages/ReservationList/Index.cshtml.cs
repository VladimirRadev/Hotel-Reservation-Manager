using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationManager.Web.Areas.Identity.Pages.ReservationList
{
    public class IndexModel : PageModel
    {
        private readonly HotelDbContext context;
        public IndexModel(HotelDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Reservation> Reservations{ get; set; }
        public async Task OnGet()
        {
            Reservations = await context.Reservations.ToListAsync();

        }
        public async Task<IActionResult> OnPostDelete(string id)
        {
            var reservation = await context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            context.Reservations.Remove(reservation);
            await context.SaveChangesAsync();
            return Redirect("/Identity/ReservationList");

        }

    }
}
