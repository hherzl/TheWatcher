using TheWatcher.Domain.Core.Models;

namespace TheWatcher.Seed.Dbo.Seeds
{
    internal class ResourceCategories
    {
        public static IEnumerable<ResourceCategory> Items
        {
            get
            {
                yield return new ResourceCategory
                {
                    Name = "Database",
                    WatcherId = 2
                };

                yield return new ResourceCategory
                {
                    Name = "RESTful API"
                };

                yield return new ResourceCategory
                {
                    Name = "Server",
                    WatcherId = 1
                };

                yield return new ResourceCategory
                {
                    Name = "URL"
                };

                yield return new ResourceCategory
                {
                    Name = "Web Service"
                };
            }
        }
    }
}
