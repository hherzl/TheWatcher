using ServiceMonitor.Core.DataLayer.Contracts;
using ServiceMonitor.Core.DataLayer.Repositories;

namespace ServiceMonitor.Core.DataLayer
{
    public class AdministrationUow : Uow, IAdministrationUow
    {
        private IServiceCategoryRepository m_serviceCategoryRepository;
        private IServiceRepository m_serviceRepository;
        private IServiceWatcherRepository m_serviceWatcherRepository;
        private IServiceStatusLogRepository m_serviceStatusLogRepository;
        private IServiceStatusRepository m_serviceStatusRepository;
        private IOwnerRepository m_ownerRepository;
        private IServiceOwnerRepository m_serviceOwnerRepository;
        private IUserRepository m_userRepository;
        private IServiceUserRepository m_serviceUserRepository;
        
        public AdministrationUow(ServiceMonitorDbContext dbContext)
            : base(dbContext)
        {
        }
        
        public IServiceCategoryRepository ServiceCategoryRepository
        {
            get
            {
                return m_serviceCategoryRepository ?? (m_serviceCategoryRepository = new ServiceCategoryRepository(DbContext));
            }
        }
        
        public IServiceRepository ServiceRepository
        {
            get
            {
                return m_serviceRepository ?? (m_serviceRepository = new ServiceRepository(DbContext));
            }
        }
        
        public IServiceWatcherRepository ServiceWatcherRepository
        {
            get
            {
                return m_serviceWatcherRepository ?? (m_serviceWatcherRepository = new ServiceWatcherRepository(DbContext));
            }
        }

        public IServiceStatusLogRepository ServiceStatusLogRepository
        {
            get
            {
                return m_serviceStatusLogRepository ?? (m_serviceStatusLogRepository = new ServiceStatusLogRepository(DbContext));
            }
        }
        
        public IServiceStatusRepository ServiceStatusRepository
        {
            get
            {
                return m_serviceStatusRepository ?? (m_serviceStatusRepository = new ServiceStatusRepository(DbContext));
            }
        }
        
        public IOwnerRepository OwnerRepository
        {
            get
            {
                return m_ownerRepository ?? (m_ownerRepository = new OwnerRepository(DbContext));
            }
        }
        
        public IServiceOwnerRepository ServiceOwnerRepository
        {
            get
            {
                return m_serviceOwnerRepository ?? (m_serviceOwnerRepository = new ServiceOwnerRepository(DbContext));
            }
        }
        
        public IUserRepository UserRepository
        {
            get
            {
                return m_userRepository ?? (m_userRepository = new UserRepository(DbContext));
            }
        }
        
        public IServiceUserRepository ServiceUserRepository
        {
            get
            {
                return m_serviceUserRepository ?? (m_serviceUserRepository = new ServiceUserRepository(DbContext));
            }
        }
    }
}
