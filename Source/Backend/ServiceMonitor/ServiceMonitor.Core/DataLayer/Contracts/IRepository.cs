using System.Threading.Tasks;

namespace ServiceMonitor.Core.DataLayer.Contracts
{
    public interface IRepository
    {
        void Add<TEntity>(TEntity entity) where TEntity : class, new();

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
