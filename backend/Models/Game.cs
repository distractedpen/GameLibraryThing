using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

[Table("Games")]
public class Game
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Developer { get; set; } = string.Empty;
    
    
    public List<Library> Libraries { get; set; } = new List<Library>();
}