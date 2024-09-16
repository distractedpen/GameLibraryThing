using backend.Data;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class GameRepository : IGameRepository
{
    private readonly ApplicationDbContext _context;

    public GameRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Game>> GetAllAsync()
    {
        return await _context.Games.ToListAsync();
    }

    public async Task<Game?> GetByIdAsync(long id)
    {
        return await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
    }
    
    public async Task<Game?> GetByNameAsync(string name)
    {
        return await _context.Games.FirstOrDefaultAsync(g => g.Name == name);
    }

    public async Task<Game> CreateAsync(Game gameModel)
    {
        if (await GameExists(gameModel.Id)) return gameModel;
        
        await _context.Games.AddAsync(gameModel);
        await _context.SaveChangesAsync();

        return gameModel;
    }


    public async Task<Game?> DeleteAsync(long id)
    {
        var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
        if (game == null) return null;

        _context.Remove(game);
        await _context.SaveChangesAsync();

        return game;
    }

    public async Task<bool> GameExists(long id)
    {
        return await _context.Games.AnyAsync(e => e.Id == id);
    }
}