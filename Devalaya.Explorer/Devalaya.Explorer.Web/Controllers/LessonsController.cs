using Devalaya.Explorer.DataAccess.Entities;
using Devalaya.Explorer.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Devalaya.Explorer.Web.Controllers
{
    public class LessonsController : Controller
    {
        private readonly ILessonsRepository _lessonsRepository;

        public LessonsController(ILessonsRepository lessonsRepo)
        {
            _lessonsRepository = lessonsRepo;
        }

        
        public async Task<IActionResult> Index()
        {
            var lessons = await _lessonsRepository.GetAllLessonsAsync();
            return View(lessons);
        }
    }
}
