using Entities;
using Infrastructure.Interfaces.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Handlers.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : AsyncRequestHandler<DeleteProductCommand>
    {
        private IDbContext _dbContext;
        public DeleteProductCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        protected override async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            _dbContext.Products.Remove(new Product { Id = request.ProductId });
            
            //cascade delete for product categories

            await _dbContext.SaveChangesAsync();
        }
    }
}
