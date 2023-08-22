namespace Hipokrates.Models;

public class Service
{
    public int Id { get; set; }
    public virtual List<Consultation> Consultations { get; set; } = new List<Consultation>();
    public string Type { get; set; }
    public Plan Plan { get; set; }
}