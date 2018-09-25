using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.DataLayer.Contracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Repositories
{
    public class AdministrationRepository : Repository, IAdministrationRepository
    {
        public AdministrationRepository(ServiceMonitorDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<ServiceEnvironmentStatus> GetByServiceEnvironmentAsync(ServiceEnvironment entity)
            => await DbContext.Set<ServiceEnvironmentStatus>().FirstOrDefaultAsync(item => item.ServiceEnvironmentID == entity.ServiceEnvironmentID);

        public async Task<ServiceEnvironmentStatus> GetServiceEnvironmentStatusAsync(ServiceEnvironmentStatus entity)
            => await DbContext.Set<ServiceEnvironmentStatus>().FirstOrDefaultAsync(item => item.ServiceEnvironmentStatusID == entity.ServiceEnvironmentStatusID);
    }
}
