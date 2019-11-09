using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Interfaces.DataAccess
{
    public interface IDbContextPostProcessor : IDbContext
    {
        ChangeTracker ChangeTracker { get; }
    }
}
