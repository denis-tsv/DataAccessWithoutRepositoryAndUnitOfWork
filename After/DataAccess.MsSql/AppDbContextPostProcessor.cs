using Microsoft.EntityFrameworkCore;
using Infrastructure.Interfaces.DataAccess;
using Entities;

namespace DataAccess.MsSql
{

    public class AppDbContextPostProcessor : DbContext, IDbContextPostProcessor
    {
        public AppDbContextPostProcessor(DbContextOptions<AppDbContextPostProcessor> options)
            : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
			
            builder.Entity<ProductCategory>()
                .HasKey(x => new { x.ProductId, x.CategoryId });
        }
    }
}
