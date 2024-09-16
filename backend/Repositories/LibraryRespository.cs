using backend.Data;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class LibraryRespository : ILibraryRepository
{
    private readonly ApplicationDbContext _context;
    public LibraryRespository(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }
    
    public async Task<List<Game>> GetUserLibrary(User user)
    {
        return await _context.Libraries.Where(u => u.UserId == user.Id)
            .Select(game => new Game
            {
                Id = game.Game.Id,
                Name = game.Game.Name,
                Developer = game.Game.Developer,
            }).ToListAsync();
    }

    public async Task<Library> CreateAsync(Library library)
    {
        await _context.Libraries.AddAsync(library);
        await _context.SaveChangesAsync();
        return library;
    }

    public async Task<Library?> DeleteAsync(User user, string gameName)
    {
        var library = await _context.Libraries.FirstOrDefaultAsync(u => u.UserId == user.Id && u.Game.Name.ToLower() == gameName.ToLower());

        if (library == null) return null;
        
        _context.Libraries.Remove(library);
        await _context.SaveChangesAsync();
        return library;
    }
}