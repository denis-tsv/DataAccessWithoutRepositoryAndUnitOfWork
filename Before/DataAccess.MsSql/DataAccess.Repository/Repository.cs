using DataAccess.MsSql;
using Infrastructure.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MsSql.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        protected readonly AppDbContext DbContext;

        public Repository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual ValueTask<TEntity> GetAsync(int id)
        {
            return DbContext.FindAsync<TEntity>(id);
        }

        public virtual void Add(TEntity entity)
        {
            DbContext.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            DbContext.Update(entity);
        }
        
        public virtual void Remove(TEntity entity)
        {
            DbContext.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            DbContext.RemoveRange(entities);
        }
    }
}
