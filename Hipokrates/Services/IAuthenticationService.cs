using Hipokrates.DTOs.Login;
using Hipokrates.Models;

namespace Hipokrates.Services.AuthenticationService;

public interface IAuthenticationService
{
    public Task<Patient?> LogIn(LoginDTO dto);
}