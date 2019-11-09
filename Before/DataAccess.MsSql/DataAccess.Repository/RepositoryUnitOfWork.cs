using Entities;
using Infrastructure.Interfaces.DataAccess;
using System.Threading.Tasks;

namespace DataAccess.MsSql.DataAccess
{
    public class RepositoryUnitOfWork : IRepositoryUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public RepositoryUnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IProductRepository _productRepository;
        public IProductRepository ProductRepository =>
            _productRepository ??= new ProductRepository(_dbContext);

        private IRepository<ProductCategory> _productCategoryRepository;
        public IRepository<ProductCategory> ProductCategoryRepository =>
            _productCategoryRepository ??= new Repository<ProductCategory>(_dbContext);

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
