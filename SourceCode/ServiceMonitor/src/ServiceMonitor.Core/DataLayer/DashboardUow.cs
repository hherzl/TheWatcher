using ServiceMonitor.Core.DataLayer.Contracts;
using ServiceMonitor.Core.DataLayer.Repositories;

namespace ServiceMonitor.Core.DataLayer
{
    public class DashboardUow : Uow, IDashboardUow
    {
        private IServiceStatusRepository m_serviceStatusRepository;
        private IServiceWatcherRepository m_serviceWatcherRepository;
        private IUserRepository m_userRepository;
        private IServiceUserRepository m_serviceUserRepository;

        public DashboardUow(ServiceMonitorDbContext dbContext)
            : base(dbContext)
        {
        }

        public IServiceStatusRepository ServiceStatusRepository
        {
            get
            {
                return m_serviceStatusRepository ?? (m_serviceStatusRepository = new ServiceStatusRepository(DbContext));
            }
        }

        public IServiceWatcherRepository ServiceWatcherRepository
        {
            get
            {
                return m_serviceWatcherRepository ?? (m_serviceWatcherRepository = new ServiceWatcherRepository(DbContext));
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
