using AutoMapper;
using Infrastructure.Interfaces.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Handlers.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : AsyncRequestHandler<UpdateProductCommand>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        protected override async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            //var product = await _dbContext.Products
            //    .Include(x => x.ProductCategories)
            //    .SingleOrDefaultAsync(x => x.Id == request.ProductId);

            //var product = await _dbContext.Products.SingleOrDefaultFullAsync(request.ProductId);

            var product = await _dbContext.FindFullProductAsync(request.ProductId);

            _mapper.Map(request.ProductDto, product);

            //method Product.UpdateCategories may be used in many handlers if needed
            product.UpdateCategories(request.ProductDto.CategoryIds);

            // update ModifiedAt and ModifiedBy in overriden SaveChanges method
            await _dbContext.SaveChangesAsync();
        }
    }
}
