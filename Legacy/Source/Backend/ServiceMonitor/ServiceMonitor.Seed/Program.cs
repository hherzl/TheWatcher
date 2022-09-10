using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Common.Watchers;
using ServiceMonitor.Core.Domain;

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
                dbContext.ServiceCategories.Add(new ServiceCategory { Name = "Database" });
                dbContext.ServiceCategories.Add(new ServiceCategory { Name = "RESTful API" });
                dbContext.ServiceCategories.Add(new ServiceCategory { Name = "Server" });
                dbContext.ServiceCategories.Add(new ServiceCategory { Name = "URL" });
                dbContext.ServiceCategories.Add(new ServiceCategory { Name = "Web Service" });

                Console.WriteLine("Creating service categories...");

                await dbContext.SaveChangesAsync();

                dbContext.Environments.Add(new Core.Domain.Environment { Name = "Development" });
                dbContext.Environments.Add(new Core.Domain.Environment { Name = "Production" });

                Console.WriteLine("Creating environments...");

                await dbContext.SaveChangesAsync();

                dbContext.Services.Add(new Service { ServiceCategoryID = 100, Name = "Northwind Database" });
                dbContext.Services.Add(new Service { ServiceCategoryID = 200, Name = "Sample API" });
                dbContext.Services.Add(new Service { ServiceCategoryID = 300, Name = "DNS" });
                dbContext.Services.Add(new Service { ServiceCategoryID = 100, Name = "DVD Rental Database" });

                Console.WriteLine("Creating services...");

                await dbContext.SaveChangesAsync();

                dbContext.ServiceEnvironments.Add(new ServiceEnvironment
                {
                    ServiceID = 1000,
                    EnvironmentID = 100,
                    Interval = 15000,
                    ConnectionString = "server=(local);database=Northwind;integrated security=yes;",
                    Description = "SQL Server Local Instance",
                    Active = true
                });

                dbContext.ServiceEnvironments.Add(new ServiceEnvironment
                {
                    ServiceID = 1000,
                    EnvironmentID = 200,
                    Interval = 15000,
                    ConnectionString = "server=(local);database=Northwind;integrated security=yes;",
                    Description = "SQL Server Local Instance",
                    Active = true
                });

                dbContext.ServiceEnvironments.Add(new ServiceEnvironment
                {
                    ServiceID = 2000,
                    EnvironmentID = 100,
                    Interval = 5000,
                    Url = "http://localhost:5612/api/values",
                    Description = "Sample Rest API",
                    Active = true
                });

                dbContext.ServiceEnvironments.Add(new ServiceEnvironment
                {
                    ServiceID = 3000,
                    EnvironmentID = 100,
                    Interval = 3000,
                    Address = "192.168.1.1",
                    Description = "DNS gateway",
                    Active = true
                });

                dbContext.ServiceEnvironments.Add(new ServiceEnvironment
                {
                    ServiceID = 4000,
                    EnvironmentID = 200,
                    Interval = 20000,
                    ConnectionString = "Server=localhost; Port=5432; Database=dvdrental; User Id=postgres; Password=Pass123$;",
                    Description = "Postgre SQL Local Instance",
                    Active = true
                });

                Console.WriteLine("Creating service environments...");

                await dbContext.SaveChangesAsync();

                dbContext.Watchers.Add(new Watcher
                {
                    Name = "SqlServerDatabaseWatcher",
                    Description = "Watcher for SQL Server databases",
                    AssemblyQualifiedName = typeof(SqlServerDatabaseWatcher).AssemblyQualifiedName
                });

                dbContext.Watchers.Add(new Watcher
                {
                    Name = "HttpRequestWatcher",
                    Description = "Watcher for http requests",
                    AssemblyQualifiedName = typeof(HttpRequestWatcher).AssemblyQualifiedName
                });

                dbContext.Watchers.Add(new Watcher
                {
                    Name = "PingWatcher",
                    Description = "Watcher for ping requests",
                    AssemblyQualifiedName = typeof(PingWatcher).AssemblyQualifiedName
                });

                dbContext.Watchers.Add(new Watcher
                {
                    Name = "PostgreSqlDatabaseWatcher",
                    Description = "Watcher for Postgre SQL databases",
                    AssemblyQualifiedName = typeof(PostgreSqlDatabaseWatcher).AssemblyQualifiedName
                });

                Console.WriteLine("Creating watchers...");

                await dbContext.SaveChangesAsync();

                dbContext.ServiceWatchers.Add(new ServiceWatcher
                {
                    ServiceID = 1000,
                    WatcherID = 1000
                });

                dbContext.ServiceWatchers.Add(new ServiceWatcher
                {
                    ServiceID = 2000,
                    WatcherID = 2000
                });

                dbContext.ServiceWatchers.Add(new ServiceWatcher
                {
                    ServiceID = 3000,
                    WatcherID = 3000
                });

                dbContext.ServiceWatchers.Add(new ServiceWatcher
                {
                    ServiceID = 4000,
                    WatcherID = 4000
                });

                Console.WriteLine("Creating service watchers...");

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
