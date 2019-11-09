using Entities;
using Infrastructure.Interfaces.Services;
using System;

namespace DataAccess.MsSql.DataAccess
{
    public class AuditableRepository<TEntity> : Repository<TEntity>
        where TEntity : AuditableEntity
    {
        private readonly ICurrentUserService _currentUserService;

        public AuditableRepository(AppDbContext dbContext, ICurrentUserService currentUserService) : base(dbContext)
        {
            _currentUserService = currentUserService;
        }

        public override void Add(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = _currentUserService.UserId.Value;
            
            base.Add(entity);
        }

        public override void Update(TEntity entity)
        {
            entity.ModifiedAt = DateTime.Now;
            entity.ModifiedBy = _currentUserService.UserId;

            base.Add(entity);
        }
    }
}
