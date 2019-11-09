using Infrastructure.Interfaces.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Handlers.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : AsyncRequestHandler<DeleteProductCommand>
    {
        private IRepositoryUnitOfWork _uow;
        public DeleteProductCommandHandler(IRepositoryUnitOfWork uow)
        {
            _uow = uow;
        }
        
        protected override async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _uow.ProductRepository.GetWithCategoriesAsync(request.ProductId);
            
            _uow.ProductCategoryRepository.RemoveRange(product.ProductCategories);
            _uow.ProductRepository.Remove(product);
            
            await _uow.SaveChangesAsync();
        }
    }
}
