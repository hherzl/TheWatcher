using System.Collections.Generic;

namespace ServiceMonitor
{
    public class ServiceStatusLog
    {
        public int? ServiceID { get; set; }

        public int? ServiceEnvironmentID { get; set; }

        public string Target { get; set; }

        public string ActionName { get; set; }

        public bool? Success { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }
    }

    public class ServiceWatchResponse
    {
        public string Message { get; set; }

        public bool DidError { get; set; }

        public string ErrorMessage { get; set; }

        public ServiceWatchItem[] Model { get; set; }
    }

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

        public Dictionary<string, string> ToDictionary()
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
