namespace SerieAFantasyGame.Models;


public interface IStatisticsRepository
{
    IEnumerable<Statistics> AllStatistics { get; }
    Statistics? GetStatisticsById(int statisticsId);
}
