namespace Hipokrates.Models;

public class Recommendations
{
    public int Id { get; set; }
    public List<Recommendation> Guidelines { get; set; }
    public string? DrugDosage { get; set; }
    
}