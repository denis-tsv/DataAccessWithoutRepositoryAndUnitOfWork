using Infrastructure.Interfaces.QueryableHelpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.MsSql.DataAccess.NoRepository
{
    public class EfQueryableExecutor : IQueryableExecutor
    {
        public Task<List<TEntity>> ToListAsync<TEntity>(IQueryable<TEntity> query)
        {
            return EntityFrameworkQueryableExtensions.ToListAsync(query);
        }
    }
}
