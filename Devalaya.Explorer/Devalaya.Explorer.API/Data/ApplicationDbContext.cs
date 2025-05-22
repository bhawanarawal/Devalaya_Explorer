using Devalaya.Explorer.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Devalaya.Explorer.Web.Data;

public class ApplicationDbContext : DbContext
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
