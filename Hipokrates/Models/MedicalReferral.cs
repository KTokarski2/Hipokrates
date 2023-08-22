namespace Hipokrates.Models;

public class MedicalReferral
{
    public int Id { get; set; }
    public int IdDoctor { get; set; }
    public virtual Doctor Doctor { get; set; }
    public int IdMedicalExam { get; set; }
    public virtual MedicalExam MedicalExam { get; set; }
    public int IdPatient { get; set; }
    public virtual Patient Patient { get; set; }
    public DateTime DateOfIssue { get; set; }
    public string Description { get; set; }
}