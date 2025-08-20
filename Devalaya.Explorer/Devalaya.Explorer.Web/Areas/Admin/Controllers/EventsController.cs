using Devalaya.Explorer.DataAccess.Entities;
using Devalaya.Explorer.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Devalaya.Explorer.Web.Admin.Controllers
{
    [Area("Admin")]
    public class EventsController : Controller
    {
        private readonly IEventsRepository _eventsRepository;
        private readonly ITemplesRepository _templesRepository;

        public EventsController(IEventsRepository eventsRepo, ITemplesRepository templesRepo)
        {
            _eventsRepository = eventsRepo;
            _templesRepository = templesRepo;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var events = await _eventsRepository.GetAllEventsAsync();
            return View(events);
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var eventItem = await _eventsRepository.GetEventByIdAsync(id);
            return eventItem == null ? NotFound() : View(eventItem);
        }

        // GET: Events/Create
        public async Task<IActionResult> Create()
        {
            var temples= await _templesRepository.GetTemplesAsync();
            ViewBag.Temples = temples.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event newEvent)
        {
            if (ModelState.IsValid)
            {
                await _eventsRepository.AddEventAsync(newEvent);
                return RedirectToAction(nameof(Index));
            }
            return View(newEvent);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var eventItem = await _eventsRepository.GetEventByIdAsync(id);
            return eventItem == null ? NotFound() : View(eventItem);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Details,EventDate,Conatct")] Event updatedEvent)
        {
            if (id != updatedEvent.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _eventsRepository.UpdateEventAsync(updatedEvent);
                return RedirectToAction(nameof(Index));
            }
            return View(updatedEvent);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var eventItem = await _eventsRepository.GetEventByIdAsync(id);
            return eventItem == null ? NotFound() : View(eventItem);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventItem = await _eventsRepository.GetEventByIdAsync(id);
            if (eventItem != null)
            {
                await _eventsRepository.DeleteEventAsync(eventItem);
                return RedirectToAction(nameof(Index));
            }
            return View(eventItem);
        }
    }
}
