using TheWatcher.Domain.Core.Models;

namespace TheWatcher.Seed.Dbo.Seeds
{
    internal class Resources
    {
        public static IEnumerable<Resource> Items
        {
            get
            {
                yield return new Resource
                {
                    Name = "The Watcher Sample for Default Gateway",
                    ResourceCategoryId = 3
                };

                yield return new Resource
                {
                    Name = "The Watcher Sample SQL Server Database",
                    ResourceCategoryId = 1
                };
            }
        }
    }
}
