namespace SerieAFantasyGame.Models;


public class MockPlayerRepository : IPlayerRepository
{
    private readonly IStatisticsRepository _statisticsRepository = new MockStatisticsRepository();

    public IEnumerable<Player> AllPlayers =>
        new List<Player>
        {
            new Player {Id = 1, Name = "Nicolo Barella", Position = "Midfielder", Team = "Inter", ImageThumbnailUrl = "https://cdn-icons-png.flaticon.com/512/8584/8584470.png", Price = 14, TotalPoints = 210, Stats = _statisticsRepository.AllStatistics.ToList()[0], IsInForm = true},
            new Player {Id = 2, Name = "Giorgio Scalvini", Position = "Defender", Team = "Atalanta", ImageThumbnailUrl = "https://cdn-icons-png.flaticon.com/512/8584/8584470.png", Price = 11, TotalPoints = 54, Stats = _statisticsRepository.AllStatistics.ToList()[1], IsInForm = false},
            new Player {Id = 1, Name = "Artem Dovbyk", Position = "Striker", Team = "Roma", ImageThumbnailUrl = "https://cdn-icons-png.flaticon.com/512/8584/8584470.png", Price = 16, TotalPoints = 356, Stats = _statisticsRepository.AllStatistics.ToList()[2], IsInForm = true}
        };
    
    public IEnumerable<Player> InFormPlayers
    {
        get
        {
            return AllPlayers.Where(p => p.IsInForm);
        }
    }

    public Player? GetPlayerById(int playerId)
    {
        return AllPlayers.FirstOrDefault(p => p.Id == playerId);
    }

    public IEnumerable<Player> SearchPlayers(string searchQuery)
    {
        throw new NotImplementedException();
    }
}
