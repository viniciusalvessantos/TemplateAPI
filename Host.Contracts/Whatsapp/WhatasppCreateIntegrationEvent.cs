using Hosted.Contracts.Events;
using MediatR;

namespace Hosted.Contracts.Whatsapp {
    public class WhatasppCreateIntegrationEvent : INotification, IIntegrationEvent {
        public WhatasppCreateIntegrationEvent() {

        }
    }
}
