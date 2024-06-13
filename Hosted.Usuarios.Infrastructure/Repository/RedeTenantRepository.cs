using Hosted.Usuarios.Domain.Entities;
using Hosted.Usuarios.Domain.Repository;

namespace Hosted.Usuarios.Infrastructure.Repository {
    public class RedeTenantRepository : IRedeTenantRepository {
        public Task Add(RedeTenant redeTenant) {
            throw new NotImplementedException();
        }

        public Task CommitAsync() {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id) {
            throw new NotImplementedException();
        }

        public Task<Tenant> Get(Guid id, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RedeTenant>> GetAll() {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, RedeTenant redeTenant) {
            throw new NotImplementedException();
        }
    }
}
