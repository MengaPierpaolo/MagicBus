using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Providers.ViewModel.Model;

namespace TDiary
{
    [ServiceFilter(typeof(LanguageActionFilter))]
    public abstract class DiaryController<T, U> : Controller where T : DiaryItem where U : ActivityViewModel
    {
        protected readonly IApiProxy _apiProxy;

        public DiaryController(IApiProxy apiProxy)
        {
            _apiProxy = apiProxy;
        }
    }
}