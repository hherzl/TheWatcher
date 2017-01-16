namespace ServiceMonitor.Core.DataLayer.Contracts
{
    public interface IAdministrationUow : IUow
    {
        IServiceCategoryRepository ServiceCategoryRepository { get; }
        
        IServiceRepository ServiceRepository { get; }
        
        IServiceWatcherRepository ServiceWatcherRepository { get; }
        
        IServiceStatusLogRepository ServiceStatusLogRepository { get; }
        
        IServiceStatusRepository ServiceStatusRepository { get; }
        
        IOwnerRepository OwnerRepository { get; }
        
        IServiceOwnerRepository ServiceOwnerRepository { get; }
        
        IUserRepository UserRepository { get; }
        
        IServiceUserRepository ServiceUserRepository { get; }
    }
}
