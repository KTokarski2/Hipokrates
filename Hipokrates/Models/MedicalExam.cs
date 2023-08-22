namespace Hipokrates.Models;

public class MedicalExam
{
    public int Id { get; set; }
    public virtual List<MedicalReferral> Referrals { get; set; } = new List<MedicalReferral>();
    public string Name { get; set; }
    public string Type { get; set; }
    public Plan Plan { get; set; }
}