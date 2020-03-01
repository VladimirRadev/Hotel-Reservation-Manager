using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationManager.Web.Areas.Identity.Pages.ClientList
{
    public class IndexModel : PageModel
    {
        private readonly HotelDbContext context;
        public IndexModel(HotelDbContext context)
        {
            this.context = context;
        }                               
        public IEnumerable<Client> Clients { get; set; }
        public async Task OnGet()
        {
            Clients = await context.Clients.ToListAsync();

        }
        public async Task<IActionResult> OnPostDelete(string id)
        {
            var client = await context.Clients.FindAsync(id);
            if(client==null)
            {
                return NotFound();
            }
            context.Clients.Remove(client);
            await context.SaveChangesAsync();
            return Redirect("ClientList/Index");

        }
    }
}
