namespace Hipokrates.Models;

public class Consultation
{
    public int Id { get; set; }
    public virtual List<Recommendations> Recommendations { get; set; } = new List<Recommendations>();
    public int IdRoom { get; set; }
    public virtual Room Room { get; set; }
    public int IdService { get; set; }
    public virtual Service Service { get; set; }
    public int IdDoctor { get; set; }
    public virtual Doctor Doctor { get; set; }
    public Status Status { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
}