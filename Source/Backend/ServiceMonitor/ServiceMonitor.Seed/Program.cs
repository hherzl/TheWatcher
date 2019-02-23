using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Common;
using ServiceMonitor.Core.DataLayer;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Seed
{
    class Program
    {
        static ServiceMonitorDbContext GetServiceMonitorDbContext()
            => new ServiceMonitorDbContext(
                new DbContextOptionsBuilder<ServiceMonitorDbContext>()
                    .UseSqlServer("server=(local);database=ServiceMonitor;integrated security=yes;")
                    .Options
            );

        static void Main(string[] args)
            => MainAsync(args).GetAwaiter().GetResult();

        static async Task MainAsync(string[] args)
        {
            Console.WriteLine("Seeding...");

            using (var dbContext = GetServiceMonitorDbContext())
            {
                dbContext.ServiceCategory.Add(new ServiceCategory { Description = "Database" });
                dbContext.ServiceCategory.Add(new ServiceCategory { Description = "Rest API" });
                dbContext.ServiceCategory.Add(new ServiceCategory { Description = "Server" });
                dbContext.ServiceCategory.Add(new ServiceCategory { Description = "URL" });
                dbContext.ServiceCategory.Add(new ServiceCategory { Description = "Web Service" });

                await dbContext.SaveChangesAsync();

                dbContext.EnvironmentCategory.Add(new EnvironmentCategory { EnvironmentCategoryName = "Development" });
                dbContext.EnvironmentCategory.Add(new EnvironmentCategory { EnvironmentCategoryName = "QA" });
                dbContext.EnvironmentCategory.Add(new EnvironmentCategory { EnvironmentCategoryName = "Production" });

                await dbContext.SaveChangesAsync();

                dbContext.Service.Add(new Service { ServiceCategoryID = 100, Name = "Northwind Database" });

                await dbContext.SaveChangesAsync();

                dbContext.ServiceEnvironment.Add(new ServiceEnvironment
                {
                    ServiceID = 1,
                    EnvironmentCategoryID = 1,
                    Interval = 15000,
                    ConnectionString = "server=(local);database=Northwind;user id=johnd;password=SqlServer2018$",
                    Description = "SQL Server Local Instance",
                    Active = true
                });

                dbContext.ServiceEnvironment.Add(new ServiceEnvironment
                {
                    ServiceID = 1,
                    EnvironmentCategoryID = 2,
                    Interval = 15000,
                    ConnectionString = "server=(local);database=Northwind;user id=johnd;password=SqlServer",
                    Description = "SQL Server Local Instance",
                    Active = true
                });

                await dbContext.SaveChangesAsync();

                dbContext.Service.Add(new Service { ServiceCategoryID = 300, Name = "DNS" });

                await dbContext.SaveChangesAsync();

                dbContext.ServiceEnvironment.Add(new ServiceEnvironment
                {
                    ServiceID = 2,
                    EnvironmentCategoryID = 1,
                    Interval = 3000,
                    Address = "192.168.1.1",
                    Description = "DNS gateway",
                    Active = true
                });

                await dbContext.SaveChangesAsync();

                dbContext.Service.Add(new Service { ServiceCategoryID = 200, Name = "Sample API" });

                await dbContext.SaveChangesAsync();

                dbContext.ServiceEnvironment.Add(new ServiceEnvironment
                {
                    ServiceID = 2,
                    EnvironmentCategoryID = 1,
                    Interval = 5000,
                    Url = "http://localhost:5612/api/values",
                    Description = "Sample Rest API",
                    Active = true
                });

                await dbContext.SaveChangesAsync();

                dbContext.ServiceWatcher.Add(new ServiceWatcher
                {
                    ServiceID = 1,
                    TypeName = typeof(DatabaseWatcher).AssemblyQualifiedName
                });

                dbContext.ServiceWatcher.Add(new ServiceWatcher
                {
                    ServiceID = 2,
                    TypeName = typeof(PingWatcher).AssemblyQualifiedName
                });

                dbContext.ServiceWatcher.Add(new ServiceWatcher
                {
                    ServiceID = 2,
                    TypeName = typeof(HttpRequestWatcher).AssemblyQualifiedName
                });

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
