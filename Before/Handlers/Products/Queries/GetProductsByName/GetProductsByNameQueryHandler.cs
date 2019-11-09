using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Entities;
using Infrastructure.Interfaces.DataAccess;

namespace Handlers.Products.Queries.GetProductsByName
{
    public class GetProductsByNameQueryHandler : IRequestHandler<GetProductsByNameQuery, IReadOnlyList<Product>>
    {
        private readonly IRepositoryUnitOfWork _uow;

        public GetProductsByNameQueryHandler(IRepositoryUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<IReadOnlyList<Product>> Handle(GetProductsByNameQuery request, CancellationToken cancellationToken)
        {
            return await _uow.ProductRepository.GetProductsByNameAsync(request.Name);
        }
    }
}
