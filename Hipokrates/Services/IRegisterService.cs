using Hipokrates.DTOs.Register;

namespace Hipokrates.Services.AuthenticationService;

public interface IRegisterService
{
    public Task Register(RegisterDTO dto);
}