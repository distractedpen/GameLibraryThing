using backend.Models;

namespace backend.Interfaces;

public interface IGameRepository
{
    public Task<Game?> GetByIdAsync(long id);
    public Task<Game?> GetByNameAsync(string name);
    public Task<Game> CreateAsync(Game gameModel);
    public Task<Game?> DeleteAsync(long id);
    public Task<bool> GameExists(long id); 
}