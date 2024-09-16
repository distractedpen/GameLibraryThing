using backend.Extensions;
using backend.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/library/")]
[ApiController]
public class LibraryController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly IGameRepository _gameRepository;
    private readonly ILibraryRepository _libraryRepository;
    private readonly IIgdbService _igdbService;
    
    public LibraryController(UserManager<User> userManager, IGameRepository gameRepository, ILibraryRepository libraryRepository, IIgdbService igdbService)
    {
        _userManager = userManager;
        _gameRepository = gameRepository;
        _libraryRepository = libraryRepository;
        _igdbService = igdbService;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetUserLibrary()
    {
        var username = User.GetUsername();
        var appUser = await _userManager.FindByNameAsync(username);
        var userLibrary = await _libraryRepository.GetUserLibrary(appUser);
        return Ok(userLibrary);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddLibrary([FromQuery] long gameId)
    {
        // check if game exists in local db
        var game = await _gameRepository.GetByIdAsync(gameId);
        if (game == null)
        {
            var igdbGame = await _igdbService.GetGameById(gameId);
            if (igdbGame == null) return NotFound("Game not found");

            game = new Game
            {
                Id = igdbGame.Id == null ? -1 : igdbGame.Id.Value,
                Name = igdbGame.Name,
            };
            await _gameRepository.CreateAsync(game);
        } 
        
        var username = User.GetUsername();
        var appUser = await _userManager.FindByNameAsync(username);
        var userLibrary = await _libraryRepository.GetUserLibrary(appUser);

        if (userLibrary.Any(x => x.Id == gameId))
        {
            BadRequest("Cannot add duplicate game");
        }

        var libraryModel = new Library
        {
            GameId = game.Id,
            UserId = appUser.Id,
        };
        
        await _libraryRepository.CreateAsync(libraryModel);

        return Created();
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> DeleteLibrary([FromQuery] long gameId)
    {
        var username = User.GetUsername();
        var appUser = await _userManager.FindByNameAsync(username);
        
        var userPortfolio = await _libraryRepository.GetUserLibrary(appUser);
        
        var filteredGame =  userPortfolio.Where(x => x.Id == gameId).ToList();

        if (filteredGame.Count == 1)
        {
            await _libraryRepository.DeleteAsync(appUser, gameId);
        }
        else
        {
            return BadRequest("Game not found");
        }

        return Ok();
    }
}