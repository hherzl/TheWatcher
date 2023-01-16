using TheWatcher.Domain.Core.Models;

namespace TheWatcher.Seed.Db.Seeds
{
    internal class ResourceCategories
    {
        public static IEnumerable<ResourceCategory> Items
        {
            get
            {
                yield return new ResourceCategory
                {
                    Name = "SQL Server Database",
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

                yield return new ResourceCategory
                {
                    Name = "MongoDB Database",
                    WatcherId = 3
                };

                yield return new ResourceCategory
                {
                    Name = "Broker",
                    WatcherId = 4
                };
            }
        }
    }
}
