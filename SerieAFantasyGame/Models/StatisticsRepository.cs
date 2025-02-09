namespace SerieAFantasyGame.Models;


public class StatisticsRepository(SerieAFantasyGameDbContext serieAFantasyGameDbContext) : IStatisticsRepository
{
    private readonly SerieAFantasyGameDbContext _serieAFantasyGameDbContext = serieAFantasyGameDbContext;

    public IEnumerable<Statistics> AllStatistics =>
        _serieAFantasyGameDbContext.StatisticsCollection;
}
