using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using eBookStore.Models;
using eBookStore.Repositories;

namespace eBookStore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

   // private readonly IAccountRepository _accountRepository;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
       // _accountRepository = accountRepository;
    }

    //public async Task<IActionResult> Index(Guid? userId)
    //{

    //    var user = await _accountRepository.GetUserAsync(userId);

    //    if(user != null)
    //    {
    //        return View(user);
    //    }

    //    return View();
    //}


    public IActionResult Index()
    {

        //var theUser = await _accountRepository.CheckUserIsValidAsync(user);

        //if (theUser)
        //{
        //    return View(theUser);
        //}

        return View();
    }


    //public async Task<IActionResult> Index(User user)
    //{

    //    var theUser = await _accountRepository.CheckUserIsValidAsync(user);

    //    if (theUser)
    //    {
    //        return View(theUser);
    //    }

    //    return View();
    //}


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

