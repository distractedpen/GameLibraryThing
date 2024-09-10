using backend.Data;
using backend.Dtos;
using backend.Interfaces;
using backend.Mappers;
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

    public async Task<Game?> GetByIdAsync(int id)
    {
        return await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<Game> CreateAsync(Game gameModel)
    {
        // TODO: Check if object with same data exists already, if so, return existing object
        await _context.Games.AddAsync(gameModel);
        await _context.SaveChangesAsync();
        return gameModel;
    }

    public async Task<Game?> UpdateAsync(int id, UpdateGameDto updateGameDto)
    {
        
        var existingGame = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);

        if (existingGame == null)
            return null;
        
        existingGame.Name = updateGameDto.Name;
        existingGame.Developer = updateGameDto.Developer;
        existingGame.Status = updateGameDto.Status;
        
        await _context.SaveChangesAsync();
        
        return existingGame;
    }

    public async Task<Game?> DeleteAsync(int id)
    {
        var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
        if (game == null)
        {
            return null;
        }
        
        _context.Remove(game);
        await _context.SaveChangesAsync();

        return game;
    }

    public async Task<bool> GameExists(int id)
    {
        return await _context.Games.AnyAsync(e => e.Id == id);
    }
}