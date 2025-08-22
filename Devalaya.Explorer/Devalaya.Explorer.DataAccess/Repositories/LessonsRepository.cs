using Devalaya.Explorer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Devalaya.Explorer.DataAccess.Repositories
{
    public interface ILessonsRepository
    {
        Task<IEnumerable<Lesson>> GetAllLessonsAsync();
        Task<int> GetLessonCount();
        Task<Lesson> GetLessonByIdAsync(int id);
        Task AddLessonAsync(Lesson newLesson);
        Task UpdateLessonAsync(Lesson updatedLesson);
        Task DeleteLessonAsync(Lesson deleteLesson);
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


        public async Task DeleteLessonAsync(Lesson deleteEvent)
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

        public async Task<int> GetLessonCount()
        {
            return await _context.Lessons.CountAsync();
        }

        public async Task UpdateLessonAsync(Lesson updatedLesson)
        {
            _context.Update(updatedLesson);
            await _context.SaveChangesAsync();
        }
    }
}
