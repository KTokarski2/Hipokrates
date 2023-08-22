namespace Hipokrates.Models;

public class Consultation
{
    public int Id { get; set; }
    public Status Status { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
}