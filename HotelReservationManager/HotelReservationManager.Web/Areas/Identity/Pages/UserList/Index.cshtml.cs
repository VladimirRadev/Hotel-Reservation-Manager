using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservationManager.Web.Areas.Identity.Pages.UserList
{
    public class IndexModel : PageModel
    {
        private readonly HotelDbContext context;
        private readonly UserManager<HotelUser> usermanager;
        public IndexModel(HotelDbContext context, 
            UserManager<HotelUser> usermanager)
        {
            
            this.context = context;
            this.usermanager = usermanager;
        }

        public IEnumerable<HotelUser> HotelUsers { get; set; }
        public async Task OnGet()
        {
            HotelUsers = usermanager.GetUsersInRoleAsync("User").Result;
        }
        public async Task<IActionResult> OnPostDelete(string id)
        {
            var user = await context.HotelUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            context.HotelUsers.Remove(user);
            await context.SaveChangesAsync();
            return Redirect("/Identity/UserList");

        }
    }

}
