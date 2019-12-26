namespace ServiceMonitor.Core.Domain
{
    public class Watcher
    {
        public Watcher()
        {
        }

        public Watcher(short? id)
        {
            ID = id;
        }

        public short? ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string AssemblyQualifiedName { get; set; }
    }
}
