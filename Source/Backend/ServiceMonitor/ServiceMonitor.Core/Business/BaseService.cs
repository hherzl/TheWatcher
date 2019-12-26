using System;
using Microsoft.Extensions.Logging;
using ServiceMonitor.Core.Domain;

namespace ServiceMonitor.Core.Business
{
    public abstract class BaseService
    {
        protected readonly ILogger Logger;
        protected readonly ServiceMonitorDbContext DbContext;
        protected bool Disposed;

        protected BaseService(ILogger<BaseService> logger, ServiceMonitorDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        public virtual void Dispose()
        {
            if (Disposed)
                return;

            DbContext.Dispose();

            GC.SuppressFinalize(this);

            Disposed = true;
        }
    }
}
