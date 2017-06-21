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
//        public IEnumerable<User> GetUsers()
//        {
//            return AdministrationUow.UserRepository.GetAll();
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public User GetUser(Int32 id)
//        {
//            return AdministrationUow.UserRepository.Get(new User(id));
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="entity"></param>
//        /// <returns></returns>
//        public User CreateUser(User entity)
//        {
//            AdministrationUow.UserRepository.Add(entity);

//            AdministrationUow.CommitChanges();

//            return entity;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="id"></param>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public User UpdateUser(Int32? id, User value)
//        {
//            var entity = AdministrationUow.UserRepository.Get(new User(id));

//            if (entity != null)
//            {
//                AdministrationUow.UserRepository.Update(entity);

//                AdministrationUow.CommitChanges();
//            }

//            return entity;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public User DeleteUser(Int32? id)
//        {
//            var entity = AdministrationUow.UserRepository.Get(new User(id));

//            if (entity != null)
//            {
//                AdministrationUow.UserRepository.Remove(entity);

//                AdministrationUow.CommitChanges();
//            }

//            return entity;
//        }
//    }
//}
