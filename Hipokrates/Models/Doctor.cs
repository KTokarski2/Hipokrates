namespace Hipokrates.Models;

public class Doctor : User
{
    public virtual List<Consultation> Consultations { get; set; } = new List<Consultation>();
    public virtual List<MedicalReferral> Referrals { get; set; } = new List<MedicalReferral>();
    public virtual List<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    public virtual List<Specialization> Specializations { get; set; } = new List<Specialization>();
    public int LicenseNumber { get; set; }
    public decimal BaseSalary { get; set; } = 8000m;
    
}