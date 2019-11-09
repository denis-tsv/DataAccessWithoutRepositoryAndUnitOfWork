using Entities;
using Infrastructure.Interfaces.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Handlers.Products.Queries.GetAvailableProducts
{
    public class GetAvailableProductsQueryHandler : IRequestHandler<GetAvailableProductsQuery, List<Product>>
    {
        private readonly IDbContext _dbContext;

        public GetAvailableProductsQueryHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<Product>> Handle(GetAvailableProductsQuery request, CancellationToken cancellationToken)
        {
            return _dbContext.Products
                .Where(Product.AvailableSpec)
                .ToListAsync();
        }
    }
}
