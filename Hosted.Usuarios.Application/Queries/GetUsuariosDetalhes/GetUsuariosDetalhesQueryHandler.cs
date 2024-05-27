using Hosted.Exceptions.Abstraction;
using Hosted.Usuarios.Contract;
using Hosted.Usuarios.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Hosted.Usuarios.Application.Queries.GetUsuariosDetalhes {
    public class GetUsuariosDetalhesQueryHandler : IRequestHandler<GetUsuariosDetalhesQuery, UsuarioContract>, IUsuariosService {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetUsuariosDetalhesQueryHandler(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        public Task<UsuarioContract> GetUsuarioDetalhes(string id) {
            return Handle(new GetUsuariosDetalhesQuery(id), CancellationToken.None);
        }

        public async Task<UsuarioContract> Handle(GetUsuariosDetalhesQuery request, CancellationToken cancellationToken) {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user is null)
                throw new NotFoundException(request.UserId, nameof(ApplicationUser));

            return new UsuarioContract(user.UserName, user.Nome, user.SobreNome);
        }
    }
}
