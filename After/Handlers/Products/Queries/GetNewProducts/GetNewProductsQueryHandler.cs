using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Entities;
using Infrastructure.Interfaces.DataAccess;

namespace Handlers.Products.Queries.GetNewProducts
{
    public class GetNewProductsQueryHandler : IRequestHandler<GetNewProductsQuery, IReadOnlyList<Product>>
    {
        private readonly IRepositoryUnitOfWork _uow;

        public GetNewProductsQueryHandler(IRepositoryUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<IReadOnlyList<Product>> Handle(GetNewProductsQuery request, CancellationToken cancellationToken)
        {
            return await _uow.ProductRepository.GetNewProductsAsync();
        }
    }
}
