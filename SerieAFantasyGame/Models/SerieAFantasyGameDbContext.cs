using Microsoft.EntityFrameworkCore;
namespace SerieAFantasyGame.Models;


public class SerieAFantasyGameDbContext : DbContext
{
    public SerieAFantasyGameDbContext(DbContextOptions<SerieAFantasyGameDbContext> options) : base(options)
    {

    }

    public DbSet<Player> Players { get; set; }
    public DbSet<Statistics> StatisticsCollection { get; set; }
}
