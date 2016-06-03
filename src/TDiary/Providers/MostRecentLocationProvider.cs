using TDiary.Model;
using System.Linq;

namespace TDiary
{
    public class MostRecentLocationProvider : ILocationProvider
    {
        private readonly DiaryContext _context;

        public MostRecentLocationProvider(DiaryContext context)
        {
            _context = context;
        }

        public string GetLastLocation()
        {
            var recentItem = _context.Experiences.OrderByDescending(di => di.Date).FirstOrDefault();

            if (recentItem != null)
            {
                var locatable = recentItem as ILocatable;
                if (locatable != null)
                {
                    return locatable.Location;
                }

                return ((Trip)recentItem).To;
            }
            return string.Empty;
        }
    }
}