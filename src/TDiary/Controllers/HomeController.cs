using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TDiary.Providers.ViewModel.Model;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TDiary
{
    [ServiceFilter(typeof(LanguageActionFilter))]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IApiProxy _apiProxy;
        private IStringLocalizer _localizer;

        public HomeController(
            IApiProxy apiProxy,
            IStringLocalizer localizer,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
       )
        {
            _localizer = localizer;
            _apiProxy = apiProxy;
            _apiProxy.SetPath("/diaryitems/");
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var recentExperiences = _signInManager.IsSignedIn(User) ?
                await _apiProxy.GetRecent() :
                new List<ExperienceViewModel>();

            recentExperiences = recentExperiences
                .OrderByDescending(d => d.Date)
                .ThenByDescending(pos => pos.SavePosition);

            return View(new HomeViewModel(recentExperiences, _localizer));
        }

        public async Task<IActionResult> OrderActivityUp(int activityId)
        {
            await _apiProxy.PromoteActivity(activityId);
            return RedirectToAction(nameof(HomeController.Index));
        }

        public async Task<IActionResult> OrderActivityDown(int activityId)
        {
            await _apiProxy.DemoteActivity(activityId);
            return RedirectToAction(nameof(HomeController.Index));
        }
    }
}