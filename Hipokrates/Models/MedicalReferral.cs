namespace Hipokrates.Models;

public class MedicalReferral
{
    public int Id { get; set; }
    public DateTime DateOfIssue { get; set; }
    public string Description { get; set; }
}