namespace Hipokrates.Models;

public class SubstanceMedicament
{
    public int IdSubstance { get; set; }
    public int IdMedicament { get; set; }
    public virtual Medicament Medicament { get; set; }
    public virtual Substance Substance { get; set; }
}