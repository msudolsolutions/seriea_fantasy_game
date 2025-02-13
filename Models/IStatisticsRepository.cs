namespace SerieAFantasyGame.Models;


public interface IStatisticsRepository
{
    IEnumerable<Statistics> AllStatistics { get; }
}
