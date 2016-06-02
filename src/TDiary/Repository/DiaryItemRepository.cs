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
            _context.Attach(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}