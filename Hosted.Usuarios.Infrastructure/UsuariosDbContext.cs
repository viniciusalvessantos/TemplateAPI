using Hosted.Domain.Entities;
using Hosted.Usuarios.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hosted.Usuarios.Infrastructure {
    public class UsuariosDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string> {
        public UsuariosDbContext(DbContextOptions<UsuariosDbContext> options) : base(options) {
        }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<RedeTenant> RedeTenants { get; set; }


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
            foreach (var auditableEntity in changedEntities) {
                var currentDate = DateTime.UtcNow;
                switch (auditableEntity.State) {
                    case EntityState.Added:
                        auditableEntity.Entity.CreatedDate = currentDate;
                        auditableEntity.Entity.ModifiedDate = currentDate;
                        auditableEntity.Entity.Description = "Create";
                        auditableEntity.Entity.CreatedBy = "";
                        auditableEntity.Entity.ModifiedBy = "";
                        break;
                    case EntityState.Modified:
                        auditableEntity.Entity.ModifiedDate = currentDate;
                        auditableEntity.Entity.ModifiedBy = "";
                        break;
                }

            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tenant>(entity => {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Nome)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(t => t.IsActive)
                    .IsRequired();


                entity.HasMany(t => t.Users)
                    .WithOne(u => u.Tenant)
                    .HasForeignKey(u => u.TenantId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<RedeTenant>(entity => {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Nome)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.HasMany(t => t.Tenants)
                    .WithOne(tenant => tenant.RedeTenantTenant)
                    .HasForeignKey(tenant => tenant.RedeId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Tenant)
                .WithMany(t => t.Users) // Assumindo que a entidade Tenant tem uma coleção de ApplicationUsers
                .HasForeignKey(u => u.TenantId);
        }

    }
}
