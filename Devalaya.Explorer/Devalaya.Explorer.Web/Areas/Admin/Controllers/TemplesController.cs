using Devalaya.Explorer.DataAccess.Entities;
using Devalaya.Explorer.DataAccess.Repositories;
using Devalaya.Explorer.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Devalaya.Explorer.Web.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TemplesController(ITemplesRepository templesRepo,IGalleryRepository galleryRepo) : Controller
    {
        private readonly ITemplesRepository _templesRepository = templesRepo;
        private readonly IGalleryRepository _galleryRepository = galleryRepo;

        public async Task<IActionResult> Index()
        {
            var temples = await _templesRepository.GetTemplesAsync();
            return View(temples);
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

            if (ModelState.IsValid)
            {
                temple.Slug = SlugHelper.GenerateSlug(temple.Name);
                temple.CreatedDate = DateTime.Now;
                await _templesRepository.AddTempleAsync(temple);
            }

            List<Gallery> galleries = [];

            // Save file upload logic here
            if (temple.Images != null)
            {
                foreach (var file in temple.Images)
                {
                    if (file?.Length == 0) continue;
                    var fileName = Path.GetFileName(file.FileName);
                    var imagepath = Path.Combine("images", "temples", fileName);
                    var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imagepath);
                    using (var stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    galleries.Add(new Gallery
                    {
                        ImagePath = imagepath,
                        TempleId = temple.Id
                    });
                }

               
            }

            if (galleries.Count > 0)
            {
                
                await _galleryRepository.AddGalleriesAsync(galleries);
                
            }
            return View();
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
            List<Gallery> galleries = [];

            // Save file upload logic here
            if (temple.Images != null)
            {
                foreach (var file in temple.Images)
                {
                    if (file?.Length == 0) continue;
                    var fileName = Path.GetFileName(file.FileName);
                    var imagepath = Path.Combine("images", "temples", fileName);
                    var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imagepath);
                    using (var stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    galleries.Add(new Gallery
                    {
                        ImagePath = imagepath,
                        TempleId = id
                    });
                }


            }

            if (galleries.Count > 0)
            {

                await _galleryRepository.AddGalleriesAsync(galleries);

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