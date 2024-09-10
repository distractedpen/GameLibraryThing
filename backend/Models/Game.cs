namespace backend.Models;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Developer { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}