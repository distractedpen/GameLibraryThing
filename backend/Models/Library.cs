using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

[Table("Libraries")]
public class Library
{
    public string UserId { get; set; }
    public long GameId { get; set; }
    public User User { get; set; }
    public Game Game { get; set; }
}