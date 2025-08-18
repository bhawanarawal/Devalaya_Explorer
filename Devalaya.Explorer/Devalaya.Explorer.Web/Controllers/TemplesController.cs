using Devalaya.Explorer.DataAccess.Entities;
using Devalaya.Explorer.DataAccess.Repositories;
using Devalaya.Explorer.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Devalaya.Explorer.Web.Controllers
{
    public class TemplesController(ITemplesRepository templesRepo) : Controller
    {
        private readonly ITemplesRepository _templesRepository = templesRepo;
        [Route("Temples")]
        public async Task<IActionResult> Index()
        {
            var temples = await _templesRepository.GetTemplesAsync();
            return View(temples);
        }
        public async Task<IActionResult> UserIndex()
        {
            var temples = await _templesRepository.GetTemplesAsync();
            return View(temples);
        }
       
        public async Task<IActionResult> Details(string slug)
        {
            if (string.IsNullOrEmpty(slug)) return NotFound();
            var temple = await _templesRepository.GetTempleBySlugAsync(slug);
            return temple == null ? NotFound() : View(temple);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult TempleDetail()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Temple temple)
        {
            // Save file upload logic here
            if (temple.Image != null)
            {
                var fileName = Path.GetFileName(temple.Image.FileName);
                var imagepath=Path.Combine("images", "temples", fileName);
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imagepath);
                using (var stream = new FileStream(uploadPath, FileMode.Create))
                {
                    await temple.Image.CopyToAsync(stream);
                }
                temple.ImagePath = imagepath;
            }

            if (ModelState.IsValid)
            {
                temple.Slug = SlugHelper.GenerateSlug(temple.Name);
                temple.CreatedDate = DateTime.Now;
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
        public async Task<IActionResult> Edit(int id, Temple temple)
        {
            // Save file upload logic here
            if (temple.Image != null)
            {
                var fileName = Path.GetFileName(temple.Image.FileName);
                var imagepath = Path.Combine("images", "temples", fileName);
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imagepath);
                using (var stream = new FileStream(uploadPath, FileMode.Create))
                {
                    await temple.Image.CopyToAsync(stream);
                }
                temple.ImagePath = imagepath;
            }
            if (id != temple.Id) return NotFound();
            if (ModelState.IsValid)
            {
                temple.LastModiefiedDate= DateTime.Now;
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