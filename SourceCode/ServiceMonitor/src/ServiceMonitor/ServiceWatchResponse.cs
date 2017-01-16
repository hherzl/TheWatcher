using System;

namespace ServiceMonitor
{
    public class ServiceWatchResponse
    {
        public ServiceWatchResponse()
        {
        }

        public String Message { get; set; }

        public Boolean DidError { get; set; }

        public String ErrorMessage { get; set; }

        public ServiceWatchItem[] Model { get; set; }
    }
}
