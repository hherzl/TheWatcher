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
//        public IEnumerable<Owner> GetOwners()
//        {
//            return AdministrationUow.OwnerRepository.GetAll();
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public Owner GetOwner(Int32 id)
//        {
//            return AdministrationUow.OwnerRepository.Get(new Owner(id));
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="entity"></param>
//        /// <returns></returns>
//        public Owner CreateOwner(Owner entity)
//        {
//            AdministrationUow.OwnerRepository.Add(entity);

//            AdministrationUow.CommitChanges();

//            return entity;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="id"></param>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public Owner UpdateOwner(Int32? id, Owner value)
//        {
//            var entity = AdministrationUow.OwnerRepository.Get(new Owner(id));

//            if (entity != null)
//            {
//                AdministrationUow.OwnerRepository.Update(entity);

//                AdministrationUow.CommitChanges();
//            }

//            return entity;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public Owner DeleteOwner(Int32? id)
//        {
//            var entity = AdministrationUow.OwnerRepository.Get(new Owner(id));

//            if (entity != null)
//            {
//                AdministrationUow.OwnerRepository.Remove(entity);

//                AdministrationUow.CommitChanges();
//            }

//            return entity;
//        }
//    }
//}
