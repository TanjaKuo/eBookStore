using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using eBookStore.Models;
using eBookStore.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace eBookStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        //private readonly IAccountRepository _accountRepository;

        private readonly IReserveRepository _reserveRepository;


        public AccountController(
            IReserveRepository reserveRepository,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager
            )
        {
           // _accountRepository = accountRepository;
            _reserveRepository = reserveRepository;
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
                TempData["notification"] = "Failed created the account. Try another name";
            }

            var newUser = new IdentityUser
            {
                UserName = userViewModel.Username
            };

            var identityResult = await _userManager.CreateAsync(newUser, userViewModel.Password);

            if(identityResult.Succeeded)
            {
                TempData["notification"] = "Account has been created. You can login to reserve the book now";
                return RedirectToAction("Login");
            }
            else
            {
                TempData["notification"] = "Failed created the account. Please try again";
                return View();
            }

            

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(User user)
        //{

        //    if(user != null)
        //    {
        //        await _accountRepository.CreateUserAsync(user);
        //        TempData["notification"] = "Account has been created. You can login to reserve the book now";
        //    }
        //    else
        //    {
        //        TempData["notification"] = "Failed created the account. Please try again";
        //    }

        //    return RedirectToAction("Login");
        //}

        // GET: /<controller>/
        public IActionResult Login()
        {
            string notification;

            if (TempData.ContainsKey("notification"))
                notification = TempData["notification"].ToString(); 

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
                       // await _reserveRepository.UpdateUserName(user.UserName);

                        return RedirectToAction("Index", "Home");
                    }
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View();
            }
            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View();
        }

        //[HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(User user)
        //{
        //    var isUserValid = await _accountRepository.CheckUserIsValidAsync(user);

        //    if (isUserValid)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    return View();
        //}
    }
}

