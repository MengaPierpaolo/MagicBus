using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

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
                // TODO: This works but is very hacky: Research and refactor needed!
                var bits = c.Request.Path.ToString().Split('/');
                var q = c.Request.Query.ToArray();
                if (bits.Length > 2 && bits[1] != string.Empty)
                {
                    if (q.Length > 0)
                    {
                        c.ViewData["currentPage"] = string.Format("{0}?{1}={2}",
                            c.Request.Path.ToString().Replace(string.Format("/{0}/", bits[1]), string.Empty),
                            q[0].Key,
                            q[0].Value.ToString());
                    }
                    else
                    {
                        c.ViewData["currentPage"] =
                            c.Request.Path.ToString().Replace(string.Format("/{0}/", bits[1]), string.Empty);
                    }
                }
            }

            base.OnActionExecuting(context);
        }
    }
}