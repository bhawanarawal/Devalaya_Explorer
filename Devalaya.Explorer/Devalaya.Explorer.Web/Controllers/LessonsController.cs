using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Devalaya.Explorer.DataAccess.Entities;
using Devalaya.Explorer.DataAccess;

namespace Devalaya.Explorer.Web.Controllers
{
    public class LessonsController : Controller
    {
        private readonly ApplicationDbContext db;
        //Dependency Injection
        public LessonsController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: Lessons
        [HttpGet]
        public IActionResult Index()
        {
            var lessons = db.Lessons.ToList();//select * from lessons
            return View(lessons);
        }

        // GET: Lessons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quote,Source")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                db.Add(lesson);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lesson);
        }

        // GET: Lessons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await db.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quote,Source")] Lesson lesson)
        {
            if (id != lesson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                db.Update(lesson);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lesson);
        }

        // GET: Lessons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await db.Lessons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lesson = await db.Lessons.FindAsync(id);
            if (lesson != null)
            {
                db.Lessons.Remove(lesson);
            }

            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
