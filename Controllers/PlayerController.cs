using Microsoft.AspNetCore.Mvc;
using SerieAFantasyGame.Models;
using SerieAFantasyGame.ViewModels;
namespace SerieAFantasyGame.Controllers;


public class PlayerController(IPlayerRepository playerRepository, IStatisticsRepository statisticsRepository) : Controller
{
    private readonly IPlayerRepository _playerRepository = playerRepository;
    private readonly IStatisticsRepository _statisticsRepository = statisticsRepository;

    public IActionResult List()
    {
        //ViewBag.CurrentRound = "Round 16";
        //return View(_playerRepository.AllPlayers);
        PlayerListViewModel playerListViewModel = new(_playerRepository.AllPlayers, "Round 16");
        return View(playerListViewModel);
    }

    public IActionResult Details(int id)
    {
        Player player = _playerRepository.GetPlayerById(id);
        Statistics stats = _statisticsRepository.GetStatisticsById(id);

        if (player == null || stats == null)
        {
            return NotFound();
        }
        PlayerWithStatisticsViewModel playerWtihStatistics = new(player, stats);
        return View(playerWtihStatistics);
    }
}
