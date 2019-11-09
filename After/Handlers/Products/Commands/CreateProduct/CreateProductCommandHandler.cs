using AutoMapper;
using Entities;
using Infrastructure.Interfaces.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Handlers.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : AsyncRequestHandler<CreateProductCommand>
    {
        private readonly IDbContextPostProcessor _dbContext;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IDbContextPostProcessor dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.ProductDto);

            product.UpdateCategories(request.ProductDto.CategoryIds);

            _dbContext.Products.Add(product);

            //CreatedAt abd CreatedBy properties initialized in PostProcessor

            //No _dbContext.SaveChanges(), it called in PostProcessor
        }
    }
}
