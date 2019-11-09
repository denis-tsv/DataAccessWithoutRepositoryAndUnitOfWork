using System.Collections.Generic;

namespace Entities
{
    public class Product : AuditableEntity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; } = new HashSet<ProductCategory>();
    }
}
