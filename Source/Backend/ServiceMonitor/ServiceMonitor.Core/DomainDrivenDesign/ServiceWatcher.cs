namespace ServiceMonitor.Core.DomainDrivenDesign
{
    public class ServiceWatcher
    {
        public ServiceWatcher()
        {
        }

        public ServiceWatcher(int? serviceWatcherID)
        {
            ServiceWatcherID = serviceWatcherID;
        }

        public int? ServiceWatcherID { get; set; }

        public int? ServiceID { get; set; }

        public string TypeName { get; set; }
    }
}
