using System;
using Microsoft.Extensions.Logging;
using ServiceMonitor.Core.DomainDrivenDesign;

namespace ServiceMonitor.Core.BusinessLayer
{
    public abstract class BaseService
    {
        protected ILogger Logger;
        protected readonly ServiceMonitorDbContext DbContext;
        protected bool Disposed;

        public BaseService(ILogger logger, ServiceMonitorDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        public void Dispose()
        {
            if (Disposed)
                return;

            DbContext.Dispose();

            GC.SuppressFinalize(this);

            Disposed = true;
        }
    }
}
