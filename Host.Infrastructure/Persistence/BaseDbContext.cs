using Hosted.Domain.Entities;
using Hosted.Infrastructure.UsuarioContext;
using Microsoft.EntityFrameworkCore;

namespace Hosted.Infrastructure.Persistence {
    public class BaseDbContext : DbContext {
        private readonly IUsuarioContext _userContext;
        protected BaseDbContext(DbContextOptions options, IUsuarioContext userContext) : base(options) {
            _userContext = userContext;
        }
        protected BaseDbContext(DbContextOptions options) : base(options) {

        }
        public override int SaveChanges() {
            SetAuditFields();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
            SetAuditFields();
            return await base.SaveChangesAsync(cancellationToken);
        }
        protected void SetAuditFields() {
            var changedEntities = ChangeTracker.Entries<BaseEntity>()
                .Where(ce => ce.State is EntityState.Added or EntityState.Modified);
            var userId = _userContext.UserId;
            foreach (var auditableEntity in changedEntities) {
                var currentDate = DateTime.UtcNow;
                switch (auditableEntity.State) {
                    case EntityState.Added:
                        auditableEntity.Entity.CreatedDate = currentDate;
                        auditableEntity.Entity.ModifiedDate = currentDate;
                        auditableEntity.Entity.Description = "Create";
                        auditableEntity.Entity.CreatedBy = userId;
                        auditableEntity.Entity.ModifiedBy = userId;
                        break;
                    case EntityState.Modified:
                        auditableEntity.Entity.ModifiedDate = currentDate;
                        auditableEntity.Entity.ModifiedBy = userId;
                        break;
                }

            }

        }
    }
}
