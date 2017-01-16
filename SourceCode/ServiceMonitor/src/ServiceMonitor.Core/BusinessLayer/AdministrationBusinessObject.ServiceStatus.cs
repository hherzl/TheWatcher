using System;
using System.Collections.Generic;
using ServiceMonitor.Core.BusinessLayer.Contracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.BusinessLayer
{
    public partial class AdministrationBusinessObject : IAdministrationBusinessObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ServiceStatus> GetServiceStatuses()
        {
            return AdministrationUow.ServiceStatusRepository.GetAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ServiceStatus GetServiceStatus(ServiceStatus entity)
        {
            return AdministrationUow.ServiceStatusRepository.Get(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ServiceStatus CreateServiceStatus(ServiceStatus entity)
        {
            AdministrationUow.ServiceStatusRepository.Add(entity);

            AdministrationUow.CommitChanges();

            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ServiceStatus UpdateServiceStatus(Int32? id, ServiceStatus value)
        {
            var entity = AdministrationUow.ServiceStatusRepository.Get(new ServiceStatus(id));

            if (entity != null)
            {
                AdministrationUow.ServiceStatusRepository.Update(entity);

                AdministrationUow.CommitChanges();
            }

            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceStatus DeleteServiceStatus(Int32? id)
        {
            var entity = AdministrationUow.ServiceStatusRepository.Get(new ServiceStatus(id));

            if (entity != null)
            {
                AdministrationUow.ServiceStatusRepository.Remove(entity);

                AdministrationUow.CommitChanges();
            }

            return entity;
        }
    }
}
