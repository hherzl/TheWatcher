namespace ServiceMonitor.Core.Domain
{
    public class ServiceWatcher
    {
        public ServiceWatcher()
        {
        }

        public ServiceWatcher(short? id)
        {
            ID = id;
        }

        public short? ID { get; set; }

        public short? ServiceID { get; set; }

        public short? WatcherID { get; set; }
    }
}
