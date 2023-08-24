namespace Hipokrates.Models;

public interface IGuest
{
    public List<Service> ViewServices();
    public void CreateConsultation();
}