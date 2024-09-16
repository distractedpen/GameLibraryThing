using backend.Models;

namespace backend.Interfaces;

public interface ILibraryRepository
{
    public Task<List<Game>> GetUserLibrary(User user);
    
    public Task<Library> CreateAsync(Library library);
    
    public Task<Library?> DeleteAsync(User user, string gameId);
}