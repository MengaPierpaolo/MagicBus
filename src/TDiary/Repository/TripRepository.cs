using System.Linq;
using Microsoft.EntityFrameworkCore;
using TDiary.Model;

namespace TDiary.Repository
{
    public class TripRepository : IDiaryItemRepository<Trip>
    {
        private readonly DiaryContext _context;

        public TripRepository(DiaryContext context)
        {
            _context = context;
        }

        public void AddNew(Trip item)
        {
            _context.Experiences.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Trip Trip)
        {
            _context.Entry(Trip).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public Trip Get(int id)
        {
            return _context.Experiences.OfType<Trip>()
                .Where(e => e.Id == id)
                .First();
        }

        public void SaveChanges(Trip item)
        {
            _context.Attach(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
