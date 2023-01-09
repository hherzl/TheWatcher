using TheWatcher.Domain.Core.Models;

namespace TheWatcher.Seed.Dbo.Seeds
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
                    Interval = 5000
                };

                yield return new ResourceWatch
                {
                    ResourceId = 2,
                    EnvironmentId = 1,
                    Interval = 15000
                };
            }
        }
    }
}
