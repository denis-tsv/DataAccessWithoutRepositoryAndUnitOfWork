using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.DataAccess.NoRepository
{
    public interface INoRepositoryUnitOfWork
    {
        public IQueryable<Product> Products { get; }

        public IQueryable<Category> Categories { get; }

        void Add<TEntity>(TEntity entity);

        void Remove<TEntity>(TEntity entity);

        Task<int> SaveChangesAsync();
    }
}
