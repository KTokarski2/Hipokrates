namespace Hipokrates.Models;

public class Doctor : User
{
    public virtual List<Consultation> Consultations { get; set; } = new List<Consultation>();
    public virtual List<MedicalReferral> Referrals { get; set; } = new List<MedicalReferral>();
    public virtual List<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    public List<String> Specialization { get; set; }
    public int LicenseNumber { get; set; }
    public decimal BaseSalary { get; set; } = 8000m;
}