using System.Collections.Generic;

namespace Handlers.Products.Commands.Dto
{
    public class ProductDto
    {
        public string Name { get; set; }
        public List<int> CategoryIds { get; set; } = new List<int>();
    }
}
