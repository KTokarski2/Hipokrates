namespace Hipokrates.Models;

public class Substance
{
    public int Id { get; set; }
    public virtual List<SubstanceMedicament> SubstanceMedicaments { get; set; } = new List<SubstanceMedicament>();
    public string Name { get; set; }
}