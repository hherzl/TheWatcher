using TheWatcher.Domain.Core.Models;

namespace TheWatcher.Seed.Db.Seeds
{
    internal class ResourceWatches
    {
        public static IEnumerable<ResourceWatch> Items
        {
            get
            {
                yield return new ResourceWatch
                {
                    ResourceId = 1,
                    EnvironmentId = 1,
                    Interval = 10000,
                    WatchCount = 0
                };

                yield return new ResourceWatch
                {
                    ResourceId = 2,
                    EnvironmentId = 1,
                    Interval = 15000,
                    WatchCount = 0
                };

                yield return new ResourceWatch
                {
                    ResourceId = 3,
                    EnvironmentId = 1,
                    Interval = 20000,
                    WatchCount = 0
                };

                yield return new ResourceWatch
                {
                    ResourceId = 4,
                    EnvironmentId = 1,
                    Interval = 30000,
                    WatchCount = 0
                };
            }
        }
    }
}
