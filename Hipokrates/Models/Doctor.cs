namespace Hipokrates.Models;

public class Doctor : User
{
    public virtual List<Consultation> Consultations { get; set; } = new List<Consultation>();
    public virtual List<MedicalReferral> Referrals { get; set; } = new List<MedicalReferral>();
    public virtual List<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    public virtual List<Specialization> Specializations { get; set; } = new List<Specialization>();
    public int LicenseNumber { get; set; }
    public decimal BaseSalary { get; set; } = 8000m;

    public void ConsiderConsultation()
    {
        throw new NotImplementedException();
    }

    public void CancelConsultation()
    {
        throw new NotImplementedException();
    }

    public void EnterRecommendations()
    {
        throw new NotImplementedException();
    }

    public void EndConsultation()
    {
        throw new NotImplementedException();
    }

    public void AnswerQuestion()
    {
        throw new NotImplementedException();
    }

    public void ViewServices()
    {
        throw new NotImplementedException();
    }

    public decimal CountBonus(int consultations)
    {
        throw new NotImplementedException();
    }
}