
namespace ServiceMonitor.Core.Domain
{
    public class Environment
    {
        public Environment()
        {
        }

        public Environment(short? id)
        {
            ID = id;
        }

        public short? ID { get; set; }

        public string Name { get; set; }
    }
}
