using Hipokrates.DTOs.Patient;
using Hipokrates.Models;
using Microsoft.EntityFrameworkCore;

namespace Hipokrates.Services.AuthenticationService;

public class PatientService : IPatientService
{
    private readonly Repository _repository;

    public PatientService(Repository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<ConsultationDTO>> GetConsultationList(string pesel)
    {
        return await _repository.Patients.Where(p => p.Pesel == Int32.Parse(pesel))
            .SelectMany(p => p.Consultations)
            .Select(c => new ConsultationDTO
            {
                Id = c.Id,
                ServiceName = c.Service.Name,
                Date = c.Date,
                Time = c.Time
            })
            .OrderBy(c => c.Date)
            .ToListAsync();
    }

    public async Task<ConsultationDTO?> GetConsultation(int id)
    {
        return await _repository.Consultations
            .Select(c => new ConsultationDTO
            {
                Id = c.Id,
                ServiceName = c.Service.Name,
                Room = c.Room.RoomNumber,
                Floor = c.Room.FloorNumber,
                Status = c.Status.ToString(),
                Date = c.Date,
                Time = c.Time
            })
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}