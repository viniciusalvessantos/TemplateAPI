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

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Tenant)
                .WithMany(t => t.Users) // Assumindo que a entidade Tenant tem uma coleção de ApplicationUsers
                .HasForeignKey(u => u.TenantId);
        }

    }
}
