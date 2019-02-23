namespace ServiceMonitor.Core.DomainDrivenDesign
{
    public class EnvironmentCategory
    {
        public EnvironmentCategory()
        {
        }

        public EnvironmentCategory(int? environmentCategoryID)
        {
            EnvironmentCategoryID = environmentCategoryID;
        }

        public int? EnvironmentCategoryID { get; set; }

        public string EnvironmentCategoryName { get; set; }
    }
}
