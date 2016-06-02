using System.Collections.Generic;
using System.Linq;
using TDiary.Model;

namespace TDiary.Repository
{
    public class DiaryItemListRepository
    {
        private readonly DiaryContext _context;

        public DiaryItemListRepository(DiaryContext context)
        {
            _context = context;
        }

        public IEnumerable<DiaryItem> GetRecentExperiences()
        {
            return _context.Experiences.OrderByDescending(d => d.Date).Take(5);
        }
    }
}
