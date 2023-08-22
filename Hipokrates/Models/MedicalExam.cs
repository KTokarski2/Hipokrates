namespace Hipokrates.Models;

public class MedicalExam
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public Plan Plan { get; set; }
}