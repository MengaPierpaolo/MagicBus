using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TDiary.Providers.Location;
using TDiary.Repository;
using TDiary.Service;

namespace TDiary.Api
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

            services.AddDbContext<DiaryContext>();

            services.AddScoped<ExperienceListRepository, ExperienceListRepository>();
            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            services.AddScoped<ILocationProvider, MostRecentLocationProvider>();
            services.AddScoped<IActivityOrderService, BasicActivityOrderService>();

            services.AddCors(options => options.AddPolicy("Allow-All",
                p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors("Allow-All");
            app.UseMvc(
            //     config =>
            // {
            //     config.MapRoute("DefaultApi", "api/{controller}/");
            //     config.MapRoute("actionable", "Api/{controller}/{action}/");
            // });
            );
        }
    }
}
