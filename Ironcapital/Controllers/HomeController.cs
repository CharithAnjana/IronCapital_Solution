using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ironcapital.Models;

namespace Ironcapital.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BuyNow()
        {
            return RedirectToAction("Form", "BuyNow");
        }

        public IActionResult MarketPlace()
        {
            return RedirectToAction("Index", "Token");
        }

    }
}