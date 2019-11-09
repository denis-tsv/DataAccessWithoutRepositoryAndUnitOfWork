using MediatR;
using System.Collections.Generic;
using Entities;

namespace Handlers.Products.Queries.GetProductsByName
{
    public class GetProductsByNameQuery : IRequest<IReadOnlyList<Product>>
    {
        public string Name { get; set; }
    }
}
