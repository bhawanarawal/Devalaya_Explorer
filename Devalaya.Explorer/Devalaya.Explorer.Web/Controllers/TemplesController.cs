using Devalaya.Explorer.DataAccess;
using Devalaya.Explorer.DataAccess.Entities;
using Devalaya.Explorer.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Devalaya.Explorer.Web.Controllers
{
    public class TemplesController : Controller
    {
        private readonly ITemplesRepository templesRepository;

        public TemplesController(ITemplesRepository templesRepo)
        {
            templesRepository = templesRepo;
        }

        // GET: Temples
        public async Task<IActionResult> Index()
        {
            var temples = await templesRepository.GetAllTemplesAsync();
            return View(temples);
        }

        // GET: Temples/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temple = await templesRepository.GetTempleByIdAsync(id);
                
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
                
                return RedirectToAction(nameof(Index));
            }
            return View(temple);
        }

        // GET: Temples/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temple = await templesRepository.GetTempleByIdAsync(id);
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
               await templesRepository.UpdateTempleAsync(temple);

                return RedirectToAction(nameof(Index));
            }
            return View(temple);
        }

        // GET: Temples/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temple = await templesRepository.GetTempleByIdAsync(id);

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
            var temple = await templesRepository.GetTempleByIdAsync(id);
            if (temple != null)
            {
                await templesRepository.DeleteTempleAsync(temple);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
