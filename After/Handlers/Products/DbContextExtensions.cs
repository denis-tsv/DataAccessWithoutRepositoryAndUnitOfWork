using System.Linq;
using System.Threading.Tasks;
using Entities;
using Infrastructure.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Handlers.Products
{
    public static class DbContextExtensions
    {
        public static Task<Product> SingleOrDefaultFullAsync(this IQueryable<Product> dbSet, int id)
        {
            return dbSet
                .Include(x => x.ProductCategories)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public static async Task<Product> FindFullProductAsync(this IDbContext dbContext, int id)
        {
            var result = await dbContext.Products.FindAsync(id);
            await dbContext.Entry(result).Collection(x => x.ProductCategories).LoadAsync();
            return result;
        }
    }
}
