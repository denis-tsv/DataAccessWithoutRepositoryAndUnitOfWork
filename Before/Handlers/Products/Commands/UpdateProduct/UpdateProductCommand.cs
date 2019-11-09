using MediatR;

namespace Handlers.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public int ProductId { get; set; }
        public ProductDto ProductDto { get; set; }
    }
}
