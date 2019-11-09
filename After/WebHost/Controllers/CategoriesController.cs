using Entities;
using Handlers.Categories.Queries.GetCategoriesByName;
using Handlers.Categories.Queries.GetDigitalCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebHost.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoriesController : ControllerBase
    {
        private IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Category>> GetDigitalCategories()
        {
            return await _mediator.Send(new GetDigitalCategoriesQuery());
        }

        [HttpGet]
        public async Task<List<Category>> GetCategoriesByName(string name)
        {
            return await _mediator.Send(new GetCategoriesByNameQuery { CategoryName = name });
        }
    }
}
