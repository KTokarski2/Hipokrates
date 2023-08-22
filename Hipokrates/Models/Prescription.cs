namespace Hipokrates.Models;

public class Prescription
{
    public int Id { get; set; }
    public DateTime DateOfIssue { get; set; }
    public DateTime ExpiryDate { get; set; }
}