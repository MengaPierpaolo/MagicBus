using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Providers.ViewModel.Model;
using TDiary.Service;
using System.Threading.Tasks;

namespace TDiary
{
    public class HomeController : Controller
    {
        private readonly ApiProxy<Trip, TripViewModel> _apiProxy;
        private readonly IActivityOrderService _activityOrderer;

        public HomeController(ApiProxy<Trip, TripViewModel> apiProxy, IActivityOrderService activityOrderService)
        {
            _apiProxy = apiProxy;
            _apiProxy.SetUrl("/diaryitems/");
            _activityOrderer = activityOrderService;
        }

        public async Task<IActionResult> Index()
        {
            var x = await _apiProxy.GetRecent();
            var vm = new HomeViewModel()
            {
                Title = "Magic Bus",
                Heading = "Your groovy new travel diary!",
                RecentExperiences = x
                    .OrderByDescending(d => d.Date)
                    .ThenByDescending(pos => pos.SavePosition)
            };

            return View(vm);
        }

        public IActionResult OrderActivityUp(int activityId)
        {
            _activityOrderer.OrderUp(activityId);
            return RedirectToAction("Index");
        }

        public IActionResult OrderActivityDown(int activityId)
        {
            _activityOrderer.OrdrDown(activityId);
            return RedirectToAction("Index");
        }
    }
}