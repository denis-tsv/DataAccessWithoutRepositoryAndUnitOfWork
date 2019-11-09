using Entities;
using MediatR;
using System.Collections.Generic;

namespace Handlers.Products.Queries.GetAvailableProducts
{
    public class GetAvailableProductsQuery : IRequest<IReadOnlyList<Product>>
    {
    }
}
