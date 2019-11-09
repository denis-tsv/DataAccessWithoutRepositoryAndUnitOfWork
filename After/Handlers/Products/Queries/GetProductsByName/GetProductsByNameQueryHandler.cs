using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Entities;
using Infrastructure.Interfaces.DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Handlers.Products.Queries.GetProductsByName
{
    public class GetProductsByNameQueryHandler : IRequestHandler<GetProductsByNameQuery, List<Product>>
    {
        private readonly IDbContext _dbContext;

        public GetProductsByNameQueryHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<Product>> Handle(GetProductsByNameQuery request, CancellationToken cancellationToken)
        {
            return _dbContext.Products
                .Where(Product.AvailableSpec && Product.ByNameSpec(request.Name))
                .ToListAsync();
        }
    }
}
