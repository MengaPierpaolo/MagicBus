using System.Collections.Generic;
using System.Linq;
using TDiary.Model;

namespace TDiary.Repository
{
    public class JourneyListRepository
    {
        private readonly DiaryContext _context;

        public JourneyListRepository(DiaryContext context)
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