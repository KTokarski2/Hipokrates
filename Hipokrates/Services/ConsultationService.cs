using Hipokrates.DTOs.Consultation;
using Hipokrates.Models;
using Microsoft.EntityFrameworkCore;

namespace Hipokrates.Services.AuthenticationService;

public class ConsultationService : IConsultationService
{
    private readonly Repository _repository;

    public ConsultationService(Repository repository)
    {
        _repository = repository;
    }

    public async Task<List<Service>> GetServices()
    {
        return await _repository.Services.ToListAsync();
    }

    public async Task RegisterConsultation(RegisterConsultationDTO dto)
    {
        var consultation = new Consultation
        {
            Date = dto.Date,
            Time = dto.Time,
            IdService = dto.ServiceId + 1,
            IdPatient = dto.PatientId,
            Status = Status.Registered
        };

        await _repository.AddAsync(consultation);
        await _repository.SaveChangesAsync();
    }
}