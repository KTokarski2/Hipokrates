namespace Hipokrates.Models;

public class Recommendation
{
    public int Id { get; set; }
    public int IdRecommendations { get; set; }
    public virtual Recommendations Recommendations { get; set; }
    public string Text { get; set; }
}