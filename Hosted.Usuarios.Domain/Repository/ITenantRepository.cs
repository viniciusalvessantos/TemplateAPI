using Hosted.Usuarios.Domain.Entities;

namespace Hosted.Usuarios.Domain.Repository {
    public interface ITenantRepository {
        Task Add(Tenant tenant);
        Task Update(Guid id, string nome, string telefone, string email, string cnpj);
        Task Delete(Guid id);
        Task<IEnumerable<Tenant>> GetAll();
        Task<Tenant> Get(Guid id, CancellationToken cancellationToken);
        Task CommitAsync();
    }
}
