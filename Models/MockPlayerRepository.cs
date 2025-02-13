namespace SerieAFantasyGame.Models;


public class MockPlayerRepository : IPlayerRepository
{
    private readonly IStatisticsRepository _statisticsRepository = new MockStatisticsRepository();

    public IEnumerable<Player> AllPlayers =>
        new List<Player>
        {
            new Player {Id = 1, Name = "Nicolo Barella", Age = 26, Nationality = "Italy", Team = "Inter", Position = "Midfielder", ImageThumbnailUrl = "https://cdn-icons-png.flaticon.com/512/8584/8584470.png", Price = 14, TotalPoints = 210, IsInForm = true, Stats = _statisticsRepository.AllStatistics.ToList()[0]},
            new Player {Id = 2, Name = "Giorgio Scalvini", Age = 23, Nationality = "Italy", Team = "Atalanta", Position = "Defender", ImageThumbnailUrl = "https://cdn-icons-png.flaticon.com/512/8584/8584470.png", Price = 11, TotalPoints = 54, IsInForm = false, Stats = _statisticsRepository.AllStatistics.ToList()[1]},
            new Player {Id = 3, Name = "Artem Dovbyk", Age = 24, Nationality = "Ukraine", Team = "Roma", Position = "Striker", ImageThumbnailUrl = "https://cdn-icons-png.flaticon.com/512/8584/8584470.png", Price = 16, TotalPoints = 356, IsInForm = true, Stats = _statisticsRepository.AllStatistics.ToList()[2]}
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
