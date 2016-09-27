using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagicBus.Providers.Location;

namespace MagicBus.Api
{
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        private readonly ILocationProvider _locationProvider;

        public LocationController(ILocationProvider locationProvider)
        {
            _locationProvider = locationProvider;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            return await _locationProvider.GetLastLocation();
        }
    }
}