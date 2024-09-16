namespace backend.Dtos.Game;

public class GameDto
{
    public long Id { get; set; }
    public long GameId { get; set; } = -1;
    public string Name { get; set; } = string.Empty;
}