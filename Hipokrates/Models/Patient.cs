namespace Hipokrates.Models;

public class Patient : User
{
    public int PhoneNumber { get; set; }
    public List<Address> Addresses { get; set; }
    public int Pesel { get; set; }
    public int InsuranceNumber { get; set; }
    public Plan Plan { get; set; }
}