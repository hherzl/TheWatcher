using System.Collections.Generic;

namespace ServiceMonitor
{
    public class ServiceWatchItem
    {
        public int? ServiceID { get; set; }

        public int? ServiceEnvironmentID { get; set; }

        public string Environment { get; set; }

        public string ServiceName { get; set; }

        public int? Interval { get; set; }

        public string Url { get; set; }

        public string Address { get; set; }

        public string ConnectionString { get; set; }

        public string TypeName { get; set; }

        public IDictionary<string, string> ToDictionary()
            => new Dictionary<string, string>
            {
                { "Url", Url },
                { "Address", Address },
                { "ConnectionString", ConnectionString },
                { "TypeName", TypeName }
            };

        public string GetTarget()
        {
            if (!string.IsNullOrEmpty(Url))
                return Url;

            if (!string.IsNullOrEmpty(Address))
                return Address;

            if (!string.IsNullOrEmpty(ConnectionString))
                return ConnectionString;

            return string.Empty;
        }
    }
}
