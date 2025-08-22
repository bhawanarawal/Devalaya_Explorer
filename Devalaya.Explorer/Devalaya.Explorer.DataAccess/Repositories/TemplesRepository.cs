using Devalaya.Explorer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Devalaya.Explorer.DataAccess.Repositories;
public interface ITemplesRepository
{
    Task<IEnumerable<Temple>> GetTemplesAsync(int count = 0);
    Task<int> GetTemplesCount();
    Task<Temple?> GetTempleByIdAsync(int id);
    Task<Temple?> GetTempleBySlugAsync(string slug);
    Task AddTempleAsync(Temple temple);
    Task UpdateTempleAsync(Temple temple);
    Task DeleteTempleAsync(Temple temple);
}
public class TemplesRepository : ITemplesRepository
{
    private readonly ApplicationDbContext _context;
    public TemplesRepository(ApplicationDbContext dbContext)
    {
        _context = dbContext;

    }
    public async Task AddTempleAsync(Temple temple)
    {
        _context.Add(temple);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTempleAsync(Temple temple)
    {
        _context.Remove(temple);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Temple>> GetTemplesAsync(int count = 0)
    {
        if (count != 0)
        {
            return await _context.Temples.Include(x=>x.Galleries).Take(count).ToListAsync();
        }
        return await _context.Temples.Include(x => x.Galleries).ToListAsync();
    }

    public async Task<Temple?> GetTempleByIdAsync(int id)
    {

        var temple = await _context.Temples.FindAsync(id);
        return temple;
    }
    public async Task<Temple?> GetTempleBySlugAsync(string slug)
    {
        return await _context.Temples.Include(x => x.Galleries).FirstOrDefaultAsync(t => t.Slug == slug);
    }
    public async Task UpdateTempleAsync(Temple temple)
    {
        _context.Update(temple);
        await _context.SaveChangesAsync();
    }

    public async Task<int> GetTemplesCount()
    {
        return await _context.Temples.CountAsync();
    }
}
