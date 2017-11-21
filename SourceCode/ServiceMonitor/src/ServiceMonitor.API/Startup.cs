using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServiceMonitor.API.Controllers;
using ServiceMonitor.Core.BusinessLayer;
using ServiceMonitor.Core.BusinessLayer.Contracts;
using ServiceMonitor.Core.DataLayer;
using ServiceMonitor.Core.DataLayer.Contracts;
using ServiceMonitor.Core.DataLayer.Repositories;

namespace ServiceMonitor.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddDbContext<ServiceMonitorDbContext>(options => options.UseSqlServer(Configuration["AppSettings:ConnectionString"]));

            services.AddScoped<IDashboardRepository, DashboardRepository>();

            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IAdministrationService, AdministrationService>();

            services.AddScoped<ILogger, Logger<DashboardService>>();
            services.AddScoped<ILogger, Logger<AdministrationService>>();

            services.AddScoped<ILogger, Logger<DashboardController>>();
            services.AddScoped<ILogger, Logger<AdministrationController>>();

            services.AddOptions();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddSingleton<IConfiguration>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
