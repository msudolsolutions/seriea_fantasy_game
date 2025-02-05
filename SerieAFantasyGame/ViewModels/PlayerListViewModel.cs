using SerieAFantasyGame.Models;
namespace SerieAFantasyGame.ViewModels;


public class PlayerListViewModel(IEnumerable<Player> players, string? currentRound)
{
    public IEnumerable<Player> Players { get; } = players;
    public string? CurrentRound { get; } = currentRound;
}
