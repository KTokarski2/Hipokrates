namespace Hipokrates.DTOs.Patient;

public class ChangeDateDTO
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
}