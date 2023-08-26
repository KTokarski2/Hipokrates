using Hipokrates.DTOs.Patient;
using Hipokrates.Models;

namespace Hipokrates.Services.AuthenticationService;

public interface IPatientService
{
    public Task<List<ConsultationDTO>> GetConsultationList(string pesel);
    public Task<ConsultationDTO?> GetConsultation(int id);
}