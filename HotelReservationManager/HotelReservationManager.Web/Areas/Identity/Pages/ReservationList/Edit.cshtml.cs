using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelReservationManager.Web.Areas.Identity.Pages.ReservationList
{
    public class EditModel : PageModel
    {
        private readonly HotelDbContext context;

        public EditModel(HotelDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Reservation Reservation { get; set; }
        public async Task OnGet(string id)
        {
            Reservation = await context.Reservations.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var ReservationFromDb = await context.Reservations.FindAsync(Reservation.Id);
                ReservationFromDb.RoomId = Reservation.RoomId;
                ReservationFromDb.HotelUserId = Reservation.HotelUserId;
                ReservationFromDb.DataOfIncoming = Reservation.DataOfIncoming;
                ReservationFromDb.DateOfOutgoing = Reservation.DateOfOutgoing;
                ReservationFromDb.includedBreakfast = Reservation.includedBreakfast;
                ReservationFromDb.allInclusive = Reservation.allInclusive;
                ReservationFromDb.AllAmount = Reservation.AllAmount;

                await context.SaveChangesAsync();

                return Redirect("/Identity/ReservationList");
            }
            return RedirectToPage();
        }
    }
}
