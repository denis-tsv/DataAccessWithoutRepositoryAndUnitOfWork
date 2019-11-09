using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Infrastructure.Interfaces.DataAccess
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetWithCategoriesAsync(int id);

        Task<IReadOnlyList<Product>> GetNewProductsAsync();

        Task<IReadOnlyList<Product>> GetAvailableProductsAsync();
    }
}
