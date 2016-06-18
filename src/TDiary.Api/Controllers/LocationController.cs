using Microsoft.AspNetCore.Mvc;
using TDiary.Providers.Location;

namespace TDiary.Api
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
        public string Get()
        {
            return _locationProvider.GetLastLocation();
        }
    }
}