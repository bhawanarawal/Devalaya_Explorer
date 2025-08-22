using System.Diagnostics;
using Devalaya.Explorer.DataAccess.Repositories;
using Devalaya.Explorer.Web.Areas.Admin.ViewModels;
using Devalaya.Explorer.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Devalaya.Explorer.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DashboardController(
        ITemplesRepository templesRepository,
        ILessonsRepository lessonsRepository,
        IEventsRepository eventsRepository,
        IGalleryRepository galleryRepository) : Controller
    {
        private readonly ITemplesRepository templesRepository = templesRepository;
        private readonly ILessonsRepository lessonsRepository = lessonsRepository;
        private readonly IEventsRepository eventsRepository = eventsRepository;
        private readonly IGalleryRepository galleryRepository = galleryRepository;

        public async Task<IActionResult> Index()
        {
          var templecount = await templesRepository.GetTemplesCount();
            var lessoncount = await lessonsRepository.GetLessonCount();
            var eventcount = await eventsRepository.GetEventCount();
            var imagecount = await galleryRepository.GetImageCount();

            DashboardViewModel dashboardViewModel = new()
            {
                SiteCount = templecount,
                ImageCount = imagecount,
                EventCount = eventcount,
                LessonCount = lessoncount
            };

            return View(dashboardViewModel);
        }
    }
}
