using Hipokrates.DTOs.Patient;
using Hipokrates.Services.AuthenticationService;
using Microsoft.AspNetCore.Mvc;

namespace Hipokrates.Controllers;

public class PatientController : Controller
{
    private readonly IPatientService _service;

    public PatientController(IPatientService service)
    {
        _service = service;
    }
    
    public async Task<IActionResult> Index()
    {
        var pesel = HttpContext.Session.GetString("Pesel");
        List<ConsultationDTO> dtos = await _service.GetConsultationList(pesel);
        return View(dtos);
    }

    public async Task<IActionResult> Details(int Id)
    {
        var dto = await _service.GetConsultation(Id);
        return View("ConsultationDetails", dto);
    }

    public async Task<IActionResult> CancelConsultation(int Id)
    {
        await _service.CancelConsultation(Id);
        return RedirectToAction("Index", "Patient");
    }

    public async Task<IActionResult> UpdateDateAndTime(ChangeDateDTO dto)
    {
        await _service.UpdateDateAndTime(dto);
        return RedirectToAction("Index", "Patient");
    }
}