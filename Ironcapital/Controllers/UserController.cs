using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ironcapital.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ironcapital.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _um;
        private readonly SignInManager<IdentityUser> _sm;
        public UserController(UserManager<IdentityUser> um, SignInManager<IdentityUser> sm)
        {
            _um = um;
            _sm = sm;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login", "User");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginClass log)
        {
            if (ModelState.IsValid)
            {
                var result = await _sm.PasswordSignInAsync(log.UserName, log.Pass, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "AdminDashboard");
                }
                ModelState.AddModelError("", "Invalid User Details");
            }

            return View(log);
        }

        public IActionResult Register()
        {
            return View();
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Register(UserClass user)
        {
            var us = new IdentityUser
            {
                UserName = user.UserName,
                Email = user.Email
            };

            if (user.Pass == user.CnfPass)
            {
                var insrec = await _um.CreateAsync(us, user.Pass);
                if (insrec.Succeeded)
                {
                    ViewBag.message = "User " + user.Email + " is saved";
                }
                else
                {
                    foreach (var error in insrec.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View();
        }

        public async Task<ActionResult> Logout()
        {
            await _sm.SignOutAsync();
            return RedirectToAction("Login", "User");
        }


    }
}