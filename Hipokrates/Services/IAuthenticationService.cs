using Hipokrates.DTOs.Login;
using Hipokrates.Models;

namespace Hipokrates.Services.AuthenticationService;

public interface IAuthenticationService
{
    public Task<Patient?> LogInPatient(LoginDTO dto);

    public Task<Doctor?> LogInDoctor(LoginDTO dto);
}