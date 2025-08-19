using Devalaya.Explorer.DataAccess.Entities;
using Devalaya.Explorer.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Devalaya.Explorer.Web.Admin.Controllers
{
    [Area("Admin")]
    public class LessonsController : Controller
    {
        private readonly ILessonsRepository _lessonsRepository;

        public LessonsController(ILessonsRepository lessonsRepo)
        {
            _lessonsRepository = lessonsRepo;
        }

        // GET: Lessons
        public async Task<IActionResult> Index()
        {

            var lessons = await _lessonsRepository.GetAllLessonsAsync();

            return View(lessons);
        }

        // GET: Lessons/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var lessonItem = await _lessonsRepository.GetLessonByIdAsync(id);
            return lessonItem == null ? NotFound() : View(lessonItem);
        }

        // GET: Lessons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lessons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quote,Source")] Lesson newLesson)
        {
            if (ModelState.IsValid)
            {
                await _lessonsRepository.AddLessonAsync(newLesson);
                return RedirectToAction(nameof(Index));
            }
            return View(newLesson);
        }

        // GET: Lessons/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var lessonItem = await _lessonsRepository.GetLessonByIdAsync(id);
            return lessonItem == null ? NotFound() : View(lessonItem);
        }

        // POST: Lessons/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quote,Source")] Lesson updatedLesson)
        {
            if (id != updatedLesson.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _lessonsRepository.UpdateLessonAsync(updatedLesson);
                return RedirectToAction(nameof(Index));
            }
            return View(updatedLesson);
        }

        // GET: Lessons/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var lessonItem = await _lessonsRepository.GetLessonByIdAsync(id);
            return lessonItem == null ? NotFound() : View(lessonItem);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lessonItem = await _lessonsRepository.GetLessonByIdAsync(id);

            if (lessonItem == null)
            {
                return NotFound();
            }

            await _lessonsRepository.DeleteLessonAsync(lessonItem);
            return RedirectToAction(nameof(Index));
        }

    }
}
