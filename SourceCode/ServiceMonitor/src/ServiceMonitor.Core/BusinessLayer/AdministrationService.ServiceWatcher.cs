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
//        public IEnumerable<ServiceWatcher> GetServiceWatchers()
//        {
//            return AdministrationUow.ServiceWatcherRepository.GetAll();
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="entity"></param>
//        /// <returns></returns>
//        public ServiceWatcher GetServiceWatcher(ServiceWatcher entity)
//        {
//            return AdministrationUow.ServiceWatcherRepository.Get(entity);
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="entity"></param>
//        /// <returns></returns>
//        public ServiceWatcher CreateServiceWatcher(ServiceWatcher entity)
//        {
//            AdministrationUow.ServiceWatcherRepository.Add(entity);

//            AdministrationUow.CommitChanges();

//            return entity;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="id"></param>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public ServiceWatcher UpdateServiceWatcher(Int32? id, ServiceWatcher value)
//        {
//            var entity = AdministrationUow.ServiceWatcherRepository.Get(new ServiceWatcher(id));

//            if (entity != null)
//            {
//                AdministrationUow.ServiceWatcherRepository.Update(entity);

//                AdministrationUow.CommitChanges();
//            }

//            return entity;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public ServiceWatcher DeleteServiceWatcher(Int32? id)
//        {
//            var entity = AdministrationUow.ServiceWatcherRepository.Get(new ServiceWatcher(id));

//            if (entity != null)
//            {
//                AdministrationUow.ServiceWatcherRepository.Remove(entity);

//                AdministrationUow.CommitChanges();
//            }

//            return entity;
//        }
//    }
//}
