using Hipokrates.DTOs.Patient;
using Hipokrates.Services.AuthenticationService;
using Microsoft.AspNetCore.Mvc;

namespace Hipokrates.Controllers;

public class DoctorController : Controller
{
    private readonly IDoctorService _service;

    public DoctorController(IDoctorService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        List<ConsultationDTO> dtos = await _service.GetConsultations();
        return View(dtos);
    }
}