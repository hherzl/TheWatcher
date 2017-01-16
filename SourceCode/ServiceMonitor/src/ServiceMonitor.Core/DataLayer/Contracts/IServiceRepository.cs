using System;
using System.Collections.Generic;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Contracts
{
    public interface IServiceRepository : IRepository<Service>
    {
        IEnumerable<Service> GetByServiceCategoryID(Int32? serviceCategoryID);
    }
}
