using System;
using ServiceMonitor.Core.DataLayer;

namespace ServiceMonitor.Core.BusinessLayer
{
    public abstract class BusinessObject
    {
        protected readonly ServiceMonitorDbContext DbContext;
        protected Boolean Disposed;

        public BusinessObject(ServiceMonitorDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected virtual void Dispose(Boolean disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }

            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
    }
}
