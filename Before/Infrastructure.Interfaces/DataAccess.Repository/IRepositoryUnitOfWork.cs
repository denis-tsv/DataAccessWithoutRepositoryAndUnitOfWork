using Entities;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.DataAccess
{
    public interface IRepositoryUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IRepository<ProductCategory> ProductCategoryRepository { get; } 
        Task<int> SaveChangesAsync();

        //IQueryable<Product> Products { get; } // anti-pattern
    }
}
