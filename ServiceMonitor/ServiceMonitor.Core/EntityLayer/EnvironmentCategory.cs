using System;

namespace ServiceMonitor.Core.EntityLayer
{
    public class EnvironmentCategory
    {
        public EnvironmentCategory()
        {
        }

        public EnvironmentCategory(Int32? environmentCategoryID)
        {
            EnvironmentCategoryID = environmentCategoryID;
        }

        public Int32? EnvironmentCategoryID { get; set; }

        public String EnvironmentCategoryName { get; set; }
    }
}
