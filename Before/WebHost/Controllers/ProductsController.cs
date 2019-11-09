using Entities;
using Handlers.Products.Commands.DeleteProduct;
using Handlers.Products.Commands.UpdateProduct;
using Handlers.Products.Queries.GetAvailableProducts;
using Handlers.Products.Queries.GetProductsByName;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace WebHost.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductsController : ControllerBase
    {
        private IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IReadOnlyList<Product>> GetAvailableProducts()
        {
            return await _mediator.Send(new GetAvailableProductsQuery());
        }

        [HttpGet]
        public async Task<IReadOnlyList<Product>> GetProductsByName(string name)
        {
            return await _mediator.Send(new GetProductsByNameQuery { Name = name });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public async Task<IActionResult> UpdateProduct(int id, [Required]ProductDto dto)
        {
            await _mediator.Send(new UpdateProductCommand 
            {
                ProductId = id,
                ProductDto = dto
            });

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _mediator.Send(new DeleteProductCommand { ProductId = id });

            return Ok();
        }
    }
}
