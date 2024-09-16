namespace backend.Models;

public class Game
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Library> Libraries { get; set; } = [];
}