using Hosted.Infrastructure.Persistence;
using Hosted.Infrastructure.UsuarioContext;
using Hosted.Outbox.Entities;
using Microsoft.EntityFrameworkCore;
namespace Hosted.Outbox.Persistence {
    public class OutboxDbContext : BaseDbContext {
        public DbSet<OutBoxMessage> OutBoxMessages { get; set; }

        protected OutboxDbContext(DbContextOptions options, IUsuarioContext userContext) : base(options,
            userContext) {
        }

        public OutboxDbContext(DbContextOptions<OutboxDbContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OutBoxMessage).Assembly);
        }
    }
}
