using Hosted.Usuarios.Application.Commands.Register;
using Hosted.Usuarios.Domain.Entities;
using Hosted.Usuarios.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace Hosted.Usuarios.Test.Registrar_Usuarios {
    [TestFixture]
    public class RegisterUsuariosCommandHandlerTests {
        private Mock<UserManager<ApplicationUser>> _userManagerMock;
        private RegisterUsuariosCommandHandler _handler;

        [SetUp]
        public void Setup() {
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(
                new Mock<IUserStore<ApplicationUser>>().Object,
                null, null, null, null, null, null, null, null);
            _handler = new RegisterUsuariosCommandHandler(_userManagerMock.Object);
        }

        [Test]
        public async Task Handle_SuccessfulRegistration_ReturnsSuccessMessage() {
            // Arrange
            var command = new RegisterUsuariosCommand(
                "testUser",
                "Test",
                "User",
                "StrongPassword123!",
                Guid.NewGuid()
            );
            var identityResult = IdentityResult.Success;

            _userManagerMock.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(identityResult);

            // Act
            var result = await _handler.Handle(command, new CancellationToken());

            // Assert

            Assert.That(result.MessagemResponser, Is.EqualTo("Cadastrado com sucesso!!"));
            //_userManagerMock.Verify(x => x.CreateAsync(It.Is<ApplicationUser>(u => u.UserName == "testUser" && u.Name == "Test" && u.Surname == "User"), "StrongPassword123!"), Times.Once);
        }
        [Test]
        public void Handle_FailedRegistration_ThrowsRegisterException() {
            // Arrange
            var command = new RegisterUsuariosCommand(
               "testUser",
               "Test",
               "User",
               "StrongPassword123!",
                Guid.NewGuid()
           );
            var identityResult = IdentityResult.Failed(new IdentityError { Description = "Failed to create user." });

            _userManagerMock.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(identityResult);

            // Act & Assert
            var ex = Assert.ThrowsAsync<RegisterException>(() => _handler.Handle(command, new CancellationToken()));
            Assert.That(ex.ValidationMessages, Contains.Item("Failed to create user."));
            //_userManagerMock.Verify(x => x.CreateAsync(It.Is<ApplicationUser>(u => u.UserName == "testUser" && u.Name == "Test" && u.Surname == "User"), "StrongPassword123!"), Times.Once);
        }
    }
}
