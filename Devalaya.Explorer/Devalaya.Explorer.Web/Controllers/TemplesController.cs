using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Devalaya.Explorer.DataAccess.Entities;
using Devalaya.Explorer.DataAccess;

namespace Devalaya.Explorer.Web.Controllers
{
    public class TemplesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TemplesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Temples
        public async Task<IActionResult> Index()
        {
            return View(await _context.Temples.ToListAsync());
        }

        // GET: Temples/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temple = await _context.Temples
                .FirstOrDefaultAsync(m => m.Id == id);
            if (temple == null)
            {
                return NotFound();
            }

            return View(temple);
        }

        // GET: Temples/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Temples/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Details,Address,Deity,MadeYear")] Temple temple)
        {
            if (ModelState.IsValid)
            {
                _context.Add(temple);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(temple);
        }

        // GET: Temples/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temple = await _context.Temples.FindAsync(id);
            if (temple == null)
            {
                return NotFound();
            }
            return View(temple);
        }

        // POST: Temples/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Details,Address,Deity,MadeYear")] Temple temple)
        {
            if (id != temple.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(temple);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TempleExists(temple.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(temple);
        }

        // GET: Temples/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temple = await _context.Temples
                .FirstOrDefaultAsync(m => m.Id == id);
            if (temple == null)
            {
                return NotFound();
            }

            return View(temple);
        }

        // POST: Temples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var temple = await _context.Temples.FindAsync(id);
            if (temple != null)
            {
                _context.Temples.Remove(temple);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TempleExists(int id)
        {
            return _context.Temples.Any(e => e.Id == id);
        }
    }
}
