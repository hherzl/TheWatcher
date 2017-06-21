//using System;
//using System.Collections.Generic;
//using ServiceMonitor.Core.BusinessLayer.Contracts;
//using ServiceMonitor.Core.EntityLayer;

//namespace ServiceMonitor.Core.BusinessLayer
//{
//    public partial class AdministrationBusinessObject : IAdministrationBusinessObject
//    {
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        public IEnumerable<ServiceOwner> GetServiceOwners()
//        {
//            return AdministrationUow.ServiceOwnerRepository.GetAll();
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public ServiceOwner GetServiceOwner(Int32 id)
//        {
//            return AdministrationUow.ServiceOwnerRepository.Get(new ServiceOwner(id));
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="entity"></param>
//        /// <returns></returns>
//        public ServiceOwner CreateServiceOwner(ServiceOwner entity)
//        {
//            AdministrationUow.ServiceOwnerRepository.Add(entity);

//            AdministrationUow.CommitChanges();

//            return entity;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="id"></param>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public ServiceOwner UpdateServiceOwner(Int32? id, ServiceOwner value)
//        {
//            var entity = AdministrationUow.ServiceOwnerRepository.Get(new ServiceOwner(id));

//            if (entity != null)
//            {
//                AdministrationUow.ServiceOwnerRepository.Update(entity);

//                AdministrationUow.CommitChanges();
//            }

//            return entity;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public ServiceOwner DeleteServiceOwner(Int32? id)
//        {
//            var entity = AdministrationUow.ServiceOwnerRepository.Get(new ServiceOwner(id));

//            if (entity != null)
//            {
//                AdministrationUow.ServiceOwnerRepository.Remove(entity);

//                AdministrationUow.CommitChanges();
//            }

//            return entity;
//        }
//    }
//}
