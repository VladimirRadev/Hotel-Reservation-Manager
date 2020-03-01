using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationManager.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly HotelDbContext context;
        public UsersController(HotelDbContext context)
        {
            this.context = context;
        }
        
    }

}
