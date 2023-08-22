namespace Hipokrates.Models;

public class PrescriptionMedicament
{
    public int IdPatient { get; set; }
    public int IdPrescription { get; set; }
    public virtual Patient Patient { get; set; }
    public virtual Prescription Prescription { get; set; }
}