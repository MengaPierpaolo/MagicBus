using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TDiary.Repository;
using TDiary.Model;

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
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddDbContext<DiaryContext>();
            
            services.AddScoped<IDiaryItemRepository, DiaryItemRepository>();
            services.AddScoped<DiaryItemListRepository, DiaryItemListRepository>();
            services.AddScoped<ILocationProvider, MostRecentLocationProvider>();
            
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
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
            });
        }
    }
}
