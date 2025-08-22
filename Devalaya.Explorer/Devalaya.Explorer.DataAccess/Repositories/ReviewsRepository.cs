using Devalaya.Explorer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Devalaya.Explorer.DataAccess.Repositories
{
    public interface IReviewsRepository
    {
        Task AddReview(Review review);
    }

    public class ReviewsRepository : IReviewsRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewsRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddReview(Review review)
        {
            await _context.Reviews.AddAsync(review);
            _context.SaveChanges();

        }
    }
}
