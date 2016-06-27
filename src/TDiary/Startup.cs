using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.Globalization;
using TDiary.Model;
using TDiary.Providers.Location;
using TDiary.Providers.ViewModel;
using TDiary.Providers.ViewModel.Model;
using TDiary.Repository;

namespace TDiary
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment environment)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = configBuilder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
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

            services.AddMvc().AddViewLocalization().AddDataAnnotationsLocalization();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute("trip", "{culture}/Trip/Edit/{id:int}", new { Controller = "Trip", Action = "Edit" });
                routes.MapRoute("sight", "{culture}/Sight/Edit/{id:int}", new { Controller = "Sight", Action = "Edit" });
                routes.MapRoute("chow", "{culture}/Chow/Edit/{id:int}", new { Controller = "Chow", Action = "Edit" });
                routes.MapRoute("nap", "{culture}/Nap/Edit/{id:int}", new { Controller = "Nap", Action = "Edit" });

                routes.MapRoute("default", "{culture=en-GB}/{controller=Home}/{action=Index}");
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
