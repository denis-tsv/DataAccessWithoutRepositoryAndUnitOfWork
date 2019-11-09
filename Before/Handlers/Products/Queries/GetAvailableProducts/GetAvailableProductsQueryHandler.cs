using Entities;
using Infrastructure.Interfaces.DataAccess;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Handlers.Products.Queries.GetAvailableProducts
{
    public class GetAvailableProductsQueryHandler : IRequestHandler<GetAvailableProductsQuery, IReadOnlyList<Product>>
    {
        private readonly IRepositoryUnitOfWork _uow;

        public GetAvailableProductsQueryHandler(IRepositoryUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<IReadOnlyList<Product>> Handle(GetAvailableProductsQuery request, CancellationToken cancellationToken)
        {
            return await _uow.ProductRepository.GetAvailableProductsAsync();
        }
    }
}
