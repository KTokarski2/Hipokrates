using Hipokrates.DTOs.Doctor;
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

    public async Task<IActionResult> Details(int Id)
    {
        var rooms = await _service.GetRooms();
        TempData["Rooms"] = rooms;
        var dto = await _service.GetConsultation(Id);
        return View("ConsultationDetails", dto);
    }

    public async Task<IActionResult> CancelConsultation(int Id)
    {
        await _service.CancelConsultation(Id);
        return RedirectToAction("Index", "Doctor");
    }

    public async Task<IActionResult> AcceptConsultation(int Id)
    {
        var doctorId = HttpContext.Session.GetString("DoctorId");
        await _service.AcceptConsultation(Id, Int32.Parse(doctorId));
        return RedirectToAction("Index", "Doctor");
    }

    public async Task<IActionResult> RefuseConsultation(int Id)
    {
        await _service.RefuseConsultation(Id);
        return RedirectToAction("Index", "Doctor");
    }

    public async Task<IActionResult> AssignRoom(AssignRoomDTO dto)
    {
        await _service.AssignRoom(dto);
        return RedirectToAction("Index", "Doctor");
    }


}