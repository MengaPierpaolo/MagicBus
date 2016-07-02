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
                new List<RecentExperienceViewModel>();

            var vm = new HomeViewModel()
            {
                Title = _localizer.GetString("ApplicationTitle"),
                Heading = _localizer.GetString("ApplicationHeading"),
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