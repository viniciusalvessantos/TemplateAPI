using Hosted.Usuarios.Domain.Entities;
using Hosted.Usuarios.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Hosted.Usuarios.Infrastructure.Repository {
    public class TenantRepository : ITenantRepository {

        private readonly UsuariosDbContext _dbContext;

        public TenantRepository(UsuariosDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task Add(Tenant tenant) {
            await _dbContext.AddAsync(tenant);
        }

        public Task CommitAsync() {
            return _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id) {
            var existingTenant = await _dbContext.Tenants.FindAsync(id);
            if (existingTenant == null) {
                throw new KeyNotFoundException($"Tenant with id {id} not found.");
            }

            _dbContext.Tenants.Remove(existingTenant);
        }

        public Task<Tenant> Get(Guid id, CancellationToken cancellationToken) {
            return _dbContext.Tenants.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)!;
        }

        public async Task<IEnumerable<Tenant>> GetAll() {
            return await _dbContext.Tenants.ToListAsync();
        }

        public async Task Update(Guid id, string nome, string telefone, string email, string cnpj) {
            var existingTenant = await _dbContext.Tenants.FindAsync(id);
            if (existingTenant == null) {
                throw new KeyNotFoundException($"Tenant with id {id} not found.");
            }
            // Update the propertie141s of the existing tenant
            existingTenant.UpdateName(nome);
            existingTenant.UpdateIsActive(true);
            // Update other properties as needed

            _dbContext.Tenants.Update(existingTenant);
        }
    }
}
