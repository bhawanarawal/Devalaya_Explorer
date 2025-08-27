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
    public class FavouritesController : ControllerBase
    {
        private readonly IFavouritesRepository favouritesRepository;

        public FavouritesController(IFavouritesRepository favouriteRepository)
        {
            favouritesRepository = favouriteRepository;
        }


        // GET: api/Favourites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Favourite>>> GetFavourites()
        {
            var favourites= await favouritesRepository.GetLikesCount();
            return Ok(favourites);
        }

       
       

        // POST: api/Favourites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Favourite>> PostFavourite(Favourite favourite)
        {
            await favouritesRepository.AddLike(favourite);

            return CreatedAtAction("GetFavourite", new { id = favourite.Id }, favourite);
        }

        
    }
}
