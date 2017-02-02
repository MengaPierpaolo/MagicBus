using System.Collections.Generic;
using System.Linq;
using MagicBus.Model;

namespace MagicBus.Repository
{
    public class JourneyListRepository
    {
        private readonly DiaryDbContext _context;

        public JourneyListRepository(DiaryDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Journey> GetJourneys()
        {
            return from j in _context.Journeys
                   select new Journey { Id = j.Id, Name = j.Name, Experiences = j.Experiences };
        }
    }
}