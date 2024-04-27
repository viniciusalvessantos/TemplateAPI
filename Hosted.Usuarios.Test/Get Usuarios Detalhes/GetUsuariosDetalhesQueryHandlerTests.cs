using Hosted.Usuarios.Application.Queries.GetUsuariosDetalhes;
using Hosted.Usuarios.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace Hosted.Usuarios.Test.Get_Usuarios_Detalhes {
    [TestFixture]
    public class GetUsuariosDetalhesQueryHandlerTests {
        private Mock<UserManager<ApplicationUser>> _userManagerMock;
        private GetUsuariosDetalhesQueryHandler _handler;

        [SetUp]
        public void Setup() {
            // Mock do UserManager
            var storeMock = new Mock<IUserStore<ApplicationUser>>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(storeMock.Object, null, null, null, null, null, null, null, null);

            // Instância do handler usando o UserManager mockado
            _handler = new GetUsuariosDetalhesQueryHandler(_userManagerMock.Object);
        }

        [Test]
        public async Task Handle_UserExists_ReturnsUsuarioContract() {
            // Configuração do mock para retornar um usuário quando FindByIdAsync é chamado
            var userId = "user-id";
            var expectedUser = new ApplicationUser("username", "name", "surname");
            _userManagerMock.Setup(x => x.FindByIdAsync(userId)).ReturnsAsync(expectedUser);

            // Act
            var result = await _handler.Handle(new GetUsuariosDetalhesQuery(userId), CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo(expectedUser.UserName));
            //Assert.That(result.Surname, Is.EqualTo(expectedUser.Surname));
            //Assert.That(result.Email, Is.EqualTo(expectedUser.Email));
        }
    }
}
