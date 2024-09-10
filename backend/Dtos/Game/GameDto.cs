namespace backend.Dtos.Game;

public class GameDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Developer { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}