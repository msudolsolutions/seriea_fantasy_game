namespace SerieAFantasyGame.Models;


public class MockStatisticsRepository : IStatisticsRepository
{
    public IEnumerable<Statistics> AllStatistics =>
        new List<Statistics>
        {
            new Statistics{Appearances = 10, Starters = 9, TotalMinutesPlayed = 810, Goals = 3, PenaltyGoals = 0, Assists = 1, YellowCards = 1, RedCards = 0, Shots = 11, ShotsOnTarget = 7, Dribbles = 3, Passes = 253, AccuratePasses = 211, KeyPasses = 3, WasFouled = 17, Tackles = 19, Fouls = 9, Interceptions = 13, CleanSheets = 0, Saves = 0},
            new Statistics{Appearances = 9, Starters = 2, TotalMinutesPlayed = 340, Goals = 0, PenaltyGoals = 0, Assists = 1, YellowCards = 2, RedCards = 0, Shots = 2, ShotsOnTarget = 0, Dribbles = 2, Passes = 83, AccuratePasses = 71, KeyPasses = 0, WasFouled = 17, Tackles = 19, Fouls = 9, Interceptions = 13, CleanSheets = 0, Saves = 0},
            new Statistics{Appearances = 15, Starters = 13, TotalMinutesPlayed = 1067, Goals = 11, PenaltyGoals = 5, Assists = 3, YellowCards = 1, RedCards = 1, Shots = 34, ShotsOnTarget = 21, Dribbles = 14, Passes = 194, AccuratePasses = 166, KeyPasses = 4, WasFouled = 22, Tackles = 3, Fouls = 2, Interceptions = 5, CleanSheets = 0, Saves = 0}
        };
}
