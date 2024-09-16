using backend.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/games")]
public class GameController : ControllerBase
{
    private readonly IGameRepository _gameRepository;
    private readonly IIgdbService _igdbService;
    
    public GameController(IGameRepository gameRepository, IIgdbService igdbService)
    {
        _gameRepository = gameRepository;    
        _igdbService = igdbService;
    }

    [HttpGet("{gameId:long}")]
    public async Task<ActionResult<Game>> GetGameByIdAsync(long gameId)
    {
        // check if game exists in local db
        var game = await _gameRepository.GetByIdAsync(gameId);
        if (game != null) return Ok(game);
        
        var igdbGame = await _igdbService.GetGameById(gameId);
        if (igdbGame == null) return NotFound("Game not found");

        var newGame = new Game
        {
            Id = igdbGame.Id == null ? -1 : igdbGame.Id.Value,
            Name = igdbGame.Name,
        };
        await _gameRepository.CreateAsync(newGame);
        return Ok(newGame);
    }
}