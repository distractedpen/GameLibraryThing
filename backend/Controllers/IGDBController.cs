using backend.Interfaces;
using backend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/igdb")]
[ApiController]
public class IGDBController : ControllerBase
{
    private readonly IIGDBService _igdbService;
    private readonly ILogger<IGDBController> _logger;
    
    public IGDBController(IIGDBService igdbService, ILogger<IGDBController> logger)
    {
        _logger = logger;
        _igdbService = igdbService;
    }
    
    [HttpGet]
    [Route("{name}")]
    [Authorize]
    public async Task<IActionResult> GetAsync(string name)
    {
        _logger.LogInformation($"Getting IGDB record for {name}");
        var game = await _igdbService.GetGameByName(name);
        if (game == null) return NotFound(); 
        return Ok(game);
    }

    [HttpGet]
    [Route("search/{name}")]
    [Authorize]
    public async Task<IActionResult> SearchAsync(string name)
    {
        var games = await _igdbService.SearchGamesByName(name);
        return Ok(games);
    }
}