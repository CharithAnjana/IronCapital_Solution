using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ironcapital.Data;
using Ironcapital.Models;

namespace Ironcapital.Controllers
{
    [Authorize]
    public class AdminDashboardController : Controller
    {
        private readonly DbDataContextClass _context;
        public AdminDashboardController(DbDataContextClass context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var dbDataContextClass = _context.BuyNow.Include(b => b.TokenClass);
            return View(await dbDataContextClass.ToListAsync());
        }

    }
}