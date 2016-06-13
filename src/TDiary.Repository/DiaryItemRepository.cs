using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TDiary.Model;

namespace TDiary.Repository
{
    public class DiaryItemRepository : IDiaryItemRepository
    {
        private readonly DiaryContext _context;

        public DiaryItemRepository(DiaryContext context)
        {
            _context = context;
        }

        public void Add(DiaryItem item)
        {
            var lastItem = GetLastItem(item.Date);
            if (lastItem != null)
            {
                item.MovePositionTo(lastItem.SavePosition + 1);
            }

            _context.Experiences.Add(item);
            _context.SaveChanges();
        }

        public void Delete(DiaryItem chow)
        {
            _context.Entry(chow).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public U Get<U>(int id) where U : DiaryItem
        {
            return _context.Experiences.OfType<U>()
                .Where(e => e.Id == id)
                .First();
        }

        public void SaveChanges(DiaryItem item)
        {
            var currentState = _context.Experiences.AsNoTracking().Where(di => di.Id == item.Id).Single();
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

        private DiaryItem GetLastItem(DateTime date)
        {
            return _context.Experiences
                .Where(i => i.Date.Date == date)
                .OrderByDescending(i => i.SavePosition)
                .FirstOrDefault();
        }
    }
}