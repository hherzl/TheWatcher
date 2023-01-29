using TheWatcher.Domain.Core.Models;
using TheWatcher.Watchers.MongoDB;
using TheWatcher.Watchers.PingWatcher;
using TheWatcher.Watchers.PostgreSQL;
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
                    Name = "Ping watcher",
                    Description = "Watcher for Ping requests",
                    ClassName = typeof(PingWatcher).FullName,
                    ClassGuid = new PingWatcher().Guid,
                    AssemblyQualifiedName = typeof(PingWatcher).AssemblyQualifiedName
                };

                yield return new Watcher
                {
                    Name = "SQL Server watcher",
                    Description = "Watcher for SQL Server databases",
                    ClassName = typeof(SqlServerDatabaseWatcher).FullName,
                    ClassGuid = new SqlServerDatabaseWatcher().Guid,
                    AssemblyQualifiedName = typeof(SqlServerDatabaseWatcher).AssemblyQualifiedName
                };

                yield return new Watcher
                {
                    Name = "Mongo DB watcher",
                    Description = "Watcher for Mongo DB",
                    ClassName = typeof(MongoDBWatcher).FullName,
                    ClassGuid = new MongoDBWatcher().Guid,
                    AssemblyQualifiedName = typeof(MongoDBWatcher).AssemblyQualifiedName
                };

                yield return new Watcher
                {
                    Name = "Rabbit MQ watcher",
                    Description = "Watcher for Rabbit MQ",
                    ClassName = typeof(RabbitMQWatcher).FullName,
                    ClassGuid = new RabbitMQWatcher().Guid,
                    AssemblyQualifiedName = typeof(RabbitMQWatcher).AssemblyQualifiedName
                };

                yield return new Watcher
                {
                    Name = "PostgreSQL watcher",
                    Description = "Watcher for PostgreSQL databases",
                    ClassName = typeof(PostgreSQLDatabaseWatcher).FullName,
                    ClassGuid = new PostgreSQLDatabaseWatcher().Guid,
                    AssemblyQualifiedName = typeof(PostgreSQLDatabaseWatcher).AssemblyQualifiedName
                };
            }
        }
    }
}
