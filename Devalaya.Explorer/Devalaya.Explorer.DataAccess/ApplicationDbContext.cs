using Devalaya.Explorer.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Devalaya.Explorer.DataAccess;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Temple> Temples { get; set; } 
    public DbSet<Event> Events { get; set; }
    public DbSet<Favourite> Favoutites { get; set; }
    public DbSet<Gallery> Galleries { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Review> Reviews { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
