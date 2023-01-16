using TheWatcher.Domain.Core.Models;

namespace TheWatcher.Seed.Db.Seeds
{
    internal class WatcherParameters
    {
        public static IEnumerable<WatcherParameter> Items
        {
            get
            {
                yield return new WatcherParameter
                {
                    WatcherId = 1,
                    Parameter = "IPAddress",
                    Value = "",
                    IsDefault = false
                };

                yield return new WatcherParameter
                {
                    WatcherId = 2,
                    Parameter = "ConnectionString",
                    Value = "",
                    IsDefault = false
                };

                yield return new WatcherParameter
                {
                    WatcherId = 3,
                    Parameter = "DatabaseName",
                    Value = "",
                    IsDefault = false
                };
            }
        }
    }
}
