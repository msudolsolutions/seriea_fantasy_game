namespace SerieAFantasyGame.Models;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string Team { get; set; } = string.Empty;
    public int Price { get; set; }
    public int TotalPoints { get; set; }
    public Statistics Stats { get; set; } = default!;
    public bool IsInForm { get; set; }
}
