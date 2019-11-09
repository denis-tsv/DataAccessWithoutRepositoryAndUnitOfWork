using AutoFilter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public class Product : AuditableEntity
    {
        public static readonly Spec<Product> AvailableProductSpec =
            new Spec<Product>(x => x.IsAvailable && x.Quantity > 0);

        public static readonly Spec<Product> NewProductSpec =
            new Spec<Product>(x => (DateTime.Now - x.CreatedAt).TotalDays < 30);


        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; protected set; } = new HashSet<ProductCategory>();

        public void UpdateCategories(IEnumerable<int> newCategoryIds)
        {
            var currentCategoryIds = ProductCategories.Select(x => x.CategoryId).ToList();

            //delete not existing categories
            foreach (var category in ProductCategories
                .Where(x => !newCategoryIds.Contains(x.CategoryId)))
            {
                ProductCategories.Remove(category);
            }

            //new categories
            foreach (var categoryId in newCategoryIds.Except(currentCategoryIds))
            {
                ProductCategories.Add(new ProductCategory
                {
                    CategoryId = categoryId,
                    ProductId = Id
                });
            }
        }
    }
}
