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
                // TODO: This works but is a bit hacky
                var bits = c.Request.Path.ToString().Split('/');
                if (bits.Length > 2 && bits[1] != string.Empty)
                {
                    c.ViewData["currentPage"] = c.Request.Path.ToString().Replace(string.Format("/{0}/", bits[1]), string.Empty);
                }
            }

            base.OnActionExecuting(context);
        }
    }
}