using TheWatcher.Seed.Dbo;
using TheWatcher.Seed.Dbo.Seeds;

Console.WriteLine("Seeding...");
Console.WriteLine();

using var ctx = DbContextHelper.GetTheWatcherDbContext();

var audit = new
{
    CreationUser = "thewatcher.seed"
};

Console.WriteLine("Creating watchers...");

foreach (var item in Watchers.Items)
{
    item.Active = true;
    item.CreationUser = audit.CreationUser;
    item.CreationDateTime = DateTime.Now;

    ctx.Watcher.Add(item);

    ctx.SaveChanges();
}

Console.WriteLine(" The watchers were created successfully");
Console.WriteLine();

Console.WriteLine("  Creating parameters for watchers...");

foreach (var item in WatcherParameters.Items)
{
    item.Active = true;
    item.CreationUser = audit.CreationUser;
    item.CreationDateTime = DateTime.Now;

    ctx.WatcherParameter.Add(item);

    ctx.SaveChanges();
}

Console.WriteLine("  The watcher parameters were created successfully");
Console.WriteLine();

Console.WriteLine("Creating resource categories...");

foreach (var item in ResourceCategories.Items)
{
    item.Active = true;
    item.CreationUser = audit.CreationUser;
    item.CreationDateTime = DateTime.Now;

    ctx.ResourceCategory.Add(item);

    ctx.SaveChanges();
}

Console.WriteLine(" The resource categories were created successfully");
Console.WriteLine();

Console.WriteLine("Creating resources...");

foreach (var item in Resources.Items)
{
    item.Active = true;
    item.CreationUser = audit.CreationUser;
    item.CreationDateTime = DateTime.Now;

    ctx.Resource.Add(item);

    ctx.SaveChanges();
}

Console.WriteLine(" The watchers were created successfully");
Console.WriteLine();

Console.WriteLine("Creating environments...");

foreach (var item in Environments.Items)
{
    item.Active = true;
    item.CreationUser = audit.CreationUser;
    item.CreationDateTime = DateTime.Now;

    ctx.Environment.Add(item);

    ctx.SaveChanges();
}

Console.WriteLine(" The environments were created successfully");
Console.WriteLine();

Console.WriteLine("Creating resource watches...");

foreach (var item in ResourceWatches.Items)
{
    item.Active = true;
    item.CreationUser = audit.CreationUser;
    item.CreationDateTime = DateTime.Now;

    ctx.ResourceWatch.Add(item);

    ctx.SaveChanges();
}

Console.WriteLine("The resource watches were created successfully");
Console.WriteLine();

Console.WriteLine("Creating resource watches parameters...");

foreach (var item in ResourceWatchParameters.Items)
{
    item.Active = true;
    item.CreationUser = audit.CreationUser;
    item.CreationDateTime = DateTime.Now;

    ctx.ResourceWatchParameter.Add(item);

    ctx.SaveChanges();
}

Console.WriteLine(" The resource watches parameters were created successfully");
