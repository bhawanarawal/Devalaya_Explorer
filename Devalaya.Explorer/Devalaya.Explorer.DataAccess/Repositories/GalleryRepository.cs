using Devalaya.Explorer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Devalaya.Explorer.DataAccess.Repositories;
public interface IGalleryRepository
{
    Task<IEnumerable<Gallery>> GetGalleriesAsync(int templeId=0);
    
    Task AddGalleriesAsync(List<Gallery> galleries);
 
}
public class GalleryRepository : IGalleryRepository
{
    private readonly ApplicationDbContext _context;
    public GalleryRepository(ApplicationDbContext dbContext)
    {
        _context = dbContext;

    }

    public async Task AddGalleriesAsync(List<Gallery> galleries)
    {
        _context.Galleries.AddRange(galleries);
       await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Gallery>> GetGalleriesAsync(int templeId = 0)
    {
        if(templeId != 0)
        {
            return await _context.Galleries.Where(g => g.TempleId == templeId).ToListAsync();
        }
        // If no templeId is provided, return all galleries
        return await _context.Galleries.ToListAsync();

    }
}