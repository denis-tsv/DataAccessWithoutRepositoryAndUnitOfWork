using Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.DataAccess
{
    public interface IDbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }        

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
