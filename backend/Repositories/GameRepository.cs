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
}