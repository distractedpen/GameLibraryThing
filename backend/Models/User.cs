using Microsoft.AspNetCore.Identity;

namespace backend.Models;

public class User : IdentityUser
{
    public List<Library> Libraries { get; set; } = new List<Library>();
}