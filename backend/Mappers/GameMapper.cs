using backend.Dtos.Game;
using backend.Models;

namespace backend.Mappers;

public static class GameMapper
{
    public static GameDto ToGameDto(this Game game)
    {
        return new GameDto
        {
            Id = game.Id,
            Name = game.Name,
            Developer = game.Developer,
            Status = game.Status
        };
    }

    public static Game ToGameFromCreateDto(this CreateGameDto createGameDto)
    {
        return new Game
        {
            Developer = createGameDto.Developer,
            Name = createGameDto.Name,
            Status = createGameDto.Status
        };
    }
}