using backend.Dtos.Game;
using backend.Interfaces;
using backend.Mappers;
using Microsoft.AspNetCore.Authorization;
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
        var gameDtos = games.Select(game => game.ToGameDto());
        return Ok(gameDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        _logger.LogInformation("Starting GetById");
        var game = await _gameRepository.GetByIdAsync(id);
        if (game == null) return NotFound();

        return Ok(game.ToGameDto());
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGameDto createGameDto)
    {
        var newGameModel = createGameDto.ToGameFromCreateDto();
        await _gameRepository.CreateAsync(newGameModel);
        return CreatedAtAction(nameof(GetById), new { id = newGameModel.Id }, newGameModel.ToGameDto());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateGameDto updateGameDto)
    {
        var updatedGame = await _gameRepository.UpdateAsync(id, updateGameDto);

        if (updatedGame == null) return NotFound();

        return Ok(updatedGame.ToGameDto());
    }


    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var game = await _gameRepository.DeleteAsync(id);
        if (game == null) return NotFound();
        return NoContent();
    }
}