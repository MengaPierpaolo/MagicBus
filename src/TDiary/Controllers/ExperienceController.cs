using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using TDiary.Providers.ViewModel.Model;

namespace TDiary
{
    [ServiceFilter(typeof(LanguageActionFilter))]
    public class ExperienceController : Controller
    {
        private readonly IApiProxy _apiProxy;
        private readonly IStringLocalizer _localizer;

        public ExperienceController(IApiProxy apiProxy, IStringLocalizer localizer)
        {
            _localizer = localizer;
            _apiProxy = apiProxy;

            _apiProxy.SetPath("/diaryitems/");
        }

        public async Task<IActionResult> Index()
        {
            var vm = new ExperienceListViewModel(await _apiProxy.GetRecent(), _localizer);
            return View(vm);
        }
    }
}