using TheWatcher.Domain.Core.Models;

namespace TheWatcher.Seed.Dbo.Seeds
{
    internal class ResourceWatchParameters
    {
        public static IEnumerable<ResourceWatchParameter> Items
        {
            get
            {
                yield return new ResourceWatchParameter
                {
                    ResourceWatchId = 1,
                    Parameter = "IPAddress",
                    Value = " 192.168.0.1"
                };

                yield return new ResourceWatchParameter
                {
                    ResourceWatchId = 2,
                    Parameter = "ConnectionString",
                    Value = "Server=(local);Database=TheWatcher;Integrated Security=yes;TrustServerCertificate=true;"
                };

                yield return new ResourceWatchParameter
                {
                    ResourceWatchId = 3,
                    Parameter = "ConnectionString",
                    Value = "mongodb://localhost:27017"
                };

                yield return new ResourceWatchParameter
                {
                    ResourceWatchId = 3,
                    Parameter = "DatabaseName",
                    Value = "TheWatcher"
                };
            }
        }
    }
}
