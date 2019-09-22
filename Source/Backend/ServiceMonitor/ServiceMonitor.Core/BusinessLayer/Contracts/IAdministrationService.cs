using System.Threading.Tasks;
using ServiceMonitor.Core.BusinessLayer.Responses;
using ServiceMonitor.Core.Domain;

namespace ServiceMonitor.Core.BusinessLayer.Contracts
{
    public interface IAdministrationService : IService
    {
        Task<ISingleResponse<ServiceEnvironmentStatusLog>> CreateServiceEnvironmentStatusLogAsync(ServiceEnvironmentStatusLog entity, int? serviceEnvironmentID);
    }
}
