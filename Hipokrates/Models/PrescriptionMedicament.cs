namespace Hipokrates.Models;

public class PrescriptionMedicament
{
    public int IdMedicament { get; set; }
    public int IdPrescription { get; set; }
    public virtual Medicament Medicament{ get; set; }
    public virtual Prescription Prescription { get; set; }
}