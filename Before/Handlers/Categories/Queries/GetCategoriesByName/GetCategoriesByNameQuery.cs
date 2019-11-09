using Entities;
using MediatR;
using System.Collections.Generic;

namespace Handlers.Categories.Queries.GetCategoriesByName
{
    public class GetCategoriesByNameQuery : IRequest<List<Category>>
    {
        public string CategoryName { get; set; }
    }
}
