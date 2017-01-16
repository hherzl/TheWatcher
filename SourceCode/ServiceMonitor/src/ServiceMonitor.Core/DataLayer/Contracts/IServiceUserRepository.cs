using System;
using System.Collections.Generic;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Contracts
{
    public interface IServiceUserRepository : IRepository<ServiceUser>
    {
        IEnumerable<ServiceUser> GetByUser(Int32? userID);
    }
}
