using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace ServiceMonitor.Core.DataLayer
{
    public abstract class Uow
    {
        protected Boolean Disposed;
        protected readonly ServiceMonitorDbContext DbContext;

        public Uow(ServiceMonitorDbContext dbContext)
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

        public IDbContextTransaction GetTransaction() => DbContext.Database.BeginTransaction();

        public Int32 CommitChanges() => DbContext.SaveChanges();

        public Task<Int32> CommitChangesAsync() => DbContext.SaveChangesAsync();
    }
}
