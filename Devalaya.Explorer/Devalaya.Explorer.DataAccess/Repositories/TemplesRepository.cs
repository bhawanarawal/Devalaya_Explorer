using Devalaya.Explorer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devalaya.Explorer.DataAccess.Repositories;
public interface ITemplesRepository
{
    Task<IEnumerable<Temple>> GetAllTemplesAsync();
    Task<Temple> GetTempleByIdAsync(int id);
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

    public async Task<IEnumerable<Temple>> GetAllTemplesAsync()
    {
        return await _context.Temples.ToListAsync();
    }

    public async Task<Temple> GetTempleByIdAsync(int id)
    {

        var temple =  await _context.Temples.FindAsync(id);
        return temple;
    }

    public async Task UpdateTempleAsync(Temple temple)
    {
        _context.Update(temple);
        await _context.SaveChangesAsync();
    }
}
