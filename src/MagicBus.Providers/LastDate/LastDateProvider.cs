using System.Linq;
using MagicBus.Repository;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace MagicBus.Providers.LastDate
{
    public class LastDateProvider : ILastDateProvider
    {
        private readonly DiaryDbContext _context;

        public LastDateProvider(DiaryDbContext context)
        {
            _context = context;
        }

        public async Task<DateTime> GetLastDate()
        {
            var item = await _context.Experiences
                .OrderBy(di => di.Date)
                .LastOrDefaultAsync();

            return item.Date;
        }
    }
}