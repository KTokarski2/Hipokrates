namespace Hipokrates.Models;

public class Prescription
{
    public int Id { get; set; }
    public int IdPatient { get; set; }
    public virtual Patient Patient { get; set; }
    public virtual List<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = new List<PrescriptionMedicament>();
    public int IdDoctor { get; set; }
    public virtual Doctor Doctor { get; set; }
    public DateTime DateOfIssue { get; set; }
    public DateTime ExpiryDate { get; set; }
}