using backend.Models;

namespace backend.Interfaces;

public interface IGameRepository
{
    public Task<List<Game>> GetAllAsync();
}