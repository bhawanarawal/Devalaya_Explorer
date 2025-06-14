using Devalaya.Explorer.DataAccess.Entities;
using Devalaya.Explorer.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Devalaya.Explorer.Web.Controllers
{
    public class TemplesController : Controller
    {
        private readonly ITemplesRepository _templesRepository;

        public TemplesController(ITemplesRepository templesRepo)
        {
            _templesRepository = templesRepo;
        }

        public async Task<IActionResult> Index()
        {
            var temples = await _templesRepository.GetAllTemplesAsync();
            return View(temples);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null) return NotFound();
            var temple = await _templesRepository.GetTempleByIdAsync(id);
            return temple == null ? NotFound() : View(temple);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Details,Address,Deity,MadeYear")] Temple temple)
        {
            if (ModelState.IsValid)
            {
                await _templesRepository.AddTempleAsync(temple);
                return RedirectToAction(nameof(Index));
            }
            return View(temple);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null) return NotFound();
            var temple = await _templesRepository.GetTempleByIdAsync(id);
            return temple == null ? NotFound() : View(temple);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Details,Address,Deity,MadeYear")] Temple temple)
        {
            if (id != temple.Id) return NotFound();
            if (ModelState.IsValid)
            {
                await _templesRepository.UpdateTempleAsync(temple);
                return RedirectToAction(nameof(Index));
            }
            return View(temple);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null) return NotFound();
            var temple = await _templesRepository.GetTempleByIdAsync(id);
            return temple == null ? NotFound() : View(temple);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var temple = await _templesRepository.GetTempleByIdAsync(id);
            if (temple != null && ModelState.IsValid)
            {
                await _templesRepository.DeleteTempleAsync(temple);
                return RedirectToAction(nameof(Index));
            }
            return View(temple);
        }
    }
}