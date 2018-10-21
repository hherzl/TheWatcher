using System;
using Microsoft.Extensions.Logging;
using ServiceMonitor.Core.DataLayer;

namespace ServiceMonitor.Core.BusinessLayer
{
    public abstract class Service
    {
        protected ILogger Logger;
        protected readonly ServiceMonitorDbContext DbContext;
        protected bool Disposed;

        public Service(ILogger logger, ServiceMonitorDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                    DbContext.Dispose();
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
