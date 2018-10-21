namespace ServiceMonitor.Core.EntityLayer
{
    public class ServiceCategory
    {
        public ServiceCategory()
        {
        }

        public ServiceCategory(int? serviceCategoryID)
        {
            ServiceCategoryID = serviceCategoryID;
        }

        public int? ServiceCategoryID { get; set; }

        public string Description { get; set; }
    }
}
