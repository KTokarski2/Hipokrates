using Hipokrates.Models;

namespace Hipokrates.Services.AuthenticationService;

public interface IConsultationService
{
    public Task<List<Service>> GetServices();

}