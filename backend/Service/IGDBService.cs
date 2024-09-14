using backend.Interfaces;
using IGDB;
using IGDB.Models;

namespace backend.Service;

public class IGDBService : IIGDBService
{
    private readonly IGDBClient _igdb;
    private readonly ILogger<IGDBService> _logger;
    public IGDBService(ILogger<IGDBService> logger)
    {
        _logger = logger;
        _igdb = new IGDBClient(
            clientId: Environment.GetEnvironmentVariable("IGDB_CLIENT_ID"),
            Environment.GetEnvironmentVariable("IGDB_CLIENT_SECRET")
        );
    }
    
    public async Task<Game[]> SearchGamesByName(string name)
    {
        var query = $"fields name; search \"{name}\";";
        _logger.LogInformation($"Executing query: {query}");
        var games = await _igdb.QueryAsync<Game>(IGDBClient.Endpoints.Games, query);
        return games;
    }

    public async Task<Game?> GetGameByName(string name)
    {
        var query = $"fields id,name; where name = \"{name}\";";
        _logger.LogInformation($"Executing query: {query}");
        var games = await _igdb.QueryAsync<Game>(IGDBClient.Endpoints.Games, query);
        var game = games.FirstOrDefault();
        return game;
    }
}