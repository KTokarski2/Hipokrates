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
}