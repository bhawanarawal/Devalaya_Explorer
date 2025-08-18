using Devalaya.Explorer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Devalaya.Explorer.DataAccess.Repositories
{
    public interface ILessonsRepository
    {
        Task<IEnumerable<Lesson>> GetAllLessonsAsync();
        Task<Lesson> GetLessonByIdAsync(int id);
        Task AddLessonAsync(Lesson newLesson);
        Task UpdateLessonAsync(Lesson updatedLesson);
        Task DeleteLessonAsync(Lesson deleteLesson);
        Task DeleteLessonAsync(Event lessonItem);
    }

    public class LessonsRepository : ILessonsRepository
    {
        private readonly ApplicationDbContext _context;

        public LessonsRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddLessonAsync(Lesson newLesson)
        {
            _context.Add(newLesson);
            await _context.SaveChangesAsync();
        }

        public Task DeleteLessonAsync(Lesson deleteLesson)
        {
            throw new NotImplementedException();
        }

        public Task DeleteLessonAsync(Event lessonItem)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteLesssonAsync(Event deleteEvent)
        {
            _context.Remove(deleteEvent);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Lesson>> GetAllLessonsAsync()
        {
            return await _context.Lessons.ToListAsync();
        }

        public async Task<Lesson> GetLessonByIdAsync(int id)
        {
            return await _context.Lessons.FindAsync(id);
        }

        public async Task UpdateLessonAsync(Lesson updatedLesson)
        {
            _context.Update(updatedLesson);
            await _context.SaveChangesAsync();
        }
    }
}
