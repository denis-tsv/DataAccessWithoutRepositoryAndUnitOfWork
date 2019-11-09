using Entities;
using Infrastructure.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MsSql.DataAccess
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
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

        public async Task<IReadOnlyList<Product>> GetNewProductsAsync()
        {
            DbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            return await GetAvailable()
                .Where(x => (DateTime.Now - x.CreatedAt).TotalDays < 30)
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
