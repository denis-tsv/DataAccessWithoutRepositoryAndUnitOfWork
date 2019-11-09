using Entities;
using MediatR;
using System.Collections.Generic;

namespace Handlers.Categories.Queries.GetDigitalCategories
{
    public class GetDigitalCategoriesQuery : IRequest<List<Category>>
    {
        
    }
}
