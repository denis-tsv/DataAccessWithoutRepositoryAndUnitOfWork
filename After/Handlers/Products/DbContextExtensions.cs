using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Handlers.Products
{
    public static class DbContextExtensions
    {
        public static Task<Product> FindFullAsync(this IQueryable<Product> dbSet, int id)
        {
            return dbSet
                .Include(x => x.ProductCategories)
                .ThenInclude(x => x.Category)
                .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
