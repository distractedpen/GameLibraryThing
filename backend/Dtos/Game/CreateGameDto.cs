using System.ComponentModel.DataAnnotations;

namespace backend.Dtos;

public class CreateGameDto
{
    [Required]
    [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
    public string Name { get; set; }
    [Required]
    [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
    public string Developer { get; set; }
    [Required]
    [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
    public string Status { get; set; }
}