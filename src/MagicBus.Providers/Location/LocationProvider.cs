using MagicBus.Model;
using System.Linq;
using MagicBus.Repository;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace MagicBus.Providers.Location
{
    public class LocationProvider : ILocationProvider
    {
        private readonly DiaryDbContext _context;

        public LocationProvider(DiaryDbContext context)
        {
            _context = context;
        }

        public async Task<string> GetLastLocation()
        {
            var item = await _context.Experiences
                .OrderByDescending(di => di.Date)
                .ThenByDescending(pos => pos.SavePosition)
                .FirstOrDefaultAsync();

            return GetLocation(item);
        }

        public async Task<string> GetLocation(DateTime forWhen)
        {
            var item = await _context.Experiences
                .Where(dt => dt.Date <= forWhen)
                .OrderByDescending(di => di.Date)
                .ThenByDescending(pos => pos.SavePosition)
                .FirstOrDefaultAsync();

            return GetLocation(item);
        }

        private static string GetLocation(Experience item)
        {
            if (item != null)
            {
                var locatable = item as ILocatable;
                if (locatable != null)
                {
                    return locatable.Location;
                }

                return ((Trip)item).To;
            }
            return default(string);
        }
    }
}