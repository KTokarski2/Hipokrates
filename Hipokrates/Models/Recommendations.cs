namespace Hipokrates.Models;

public class Recommendations
{
    public int Id { get; set; }
    public virtual List<Recommendation> Guidelines { get; set; }
    public int IdPatient { get; set; }
    public virtual Patient Patient { get; set; }
    public int IdConsultation { get; set; }
    public virtual Consultation Consultation { get; set; }
    public string? DrugDosage { get; set; }
    
}