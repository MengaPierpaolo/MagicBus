using TDiary.Model;
using System.Linq;
using TDiary.Repository;
using System.Threading.Tasks;

namespace TDiary.Providers.Location
{
    public class MostRecentLocationProvider : ILocationProvider
    {
        private readonly DiaryContext _context;

        public MostRecentLocationProvider(DiaryContext context)
        {
            _context = context;
        }

        Task<string> ILocationProvider.GetLastLocation()
        {
            var recentItem = _context.Experiences
                .OrderByDescending(di => di.Date)
                .OrderByDescending(pos => pos.SavePosition)
                .FirstOrDefault();

            if (recentItem != null)
            {
                var locatable = recentItem as ILocatable;
                if (locatable != null)
                {
                    return new Task<string>(() => locatable.Location);
                }

                return new Task<string>(() => ((Trip)recentItem).To);
            }
            return default(Task<string>);
        }
    }
}