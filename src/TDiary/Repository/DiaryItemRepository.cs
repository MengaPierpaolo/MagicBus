using System.Collections.Generic;
using System.Linq;
using TDiary.Model;

namespace TDiary.Repository
{
    public class DiaryItemRepository
    {
        private readonly DiaryContext _context;

        public DiaryItemRepository(DiaryContext context)
        {
            _context = context;
        }

        public IEnumerable<Chow> GetChows()
        {
            return _context.Experiences.OfType<Chow>();
        }

        public IEnumerable<Trip> GetTrips()
        {
            return _context.Experiences.OfType<Trip>();
        }

        public IEnumerable<Sight> GetSights()
        {
            return _context.Experiences.OfType<Sight>();
        }
    }
}
