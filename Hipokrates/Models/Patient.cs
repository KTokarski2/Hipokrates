namespace Hipokrates.Models;

public class Patient : User
{
    public virtual List<Recommendations> Recommendations { get; set; } = new List<Recommendations>();
    public virtual List<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    public virtual List<MedicalReferral> Referrals { get; set; } = new List<MedicalReferral>();
    public virtual List<Consultation> Consultations { get; set; } = new List<Consultation>();
    public int PhoneNumber { get; set; }
    public virtual List<Address> Addresses { get; set; } = new List<Address>();
    public int Pesel { get; set; }
    public int InsuranceNumber { get; set; }
    public Plan Plan { get; set; }

    public void CancelConsultation(DateTime date, TimeSpan time)
    {
        throw new NotImplementedException();
    }

    public void DownloadPrescription(Prescription prescription)
    {
        throw new NotImplementedException();
    }

    public void DownloadConsultationReport(Consultation consultation)
    {
        throw new NotImplementedException();
    }

    public void AskConsultation(String question)
    {
        throw new NotImplementedException();
    }
}