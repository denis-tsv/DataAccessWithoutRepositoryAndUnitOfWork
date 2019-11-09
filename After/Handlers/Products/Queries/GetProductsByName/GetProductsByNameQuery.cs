using MediatR;
using System.Collections.Generic;
using Entities;
using Handlers.SaveChangesPostProcessor;

namespace Handlers.Products.Queries.GetProductsByName
{
    public class GetProductsByNameQuery : IRequest<List<Product>>
    {
        public string Name { get; set; }
    }
}
