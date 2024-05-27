using Hosted.Usuarios.Domain.Entities;

namespace Hosted.Usuarios.Domain.Repository {
    public interface IRedeTenantRepository {
        Task Add(RedeTenant redeTenant);
        Task Update(Guid id, RedeTenant redeTenant);
        Task Delete(Guid id);
        Task<IEnumerable<RedeTenant>> GetAll();
        Task<Tenant> Get(Guid id, CancellationToken cancellationToken);
        Task CommitAsync();
    }
}
