using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelReservationManager.Web.Areas.Identity.Pages.ClientList
{
    public class EditModel : PageModel
    {
        private readonly HotelDbContext context;

        public EditModel(HotelDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Client Client { get; set; }
        public async Task OnGet(string id)
        {
            Client = await context.Clients.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var ClientFromDb = await context.Clients.FindAsync(Client.Id);
                ClientFromDb.Firstname = Client.Firstname;
                ClientFromDb.Lastname = Client.Lastname;
                ClientFromDb.PhoneNumber = Client.PhoneNumber;
                ClientFromDb.Email = Client.Email;
                ClientFromDb.isAdult = Client.isAdult;

                await context.SaveChangesAsync();

                return Redirect("/Identity/ClientList");
            }
            return RedirectToPage();
        }
    }
}
