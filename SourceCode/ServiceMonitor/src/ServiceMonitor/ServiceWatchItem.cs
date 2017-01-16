using System;
using System.Collections.Generic;

namespace ServiceMonitor
{
    public class ServiceWatchItem
    {
        public ServiceWatchItem()
        {
        }

        public Int32? ServiceID { get; set; }

        public String ServiceName { get; set; }

        public Int32? Interval { get; set; }

        public String Url { get; set; }

        public String Address { get; set; }

        public String ProviderName { get; set; }

        public String ConnectionString { get; set; }

        public String TypeName { get; set; }

        public Dictionary<String, String> ToDictionary()
        {
            var values = new Dictionary<String, String>();

            values.Add("Url", Url);
            values.Add("Address", Address);
            values.Add("ProviderName", ProviderName);
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
