namespace SerieAFantasyGame.Models;

public interface IPlayerRepository
{
    IEnumerable<Player> AllPlayers { get; }
    IEnumerable<Player> InFormPlayers { get; }
    Player? GetPlayerById(int playerId);
}
