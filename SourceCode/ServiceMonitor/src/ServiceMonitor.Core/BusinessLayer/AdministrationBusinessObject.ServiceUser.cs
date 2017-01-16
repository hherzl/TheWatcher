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
        public IEnumerable<ServiceUser> GetServiceUsers()
        {
            return AdministrationUow.ServiceUserRepository.GetAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ServiceUser GetServiceUser(ServiceUser entity)
        {
            return AdministrationUow.ServiceUserRepository.Get(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ServiceUser CreateServiceUser(ServiceUser entity)
        {
            AdministrationUow.ServiceUserRepository.Add(entity);

            AdministrationUow.CommitChanges();

            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ServiceUser UpdateServiceUser(Int32? id, ServiceUser value)
        {
            var entity = AdministrationUow.ServiceUserRepository.Get(new ServiceUser(id));

            if (entity != null)
            {
                AdministrationUow.ServiceUserRepository.Update(entity);

                AdministrationUow.CommitChanges();
            }

            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceUser DeleteServiceUser(Int32? id)
        {
            var entity = AdministrationUow.ServiceUserRepository.Get(new ServiceUser(id));

            if (entity != null)
            {
                AdministrationUow.ServiceUserRepository.Remove(entity);

                AdministrationUow.CommitChanges();
            }

            return entity;
        }
    }
}
