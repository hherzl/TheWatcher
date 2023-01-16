using TheWatcher.Domain.Core.Models;
using TheWatcher.Watchers.MongoDB;
using TheWatcher.Watchers.PingWatcher;
using TheWatcher.Watchers.RabbitMQ;
using TheWatcher.Watchers.SqlServer;

namespace TheWatcher.Seed.Db.Seeds
{
    internal class Watchers
    {
        public static IEnumerable<Watcher> Items
        {
            get
            {
                yield return new Watcher
                {
                    Name = typeof(PingWatcher).Name,
                    Description = "Watcher for Ping requests",
                    AssemblyQualifiedName = typeof(PingWatcher).AssemblyQualifiedName,
                    ClassName = typeof(PingWatcher).FullName,
                    Guid = new PingWatcher().Guid
                };

                yield return new Watcher
                {
                    Name = typeof(SqlServerDatabaseWatcher).Name,
                    Description = "Watcher for SQL Server databases",
                    AssemblyQualifiedName = typeof(SqlServerDatabaseWatcher).AssemblyQualifiedName,
                    ClassName = typeof(SqlServerDatabaseWatcher).FullName,
                    Guid = new SqlServerDatabaseWatcher().Guid
                };

                yield return new Watcher
                {
                    Name = typeof(MongoDBWatcher).Name,
                    Description = "Watcher for Mongo DB",
                    AssemblyQualifiedName = typeof(MongoDBWatcher).AssemblyQualifiedName,
                    ClassName = typeof(MongoDBWatcher).FullName,
                    Guid = new MongoDBWatcher().Guid
                };

                yield return new Watcher
                {
                    Name = typeof(RabbitMQWatcher).Name,
                    Description = "Watcher for Rabbit MQ",
                    AssemblyQualifiedName = typeof(RabbitMQWatcher).AssemblyQualifiedName,
                    ClassName = typeof(RabbitMQWatcher).FullName,
                    Guid = new RabbitMQWatcher().Guid
                };
            }
        }
    }
}
