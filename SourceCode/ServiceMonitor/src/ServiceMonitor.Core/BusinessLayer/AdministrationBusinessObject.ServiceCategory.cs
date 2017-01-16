using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<ServiceCategory> GetServiceCategories()
        {
            return AdministrationUow.ServiceCategoryRepository.GetAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ServiceCategory GetServiceCategory(ServiceCategory entity)
        {
            return AdministrationUow.ServiceCategoryRepository.Get(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ServiceCategory CreateServiceCategory(ServiceCategory entity)
        {
            AdministrationUow.ServiceCategoryRepository.Add(entity);

            AdministrationUow.CommitChangesAsync();

            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ServiceCategory UpdateServiceCategory(Int32? id, ServiceCategory value)
        {
            var entity = AdministrationUow.ServiceCategoryRepository.Get(new ServiceCategory(id));

            if (entity != null)
            {
                entity.Description = value.Description;

                AdministrationUow.ServiceCategoryRepository.Update(entity);

                AdministrationUow.CommitChanges();
            }

            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceCategory DeleteServiceCategory(Int32? id)
        {
            var entity = AdministrationUow.ServiceCategoryRepository.Get(new ServiceCategory(id));

            if (entity != null)
            {
                if (AdministrationUow.ServiceRepository.GetByServiceCategoryID(entity.ServiceCategoryID).Count() > 0)
                {
                    throw new ForeignKeyDependencyException(String.Format("Unable to delete service category with id: '{0}', because has services associated.", entity.ServiceCategoryID));
                }

                AdministrationUow.ServiceCategoryRepository.Remove(entity);

                AdministrationUow.CommitChanges();
            }

            return entity;
        }
    }
}
