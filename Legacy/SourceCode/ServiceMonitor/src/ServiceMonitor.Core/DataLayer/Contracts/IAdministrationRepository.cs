using System;
using System.Threading.Tasks;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Contracts
{
    public interface IAdministrationRepository : IRepository
    {
        Task<ServiceEnvironmentStatus> GetByServiceEnvironmentAsync(ServiceEnvironment entity);

        Task<ServiceEnvironmentStatus> GetServiceEnvironmentStatusAsync(ServiceEnvironmentStatus entity);

        Task<Int32> CreateServiceEnvironmentStatusAsync(ServiceEnvironmentStatus entity);

        Task<Int32> CreateServiceEnvironmentStatusLogAsync(ServiceEnvironmentStatusLog entity);
    }
}
