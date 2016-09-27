using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MagicBus
{
    public class ExperienceListController : Controller
    {
        protected readonly IApiProxy _apiProxy;

        public ExperienceListController(IApiProxy apiProxy)
        {
            _apiProxy = apiProxy;
        }

        public async Task<IActionResult> OrderActivityUp(int activityId)
        {
            await _apiProxy.PromoteActivity(activityId);
            return RedirectToAction(nameof(HomeController.Index), GetType().Name.Replace("Controller", string.Empty));
        }

        public async Task<IActionResult> OrderActivityDown(int activityId)
        {
            await _apiProxy.DemoteActivity(activityId);
            return RedirectToAction(nameof(HomeController.Index), GetType().Name.Replace("Controller", string.Empty));
        }
    }
}