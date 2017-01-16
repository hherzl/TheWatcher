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
        public IEnumerable<ServiceStatusLog> GetServiceStatusLogs()
        {
            return AdministrationUow.ServiceStatusLogRepository.GetAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ServiceStatusLog GetServiceStatusLog(ServiceStatusLog entity)
        {
            return AdministrationUow.ServiceStatusLogRepository.Get(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ServiceStatusLog CreateServiceStatusLog(ServiceStatusLog entity)
        {
            using (var transaction = AdministrationUow.GetTransaction())
            {
                try
                {
                    AdministrationUow.ServiceStatusLogRepository.Add(entity);

                    var serviceStatus = AdministrationUow.ServiceStatusRepository.GetByService(entity.ServiceID);

                    if (serviceStatus == null)
                    {
                        serviceStatus = new ServiceStatus();

                        serviceStatus.ServiceID = entity.ServiceID;
                        serviceStatus.Success = entity.Success;
                        serviceStatus.WatchCount = 1;
                        serviceStatus.LastWatch = DateTime.Now;

                        AdministrationUow.ServiceStatusRepository.Add(serviceStatus);
                    }
                    else
                    {
                        serviceStatus.Success = entity.Success;
                        serviceStatus.WatchCount += 1;
                        serviceStatus.LastWatch = DateTime.Now;
                    }

                    AdministrationUow.CommitChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    throw ex;
                }

                return entity;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ServiceStatusLog UpdateServiceStatusLog(Int32? id, ServiceStatusLog value)
        {
            var entity = AdministrationUow.ServiceStatusLogRepository.Get(new ServiceStatusLog(id));

            if (entity != null)
            {
                AdministrationUow.ServiceStatusLogRepository.Update(entity);

                AdministrationUow.CommitChanges();
            }

            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceStatusLog DeleteServiceStatusLog(Int32? id)
        {
            var entity = AdministrationUow.ServiceStatusLogRepository.Get(new ServiceStatusLog(id));

            if (entity != null)
            {
                AdministrationUow.ServiceStatusLogRepository.Remove(entity);

                AdministrationUow.CommitChanges();
            }

            return entity;
        }
    }
}
