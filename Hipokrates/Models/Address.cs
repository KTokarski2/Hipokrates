namespace Hipokrates.Models;

public class Address
{
    public int Id { get; set; }
    public int IdPatient { get; set; }
    public virtual Patient Patient { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
}