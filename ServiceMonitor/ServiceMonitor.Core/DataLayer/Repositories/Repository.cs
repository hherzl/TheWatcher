using System.Threading.Tasks;

namespace ServiceMonitor.Core.DataLayer.Repositories
{
    public abstract class Repository
    {
        protected ServiceMonitorDbContext DbContext;

        public Repository(ServiceMonitorDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual int SaveChanges()
            => DbContext.SaveChanges();

        public virtual async Task<int> SaveChangesAsync()
            => await DbContext.SaveChangesAsync();
    }
}
