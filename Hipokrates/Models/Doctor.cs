namespace Hipokrates.Models;

public class Doctor : User
{
    public List<String> Specialization { get; set; }
    public int LicenseNumber { get; set; }
    public decimal BaseSalary { get; set; } = 8000m;
}