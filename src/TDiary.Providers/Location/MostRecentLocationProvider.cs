using TDiary.Model;
using System.Linq;
using TDiary.Repository;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TDiary.Providers.Location
{
    public class MostRecentLocationProvider : ILocationProvider
    {
        private readonly DiaryContext _context;

        public MostRecentLocationProvider(DiaryContext context)
        {
            _context = context;
        }

        public async Task<string> GetLastLocation()
        {
            var recentItem = await _context.Experiences
                .OrderByDescending(di => di.Date)
                .ThenByDescending(pos => pos.SavePosition)
                .FirstOrDefaultAsync();

            if (recentItem != null)
            {
                var locatable = recentItem as ILocatable;
                if (locatable != null)
                {
                    return locatable.Location;
                }

                return ((Trip)recentItem).To;
            }
            return default(string);
        }
    }
}