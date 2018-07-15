using System;

namespace ServiceMonitor.Core.EntityLayer
{
    public class ServiceCategory
    {
        public ServiceCategory()
        {
        }

        public ServiceCategory(Int32? serviceCategoryID)
        {
            ServiceCategoryID = serviceCategoryID;
        }

        public Int32? ServiceCategoryID { get; set; }

        public String Description { get; set; }
    }
}
