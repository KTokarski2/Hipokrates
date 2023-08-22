namespace Hipokrates.Models;

public interface Guest
{
    public List<Service> ViewServices();
    public void CreateConsultation();
}