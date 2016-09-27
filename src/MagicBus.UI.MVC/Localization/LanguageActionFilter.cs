using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MagicBus
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

                var pathSections = c.Request.Path.ToString().Split('/');
                var queryStringSections = c.Request.Query.ToArray();

                if (pathSections.Length > 2 && pathSections[1] != string.Empty)
                {
                    var path = c.Request.Path.ToString();

                    if (queryStringSections.Length > 0)
                    {
                        c.ViewData["currentPage"] =
                            string.Format("{0}?{1}",
                                ExcludeCulture(pathSections, path),
                                BuildQueryString(queryStringSections));
                    }
                    else
                    {
                        c.ViewData["currentPage"] = ExcludeCulture(pathSections, path);
                    }
                }
            }

            base.OnActionExecuting(context);
        }

        private string ExcludeCulture(string[] pathSections, string path)
        {
            return path.Replace(string.Format("/{0}/", pathSections[1]), string.Empty);
        }

        private string BuildQueryString(KeyValuePair<string, StringValues>[] sections)
        {
            var sb = new StringBuilder();
            foreach (var item in sections)
            {
                sb.Append(item.Key);
                sb.Append("=");
                sb.Append(item.Value.ToString());
            }
            return sb.ToString();
        }
    }
}