namespace ServiceMonitor.Core.DomainDrivenDesign
{
    public class EnvironmentCategory
    {
        public EnvironmentCategory()
        {
        }

        public EnvironmentCategory(int? id)
        {
            ID = id;
        }

        public int? ID { get; set; }

        public string Name { get; set; }
    }
}
