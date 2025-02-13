namespace SerieAFantasyGame.Models
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            SerieAFantasyGameDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<SerieAFantasyGameDbContext>();

            if (!context.Players.Any())
            {
                IPlayerFetcher playerFetcher = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IPlayerFetcher>();
                var players = playerFetcher.FetchPlayers().Result;
                context.AddRange(players);
            }
            context.SaveChanges();
        }
    }
}
