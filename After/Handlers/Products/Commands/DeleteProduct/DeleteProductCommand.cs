using MediatR;

namespace Handlers.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public int ProductId { get; set; }
    }
}
