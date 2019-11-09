using Entities;
using Infrastructure.Interfaces.DataAccess;
using Infrastructure.Interfaces.Services;
using System.Threading.Tasks;

namespace DataAccess.MsSql.DataAccess
{
    public class RepositoryUnitOfWork : IRepositoryUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;

        public RepositoryUnitOfWork(AppDbContext dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
        }

        private IProductRepository _productRepository;
        public IProductRepository ProductRepository =>
            _productRepository ??= new ProductRepository(_dbContext, _currentUserService);

        private IRepository<ProductCategory> _productCategoryRepository;
        public IRepository<ProductCategory> ProductCategoryRepository =>
            _productCategoryRepository ??= new Repository<ProductCategory>(_dbContext);

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
