using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.DataLayer.Contracts;

namespace ServiceMonitor.Core.DataLayer.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected ServiceMonitorDbContext DbContext;
        protected DbSet<TEntity> DbSet;

        public Repository(ServiceMonitorDbContext dbContext)
        {
            DbContext = dbContext;

            DbSet = DbContext.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual TEntity Get(TEntity entity)
        {
            throw new NotImplementedException(String.Format("There is not implementation for '{0}' method in '{1}' class", "Get", typeof(Repository<TEntity>).FullName));
        }

        public virtual void Add(TEntity entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public virtual void Update(TEntity entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Remove(TEntity entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);

            if (dbEntityEntry.State == EntityState.Deleted)
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
            else
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
        }
    }
}
