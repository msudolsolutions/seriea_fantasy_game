namespace SerieAFantasyGame.Models;


public class StatisticsRepository(SerieAFantasyGameDbContext serieAFantasyGameDbContext) : IStatisticsRepository
{
    private readonly SerieAFantasyGameDbContext _serieAFantasyGameDbContext = serieAFantasyGameDbContext;

    public IEnumerable<Statistics> AllStatistics =>
        _serieAFantasyGameDbContext.StatisticsCollection;

    public Statistics? GetStatisticsById(int statisticsId)
    {
        return _serieAFantasyGameDbContext.StatisticsCollection.FirstOrDefault(s => s.Id == statisticsId);
    }
}
