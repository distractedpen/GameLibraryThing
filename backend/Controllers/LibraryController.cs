using backend.Data;
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
    
    public LibraryController(UserManager<User> userManager, IGameRepository gameRepository, ILibraryRepository libraryRepository)
    {
        _userManager = userManager;
        _gameRepository = gameRepository;
        _libraryRepository = libraryRepository;
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
    public async Task<IActionResult> AddLibrary([FromQuery] string gameName)
    {
        var username = User.GetUsername();
        var appUser = await _userManager.FindByNameAsync(username);
        var game = await _gameRepository.GetByNameAsync(gameName);

        if (game == null) return BadRequest("Game not found");
        
        var userLibrary = await _libraryRepository.GetUserLibrary(appUser);

        if (userLibrary.Any(x => x.Name.Equals(gameName, StringComparison.CurrentCultureIgnoreCase)))
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
    public async Task<IActionResult> DeleteLibrary([FromQuery] string gameName)
    {
        var username = User.GetUsername();
        var appUser = await _userManager.FindByNameAsync(username);
        
        var userPortfolio = await _libraryRepository.GetUserLibrary(appUser);
        
        var filteredGame =  userPortfolio.Where(x => x.Name.Equals(gameName, StringComparison.CurrentCultureIgnoreCase)).ToList();

        if (filteredGame.Count == 1)
        {
            await _libraryRepository.DeleteAsync(appUser, gameName);
        }
        else
        {
            return BadRequest("Game not found");
        }

        return Ok();
    }
    
}