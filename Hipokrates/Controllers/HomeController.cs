using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hipokrates.Models;

namespace Hipokrates.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Pesel= HttpContext.Session.GetString("Pesel");
        ViewBag.User = HttpContext.Session.GetString("User");
        ViewBag.UserClass = HttpContext.Session.GetString("Class");
        return View();
    }

    
    
}