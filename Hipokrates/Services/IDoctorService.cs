using Hipokrates.DTOs.Patient;

namespace Hipokrates.Services.AuthenticationService;

public interface IDoctorService
{
    public Task<List<ConsultationDTO>> GetConsultations();
}