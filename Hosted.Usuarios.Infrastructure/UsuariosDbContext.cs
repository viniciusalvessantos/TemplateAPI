using Hosted.Usuarios.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hosted.Usuarios.Infrastructure {
    public class UsuariosDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string> {
        public UsuariosDbContext(DbContextOptions<UsuariosDbContext> options) : base(options) {
        }
        public DbSet<Tenant> Tenants { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Tenant)
                .WithMany(t => t.Users) // Assumindo que a entidade Tenant tem uma coleção de ApplicationUsers
                .HasForeignKey(u => u.TenantId);
        }

    }
}
