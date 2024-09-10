using backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/games")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly IGameRepository _gameRepository;
    private readonly ILogger<GameController> _logger;
    
    public GameController(IGameRepository gameRepository, ILogger<GameController> logger)
    {
        _gameRepository = gameRepository;
        _logger = logger;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        _logger.LogInformation("Starting GetAll");
        var games = await _gameRepository.GetAllAsync();
        return Ok(games);
    }
}