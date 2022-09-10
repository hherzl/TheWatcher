using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServiceMonitor.Core.Business;
using ServiceMonitor.Core.Business.Contracts;
using ServiceMonitor.Core.Domain;
using ServiceMonitor.WebAPI.Controllers;
using Swashbuckle.AspNetCore.Swagger;

namespace ServiceMonitor.WebAPI
{
#pragma warning disable CS1591
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            /* Setting up dependency injection */

            // Loggers

            services.AddScoped<ILogger, Logger<BaseService>>();
            services.AddScoped<ILogger, Logger<DashboardController>>();
            services.AddScoped<ILogger, Logger<AdministrationController>>();

            // Services

            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IAdministrationService, AdministrationService>();

            // DbContext

            services.AddDbContext<ServiceMonitorDbContext>(builder =>
            {
                builder.UseSqlServer(Configuration["ConnectionStrings:ServiceMonitor"]);
            });

            /* Configuration for Swagger */

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "Service Monitor API", Version = "v1" });

                // Get xml comments path
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                // Set xml path
                options.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Service Monitor API V1");
            });

            app.UseMvc();
        }
    }
#pragma warning restore CS1591
}
