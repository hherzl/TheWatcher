using Microsoft.EntityFrameworkCore;
using TheWatcher.Domain.Core;
using TheWatcher.Domain.Core.Models;
using TheWatcher.Watcher.PingWatcher;
using TheWatcher.Watcher.SqlServer;
using Environment = TheWatcher.Domain.Core.Models.Environment;

const string CnnStr = "Server=(local);Database=TheWatcher;Integrated Security=yes;TrustServerCertificate=true;";

static TheWatcherDbContext GetTheWatcherDbContext()
    => new TheWatcherDbContext(new DbContextOptionsBuilder<TheWatcherDbContext>().UseSqlServer(CnnStr).Options);

Console.WriteLine("Seeding...");
Console.WriteLine();

using var ctx = GetTheWatcherDbContext();

var audit = new
{
    CreationUser = "thewatcher.seed"
};

Console.WriteLine("Creating watchers...");

ctx.Watcher.Add(new Watcher
{
    AssemblyQualifiedName = typeof(PingWatcher).AssemblyQualifiedName,
    Name = typeof(PingWatcher).FullName,
    Description = "Watcher for Ping requests",
    Active = true,
    CreationUser = audit.CreationUser,
    CreationDateTime = DateTime.Now
});

ctx.SaveChanges();

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

Console.WriteLine(" The watchers were created successfully");
Console.WriteLine();

Console.WriteLine("  Creating parameters for watchers...");

ctx.WatcherParameter.Add(new WatcherParameter
{
    WatcherId = 1,
    Parameter = "IPAddress",
    Value = "",
    IsDefault = false,
    Active = true,
    CreationUser = audit.CreationUser,
    CreationDateTime = DateTime.Now
});

ctx.WatcherParameter.Add(new WatcherParameter
{
    WatcherId = 2,
    Parameter = "ConnectionString",
    Value = "",
    IsDefault = false,
    Active = true,
    CreationUser = audit.CreationUser,
    CreationDateTime = DateTime.Now
});

ctx.SaveChanges();

Console.WriteLine("  The watcher parameters were created successfully");
Console.WriteLine();

Console.WriteLine("Creating resource categories...");

ctx.ResourceCategory.Add(new ResourceCategory { Name = "Database", WatcherId = 2, Active = true, CreationUser = audit.CreationUser, CreationDateTime = DateTime.Now });

ctx.SaveChanges();

ctx.ResourceCategory.Add(new ResourceCategory { Name = "RESTful API", Active = true, CreationUser = audit.CreationUser, CreationDateTime = DateTime.Now });

ctx.SaveChanges();

ctx.ResourceCategory.Add(new ResourceCategory { Name = "Server", WatcherId = 1, Active = true, CreationUser = audit.CreationUser, CreationDateTime = DateTime.Now });

ctx.SaveChanges();

ctx.ResourceCategory.Add(new ResourceCategory { Name = "URL", Active = true, CreationUser = audit.CreationUser, CreationDateTime = DateTime.Now });

ctx.SaveChanges();

ctx.ResourceCategory.Add(new ResourceCategory { Name = "Web Service", Active = true, CreationUser = audit.CreationUser, CreationDateTime = DateTime.Now });

ctx.SaveChanges();

Console.WriteLine(" The resource categories were created successfully");
Console.WriteLine();

Console.WriteLine("Creating resources...");

ctx.Resource.Add(new Resource
{
    Name = "The Watcher Sample for Default Gateway",
    ResourceCategoryId = 1,
    Active = true,
    CreationUser = audit.CreationUser,
    CreationDateTime = DateTime.Now
});

ctx.Resource.Add(new Resource
{
    Name = "The Watcher Sample SQL Server Database",
    ResourceCategoryId = 3,
    Active = true,
    CreationUser = audit.CreationUser,
    CreationDateTime = DateTime.Now
});

ctx.SaveChanges();

Console.WriteLine(" The watchers were created successfully");
Console.WriteLine();

Console.WriteLine("Creating environments...");

ctx.Environment.Add(new Environment { Name = "Development", Active = true, CreationUser = audit.CreationUser, CreationDateTime = DateTime.Now });
ctx.Environment.Add(new Environment { Name = "QA", Active = true, CreationUser = audit.CreationUser, CreationDateTime = DateTime.Now });
ctx.Environment.Add(new Environment { Name = "Staging", Active = true, CreationUser = audit.CreationUser, CreationDateTime = DateTime.Now });
ctx.Environment.Add(new Environment { Name = "Production", Active = true, CreationUser = audit.CreationUser, CreationDateTime = DateTime.Now });

ctx.SaveChanges();

Console.WriteLine(" The environments were created successfully");
Console.WriteLine();

Console.WriteLine("Creating resource watches...");

ctx.ResourceWatch.Add(new ResourceWatch
{
    ResourceId = 1,
    EnvironmentId = 1,
    Interval = 5000,
    Active = true,
    CreationUser = audit.CreationUser,
    CreationDateTime = DateTime.Now
});

ctx.ResourceWatch.Add(new ResourceWatch
{
    ResourceId = 2,
    EnvironmentId = 1,
    Interval = 15000,
    Active = true,
    CreationUser = audit.CreationUser,
    CreationDateTime = DateTime.Now
});

ctx.SaveChanges();

Console.WriteLine("The resource watches were created successfully");
Console.WriteLine();

Console.WriteLine("Creating resource watches parameters...");

ctx.ResourceWatchParameter.Add(new ResourceWatchParameter
{
    ResourceWatchId = 1,
    Parameter = "IPAddress",
    Value = " 192.168.0.1",
    Active = true,
    CreationUser = audit.CreationUser,
    CreationDateTime = DateTime.Now
});

ctx.ResourceWatchParameter.Add(new ResourceWatchParameter
{
    ResourceWatchId = 2,
    Parameter = "ConnectionString",
    Value = "Server=(local);Database=TheWatcher;Integrated Security=yes;TrustServerCertificate=true;",
    Active = true,
    CreationUser = audit.CreationUser,
    CreationDateTime = DateTime.Now
});

ctx.SaveChanges();

Console.WriteLine(" The resource watches parameters were created successfully");
