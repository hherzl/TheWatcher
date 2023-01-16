using TheWatcher.Domain.Core.Models;
using TheWatcher.Watchers.MongoDB;
using TheWatcher.Watchers.PingWatcher;
using TheWatcher.Watchers.SqlServer;

namespace TheWatcher.Seed.Dbo.Seeds
{
    internal class Watchers
    {
        public static IEnumerable<Watcher> Items
        {
            get
            {
                yield return new Watcher
                {
                    Name = typeof(PingWatcher).FullName,
                    Description = "Watcher for Ping requests",
                    AssemblyQualifiedName = typeof(PingWatcher).AssemblyQualifiedName,
                    ClassName = typeof(PingWatcher).Name,
                    Guid = new PingWatcher().Guid
                };

                yield return new Watcher
                {
                    Name = typeof(SqlServerDatabaseWatcher).FullName,
                    Description = "Watcher for SQL Server databases",
                    AssemblyQualifiedName = typeof(SqlServerDatabaseWatcher).AssemblyQualifiedName,
                    ClassName = typeof(SqlServerDatabaseWatcher).AssemblyQualifiedName,
                    Guid = new SqlServerDatabaseWatcher().Guid
                };

                yield return new Watcher
                {
                    Name = typeof(MongoDBWatcher).FullName,
                    Description = "Watcher for MongoDB",
                    AssemblyQualifiedName = typeof(MongoDBWatcher).AssemblyQualifiedName,
                    ClassName = typeof(MongoDBWatcher).AssemblyQualifiedName,
                    Guid = new MongoDBWatcher().Guid
                };
            }
        }
    }
}
