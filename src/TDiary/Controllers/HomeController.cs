using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TDiary.Providers.ViewModel.Model;
using System.Threading.Tasks;

namespace TDiary
{
    public class HomeController : Controller
    {
        private readonly IApiProxy _apiProxy;

        public HomeController(IApiProxy apiProxy)
        {
            _apiProxy = apiProxy;
            _apiProxy.SetPath("/diaryitems/");
        }

        public async Task<IActionResult> Index()
        {
            var recentExperiences = await _apiProxy.GetRecent();
            var vm = new HomeViewModel()
            {
                Title = "Magic Bus",
                Heading = "Your groovy new travel diary!",
                RecentExperiences = recentExperiences
                    .OrderByDescending(d => d.Date)
                    .ThenByDescending(pos => pos.SavePosition)
            };

            return View(vm);
        }

        public async Task<IActionResult> OrderActivityUp(int activityId)
        {
            await _apiProxy.PromoteActivity(activityId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> OrderActivityDown(int activityId)
        {
            await _apiProxy.DemoteActivity(activityId);
            return RedirectToAction("Index");
        }
    }
}