using Devalaya.Explorer.DataAccess.Entities;
using Devalaya.Explorer.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Devalaya.Explorer.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventsRepository _eventsRepository;

        public EventsController(IEventsRepository eventsRepo)
        {
            _eventsRepository = eventsRepo;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var events = await _eventsRepository.GetAllEventsAsync();
            return View(events);
        }
    }
}
