using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelReservationManager.Web.Areas.Identity.Pages.UserList
{
    public class EditModel : PageModel
    {
        private readonly HotelDbContext context;
        private readonly UserManager<HotelUser> _userManager;

        public EditModel(HotelDbContext context, UserManager<HotelUser> _userManager)
        {
            this.context = context;
            this._userManager = _userManager;
        }

        [BindProperty]
        public HotelUser HotelUser { get; set; }
        public async Task OnGet(string id)
        {
            HotelUser = await context.HotelUsers.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var HotelUserFromDb = await context.HotelUsers.FindAsync(HotelUser.Id);
                HotelUserFromDb.UserName = HotelUser.UserName;
                HotelUserFromDb.Firstname = HotelUser.Firstname;
                HotelUserFromDb.Middlename = HotelUser.Middlename;
                HotelUserFromDb.Lastname = HotelUser.Lastname;
                HotelUserFromDb.PersonalInditification = HotelUser.PersonalInditification;
                HotelUserFromDb.DateOfEmployed = HotelUser.DateOfEmployed;
                HotelUserFromDb.Isactive = HotelUser.Isactive;
                HotelUserFromDb.Dateofleavingcompany = HotelUser.Dateofleavingcompany;

                if (!HotelUser.Isactive)
                {
                    await _userManager.RemoveFromRoleAsync(HotelUserFromDb, "User");
                    await _userManager.AddToRoleAsync(HotelUserFromDb, "Client");
                    HotelUserFromDb.Dateofleavingcompany = DateTime.UtcNow;
                }
                await context.SaveChangesAsync();

                return Redirect("/Identity/UserList");
            }
            return RedirectToPage();
        }
    }
}
