using Microsoft.AspNetCore.Mvc;
using HotelReservationManager.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace HotelReservationManager.Web.Controllers
{
    public class HomeController : Controller
    {
       private readonly HotelDbContext context;
       // private readonly RoleManager<IdentityRole> rolemanager;
        public HomeController(HotelDbContext context)
        {
            this.context = context;
         
        }

        public async Task<IActionResult> Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {

            }
            return View();
        }
    }
}
