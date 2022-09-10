namespace ServiceMonitor.Clients.DataContracts
{
    public class ServiceWatchResponse
    {
        public string Message { get; set; }

        public bool DidError { get; set; }

        public string ErrorMessage { get; set; }

        public ServiceWatchItem[] Model { get; set; }
    }
}
