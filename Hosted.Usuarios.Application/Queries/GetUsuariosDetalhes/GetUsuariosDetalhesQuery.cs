using Hosted.Usuarios.Contract;
using MediatR;

namespace Hosted.Usuarios.Application.Queries.GetUsuariosDetalhes {
    public class GetUsuariosDetalhesQuery : IRequest<UsuarioContract> {
        public GetUsuariosDetalhesQuery(string userId) {
            UserId = userId;
        }
        public string UserId { get; }
    }
}
