using Host.Contracts.Events;
using MediatR;

namespace Host.Contracts.Whatsapp {
    public class WhatasppCreateIntegrationEvent : INotification, IIntegrationEvent {
        public WhatasppCreateIntegrationEvent() {

        }
    }
}
