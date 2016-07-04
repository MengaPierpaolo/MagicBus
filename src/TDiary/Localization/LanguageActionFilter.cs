using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TDiary
{
    public class LanguageActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string culture = context.RouteData.Values["culture"]?.ToString() ?? string.Empty;

            if (culture != "en-US" && culture != "zh-CN")
            {
                culture = "en-GB";
            }

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(culture);
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(culture);

            var c = context.Controller as Controller;
            if (c != null)
            {
                c.ViewData["culture"] = culture;
                if (c.Request.Path.ToString().Contains("/") && c.Request.Path.ToString().Length > 1)
                {
                    c.ViewData["currentPage"] = c.Request.Path.ToString().Substring(c.Request.Path.ToString().IndexOf("/", 2) + 1);
                }
            }

            base.OnActionExecuting(context);
        }
    }
}