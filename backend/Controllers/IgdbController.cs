using backend.Interfaces;
using backend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/igdb")]
[ApiController]
public class IgdbController : ControllerBase
{
    private readonly IIgdbService _igdbService;
    private readonly ILogger<IgdbController> _logger;
    
    public IgdbController(IIgdbService igdbService, ILogger<IgdbController> logger)
    {
        _logger = logger;
        _igdbService = igdbService;
    }
    
    [HttpGet]
    [Route("{id:long}")]
    [Authorize]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        _logger.LogInformation($"Getting IGDB record for {id}");
        var game = await _igdbService.GetGameById(id);
        if (game == null) return NotFound(); 
        return Ok(game);
    }
    
    [HttpGet]
    [Route("search/")]
    [Authorize]
    public async Task<IActionResult> SearchAsync([FromQuery] string gameName, [FromQuery] int limit = 10, [FromQuery] int offset = 0)
    {
        var games = await _igdbService.SearchGamesByName(gameName, limit, offset);
        return Ok(games);
    }
}