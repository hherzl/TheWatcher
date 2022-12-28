using TheWatcher.Domain.Core.QueryModels;

namespace TheWatcher.Domain.Core
{
    public static class TheWatcherDbContextQueries
    {
        public static IQueryable<ResourceWatchQueryModel> GetResourceWatchItems(this TheWatcherDbContext ctx)
        {
            var query =
                from resourceWatch in ctx.ResourceWatch
                join resource in ctx.Resource on resourceWatch.ResourceId equals resource.Id
                join resourceCategory in ctx.ResourceCategory on resource.ResourceCategoryId equals resourceCategory.Id
                join watcher in ctx.Watcher on resourceCategory.WatcherId equals watcher.Id
                join environment in ctx.Environment on resourceWatch.EnvironmentId equals environment.Id
                select new ResourceWatchQueryModel
                {
                    Id = resourceWatch.Id,
                    Resource = resource.Name,
                    ResourceCategory = resourceCategory.Name,
                    AssemblyQualifiedName = watcher.AssemblyQualifiedName,
                    Interval = resourceWatch.Interval,
                    Environment = environment.Name
                };

            return query;
        }
    }
}
