using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MagicBus.Providers.ViewModel.Model;

namespace MagicBus.Controllers
{
    public class JourneyController : Controller
    {
        private readonly IApiProxy _apiProxy;

        public JourneyController(IApiProxy apiProxy)
        {
            _apiProxy = apiProxy;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new JourneyListViewModel
            {
                Title = "Your Journeys",
                Heading = "Edit your journeys!",
                Journeys = await _apiProxy.GetJourneys()
            };

            return View(vm);
        }
    }
}