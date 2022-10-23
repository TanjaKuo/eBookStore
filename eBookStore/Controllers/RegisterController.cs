using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eBookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eBookStore.Controllers
{
    public class RegisterController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;

        public RegisterController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        //public async Task<IActionResult> OnPost()
        //{
        //    var newUser = new IdentityUser
        //    {
        //        UserName = UserViewModel.
        //    };

        //    var identityResult = await _userManager.CreateAsync(newUser, UserViewModel.Password);


        //}
    }

}