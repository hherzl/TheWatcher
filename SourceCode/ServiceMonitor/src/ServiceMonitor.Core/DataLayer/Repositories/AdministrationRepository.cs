using System;
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
            => await DbContext
                .Set<ServiceEnvironmentStatus>()
                .FirstOrDefaultAsync(item => item.ServiceEnvironmentID == entity.ServiceEnvironmentID);

        public async Task<ServiceEnvironmentStatus> GetServiceEnvironmentStatusAsync(ServiceEnvironmentStatus entity)
            => await DbContext
                .Set<ServiceEnvironmentStatus>()
                .FirstOrDefaultAsync(item => item.ServiceEnvironmentStatusID == entity.ServiceEnvironmentStatusID);

        public async Task<Int32> CreateServiceEnvironmentStatusAsync(ServiceEnvironmentStatus entity)
        {
            DbContext.Set<ServiceEnvironmentStatus>().Add(entity);

            return await DbContext.SaveChangesAsync();
        }

        public async Task<Int32> CreateServiceEnvironmentStatusLogAsync(ServiceEnvironmentStatusLog entity)
        {
            entity.Date = DateTime.Now;

            DbContext.Set<ServiceEnvironmentStatusLog>().Add(entity);

            return await DbContext.SaveChangesAsync();
        }
    }
}
