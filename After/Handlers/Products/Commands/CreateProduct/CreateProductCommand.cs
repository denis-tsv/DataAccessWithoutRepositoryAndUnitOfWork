using Handlers.Products.Commands.Dto;
using Handlers.SaveChangesPostProcessor;
using MediatR;

namespace Handlers.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest, IChangeDataRequest
    {
        public ProductDto ProductDto { get; set; }
    }
}
