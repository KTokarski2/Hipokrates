namespace Hipokrates.Models;

public class Patient : User
{
    public virtual List<Recommendations> Recommendations { get; set; } = new List<Recommendations>();
    public virtual List<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    public virtual List<MedicalReferral> Referrals { get; set; } = new List<MedicalReferral>();
    public int PhoneNumber { get; set; }
    public List<Address> Addresses { get; set; }
    public int Pesel { get; set; }
    public int InsuranceNumber { get; set; }
    public Plan Plan { get; set; }
}