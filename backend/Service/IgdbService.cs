using backend.Interfaces;
using IGDB;
using IGDB.Models;

namespace backend.Service;

public class IgdbService : IIgdbService
{
    private readonly IGDBClient _igdb;
    private readonly ILogger<IgdbService> _logger;
    public IgdbService(ILogger<IgdbService> logger)
    {
        _logger = logger;
        _igdb = new IGDBClient(
            clientId: Environment.GetEnvironmentVariable("IGDB_CLIENT_ID"),
            Environment.GetEnvironmentVariable("IGDB_CLIENT_SECRET")
        );
    }
    
    public async Task<Game[]> SearchGamesByName(string name, int limit, int offset)
    {
        var query = $"fields id, name; search \"{name}\"; limit {limit}; offset {offset};";
        _logger.LogInformation($"Executing query: {query}");
        var games = await _igdb.QueryAsync<Game>(IGDBClient.Endpoints.Games, query);
        return games;
    }

    public async Task<Game?> GetGameByName(string name)
    {
        var query = $"fields id,name; where name = {name};";
        _logger.LogInformation($"Executing query: {query}");
        var games = await _igdb.QueryAsync<Game>(IGDBClient.Endpoints.Games, query);
        var game = games.FirstOrDefault();
        return game;
    }

    public async Task<Game?> GetGameById(long id)
    {
        var query = $"fields id,name; where id = {id};";
        _logger.LogInformation($"Executing query: {query}");
        var games = await _igdb.QueryAsync<Game>(IGDBClient.Endpoints.Games, query);
        var game = games.FirstOrDefault();
        return game;
    }
}