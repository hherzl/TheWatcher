using TheWatcher.Domain.Core.Models;

namespace TheWatcher.Seed.Db.Seeds
{
    internal class Resources
    {
        public static IEnumerable<Resource> Items
        {
            get
            {
                yield return new Resource
                {
                    Name = "Watcher Sample for Default Gateway",
                    ResourceCategoryId = 3
                };

                yield return new Resource
                {
                    Name = "Watcher Sample SQL Server Database",
                    ResourceCategoryId = 1
                };

                yield return new Resource
                {
                    Name = "Watcher Sample MongoDB",
                    ResourceCategoryId = 6
                };
            }
        }
    }
}
