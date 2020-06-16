using Entities;
using Infrastructure.Interfaces.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.CommonTools;

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
                .AsVisitable(new EfFunctionsExpander())
                .AsNoTracking()
                .Where(x => EfFunctions.Like(x.Name, "%1"))
                //.Where(x => EF.Functions.Like(x.Name, "%1"))
                .ToListAsync();
        }
    }
}
