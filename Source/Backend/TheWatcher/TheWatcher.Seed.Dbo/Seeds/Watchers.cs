using TheWatcher.Watcher.PingWatcher;
using TheWatcher.Watcher.SqlServer;
using Foo = TheWatcher.Domain.Core.Models.Watcher;

namespace TheWatcher.Seed.Dbo.Seeds
{
    internal class Watchers
    {
        public static IEnumerable<Foo> Items
        {
            get
            {
                yield return new Foo
                {
                    Guid = new PingWatcher().Guid,
                    AssemblyQualifiedName = typeof(PingWatcher).AssemblyQualifiedName,
                    Name = typeof(PingWatcher).FullName,
                    Description = "Watcher for Ping requests",
                };

                yield return new Foo
                {
                    Guid = new SqlServerDatabaseWatcher().Guid,
                    AssemblyQualifiedName = typeof(SqlServerDatabaseWatcher).AssemblyQualifiedName,
                    Name = typeof(SqlServerDatabaseWatcher).FullName,
                    Description = "Watcher for SQL Server databases"
                };
            }
        }
    }
}
