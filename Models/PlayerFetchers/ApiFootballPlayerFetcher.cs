using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
namespace SerieAFantasyGame.Models;


public class ApiFootballPlayerFetcher : IPlayerFetcher
{
    private readonly HttpClient _httpClient = new HttpClient();
    private readonly string apiFootballKey = "653da1f0a0mshcc6113c12125d73p18a814jsnb1451c41f41c";

    public class ApiResponse
    {
        [JsonProperty("response")]
        public List<PlayerData> Response { get; set; }

        [JsonProperty("paging")]
        public PagingInfo Paging { get; set; }
    }

    public class PagingInfo
    {
        [JsonProperty("current")]
        public int Current { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class PlayerData
    {
        [JsonProperty("player")]
        public PlayerInfo Player { get; set; }

        [JsonProperty("statistics")]
        public List<PlayerStatistics> Statistics { get; set; }
    }

    public class PlayerInfo
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Nationality { get; set; }
    }

    public class PlayerStatistics
    {
        public TeamInfo Team { get; set; }
        public LeagueInfo League { get; set; }
        public GameStats Games { get; set; }
        public ShotStats Shots { get; set; }
        public GoalStats Goals { get; set; }
        public PassStats Passes { get; set; }
        public TackleStats Tackles { get; set; }
        public CardStats Cards { get; set; }
        public PenaltyStats Penalty { get; set; }
        public DribbleStats Dribbles { get; set; }
        public FoulStats Fouls { get; set; }
    }

    public class TeamInfo
    {
        public string Name { get; set; }
    }

    public class LeagueInfo
    {
        public string Name { get; set; }
    }

    public class GameStats
    {
        public int? Appearences { get; set; }
        public int? Lineups { get; set; }
        public int? Minutes { get; set; }
        public string Position { get; set; }
    }

    public class ShotStats
    {
        public int? Total { get; set; }
        public int? On { get; set; }
    }

    public class GoalStats
    {
        public int? Total { get; set; }
        public int? Assists { get; set; }
        public int? Saves { get; set; }
        public int? CleanSheets { get; set; }
    }

    public class PassStats
    {
        public int? Total { get; set; }
        public int? Accuracy { get; set; }
        public int? Key { get; set; }
    }

    public class TackleStats
    {
        public int? Total { get; set; }
        public int? Interceptions { get; set; }
    }

    public class CardStats
    {
        public int? Yellow { get; set; }
        public int? Red { get; set; }
    }

    public class PenaltyStats
    {
        public int? Scored { get; set; }
    }

    public class DribbleStats
    {
        public int? Success { get; set; }
    }

    public class FoulStats
    {
        public int? Drawn { get; set; }
        public int? Committed { get; set; }
    }

    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public async Task<List<Player>> FetchPlayers()
    {
        List<Player> allPlayers = new List<Player>();
        List<Team> teams = await FetchAllTeams();

        foreach (var team in teams)
        {
            int currentPage = 1;
            int totalPages = 1; // Start with 1 and update later

            do
            {
                var requestUrl = $"https://api-football-v1.p.rapidapi.com/v3/players?team={team.Id}&league=135&season=2023&page={currentPage}";
                var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                request.Headers.Add("X-RapidAPI-Key", apiFootballKey);
                request.Headers.Add("X-RapidAPI-Host", "api-football-v1.p.rapidapi.com");

                using (var response = await _httpClient.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonData = await response.Content.ReadAsStringAsync();
                        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonData);                 

                        if (apiResponse?.Response != null)
                        {
                            Console.WriteLine($"Page {currentPage} contains {apiResponse.Response.Count} players");
                            foreach (var p in apiResponse.Response.Take(5)) 
                            {
                                Console.WriteLine($"- {p.Player.Name}, {p.Player.Nationality}, {p.Statistics.FirstOrDefault()?.Team?.Name}");
                            }

                            foreach (var p in apiResponse.Response)
                            {
                                var stats = p.Statistics.FirstOrDefault();

                                if (stats != null)
                                {
                                    Statistics statistics = new Statistics{
                                        Appearances = stats.Games?.Appearences,
                                        Starters = stats.Games?.Lineups,
                                        TotalMinutes = stats.Games?.Minutes,
                                        Goals = stats.Goals?.Total,
                                        PenaltyGoals = stats.Penalty?.Scored,
                                        Assists = stats.Goals?.Assists,
                                        YellowCards = stats.Cards?.Yellow,
                                        RedCards = stats.Cards?.Red,
                                        Shots = stats.Shots?.Total,
                                        ShotsOnTarget = stats.Shots?.On,
                                        Dribbles = stats.Dribbles?.Success,
                                        Passes = stats.Passes?.Total,
                                        AccuratePasses = stats.Passes?.Accuracy,
                                        KeyPasses = stats.Passes?.Key,
                                        WasFouled = stats.Fouls?.Drawn,
                                        Tackles = stats.Tackles?.Total,
                                        Fouls = stats.Fouls?.Committed,
                                        Interceptions = stats.Tackles?.Interceptions,
                                        CleanSheets = stats.Goals?.CleanSheets,
                                        Saves = stats.Goals?.Saves
                                    };

                                    if (!AreAllPropertiesNull(statistics))
                                    {
                                        allPlayers.Add(new Player
                                        {
                                            Name = p.Player.Name,
                                            Age = p.Player.Age,
                                            Nationality = p.Player.Nationality,
                                            Team = team.Name,
                                            Position = stats.Games?.Position,
                                            Stats = statistics
                                        });
                                    }
                                }
                            }

                            // Update total pages based on API response
                            totalPages = apiResponse.Paging?.Total ?? 1;
                        }
                    }
                }

                currentPage++; // Move to the next page

            } while (currentPage <= totalPages); // Fetch a few more pages, just in case
        }

        

        return allPlayers;

        static bool AreAllPropertiesNull(object obj)
        {
            if (obj == null)
                return true;

            return obj.GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .All(p => p.GetValue(obj) == null);
        }
    }

    public async Task<List<Team>> FetchAllTeams()
    {
        List<Team> allTeams = new List<Team>();
        var requestUrl = "https://api-football-v1.p.rapidapi.com/v3/teams?league=135&season=2023";
        var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
        request.Headers.Add("X-RapidAPI-Key", apiFootballKey);
        request.Headers.Add("X-RapidAPI-Host", "api-football-v1.p.rapidapi.com");

        using (var response = await _httpClient.SendAsync(request))
        {
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                dynamic apiResponse = JsonConvert.DeserializeObject(jsonData);

                foreach (var team in apiResponse.response)
                {
                    allTeams.Add(new Team
                    {
                        Id = team.team.id,
                        Name = team.team.name
                    });
                }
            }
        }

        return allTeams;
    }
}
