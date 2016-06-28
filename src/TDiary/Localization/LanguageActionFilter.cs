using System.Globalization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TDiary
{
    public class LanguageActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string culture = context.RouteData.Values["culture"].ToString();

            if (culture == "en-GB" || culture == "en-US" || culture == "zh-CN")
            {
                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(culture);
                CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(culture);
            }
            else
            {
                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-GB");
                CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-GB");
            }

            base.OnActionExecuting(context);
        }
    }
}