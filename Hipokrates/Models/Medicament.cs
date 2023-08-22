namespace Hipokrates.Models;

public class Medicament
{
    public int Id { get; set; }

    public virtual List<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = new List<PrescriptionMedicament>(); 
    public string Name { get; set; }
    public virtual List<SubstanceMedicament> SubstancesMedicaments { get; set; } = new List<SubstanceMedicament>();
    public string Producer { get; set; }
    public string Description { get; set; }
}