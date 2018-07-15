namespace ServiceMonitor.Core.DataLayer.Repositories
{
    public abstract class Repository
    {
        protected ServiceMonitorDbContext DbContext;

        public Repository(ServiceMonitorDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Dispose()
        {
            // todo: Implement dispose logic
        }
    }
}
