using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCoreMovieTheater.Models.Entities;
using NetCoreMovieTheater.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = registerVM.UserName,
                    Email = registerVM.Email

                };
              var result= await userManager.CreateAsync(user,registerVM.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return View(registerVM);
                }
                
            }
            else
            {
                return View(registerVM);
            }
        }
    }
}
