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

    public IActionResult IndexPatient()
    {
        return View("LoginPatient");
    }

    public IActionResult IndexDoctor()
    {
        return View("LoginDoctor");
    }

    public async Task<IActionResult> LoginPatient(LoginDTO loginDto)
    {
        var user = await _service.LogInPatient(loginDto);
        if (user != null)
        {
            HttpContext.Session.SetString("Pesel", user.Pesel.ToString());
            HttpContext.Session.SetString("PatientId", user.Id.ToString());
            var userString = user.FirstName + " " + user.LastName;
            HttpContext.Session.SetString("User", userString);
            HttpContext.Session.SetString("Class", "Patient");
            return RedirectToAction("Index", "Home");
        }

        string message = "Bad login or password";
        return RedirectToAction("Index", "Login", message);
    }

    public async Task<IActionResult> LoginDoctor(LoginDTO loginDto)
    {
        var doctor = await _service.LogInDoctor(loginDto);
        if (doctor != null)
        {
            HttpContext.Session.SetString("DoctorId", doctor.Id.ToString());
            var userString = "dr. " + doctor.FirstName + " " + doctor.LastName;
            HttpContext.Session.SetString("User", userString);
            HttpContext.Session.SetString("Class", "Doctor");
            return RedirectToAction("Index", "Home");
        }

        string message = "Bad login or password";
        return RedirectToAction("Index", "Login", message);
    }

    public IActionResult LogoutPatient()
    {
        HttpContext.Session.Remove("Pesel");
        HttpContext.Session.Remove("User");
        HttpContext.Session.Remove("Id");
        HttpContext.Session.Remove("Class");
        return RedirectToAction("Index", "Home");
    }
    
    public IActionResult LogoutDoctor()
    {
        HttpContext.Session.Remove("DoctorId");
        HttpContext.Session.Remove("User");
        HttpContext.Session.Remove("Class");
        return RedirectToAction("Index", "Home");
    }
}