using System.Threading.Tasks;

namespace ServiceMonitor.Core.DataLayer.Contracts
{
    public interface IRepository
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
