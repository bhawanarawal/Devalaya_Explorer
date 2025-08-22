using Devalaya.Explorer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Devalaya.Explorer.DataAccess.Repositories
{
    public interface IEventsRepository
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<int> GetEventCount();
        Task<Event> GetEventByIdAsync(int id);
        Task AddEventAsync(Event newEvent);
        Task UpdateEventAsync(Event updatedEvent);
        Task DeleteEventAsync(Event deleteEvent);
    }

    public class EventsRepository : IEventsRepository
    {
        private readonly ApplicationDbContext _context;

        public EventsRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddEventAsync(Event newEvent)
        {
            _context.Add(newEvent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(Event deleteEvent)
        {
            _context.Remove(deleteEvent);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _context.Events.Include(x=>x.Temple).ToListAsync();
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task<int> GetEventCount()
        {
            return await _context.Events.CountAsync();
        }

        public async Task UpdateEventAsync(Event updatedEvent)
        {
            _context.Update(updatedEvent);
            await _context.SaveChangesAsync();
        }
    }
}
