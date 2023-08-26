using Hipokrates.DTOs.Login;
using Hipokrates.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hipokrates.Services.AuthenticationService;

public class AuthenticationService : IAuthenticationService
{
    private readonly Repository _repository;

    public AuthenticationService(Repository repository)
    {
        _repository = repository;
    }


    public async Task<Patient?> LogIn(LoginDTO dto)
    {
        return await _repository.Patients.FirstOrDefaultAsync(u =>
            u.Email.Equals(dto.Email) && u.Password.Equals(dto.Password));
    }
    
}