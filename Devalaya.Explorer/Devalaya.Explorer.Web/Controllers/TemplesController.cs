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
       
        public async Task<IActionResult> Details(string slug)
        {
            if (string.IsNullOrEmpty(slug)) return NotFound();
            var temple = await _templesRepository.GetTempleBySlugAsync(slug);
            return temple == null ? NotFound() : View(temple);
        }
    }
}