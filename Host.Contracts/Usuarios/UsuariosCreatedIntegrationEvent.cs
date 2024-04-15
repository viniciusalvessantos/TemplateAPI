using Host.Contracts.Events;
using MediatR;
namespace Host.Contracts.Usuarios {
    public class UsuariosCreatedIntegrationEvent : INotification, IIntegrationEvent {

        public UsuariosCreatedIntegrationEvent() {

        }

    }
}
