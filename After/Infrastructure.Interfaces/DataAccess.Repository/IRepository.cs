using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.DataAccess
{
    public interface IRepository<TEntity>
    {
        ValueTask<TEntity> GetAsync(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
