using Entities;
using Infrastructure.Interfaces.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Handlers.Categories.Queries.GetCategoriesByName
{
    public class GetCategoriesByNameQueryHandler : IRequestHandler<GetCategoriesByNameQuery, List<Category>>
    {
        private readonly IDbContext _dbContext;

        public GetCategoriesByNameQueryHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<Category>> Handle(GetCategoriesByNameQuery request, CancellationToken cancellationToken)
        {
            return _dbContext.Categories
                .AsNoTracking()
                .Where(x => x.Name.Contains(request.CategoryName))
                .ToListAsync(); // EF Core
        }
    }
}
