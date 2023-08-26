using Hipokrates.Models;
using Microsoft.EntityFrameworkCore;

namespace Hipokrates.Services.AuthenticationService;

public class AuthenticationService : IAuthenticationService
{
    private readonly Repository _repository;

    public AuthenticationService(Repository repository)
    {
        _repository = repository;
    }


    public Task<User> LogIn(string email, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> FindUser(string email, string password)
    {
        return await _repository.Users.AnyAsync(u => u.Email.Equals(email) && u.Password.Equals(password));
    }
}