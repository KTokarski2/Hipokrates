namespace Hipokrates.Models;

public class Specialization
{
    public int Id { get; set; }
    public int IdDoctor { get; set; }
    public virtual Doctor Doctor { get; set; }
    public string Name { get; set; }
}