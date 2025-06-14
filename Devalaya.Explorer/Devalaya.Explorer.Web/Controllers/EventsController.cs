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

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var eventItem = await _eventsRepository.GetEventByIdAsync(id);
            return eventItem == null ? NotFound() : View(eventItem);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Details,Address,Deity,MadeYear")] Event newEvent)
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
