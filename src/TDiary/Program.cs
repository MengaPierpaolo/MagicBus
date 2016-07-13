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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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
                services.Configure<ApplicationSettings>(Configuration.GetSection("AppSettings"));

                services.AddDbContext<UserDbContext>(options =>
                    options.UseSqlite("Filename=./Users.db"));

                services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<UserDbContext>()
                    .AddDefaultTokenProviders();

                services.AddScoped<IApiProxy, ApiProxy>();
                services.AddScoped<ILocationProvider, ApiLocationProvider>();
                services.AddScoped<IViewModelProvider<Chow, ChowViewModel>, ChowViewModelProvider>();
                services.AddScoped<IViewModelProvider<Sight, SightViewModel>, SightViewModelProvider>();
                services.AddScoped<IViewModelProvider<Trip, TripViewModel>, TripViewModelProvider>();
                services.AddScoped<IViewModelProvider<Nap, NapViewModel>, NapViewModelProvider>();
                services.AddSingleton<IStringLocalizerFactory, MyStringLocalizerFactory>();
                services.AddTransient<IStringLocalizer, MyStringLocalizer>();

                services.AddScoped<LanguageActionFilter>();
                services.AddLocalization();

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
                app.UseStaticFiles();

                app.UseIdentity();

                var option = new GoogleOptions();
                option.ClientId = "154065577637-8vr1fup5f9ficj41gqoj4263qsgbj92e.apps.googleusercontent.com";
                option.ClientSecret = "jzu-ThkUmBb5xU_P47V3u1K4";
                app.UseGoogleAuthentication(option);

                app.UseMvc(routes =>
                {
                    routes.MapRoute("Google API Sign-in", "signin-google", new { controller = "Account", action = "ExternalLoginCallbackRedirect" });

                    routes.MapRoute("trip", "{culture}/Trip/Edit/{id:int}", new { Controller = "Trip", Action = "Edit" });
                    routes.MapRoute("sight", "{culture}/Sight/Edit/{id:int}", new { Controller = "Sight", Action = "Edit" });
                    routes.MapRoute("chow", "{culture}/Chow/Edit/{id:int}", new { Controller = "Chow", Action = "Edit" });
                    routes.MapRoute("nap", "{culture}/Nap/Edit/{id:int}", new { Controller = "Nap", Action = "Edit" });

                    routes.MapRoute("default", "{culture=en-GB}/{controller=Home}/{action=Index}");
                    routes.MapRoute("login", "{controller=Account}/{action=Login}");
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
