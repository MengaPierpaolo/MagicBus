using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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

            services.AddMvc();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddDebug(LogLevel.Information); // Only my Logs for now.

            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseRuntimeInfoPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute("trip", "Trip/Edit/{id:int}", new { Controller = "Trip", Action = "Edit" });
                routes.MapRoute("sight", "Sight/Edit/{id:int}", new { Controller = "Sight", Action = "Edit" });
                routes.MapRoute("chow", "Chow/Edit/{id:int}", new { Controller = "Chow", Action = "Edit" });
                routes.MapRoute("nap", "Nap/Edit/{id:int}",new { Controller = "Nap", Action = "Edit" });

                routes.MapRoute("default", "{controller=Home}/{action=Index}");
            });
        }
    }
}
