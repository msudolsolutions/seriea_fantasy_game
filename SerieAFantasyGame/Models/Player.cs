namespace SerieAFantasyGame.Models;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Age { get; set; }
    public string Nationality { get; set; }
    public string Team { get; set; }
    public string Position { get; set; }
    public string? ImageThumbnailUrl { get; set; }
    public int Price { get; set; }
    public int TotalPoints { get; set; }
    public bool IsInForm { get; set; }
    public Statistics Stats { get; set; } = default!;
}
