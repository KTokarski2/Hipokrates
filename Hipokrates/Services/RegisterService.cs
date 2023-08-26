using Hipokrates.DTOs.Register;
using Hipokrates.Models;

namespace Hipokrates.Services.AuthenticationService;

public class RegisterService : IRegisterService
{
    private readonly Repository _repository;

    public RegisterService(Repository repository)
    {
        _repository = repository;
    }


    public async Task Register(RegisterDTO dto)
    {
        var patient = new Patient
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Password = dto.Password,
            Pesel = Int32.Parse(dto.Pesel),
            InsuranceNumber = Int32.Parse(dto.InsuranceNumber)
        };

        await _repository.Patients.AddAsync(patient);
        await _repository.SaveChangesAsync();
    }
}