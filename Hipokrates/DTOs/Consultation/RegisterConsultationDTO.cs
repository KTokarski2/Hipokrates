namespace Hipokrates.DTOs.Consultation;

public class RegisterConsultationDTO
{
    public int ServiceId { get; set; }
    public int PatientId { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
}