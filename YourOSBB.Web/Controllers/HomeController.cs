using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YourOSBB.Entities;
using YourOSBB.Web.Models;

namespace YourOSBB.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(ILogger<HomeController> logger, 
        SignInManager<ApplicationUser> signInManager, 
        UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        if (_signInManager.IsSignedIn(User)) //verify if it's logged
        {
            var usr = await _userManager.GetUserAsync(HttpContext.User);
            var userRole = await _userManager.FindByEmailAsync(usr.Email);
            if (userRole.Role == "Голова ОСББ")
            {
                return LocalRedirect(Url.Content("~/OsbbHead/OsbbHead/"));
            }
            if (userRole.Role == "Мешканець")
            {
                return LocalRedirect(Url.Content("~/Resident/Resident/"));
            }
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}