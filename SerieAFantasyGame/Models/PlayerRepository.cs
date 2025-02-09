using Microsoft.EntityFrameworkCore;
namespace SerieAFantasyGame.Models;


public class PlayerRepository(SerieAFantasyGameDbContext serieAFantasyGameDbContext) : IPlayerRepository
{
    private readonly SerieAFantasyGameDbContext _serieAFantasyGameDbContext = serieAFantasyGameDbContext;

    public IEnumerable<Player> AllPlayers
    {
        get
        {
            return _serieAFantasyGameDbContext.Players.Include(c => c.Stats);
        }
    }
    
    public IEnumerable<Player> InFormPlayers
    {
        get
        {
            return _serieAFantasyGameDbContext.Players.Include(c => c.Stats).Where(p => p.IsInForm);
        }
    }

    public Player? GetPlayerById(int playerId)
    {
        return _serieAFantasyGameDbContext.Players.FirstOrDefault(p => p.Id == playerId);
    }

    public IEnumerable<Player> SearchPlayers(string searchQuery)
    {
        throw new NotImplementedException();
    }
}
