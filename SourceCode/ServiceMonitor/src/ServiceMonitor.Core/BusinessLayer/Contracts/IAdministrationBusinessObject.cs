using System;
using System.Collections.Generic;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.BusinessLayer.Contracts
{
    public interface IAdministrationBusinessObject : IBusinessObject
    {
        IEnumerable<ServiceCategory> GetServiceCategories();

        ServiceCategory GetServiceCategory(ServiceCategory entity);

        ServiceCategory CreateServiceCategory(ServiceCategory entity);

        ServiceCategory UpdateServiceCategory(Int32? id, ServiceCategory entity);

        ServiceCategory DeleteServiceCategory(Int32? id);

        IEnumerable<Service> GetServices();

        Service GetService(Int32 id);

        Service CreateService(Service entity);

        Service UpdateService(Int32? id, Service entity);

        Service DeleteService(Int32? id);

        IEnumerable<ServiceWatcher> GetServiceWatchers();

        ServiceWatcher GetServiceWatcher(ServiceWatcher entity);

        ServiceWatcher CreateServiceWatcher(ServiceWatcher entity);

        ServiceWatcher UpdateServiceWatcher(Int32? id, ServiceWatcher entity);

        ServiceWatcher DeleteServiceWatcher(Int32? id);

        IEnumerable<ServiceStatus> GetServiceStatuses();

        ServiceStatus GetServiceStatus(ServiceStatus entity);

        ServiceStatus CreateServiceStatus(ServiceStatus entity);

        ServiceStatus UpdateServiceStatus(Int32? id, ServiceStatus entity);

        ServiceStatus DeleteServiceStatus(Int32? id);

        IEnumerable<ServiceStatusLog> GetServiceStatusLogs();

        ServiceStatusLog GetServiceStatusLog(ServiceStatusLog entity);

        ServiceStatusLog CreateServiceStatusLog(ServiceStatusLog entity);

        ServiceStatusLog UpdateServiceStatusLog(Int32? id, ServiceStatusLog entity);

        ServiceStatusLog DeleteServiceStatusLog(Int32? id);

        IEnumerable<Owner> GetOwners();

        Owner GetOwner(Int32 id);

        Owner CreateOwner(Owner entity);

        Owner UpdateOwner(Int32? id, Owner entity);

        Owner DeleteOwner(Int32? id);

        IEnumerable<ServiceOwner> GetServiceOwners();

        ServiceOwner GetServiceOwner(Int32 id);

        ServiceOwner CreateServiceOwner(ServiceOwner entity);

        ServiceOwner UpdateServiceOwner(Int32? id, ServiceOwner entity);

        ServiceOwner DeleteServiceOwner(Int32? id);

        IEnumerable<User> GetUsers();

        User GetUser(Int32 id);

        User CreateUser(User entity);

        User UpdateUser(Int32? id, User entity);

        User DeleteUser(Int32? id);

        IEnumerable<ServiceUser> GetServiceUsers();

        ServiceUser GetServiceUser(ServiceUser entity);

        ServiceUser CreateServiceUser(ServiceUser entity);

        ServiceUser UpdateServiceUser(Int32? id, ServiceUser entity);

        ServiceUser DeleteServiceUser(Int32? id);
    }
}
