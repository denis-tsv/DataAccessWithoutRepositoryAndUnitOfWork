using MediatR;
using System.Collections.Generic;
using Entities;

namespace Handlers.Products.Queries.GetNewProducts
{
    public class GetNewProductsQuery : IRequest<List<Product>>
    {
    }
}
