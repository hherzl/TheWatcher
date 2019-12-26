using System.Threading.Tasks;
using ServiceMonitor.Core.Business.Responses.Contracts;
using ServiceMonitor.Core.Domain;

namespace ServiceMonitor.Core.Business.Contracts
{
    public interface IAdministrationService : IService
    {
        Task<ISingleResponse<ServiceEnvironmentStatusLog>> CreateServiceEnvironmentStatusLogAsync(ServiceEnvironmentStatusLog entity, short? serviceEnvironmentID);
    }
}
