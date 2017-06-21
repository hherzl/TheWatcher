using System;
using System.Collections.Generic;

namespace ServiceMonitor
{
    public class ServiceStatusLog
    {
        public Int32? ServiceID { get; set; }

        public Int32? ServiceEnvironmentID { get; set; }

        public String Target { get; set; }

        public String ActionName { get; set; }

        public Boolean? Success { get; set; }

        public String Message { get; set; }

        public String StackTrace { get; set; }
    }

    public class ServiceWatchResponse
    {
        public String Message { get; set; }

        public Boolean DidError { get; set; }

        public String ErrorMessage { get; set; }

        public ServiceWatchItem[] Model { get; set; }
    }

    public class ServiceWatchItem
    {
        public Int32? ServiceID { get; set; }

        public Int32? ServiceEnvironmentID { get; set; }

        public String Environment { get; set; }

        public String ServiceName { get; set; }

        public Int32? Interval { get; set; }

        public String Url { get; set; }

        public String Address { get; set; }

        public String ConnectionString { get; set; }

        public String TypeName { get; set; }

        public Dictionary<String, String> ToDictionary()
        {
            var values = new Dictionary<String, String>();

            values.Add("Url", Url);
            values.Add("Address", Address);
            values.Add("ConnectionString", ConnectionString);
            values.Add("TypeName", TypeName);

            return values;
        }

        public String GetTarget()
        {
            if (!String.IsNullOrEmpty(Url))
            {
                return Url;
            }

            if (!String.IsNullOrEmpty(Address))
            {
                return Address;
            }

            if (!String.IsNullOrEmpty(ConnectionString))
            {
                return ConnectionString;
            }

            return String.Empty;
        }
    }
}
