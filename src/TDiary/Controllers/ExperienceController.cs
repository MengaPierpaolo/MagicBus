using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using TDiary.Providers.ViewModel.Model;

namespace TDiary
{
    [ServiceFilter(typeof(LanguageActionFilter))]
    public class ExperienceController : Controller
    {
        private IStringLocalizer _localizer;

        public ExperienceController(IStringLocalizer localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            var vm = new ExperienceListViewModel()
            {
                Title = _localizer.GetString("ExperienceListTitle"),
                Heading = _localizer.GetString("ExperienceListHeading")
            };
            return View(vm);
        }
    }
}