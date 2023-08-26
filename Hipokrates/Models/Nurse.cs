namespace Hipokrates.Models;

public sealed class Nurse : User
{
    public decimal BaseSalary = 5000m;

    public decimal CountBonus(int hours)
    {
        throw new NotImplementedException();
    }
}