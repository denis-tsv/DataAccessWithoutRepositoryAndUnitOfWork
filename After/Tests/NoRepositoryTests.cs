using DataAccess.MsSql;
using Entities;
using Infrastructure.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class NoRepositoryTests
    {
        [Fact]
        public async Task CreateInMemoryDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContextPostProcessor>()
                .UseInMemoryDatabase(databaseName: "in_memory_database")
                .Options;
            IDbContextPostProcessor dbContext = new AppDbContextPostProcessor(options);
            //we have to create in memory database
            dbContext.Products.AddRange(new List<Product> 
            {
                new Product { IsAvailable = true, Quantity = 10, Id = 1, Name = "Product1" },
                new Product { IsAvailable = true, Quantity = 1, Id = 2, Name = "Product2" },
            });
            await dbContext.SaveChangesAsync();

            // Act
            var products = await dbContext.Products.Where(Product.AvailableSpec).ToListAsync();

            // Assert
            Assert.All(products, x => Assert.True(x.IsAvailable));
            Assert.All(products, x => Assert.NotEqual(0, x.Quantity));
        }
    }
}
