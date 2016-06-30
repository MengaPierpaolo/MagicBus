using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.IO;
using TDiary.Model;
using TDiary.Providers.Location;
using TDiary.Providers.ViewModel;
using TDiary.Providers.ViewModel.Model;
using TDiary.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace TDiary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }

        public class Startup
        {
            public IConfigurationRoot Configuration { get; }

            public Startup(IHostingEnvironment environment)
            {
                var configBuilder = new ConfigurationBuilder()
                    .SetBasePath(environment.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

                Configuration = configBuilder.Build();
            }

            public void ConfigureServices(IServiceCollection services)
            {
                services.AddAuthentication();

                services.Configure<ApplicationSettings>(Configuration.GetSection("AppSettings"));

                services.AddScoped<IApiProxy, ApiProxy>();
                services.AddScoped<ILocationProvider, ApiLocationProvider>();
                services.AddScoped<IViewModelProvider<Chow, ChowViewModel>, ChowViewModelProvider>();
                services.AddScoped<IViewModelProvider<Sight, SightViewModel>, SightViewModelProvider>();
                services.AddScoped<IViewModelProvider<Trip, TripViewModel>, TripViewModelProvider>();
                services.AddScoped<IViewModelProvider<Nap, NapViewModel>, NapViewModelProvider>();

                services.AddLocalization();
                services.AddScoped<LanguageActionFilter>();
                services.AddSingleton<IStringLocalizerFactory, MyStringLocalizerFactory>();
                services.AddTransient<IStringLocalizer, MyStringLocalizer>();

                services.AddMvc(config =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                     .RequireAuthenticatedUser()
                     .Build();

                    config.Filters.Add(new AuthorizeFilter(policy));
                })
                .AddViewLocalization()
                .AddDataAnnotationsLocalization();
            }

            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationScheme = "Cookie",
                    LoginPath = new PathString("/Account/Login"),
                    AccessDeniedPath = new PathString("/Account/Forbidden"),
                    AutomaticAuthenticate = true,
                    AutomaticChallenge = true
                });

                app.UseStaticFiles();

                app.UseMvc(routes =>
                {
                    routes.MapRoute("trip", "{culture}/Trip/Edit/{id:int}", new { Controller = "Trip", Action = "Edit" });
                    routes.MapRoute("sight", "{culture}/Sight/Edit/{id:int}", new { Controller = "Sight", Action = "Edit" });
                    routes.MapRoute("chow", "{culture}/Chow/Edit/{id:int}", new { Controller = "Chow", Action = "Edit" });
                    routes.MapRoute("nap", "{culture}/Nap/Edit/{id:int}", new { Controller = "Nap", Action = "Edit" });

                    routes.MapRoute("default", "{culture=en-GB}/{controller=Home}/{action=Index}");
                    routes.MapRoute("forbidden", "{controller=Account}/{action=Forbidden}");
                });

                var supportedCultures = new[]
                {
                new CultureInfo("en-GB"),
                new CultureInfo("en-US"),
                new CultureInfo("zh-CN")
            };

                app.UseRequestLocalization(new RequestLocalizationOptions
                {
                    DefaultRequestCulture = new RequestCulture("en-GB"),
                    SupportedCultures = supportedCultures,
                    SupportedUICultures = supportedCultures
                });
            }
        }
    }
}
