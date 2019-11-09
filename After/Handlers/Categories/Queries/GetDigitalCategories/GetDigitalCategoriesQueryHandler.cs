using Entities;
using Infrastructure.Interfaces.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Handlers.Categories.Queries.GetDigitalCategories
{
    public class GetDigitalCategoriesQueryHandler : IRequestHandler<GetDigitalCategoriesQuery, List<Category>>
    {
        private readonly IDbContext _dbContext;
        
        public GetDigitalCategoriesQueryHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;            
        }
        public Task<List<Category>> Handle(GetDigitalCategoriesQuery request, CancellationToken cancellationToken)
        {
            return _dbContext.Categories
                .AsNoTracking()
                .Where(x => x.IsDigital)
                .ToListAsync();            
        }
    }
}
