using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using eBookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace eBookStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserViewModel userViewModel)
        {

            var checkUserExisting = await _userManager.FindByNameAsync(userViewModel.Username);

            if (checkUserExisting != null)
            {
                TempData["Error"] = "Wrong credentials. Please, try again!";
            }

            var newUser = new IdentityUser
            {
                UserName = userViewModel.Username
            };

            var identityResult = await _userManager.CreateAsync(newUser, userViewModel.Password);

            if(identityResult.Succeeded)
            {
                TempData["Success"] = "Account has been created. You can login to reserve the book now";
                return RedirectToAction("Login");
            }
            else
            {
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View();
            }
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserViewModel userViewModel)
        {
            var user = await _userManager.FindByNameAsync(userViewModel.Username);

            if(user != null)
            {
                var checkPassword = await _userManager.CheckPasswordAsync(user, userViewModel.Password);

                if (checkPassword)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, userViewModel.Password, false, false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Book");
                    }
                }
                ViewData["Error"] = "Wrong credentials. Please, try again!";
                return View();
            }
            ViewData["Error"] = "Wrong credentials. Please, try again!";
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Book");
        }


    }
}

