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

namespace ServiceMonitor.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<ServiceMonitorDbContext>(options => options.UseSqlServer(Configuration["AppSettings:ConnectionString"]));

            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IAdministrationService, AdministrationService>();

            services.AddScoped<ILogger, Logger<DashboardService>>();
            services.AddScoped<ILogger, Logger<AdministrationService>>();

            services.AddScoped<ILogger, Logger<DashboardController>>();
            services.AddScoped<ILogger, Logger<AdministrationController>>();

            services.AddOptions();

            services.AddSingleton(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
        }
    }
}
