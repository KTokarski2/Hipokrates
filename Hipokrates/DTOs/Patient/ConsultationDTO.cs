namespace Hipokrates.DTOs.Patient;

public class ConsultationDTO
{
    public int Id { get; set; }
    public string ServiceName { get; set; }
    public string Room { get; set; } = "unsigned";
    public string Floor { get; set; } = "unsigned";
    public string Status { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
}