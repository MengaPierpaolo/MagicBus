using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TDiary.Providers.ViewModel.Model;

namespace TDiary.Controllers
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