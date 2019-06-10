namespace ServiceMonitor.Core.DomainDrivenDesign
{
    public class ServiceWatcher
    {
        public ServiceWatcher()
        {
        }

        public ServiceWatcher(int? id)
        {
            ID = id;
        }

        public int? ID { get; set; }

        public int? ServiceID { get; set; }

        public string TypeName { get; set; }
    }
}
