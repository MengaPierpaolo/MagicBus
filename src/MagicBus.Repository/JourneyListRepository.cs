using System.Collections.Generic;
using System.Linq;
using MagicBus.Model;

namespace MagicBus.Repository
{
    public class ExperienceListRepository
    {
        private readonly DiaryDbContext _context;

        public ExperienceListRepository(DiaryDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Experience> GetRecentExperiences(PageSize howMany)
        {
            return _context
                .Experiences
                    .OrderByDescending(d => d.Date)
                    .ThenByDescending(pos => pos.Date)
                    .Take((int)howMany);
        }

        public IEnumerable<Journey> GetJourneys()
        {
            return from j in _context.Journeys
                   select new Journey { Id = j.Id, Name = j.Name, Experiences = j.Experiences };
        }

        public IEnumerable<Experience> GetAllByPage(PageSize pageSize, int page = 0)
        {
            return _context
                .Experiences
                    .OrderByDescending(d => d.Date)
                    .ThenByDescending(pos => pos.Date)
                    .Skip((int)pageSize * page)
                    .Take((int)pageSize);
        }
    }

    public enum PageSize
    {
        Five = 5,
        Ten = 10,
        Fifteen = 15
    }
}