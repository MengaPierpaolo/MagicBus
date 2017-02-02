using MagicBus.Providers.LastDate;
using MagicBus.Providers.Location;
using MagicBus.Repository;
using MagicBus.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MagicBus.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApplicationSettings>(Configuration.GetSection("AppSettings"));

            services.AddDbContext<DiaryDbContext>();
            services.AddDbContext<MigrationsContext>(); // See note in MigrationsContext.cs

            services.AddScoped<ExperienceListRepository, ExperienceListRepository>();
            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            services.AddScoped<ILocationProvider, LocationProvider>();
            services.AddScoped<ILastDateProvider, LastDateProvider>();
            services.AddScoped<IActivityOrderService, BasicActivityOrderService>();

            services.AddCors(options => options.AddPolicy("Allow-All",
                p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseCors("Allow-All");

            app.UseMvc();

            app.ApplicationServices
                .GetService<MigrationsContext>()
                .Migrate();
        }
    }
}
