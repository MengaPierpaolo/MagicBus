using System.Linq;
using Microsoft.EntityFrameworkCore;
using TDiary.Model;

namespace TDiary.Repository
{
    public class SightRepository : IDiaryItemRepository<Sight>
    {
        private readonly DiaryContext _context;

        public SightRepository(DiaryContext context)
        {
            _context = context;
        }

        public void AddNew(Sight item)
        {
            _context.Experiences.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Sight Sight)
        {
            _context.Entry(Sight).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public Sight Get(int id)
        {
            return _context.Experiences.OfType<Sight>()
                .Where(e => e.Id == id)
                .First();
        }

        public void SaveChanges(Sight item)
        {
            _context.Attach(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
