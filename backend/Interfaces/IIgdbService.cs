using IGDB.Models;

namespace backend.Interfaces;

public interface IIgdbService
{
    // Search Game Names
    // limit in the query for now
    Task<Game[]> SearchGamesByName(string name, int limit, int offset);
    
    // Get Game by Name
    Task<Game?> GetGameByName(string name);
    
    Task<Game?> GetGameById(long id);
}