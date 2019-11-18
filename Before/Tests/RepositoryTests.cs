using Entities;
using Infrastructure.Interfaces.DataAccess;
using Infrastructure.Interfaces.QueryableHelpers;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class RepositoryTests
    {
        static RepositoryTests()
        {
            QueryableHelper.QueryableExecutor = new InMemoryQueryableExecutor();
        }

        [Fact]
        public async Task MockOfRepositoryMethod()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();
            IReadOnlyList<Product> products = new List<Product>()
                {
                    new Product { IsAvailable = true, Quantity = 10, Id = 1, Name = "Product1" },
                    new Product { IsAvailable = true, Quantity = 1, Id = 2, Name = "Product2" },
                };
            //it is possible to mock any method of repository or unit of work
            mockRepository.Setup(x => x.GetAvailableProductsAsync())
                .Returns(Task.FromResult(products));

            // Act
            var res = await mockRepository.Object.GetAvailableProductsAsync();

            // Assert
            Assert.All(res, x => Assert.True(x.IsAvailable));
            Assert.All(res, x => Assert.NotEqual(0, x.Quantity));
        }

    }
}
