using System;
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

        public IEnumerable<DiaryItem> GetRecentExperiences(PageSize howMany)
        {
            return _context.Experiences
                    .OrderByDescending(d => d.Date)
                    .ThenByDescending(pos => pos.Date)
                    .Take((int)howMany);
        }

        public IEnumerable<DiaryItem> GetAllByPage(PageSize pageSize, int page = 0)
        {
            return _context.Experiences
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
