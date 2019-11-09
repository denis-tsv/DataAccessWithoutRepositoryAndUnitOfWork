using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Infrastructure.Interfaces.DataAccess
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetWithCategoriesAsync(int id);

        Task<IReadOnlyList<Product>> GetProductsByNameAsync(string name);

        Task<IReadOnlyList<Product>> GetAvailableProductsAsync();

        //IQueryable<Product> Products { get; } // anti-pattern
        //IQueryable<Product> AvailableProducts { get; } // anti-pattern
    }
}
