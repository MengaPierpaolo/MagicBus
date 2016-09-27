using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicBus.Providers.ViewModel.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace MagicBus
{
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