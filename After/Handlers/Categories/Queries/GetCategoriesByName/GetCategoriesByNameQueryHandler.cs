using Entities;
using Infrastructure.Interfaces.DataAccess.NoRepository;
using Infrastructure.Interfaces.QueryableHelpers;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Handlers.Categories.Queries.GetCategoriesByName
{
    public class GetCategoriesByNameQueryHandler : IRequestHandler<GetCategoriesByNameQuery, List<Category>>
    {
        private readonly INoRepositoryUnitOfWork _uow;

        public GetCategoriesByNameQueryHandler(INoRepositoryUnitOfWork uow)
        {
            _uow = uow;
        }
        public Task<List<Category>> Handle(GetCategoriesByNameQuery request, CancellationToken cancellationToken)
        {
            return _uow.Categories
                .Where(x => x.Name.Contains(request.CategoryName))
                .ToListAsync(); // QueryableHelper
        }
    }
}
