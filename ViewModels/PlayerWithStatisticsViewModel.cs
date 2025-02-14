using SerieAFantasyGame.Models;
namespace SerieAFantasyGame.ViewModels;


public class PlayerWithStatisticsViewModel(Player player, Statistics statistics)
{
    public Player PlayerWithoutStats { get; } = player;
    public Statistics Stats { get; } = statistics;
}
