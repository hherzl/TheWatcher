using System;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUserName(String userName);
    }
}
