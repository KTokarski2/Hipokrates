using Hipokrates.Models;

namespace Hipokrates.Services.AuthenticationService;

public interface IAuthenticationService
{
    public Task<User> LogIn(string email, string password);
    public Task<bool> FindUser(string email, string password);
}