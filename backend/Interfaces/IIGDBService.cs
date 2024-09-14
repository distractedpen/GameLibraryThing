using IGDB.Models;

namespace backend.Interfaces;

public interface IIGDBService
{
    // Search Game Names
    // limit in the query for now
    Task<Game[]> SearchGamesByName(string name);
    
    // Get Game by Name
    Task<Game?> GetGameByName(string name);
}