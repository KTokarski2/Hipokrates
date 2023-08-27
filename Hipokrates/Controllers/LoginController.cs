using Hipokrates.DTOs.Login;
using Hipokrates.Services.AuthenticationService;
using Microsoft.AspNetCore.Mvc;

namespace Hipokrates.Controllers;

public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;
    private readonly IAuthenticationService _service;

    public LoginController(ILogger<LoginController> logger, IAuthenticationService service)
    {
        _logger = logger;
        _service = service;
    }

    public IActionResult Index()
    {
        return View("Login");
    }

    public async Task<IActionResult> Login(LoginDTO loginDto)
    {
        var user = await _service.LogIn(loginDto);
        if (user != null)
        {
            HttpContext.Session.SetString("Pesel", user.Pesel.ToString());
            HttpContext.Session.SetString("PatientId", user.Id.ToString());
            var userString = user.FirstName + " " + user.LastName;
            HttpContext.Session.SetString("User", userString);
            return RedirectToAction("Index", "Home");
        }

        string message = "Bad login or password";
        return RedirectToAction("Index", "Login", message);
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("Pesel");
        HttpContext.Session.Remove("User");
        HttpContext.Session.Remove("Id");
        return RedirectToAction("Index", "Home");
    }
}