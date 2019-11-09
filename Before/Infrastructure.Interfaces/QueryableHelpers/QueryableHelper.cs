using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.QueryableHelpers
{
    public static class QueryableHelper
    {
        public static IQueryableExecutor QueryableExecutor { get; set; }

        public static Task<List<TEntity>> ToListAsync<TEntity>(this IQueryable<TEntity> query)
        {
            return QueryableExecutor.ToListAsync(query);
        }
    }
}
