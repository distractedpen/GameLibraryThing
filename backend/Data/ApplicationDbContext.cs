using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Game> Games { get; set; }
    
    public DbSet<Library> Libraries { get; set; }

    // This is specifically for user Identity creation
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Game>().Property(g => g.Id).ValueGeneratedNever();

        modelBuilder.Entity<Library>(x => x.HasKey(p => new { p.UserId, p.GameId }));
        
        modelBuilder.Entity<Library>()
            .HasOne(u => u.User)
            .WithMany(u => u.Libraries)
            .HasForeignKey(p => p.UserId);
        
        modelBuilder.Entity<Library>()
            .HasOne(u => u.Game)
            .WithMany(u => u.Libraries)
            .HasForeignKey(p => p.GameId);

        List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER"
            }
        };
        modelBuilder.Entity<IdentityRole>().HasData(roles); 
    }
}