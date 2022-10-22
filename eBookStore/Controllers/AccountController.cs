using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eBookStore.Models;
using eBookStore.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eBookStore.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAccountRepository _accountRepository;

        private readonly IReserveRepository _reserveRepository;

        public AccountController(IAccountRepository accountRepository, IReserveRepository reserveRepository)
        {
            _accountRepository = accountRepository;
            _reserveRepository = reserveRepository;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {

            if(user != null)
            {
                await _accountRepository.CreateUserAsync(user);
            }

            return RedirectToAction("Login");

        }

        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(string searchString)
        //{
        //    _accountRepository.
        //}
    }
}

