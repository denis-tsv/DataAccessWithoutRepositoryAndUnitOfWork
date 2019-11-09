using Entities;
using Infrastructure.Interfaces.DataAccess;
using Infrastructure.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.MsSql.DataAccess
{
    public class ProductRepository : AuditableRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext, ICurrentUserService currentUserService) : base(dbContext, currentUserService)
        {
        }

        private IQueryable<Product> GetAvailable()
        {
            return DbContext.Products
                .Where(x => x.IsAvailable && x.Quantity > 0);
        }

        public async Task<IReadOnlyList<Product>> GetAvailableProductsAsync()
        {
            DbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            return await GetAvailable().ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetProductsByNameAsync(string name)
        {
            DbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            return await GetAvailable()
                .Where(x => x.Name.Contains(name))
                .ToListAsync();
        }

        public Task<Product> GetWithCategoriesAsync(int id)
        {
            return DbContext.Products
                .Include(x => x.ProductCategories)
                .SingleAsync(x => x.Id == id);                
        }
    }
}
