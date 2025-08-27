using Devalaya.Explorer.DataAccess;
using Devalaya.Explorer.DataAccess.Entities;
using Devalaya.Explorer.DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Devalaya.Explorer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewsRepository reviewsRepository;

        public ReviewsController(IReviewsRepository reviewRepository)
        {
            reviewsRepository = reviewRepository;
        }
       
        // POST: api/Reviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
           await reviewsRepository.AddReview(review);

            return CreatedAtAction("GetReview", new { id = review.Id }, review);
        }

        
    }
}
