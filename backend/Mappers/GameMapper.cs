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
        };
    }

    public static Game ToGameFromCreateDto(this CreateGameDto createGameDto)
    {
        return new Game
        {
            Developer = createGameDto.Developer,
            Name = createGameDto.Name,
        };
    }
}