using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace ServiceMonitor.Core.DataLayer.Contracts
{
    public interface IUow : IDisposable
    {
        IDbContextTransaction GetTransaction();

        Int32 CommitChanges();

        Task<Int32> CommitChangesAsync();
    }
}
