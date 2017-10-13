//using System;
//using System.Collections.Generic;
//using System.Linq;
//using ServiceMonitor.Core.BusinessLayer.Contracts;
//using ServiceMonitor.Core.EntityLayer;

//namespace ServiceMonitor.Core.BusinessLayer
//{
//    public partial class AdministrationBusinessObject : IAdministrationBusinessObject
//    {
//        public IEnumerable<ServiceCategory> GetServiceCategories()
//        {
//            return AdministrationUow.ServiceCategoryRepository.GetAll();
//        }

//        public ServiceCategory GetServiceCategory(ServiceCategory entity)
//        {
//            return AdministrationUow.ServiceCategoryRepository.Get(entity);
//        }

//        public ServiceCategory CreateServiceCategory(ServiceCategory entity)
//        {
//            AdministrationUow.ServiceCategoryRepository.Add(entity);

//            AdministrationUow.CommitChangesAsync();

//            return entity;
//        }

//        public ServiceCategory UpdateServiceCategory(Int32? id, ServiceCategory value)
//        {
//            var entity = AdministrationUow.ServiceCategoryRepository.Get(new ServiceCategory(id));

//            if (entity != null)
//            {
//                entity.Description = value.Description;

//                AdministrationUow.ServiceCategoryRepository.Update(entity);

//                AdministrationUow.CommitChanges();
//            }

//            return entity;
//        }

//        public ServiceCategory DeleteServiceCategory(Int32? id)
//        {
//            var entity = AdministrationUow.ServiceCategoryRepository.Get(new ServiceCategory(id));

//            if (entity != null)
//            {
//                if (AdministrationUow.ServiceRepository.GetByServiceCategoryID(entity.ServiceCategoryID).Count() > 0)
//                {
//                    throw new ForeignKeyDependencyException(String.Format("Unable to delete service category with id: '{0}', because has services associated.", entity.ServiceCategoryID));
//                }

//                AdministrationUow.ServiceCategoryRepository.Remove(entity);

//                AdministrationUow.CommitChanges();
//            }

//            return entity;
//        }
//    }
//}
