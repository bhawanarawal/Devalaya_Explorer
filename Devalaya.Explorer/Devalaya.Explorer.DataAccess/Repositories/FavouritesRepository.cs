using Devalaya.Explorer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Devalaya.Explorer.DataAccess.Repositories
{
    public interface IFavouritesRepository
    {
        Task<List<(string, int)>> GetLikesCount();
        Task<int> GetLikesCount(int templeId);
        Task AddLike(Favourite favourite);
    }

    public class FavouritesRepository : IFavouritesRepository
    {
        private readonly ApplicationDbContext _context;

        public FavouritesRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddLike(Favourite favourite)
        {

            await _context.Favourites.AddAsync(favourite);
            _context.SaveChanges();
        }

        public async Task<List<(string, int)>> GetLikesCount()
        {
            var likes = await _context.Favourites.Include(x => x.Temple).ToListAsync();
            var likesGrouped = likes.GroupBy(x => x.Temple.Name);

            List<(string, int)> totalLikes = [];

            foreach (var like in likesGrouped)
            {
                totalLikes.Add((like.Key, like.Count()));
            }

            return totalLikes;
        }

        public async Task<int> GetLikesCount(int templeId)
        {
            return await _context.Favourites.Where(x => x.TempleId == templeId).CountAsync();
        }
    }
}
