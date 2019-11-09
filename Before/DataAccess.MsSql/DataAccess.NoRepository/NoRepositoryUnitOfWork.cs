using Entities;
using Infrastructure.Interfaces.DataAccess.NoRepository;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.MsSql.DataAccess.NoRepository
{
    public class NoRepositoryUnitOfWork : INoRepositoryUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public NoRepositoryUnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Product> Products => _dbContext.Products;

        public IQueryable<Category> Categories => _dbContext.Categories;

        public void Add<TEntity>(TEntity entity)
        {
            _dbContext.Add(entity);
        }

        public void Remove<TEntity>(TEntity entity)
        {
            _dbContext.Remove(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
