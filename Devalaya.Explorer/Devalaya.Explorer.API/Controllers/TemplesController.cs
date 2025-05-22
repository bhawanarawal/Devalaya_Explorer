using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Devalaya.Explorer.DataAccess.Entities;
using Devalaya.Explorer.DataAccess;

namespace Devalaya.Explorer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TemplesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Temples
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Temple>>> GetTemples()
        {
            return await _context.Temples.ToListAsync();
        }

        // GET: api/Temples/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Temple>> GetTemple(int id)
        {
            var temple = await _context.Temples.FindAsync(id);

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

            _context.Entry(temple).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TempleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Temples
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Temple>> PostTemple(Temple temple)
        {
            _context.Temples.Add(temple);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTemple", new { id = temple.Id }, temple);
        }

        // DELETE: api/Temples/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemple(int id)
        {
            var temple = await _context.Temples.FindAsync(id);
            if (temple == null)
            {
                return NotFound();
            }

            _context.Temples.Remove(temple);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TempleExists(int id)
        {
            return _context.Temples.Any(e => e.Id == id);
        }
    }
}
