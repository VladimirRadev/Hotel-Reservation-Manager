using System;
using System.Threading.Tasks;
using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using HotelReservationManager.Web.Models.Binding;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationManager.Web.Controllers
{
    public class ClientsController : Controller
    {
        private readonly HotelDbContext _context;
        public ClientsController(HotelDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles="Admin,User")]
        public IActionResult Create(ClientCreateBindingModel clientCreateBindingModel)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            Client client = new Client
            {
                Id = Guid.NewGuid().ToString(),
                Firstname = clientCreateBindingModel.FirstName,
                Lastname = clientCreateBindingModel.LastName,
                PhoneNumber = clientCreateBindingModel.PhoneNumber,
                Email = clientCreateBindingModel.Email,
                isAdult = clientCreateBindingModel.isAdult
      
            };
            this._context.Add(client);
            this._context.SaveChanges();
            return Redirect("/Identity/ClientList");
        }

         #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _context.Clients.ToListAsync() });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var bookFromDb = await _context.Clients.FirstOrDefaultAsync(u => u.Id == id);
            if (bookFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _context.Clients.Remove(bookFromDb);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
        #endregion


    }
}