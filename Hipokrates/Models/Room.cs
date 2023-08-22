namespace Hipokrates.Models;

public class Room
{
    public int Id { get; set; }
    public virtual List<Consultation> Consultations { get; set; } = new List<Consultation>();
    public int RoomNumber { get; set; }
    public int FloorNumber { get; set; }
}