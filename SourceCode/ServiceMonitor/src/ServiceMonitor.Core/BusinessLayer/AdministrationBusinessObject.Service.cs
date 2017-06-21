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
//        public IEnumerable<Service> GetServices()
//        {
//            return AdministrationUow.ServiceRepository.GetAll();
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public Service GetService(Int32 id)
//        {
//            return AdministrationUow.ServiceRepository.Get(new Service(id));
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="entity"></param>
//        /// <returns></returns>
//        public Service CreateService(Service entity)
//        {
//            AdministrationUow.ServiceRepository.Add(entity);

//            AdministrationUow.CommitChanges();

//            return entity;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="id"></param>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public Service UpdateService(Int32? id, Service value)
//        {
//            var entity = AdministrationUow.ServiceRepository.Get(new Service(id));

//            if (entity != null)
//            {
//                entity.Description = value.Description;

//                AdministrationUow.ServiceRepository.Update(entity);

//                AdministrationUow.CommitChanges();
//            }

//            return entity;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public Service DeleteService(Int32? id)
//        {
//            var entity = AdministrationUow.ServiceRepository.Get(new Service(id));

//            if (entity != null)
//            {
//                AdministrationUow.ServiceRepository.Remove(entity);

//                AdministrationUow.CommitChanges();
//            }

//            return entity;
//        }
//    }
//}
