using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.QueryableHelpers
{
    public interface IQueryableExecutor
    {
        Task<List<TEntity>> ToListAsync<TEntity>(IQueryable<TEntity> query);
    }
}
