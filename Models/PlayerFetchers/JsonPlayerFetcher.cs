using Newtonsoft.Json;
using System.Text.Json.Serialization;
namespace SerieAFantasyGame.Models;


public class JsonPlayerFetcher : IPlayerFetcher
{
    private readonly string _filePath = "players.json";

    public async Task<List<Player>> FetchPlayers()
    {
        if (File.Exists(_filePath))
        {
            string json = await File.ReadAllTextAsync(_filePath);
            return JsonConvert.DeserializeObject<List<Player>>(json) ?? new List<Player>();
        }
        return new List<Player>();
    }
}
