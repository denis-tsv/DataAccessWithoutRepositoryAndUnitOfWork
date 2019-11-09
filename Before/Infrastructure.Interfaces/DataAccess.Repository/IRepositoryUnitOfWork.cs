using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.DataAccess
{
    public interface IRepositoryUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IRepository<ProductCategory> ProductCategoryRepository { get; } 
        Task<int> SaveChangesAsync();
    }
}
