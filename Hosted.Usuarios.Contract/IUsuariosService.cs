namespace Hosted.Usuarios.Contract {
    public interface IUsuariosService {
        Task<UsuarioContract> GetUsuarioDetalhes(string id);
    }
}
