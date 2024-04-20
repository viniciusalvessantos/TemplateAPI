using Refit;

namespace Hosted.Usuarios.Contract {
    public interface IUsuariosAPI {
        [Get("/usuario/{id}")]
        public Task<UsuarioContract> GetUsuarioDetalhes(string id);
    }
}
