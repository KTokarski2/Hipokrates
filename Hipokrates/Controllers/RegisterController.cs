using Hipokrates.DTOs.Register;
using Hipokrates.Services.AuthenticationService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Hipokrates.Controllers;

public class RegisterController : Controller
{
    private readonly IRegisterService _service;

    public RegisterController(IRegisterService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        return View("Register");
    }

    public async Task<IActionResult> Register(RegisterDTO dto)
    {
        await _service.Register(dto);
        return RedirectToAction("Index", "Home");
    }
}