using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MagicBus.Model;

namespace MagicBus.Repository
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly DiaryDbContext _context;

        public ExperienceRepository(DiaryDbContext context)
        {
            _context = context;
        }

        public void Add(Experience item)
        {
            var lastItem = GetLastItem(item.Date);
            if (lastItem != null)
            {
                item.MovePositionTo(lastItem.SavePosition + 1);
            }

            _context.Experiences.Add(item);
            _context.Journeys.Attach(item.Journey);
            _context.SaveChanges();
        }

        public void Delete(Experience chow)
        {
            _context.Entry(chow).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public U Get<U>(int id) where U : Experience
        {
            return _context
                .Experiences.OfType<U>()
                .Where(e => e.Id == id)
                .Include(j => j.Journey)
                .FirstOrDefault();
        }

        public void SaveChanges(Experience item)
        {
            var currentState = _context
                .Experiences
                .AsNoTracking()
                .Where(di => di.Id == item.Id)
                .Single();

            if (item.Date.Date != currentState.Date.Date)
            {
                 var lastItem = GetLastItem(item.Date);
                 if (lastItem != null)
                 {
                     item.MovePositionTo(lastItem.SavePosition + 1);
                 }
            }

            _context.Attach(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        private Experience GetLastItem(DateTime date)
        {
            return _context
                .Experiences
                .Where(i => i.Date.Date == date)
                .OrderByDescending(i => i.SavePosition)
                .FirstOrDefault();
        }
    }
}