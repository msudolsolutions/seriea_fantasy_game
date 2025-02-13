using System.Threading.Tasks;
namespace SerieAFantasyGame.Models;


public interface IPlayerFetcher
{
    Task<List<Player>> FetchPlayers();
}
