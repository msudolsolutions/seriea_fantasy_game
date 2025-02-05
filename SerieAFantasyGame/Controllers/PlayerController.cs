using Microsoft.AspNetCore.Mvc;
using SerieAFantasyGame.Models;
namespace SerieAFantasyGame.Controllers;


public class PlayerController : Controller
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IStatisticsRepository _statisticsRepository;

    public PlayerController(IPlayerRepository playerRepository, IStatisticsRepository statisticsRepository)
    {
        _playerRepository = playerRepository;
        _statisticsRepository = statisticsRepository;
    }

    public IActionResult List()
    {
        ViewBag.CurrentStatistics = "Appearances";
        return View(_playerRepository.AllPlayers);
    }
}
