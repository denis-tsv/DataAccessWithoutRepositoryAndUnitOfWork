using Entities;
using Infrastructure.Interfaces.DataAccess.NoRepository;
using Infrastructure.Interfaces.QueryableHelpers;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Handlers.Categories.Queries.GetDigitalCategories
{
    public class GetDigitalCategoriesQueryHandler : IRequestHandler<GetDigitalCategoriesQuery, List<Category>>
    {
        private readonly INoRepositoryUnitOfWork _uow;
        private readonly IQueryableExecutor _queryableExecutor;

        public GetDigitalCategoriesQueryHandler(INoRepositoryUnitOfWork uow, IQueryableExecutor queryableExecutor)
        {
            _uow = uow;
            _queryableExecutor = queryableExecutor;
        }
        public Task<List<Category>> Handle(GetDigitalCategoriesQuery request, CancellationToken cancellationToken)
        {
            var query = _uow.Categories
                .Where(x => x.IsDigital);

            return _queryableExecutor.ToListAsync(query);
        }
    }
}
