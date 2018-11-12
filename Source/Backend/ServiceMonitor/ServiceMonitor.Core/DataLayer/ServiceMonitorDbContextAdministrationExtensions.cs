using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer
{
    public static class ServiceMonitorDbContextAdministrationExtensions
    {
        public static async Task<ServiceEnvironmentStatus> GetByServiceEnvironmentAsync(this ServiceMonitorDbContext dbContext, ServiceEnvironment entity)
            => await dbContext.ServiceEnvironmentStatus.FirstOrDefaultAsync(item => item.ServiceEnvironmentID == entity.ServiceEnvironmentID);
    }
}
