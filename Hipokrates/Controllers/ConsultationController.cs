using Hipokrates.Models;
using Hipokrates.Services.AuthenticationService;
using Microsoft.AspNetCore.Mvc;

namespace Hipokrates.Controllers;

public class ConsultationController : Controller
{
    private readonly IConsultationService _service;

    public ConsultationController(IConsultationService service)
    {
        _service = service;
    }

    public async Task<IActionResult>Index()
    {
        var services = await _service.GetServices();
        return View(services);
    }
}