using Microsoft.AspNetCore.Mvc;
using MagicBus.Model;
using MagicBus.Providers.ViewModel.Model;

namespace MagicBus
{
    [ServiceFilter(typeof(LanguageActionFilter))]
    public abstract class DiaryController<T, U> : Controller where T : Experience where U : ActivityViewModel
    {
        protected readonly IApiProxy _apiProxy;

        public DiaryController(IApiProxy apiProxy)
        {
            _apiProxy = apiProxy;
        }

        public string GetRedirectController(string controllerFullName, string sourceLocation = "")
        {
            return sourceLocation == string.Empty ?
                controllerFullName.Replace("Controller", string.Empty) : sourceLocation;
        }
    }
}