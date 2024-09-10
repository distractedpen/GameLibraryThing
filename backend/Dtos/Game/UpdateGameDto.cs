using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Game;

public class UpdateGameDto
{
    [Required]
    [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
    public string Developer { get; set; } = string.Empty;

    [Required]
    [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
    public string Status { get; set; } = string.Empty;
}