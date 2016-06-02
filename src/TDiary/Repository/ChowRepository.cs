using System.Linq;
using Microsoft.EntityFrameworkCore;
using TDiary.Model;

namespace TDiary.Repository
{
    public class ChowRepository : IDiaryItemRepository<Chow>
    {
        private readonly DiaryContext _context;

        public ChowRepository(DiaryContext context)
        {
            _context = context;
        }

        public void AddNew(Chow item)
        {
            _context.Experiences.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Chow chow)
        {
            _context.Entry(chow).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public Chow Get(int id)
        {
            return _context.Experiences.OfType<Chow>()
                .Where(e => e.Id == id)
                .First();
        }

        public void SaveChanges(Chow item)
        {
            _context.Attach(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
