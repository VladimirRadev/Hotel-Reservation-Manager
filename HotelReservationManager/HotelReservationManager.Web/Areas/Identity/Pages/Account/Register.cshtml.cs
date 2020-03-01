using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelReservationManager.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<HotelUser> _signInManager;
        private readonly UserManager<HotelUser> _userManager;
        private readonly HotelDbContext _context;

        public RegisterModel(
            UserManager<HotelUser> userManager,
            SignInManager<HotelUser> signInManager,
            HotelDbContext context)
          
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;


        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(15, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required]
            [StringLength(15, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [Display(Name = "Firstname")]
            public string Firstname { get; set; }
            [Required]
            [StringLength(15, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [Display(Name = "Middlename")]
            public string Middlename { get; set; }
            [Required]
            [StringLength(25, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [Display(Name = "Lastname")]
            public string Lastname { get; set; }
            [Required]
            [MaxLength(10, ErrorMessage = "PersonalInditification must be 10 digits or less"), MinLength(3)]
            public string PersonalInditification { get; set; }

            [Required]
            [MaxLength(10, ErrorMessage = "Phonenumber must be 10 digits or less"), MinLength(3)]
            public string PhoneNumber { get; set; }
            [Required]
            public DateTime DateOfEmployed { get; set; }
            
            
            public DateTime Dateofleavingcompany { get; set; }
            [Required]
            public bool Isactive { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(25, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
           
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
           
            returnUrl = returnUrl ?? Url.Content("~/");
            
            if (ModelState.IsValid)
            {
                var user = new HotelUser {Id=Guid.NewGuid().ToString(), UserName = Input.Username, Email = Input.Email,Firstname=Input.Firstname,
                Middlename=Input.Middlename,Lastname=Input.Lastname,
                PersonalInditification=Input.PersonalInditification,PhoneNumber=Input.PhoneNumber,
                DateOfEmployed=Input.DateOfEmployed,Dateofleavingcompany=Input.Dateofleavingcompany,Isactive=true};
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if (this._context.HotelUsers.Count() == 1)
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                    }

                 if(this.User.IsInRole("Admin"))
                 {
                        return Redirect("/Identity/UserList");
                 }
                 await _signInManager.SignInAsync(user, isPersistent: false);
                 return LocalRedirect(returnUrl);
                    
                }
                foreach (var error in result.Errors)
                {// i should add error for already excisitin username!
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
