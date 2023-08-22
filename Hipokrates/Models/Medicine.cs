namespace Hipokrates.Models;

public class Medicine
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Substance> Substances { get; set; }
    public string Producer { get; set; }
    public string Description { get; set; }
}