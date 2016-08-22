using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using TDiary.Providers.ViewModel.Model;
using System.Linq;

namespace TDiary
{
    [ServiceFilter(typeof(LanguageActionFilter))]
    public class ExperienceController : ExperienceListController
    {
        private readonly IStringLocalizer _localizer;

        public ExperienceController(IApiProxy apiProxy, IStringLocalizer localizer) : base(apiProxy)
        {
            _localizer = localizer;
            _apiProxy.SetPath("/diaryitems/");
        }

        public async Task<IActionResult> Index(int pageNumber = 0)
        {
            var experiences = await _apiProxy.GetAllByPage(10, pageNumber);

            if (experiences != null)
            {
                experiences = experiences
                    .OrderByDescending(d => d.Date)
                    .ThenByDescending(pos => pos.SavePosition);
            }

            return View(new ExperienceListViewModel(experiences, _localizer, pageNumber));
        }
    }
}