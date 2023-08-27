namespace Hipokrates.DTOs.Patient;

public class ConsultationDTO
{
    public int Id { get; set; }
    public string ServiceName { get; set; }
    public int Room { get; set; }
    public int Floor { get; set; }
    public string Status { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
}