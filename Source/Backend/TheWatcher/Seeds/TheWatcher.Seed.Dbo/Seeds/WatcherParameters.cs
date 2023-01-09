using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using TheWatcher.Domain.Core.Models;

namespace TheWatcher.Seed.Dbo.Seeds
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
            }
        }
    }
}
