using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Devalaya.Explorer.DataAccess.Entities;
using Devalaya.Explorer.DataAccess;

namespace Devalaya.Explorer.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext db;

        public EventsController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = db.Events.Include(x => x.Temple);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await db.Events
                .Include(x => x.Temple)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            ViewData["TempleId"] = new SelectList(db.Temples, "Id", "Name");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Details,EventDate,Contact,TempleId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Add(@event);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TempleId"] = new SelectList(db.Temples, "Id", "Id", @event.TempleId);
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await db.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            ViewData["TempleId"] = new SelectList(db.Temples, "Id", "Id", @event.TempleId);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Details,EventDate,Contact,TempleId")] Event @event)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(@event);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id))
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
            ViewData["TempleId"] = new SelectList(db.Temples, "Id", "Id", @event.TempleId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await db.Events
                .Include(x => x.Temple)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await db.Events.FindAsync(id);
            if (@event != null)
            {
                db.Events.Remove(@event);
            }

            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return db.Events.Any(e => e.Id == id);
        }
    }
}
