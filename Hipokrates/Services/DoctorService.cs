using Hipokrates.DTOs.Patient;
using Hipokrates.Models;
using Microsoft.EntityFrameworkCore;

namespace Hipokrates.Services.AuthenticationService;

public class DoctorService : IDoctorService
{
    private readonly Repository _repository;

    public DoctorService(Repository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<ConsultationDTO>> GetConsultations()
    {
        return await _repository.Consultations.Select(c => new ConsultationDTO
        {
            Id = c.Id,
            ServiceName = c.Service.Name,
            Room = c.Room.RoomNumber,
            Floor = c.Room.FloorNumber,
            Status = c.Status.ToString(),
            Date = c.Date,
            Time = c.Time

        }).ToListAsync();
    }
}