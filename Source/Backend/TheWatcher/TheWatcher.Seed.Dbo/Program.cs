using Microsoft.EntityFrameworkCore;
using TheWatcher.Domain.Core;
using TheWatcher.Domain.Core.Models;
using TheWatcher.Watcher.SqlServer;
using Environment = TheWatcher.Domain.Core.Models.Environment;

const string CnnStr = "Server=(local);Database=TheWatcher;Integrated Security=yes;TrustServerCertificate=true;";

static TheWatcherDbContext GetTheWatcherDbContext()
    => new TheWatcherDbContext(new DbContextOptionsBuilder<TheWatcherDbContext>().UseSqlServer(CnnStr).Options);

Console.WriteLine("Seeding...");

using var ctx = GetTheWatcherDbContext();

var audit = new
{
    CreationUser = "thewatcher.seed"
};

Console.WriteLine("Creating watchers...");

ctx.Watcher.Add(new Watcher
{
    AssemblyQualifiedName = typeof(SqlServerDatabaseWatcher).AssemblyQualifiedName,
    Name = typeof(SqlServerDatabaseWatcher).FullName,
    Description = "Watcher for SQL Server databases",
    Active = true,
    CreationUser = audit.CreationUser,
    CreationDateTime = DateTime.Now
});

ctx.SaveChanges();

Console.WriteLine();

Console.WriteLine(" Creating parameters for watchers...");

ctx.WatcherParameter.Add(new WatcherParameter
{
    WatcherId = 1,
    Parameter = "ConnectionString",
    Value = "",
    IsDefault = false,
    Active = true,
    CreationUser = audit.CreationUser,
    CreationDateTime = DateTime.Now
});

ctx.SaveChanges();

Console.WriteLine();

Console.WriteLine("Creating resource categories...");

ctx.ResourceCategory.Add(new ResourceCategory { Name = "Database", WatcherId = 1, Active = true, CreationUser = audit.CreationUser, CreationDateTime = DateTime.Now });
ctx.ResourceCategory.Add(new ResourceCategory { Name = "RESTful API", Active = true, CreationUser = audit.CreationUser, CreationDateTime = DateTime.Now });
ctx.ResourceCategory.Add(new ResourceCategory { Name = "Server", Active = true, CreationUser = audit.CreationUser, CreationDateTime = DateTime.Now });
ctx.ResourceCategory.Add(new ResourceCategory { Name = "URL", Active = true, CreationUser = audit.CreationUser, CreationDateTime = DateTime.Now });
ctx.ResourceCategory.Add(new ResourceCategory { Name = "Web Service", Active = true, CreationUser = audit.CreationUser, CreationDateTime = DateTime.Now });

ctx.SaveChanges();

Console.WriteLine();

Console.WriteLine("Creating resources...");

ctx.Resource.Add(new Resource
{
    Name = "The Watcher Sample SQL Server Database",
    ResourceCategoryId = 1,
    Active = true,
    CreationUser = audit.CreationUser,
    CreationDateTime = DateTime.Now
});

ctx.SaveChanges();

Console.WriteLine();

Console.WriteLine("Creating environments...");

ctx.Environment.Add(new Environment { Name = "Development", Active = true, CreationUser = audit.CreationUser, CreationDateTime = DateTime.Now });
ctx.Environment.Add(new Environment { Name = "QA", Active = true, CreationUser = audit.CreationUser, CreationDateTime = DateTime.Now });
ctx.Environment.Add(new Environment { Name = "Staging", Active = true, CreationUser = audit.CreationUser, CreationDateTime = DateTime.Now });
ctx.Environment.Add(new Environment { Name = "Production", Active = true, CreationUser = audit.CreationUser, CreationDateTime = DateTime.Now });

ctx.SaveChanges();

Console.WriteLine();

Console.WriteLine("Creating resource watches...");

ctx.ResourceWatch.Add(new ResourceWatch
{
    ResourceId = 1,
    EnvironmentId = 1,
    Interval = 15000,
    Active = true,
    CreationUser = audit.CreationUser,
    CreationDateTime = DateTime.Now
});

ctx.SaveChanges();

Console.WriteLine();

Console.WriteLine("Creating resource watches parameters...");

ctx.ResourceWatchParameter.Add(new ResourceWatchParameter
{
    ResourceWatchId = 1,
    Parameter = "ConnectionString",
    Value = "",
    Active = true,
    CreationUser = audit.CreationUser,
    CreationDateTime = DateTime.Now
});

ctx.SaveChanges();
