using Hipokrates.DTOs.Consultation;
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

    public async Task<IActionResult> Index()
    {
        var services = await _service.GetServices();
        return View(services);
    }

    public IActionResult ChooseService(int serviceId)
    {
        
        var dto = new PassIdDTO {PatientId = Int32.Parse(HttpContext.Session.GetString("PatientId")), ServiceId = serviceId};
        return View("Register", dto);
    }

    public async Task<IActionResult> RegisterConsultation(RegisterConsultationDTO dto)
    {
        await _service.RegisterConsultation(dto);
        var viewPath = "~/Views/Home/Index.cshtml";
        return View(viewPath);
    }
    
}