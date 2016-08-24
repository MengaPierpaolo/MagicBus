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

    [ServiceFilter(typeof(LanguageActionFilter))]
    public class HomeController : ExperienceListController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private IStringLocalizer _localizer;

        public HomeController(
            IApiProxy apiProxy,
            IStringLocalizer localizer,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
       ) : base(apiProxy)
        {
            _localizer = localizer;
            _apiProxy.SetPath("/experiences/");
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            IEnumerable<ExperienceViewModel> recentExperiences = new List<ExperienceViewModel>();
            IEnumerable<JourneyViewModel> recentJourneys = new List<JourneyViewModel>();

            if (_signInManager.IsSignedIn(User))
            {
                recentExperiences = await _apiProxy.GetRecent();
                recentJourneys = await _apiProxy.GetJourneys();

                recentExperiences = recentExperiences
                    .OrderByDescending(d => d.Date)
                    .ThenByDescending(pos => pos.SavePosition);

            }

            return View(new HomeViewModel(recentExperiences, recentJourneys, _localizer));
        }
    }
}