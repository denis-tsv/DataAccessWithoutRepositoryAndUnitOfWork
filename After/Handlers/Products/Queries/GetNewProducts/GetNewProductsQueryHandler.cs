using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Entities;
using Infrastructure.Interfaces.DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Handlers.Products.Queries.GetNewProducts
{
    public class GetNewProductsQueryHandler : IRequestHandler<GetNewProductsQuery, List<Product>>
    {
        private readonly IDbContext _dbContext;

        public GetNewProductsQueryHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<Product>> Handle(GetNewProductsQuery request, CancellationToken cancellationToken)
        {
            return _dbContext.Products
                .Where(Product.AvailableProductSpec && Product.NewProductSpec)
                .ToListAsync();
        }
    }
}
