using DataAccess.MsSql;
using Entities;
using Handlers.Products.Queries.GetAvailableProducts;
using Infrastructure.Interfaces.DataAccess;
using Infrastructure.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class NoRepositoryTests
    {
        class CurrentUserServiceServiceStub : ICurrentUserService
        {
            private readonly int? _userId;
            private readonly bool _isAuthentificated;

            public CurrentUserServiceServiceStub(int? userId, bool isAuthentificated)
            {
                _userId = userId;
                _isAuthentificated = isAuthentificated;
            }

            public int? UserId => _userId;

            public bool IsAuthenticated => _isAuthentificated;
        }

        [Fact]
        public async Task CreateInMemoryDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "in_memory_database")
                .Options;
            var currentUserService = new CurrentUserServiceServiceStub(1, true);
            IDbContext dbContext = new AppDbContext(options, currentUserService);
            //we have to create in memory database
            dbContext.Products.AddRange(new List<Product>
            {
                new Product { IsAvailable = true, Quantity = 10, Id = 1, Name = "Product1" },
                new Product { IsAvailable = true, Quantity = 1, Id = 2, Name = "Product2" },
            });
            await dbContext.SaveChangesAsync();
            var handler = new GetAvailableProductsQueryHandler(dbContext);

            // Act
            var products = await handler.Handle(new GetAvailableProductsQuery(), CancellationToken.None);

            // Assert
            Assert.All(products, x => 
            {
                    Assert.True(x.IsAvailable);
                    Assert.NotEqual(0, x.Quantity);
            });

        }
    }
}
