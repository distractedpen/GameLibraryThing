using backend.Dtos;
using backend.Dtos.Game;
using backend.Models;

namespace backend.Interfaces;

public interface IGameRepository
{
    public Task<List<Game>> GetAllAsync();
    
    public Task<Game?> GetByIdAsync(int id);

    public Task<Game> CreateAsync(Game game);
    
    public Task<Game?> UpdateAsync(int id, UpdateGameDto updateGameDto);

    public Task<Game?> DeleteAsync(int id);
        
    public Task<bool> GameExists(int id);
}