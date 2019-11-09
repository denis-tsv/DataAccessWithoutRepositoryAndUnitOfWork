using Entities;
using Infrastructure.Interfaces.DataAccess;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Handlers.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : AsyncRequestHandler<UpdateProductCommand>
    {
        private readonly IRepositoryUnitOfWork _uow;
        public UpdateProductCommandHandler(IRepositoryUnitOfWork uow)
        {
            _uow = uow;
        }

        protected override async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _uow.ProductRepository.GetWithCategoriesAsync(request.ProductId);

            product.Name = request.ProductDto.Name; //TODO AutoMapper
            
            var newCategoryIds = request.ProductDto.CategoryIds;
            var currentCategoryIds = product.ProductCategories.Select(x => x.CategoryId).ToList();

            //delete not existing in DTO categories
            foreach (var category in product.ProductCategories
                .Where(x => !newCategoryIds.Contains(x.CategoryId)))
            {
                product.ProductCategories.Remove(category);                
            }
            
            //new categories
            foreach (var categoryId in newCategoryIds.Except(currentCategoryIds))
            {
                product.ProductCategories.Add(new ProductCategory 
                        { 
                            CategoryId = categoryId, 
                            ProductId = product.Id 
                        });
            }

            _uow.ProductRepository.Update(product); // update ModifiedAt and ModifiedBy properties
            
            await _uow.SaveChangesAsync();
        }
    }
}
