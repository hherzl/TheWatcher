namespace ServiceMonitor.Core.DataLayer.Contracts
{
    public interface IDashboardUow : IUow
    {
        IServiceStatusRepository ServiceStatusRepository { get; }
        
        IServiceWatcherRepository ServiceWatcherRepository { get; }
        
        IUserRepository UserRepository { get; }
        
        IServiceUserRepository ServiceUserRepository { get; }
    }
}
