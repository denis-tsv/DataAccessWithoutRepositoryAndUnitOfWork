using Entities;
using Infrastructure.Interfaces.DataAccess;
using Infrastructure.Interfaces.Services;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Handlers.SaveChangesPostProcessor
{

    public class SaveChangesRequestPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
        where TRequest : IChangeDataRequest
    {
        private readonly IDbContextPostProcessor _dbContext;
        private readonly ICurrentUserService _currentUserService;

        public SaveChangesRequestPostProcessor(IDbContextPostProcessor dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
        }

        public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            var now = DateTime.Now;

            _dbContext.ChangeTracker.Entries<AuditableEntity>().ToList()
                .ForEach(x => 
                {
                        if (x.State == EntityState.Added)
                        {
                            x.Entity.CreatedBy = _currentUserService.UserId.Value;
                            x.Entity.CreatedAt = now;
                        }
                        if (x.State == EntityState.Modified)
                        {
                            x.Entity.ModifiedBy = _currentUserService.UserId.Value;
                            x.Entity.ModifiedAt = now;
                        }
                });

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }

}
