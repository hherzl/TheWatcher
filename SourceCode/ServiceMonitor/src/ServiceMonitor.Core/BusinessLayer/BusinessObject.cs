using System;
using Microsoft.Extensions.Logging;
using ServiceMonitor.Core.DataLayer;

namespace ServiceMonitor.Core.BusinessLayer
{
    public abstract class BusinessObject
    {
        protected ILogger Logger;
        protected readonly ServiceMonitorDbContext DbContext;
        protected Boolean Disposed;

        public BusinessObject(ILogger logger, ServiceMonitorDbContext dbContext)
        {
            Logger = logger;
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
