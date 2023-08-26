namespace Hipokrates.DTOs.Register;

public class RegisterDTO
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public string Pesel { get; set; }
    public string Password { get; set; }
    public string InsuranceNumber { get; set; }
}