using Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Interfaces.DataAccess
{
    public interface IDbContext
    {
        DbSet<Product> Products { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<ProductCategory> ProductCategories { get; set; }        

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry<TEntity> Entry<TEntity>(TEntity result) where TEntity : class;
    }
}
