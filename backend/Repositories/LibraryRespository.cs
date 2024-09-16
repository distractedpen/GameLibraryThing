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
            .Select(library => new Game
            {
                Id = library.Game.Id,
                Name = library.Game.Name,
            }).ToListAsync();
    }

    public async Task<Library> CreateAsync(Library library)
    {
        await _context.Libraries.AddAsync(library);
        await _context.SaveChangesAsync();
        return library;
    }

    public async Task<Library?> DeleteAsync(User user, long gameId)
    {
        var library = await _context.Libraries.FirstOrDefaultAsync(u => u.UserId == user.Id && u.Game.Id == gameId);

        if (library == null) return null;
        
        _context.Libraries.Remove(library);
        await _context.SaveChangesAsync();
        return library;
    }
}