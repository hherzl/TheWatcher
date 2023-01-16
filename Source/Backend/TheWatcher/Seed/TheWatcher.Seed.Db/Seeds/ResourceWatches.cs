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
                    Interval = 10000
                };

                yield return new ResourceWatch
                {
                    ResourceId = 2,
                    EnvironmentId = 1,
                    Interval = 15000
                };

                yield return new ResourceWatch
                {
                    ResourceId = 3,
                    EnvironmentId = 1,
                    Interval = 20000
                };
            }
        }
    }
}
