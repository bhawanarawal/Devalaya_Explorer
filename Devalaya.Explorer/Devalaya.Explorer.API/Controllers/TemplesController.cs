using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Devalaya.Explorer.DataAccess.Entities;
using Devalaya.Explorer.DataAccess;
using Devalaya.Explorer.DataAccess.Repositories;

namespace Devalaya.Explorer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplesController : ControllerBase
    {
        private readonly ITemplesRepository templesRepository;

        public TemplesController(ITemplesRepository templesRepo)
        {
            templesRepository = templesRepo;
        }

        // GET: api/Temples
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Temple>>> GetTemples()
        {
          var temples= await templesRepository.GetAllTemplesAsync();
            return Ok(temples);
        }

        // GET: api/Temples/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Temple>> GetTemple(int id)
        {
            var temple = await templesRepository.GetTempleByIdAsync(id);

            if (temple == null)
            {
                return NotFound();
            }

            return temple;
        }

        // PUT: api/Temples/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTemple(int id, Temple temple)
        {
            if (id != temple.Id)
            {
                return BadRequest();
            }
        
           await templesRepository.UpdateTempleAsync(temple);

            return NoContent();
        }

        // POST: api/Temples
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Temple>> PostTemple(Temple temple)
        {
           await templesRepository.AddTempleAsync(temple);

            return CreatedAtAction("GetTemple", new { id = temple.Id }, temple);
        }

        // DELETE: api/Temples/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemple(int id)
        {
            var temple = await templesRepository.GetTempleByIdAsync(id);
            if (temple == null)
            {
                return NotFound();
            }
            await templesRepository.DeleteTempleAsync(temple);

            return NoContent();
        }
    }
}
